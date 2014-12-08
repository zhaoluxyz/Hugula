local teamCompose = LuaItemManager:getItemObject("teamCompose")
local localTeam = LuaItemManager:getItemObject("teamPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local Vector3 = UnityEngine.Vector3
local Encodeing = luanet.import_type("System.Text.Encoding")
local Quaternion = UnityEngine.Quaternion
local Net=Net.instance
local LFunction = LFunction.instance
local Proxy=Proxy
local Model = Model
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")

local showTips = showTips
--==================================================================================================
-- 合成用的所有卡不包括上阵的卡
teamCompose.assets=
{
	 Asset("TComposeUI.u3d", {"Config"}),
	 Asset("Strengthenmap.u3d"),
	 Asset("heroPanel.u3d", {"Refers"}),
}
-- 检查界面是否打开
teamCompose.isShow = false;
-- panel
teamCompose.panels = {};
-- 合成用的主卡ID[服务器ID]
teamCompose.selMain = nil; 
-- 材料副卡唯一ID[服务器ID]
teamCompose.selDeputy = nil;
--- 当前界面状态
teamCompose.panelState = 1;
--- 当前选中的分类方式, 默认是战力
teamCompose.selType = "BtnPower";
--- 合成的新卡ID[服务器ID]
teamCompose.newCard = nil;
--- 申请www的table
teamCompose.reqs = {};
--- www保留到本地的data
teamCompose.prefabPool = {};
--- 记录3D场景挂载模型的parent
teamCompose.modelParent = nil;
------------------private-----------------
-- 记录当前界面操作的状态， 分别是 一般/强化/切换到合成场景
local PanelStates =
{
	normal = 1,
	compose = 2,
	comScene = 3,
};
--- 英雄顶部按钮的精灵名
local btnSpriteNames = 
{
	"pack_tab1",
	"pack_tab2",  
};
--- 强化相关数据
local MaxStar = 5;
local MaxStren = 5;
local MaxLv = 30;
--- 返回一个指定长度的数值字符串, 比如1,显示为"01"
--- 字符串第一个元素的索引为1,sub返回两个字符之间的值
local function GetSpecifyStr(num, len)
	local numble = math.pow(10, len) + num
	local tempStr = tostring(numble)
	tempStr = string.sub(tempStr,2,#tempStr)
	return tempStr
end

--- 返回某个颜色的字符串, color需要是"[fffbda]"这样的RGB值
local function GetColorString(color, str)
	if str == ""  then return str end
	local colorStr = color .. str .. "[-]"
	return colorStr
end

--- 按战力排序
local function sortPower(a,b)  
	if a~=nil and b~=nil and a.power and b.power then  
		return tonumber(a.power)>tonumber(b.power) 
	else
		return false
	end
end

--- 按星级大小排序
local function sortStar(a,b)  
	if a~=nil and b~=nil and a.star and b.star then  
		return tonumber(a.star)>tonumber(b.star) 
	else
		return false
	end
end

--- 按强化次数排序
local function sortStrenCount(a,b)  
	if a~=nil and b~=nil and a.player_hero_strengthen and b.player_hero_strengthen then  
		return tonumber(a.player_hero_strengthen)>tonumber(b.player_hero_strengthen) 
	else
		return false
	end
end

--- 获得实际上需要的数量, 传入需要检查的值， 标准值， 变化值
local function GetNewCountInfact(check, normal, add)
	--- 不够标准数量补足标准数量
	if check < normal then return normal end
	--- 按当前需要添加
	local checkEnd = check - normal;
	while checkEnd > add do
		checkEnd = checkEnd - add;
	end
	local reValue = check;
	if checkEnd > 0 then
		reValue = reValue + add - checkEnd;
	end
	return reValue;
end

---- 设置一个obj的child 隐藏/显示， 关闭/打开obj的碰撞块
local function SetChildAndBoxCollider(obj, switch)
	if obj == nil then return end
	local trans = LuaHelper.GetAllChild(obj);
	for i=0, trans.Length-1 do
		trans[i].gameObject:SetActive(switch);  
	end
	local boxCollider = LuaHelper.GetComponent(obj, "BoxCollider");
	if boxCollider then boxCollider.enabled = switch end
end

-- 根据当前显示英雄数量, 获得需要额外添加的板子块数
local function GetNeedAddBlock(curLen)
	if curLen < 10 then return 10-curLen end
	local newAdd = curLen - 10;
	while newAdd > 5 do
		newAdd = newAdd - 5;
	end
	if newAdd == 0 then return 0;
	else return 5 - newAdd end
end

--- 获得英雄的五行 sprite name
local function GetHeroElemName(elemType)
	local name = "wuxing0";
	if elemType == 1 then name = "wuxing0";
	elseif elemType == 2 then name = "wuxing1";
	elseif elemType == 3 then name = "wuxing2" end 

	return name;
end

--- 设置英雄的其他显示
local function SetHeroNormalInfo(obj, text)
  local childs = LuaHelper.GetAllChild(obj);
  local uiLable = LuaHelper.GetComponent(childs[0].gameObject,"UILabel");
  uiLable.text = text;
end

--- 发送英雄合成的消息 2241
local function Sendplayer_hero_compose(player_hero_idl, player_hero_idr)
	local cont = NetMsgHelper:makesend_hero_hero_synthesis(player_hero_idl,player_hero_idr);
	Proxy:send(NetAPIList.hero_hero_synthesis,cont);
end


------------------public------------------
--- 根据需要设置当前进入UI的状态, 传入字符串
function teamCompose:setPanelState(state)
	self.panelState = PanelStates[state];
end

function teamCompose:getMUpPanel()
	local referScript = LuaHelper.GetComponent(self.panels[2],"ReferGameObjects");
	self.mPreviews = {};
	if referScript then
		--- lable:消耗金币/lable_金币数量/lable:开始合成/btn_开始合成
		self.mPreviews["cost"] = referScript.monos[0];
		self.mPreviews["costLable"] = referScript.monos[1];
		self.mPreviews["cBtnText"] = referScript.monos[2];
		self.mPreviews["btnComp"] = referScript.refers[2];
		---------------- 主卡(左侧)
		self.mPreviews["main"] = {};
		local subRef = LuaHelper.GetComponent(referScript.refers[0],"ReferGameObjects");
		--- 头像/元素/强化等级/名字/星级(x?)
		self.mPreviews["main"].icon = subRef.monos[0];
		self.mPreviews["main"].elem = subRef.monos[1];
		self.mPreviews["main"].add = subRef.monos[2];
		self.mPreviews["main"].name = subRef.monos[3];
		self.mPreviews["main"].starLv = subRef.monos[4];
		----------------- 副卡
		self.mPreviews["deputy"] = {};
		subRef = LuaHelper.GetComponent(referScript.refers[1],"ReferGameObjects");
		--- 头像/元素/强化等级/名字/星级(x?)
		self.mPreviews["deputy"].icon = subRef.monos[0];
		self.mPreviews["deputy"].elem = subRef.monos[1];
		self.mPreviews["deputy"].add = subRef.monos[2];
		self.mPreviews["deputy"].name = subRef.monos[3];
		self.mPreviews["deputy"].starLv = subRef.monos[4];
	end 	
end

function teamCompose:getMDownPanel()
	local referScript = LuaHelper.GetComponent(self.panels[3],"ReferGameObjects");
	self.mFilter = {};
	self.mFilter["setBtn"] = {};
	if referScript then
		for i=0, 2 do
			table.insert(self.mFilter["setBtn"], referScript.refers[i]);
		end
		--- 复制用的prefab
		self.mFilter["prefab"] = referScript.refers[3];
		--- 按钮的文字显示
		self.mFilter["powerL"] = referScript.monos[0];
		self.mFilter["starL"] = referScript.monos[1];
		self.mFilter["strenL"] = referScript.monos[2];
	end
end

function teamCompose:getMInfoPanel()
	local referScript = LuaHelper.GetComponent(self.panels[4],"ReferGameObjects");
	self.mInfo = {};
	if referScript then
		local refInfo = LuaHelper.GetComponent(referScript.refers[0],"ReferGameObjects");
		--- 星级/战力/hp/攻击/物防/魔防
		self.mInfo.lv = refInfo.refers[0];
		self.mInfo.power = refInfo.refers[1];
		self.mInfo.hp = refInfo.refers[2];
		self.mInfo.attack = refInfo.refers[3];
		self.mInfo.defence = refInfo.refers[4];
		self.mInfo.mdefence = refInfo.refers[5];
		--- lable:星阶/lable:战力
		-- referScript.monos[0] = getValue("");
		-- referScript.monos[1] = getValue("");
	end
end

function teamCompose:initMainPan()
	-------- 面板初始化
	--- 主卡/副卡
	self:getMUpPanel();
	--- 筛选面板
	self:getMDownPanel();
	--- 信息面板
	self:getMInfoPanel();
end

--- 初始化英雄UI
function teamCompose:initHeroUI(heroScript)
	local showScript = LuaHelper.GetComponent(heroScript.refers[0],"ReferGameObjects");
	local popScript = LuaHelper.GetComponent(heroScript.refers[1],"ReferGameObjects");
	--- 英雄 名字/信息/图标
	self.heroUI.name = showScript.monos[0];
	self.heroUI.info = showScript.monos[1];
	self.heroUI.icon = showScript.monos[2];
	--- 技能
	self.heroUI.skills = {};
	for i=3, 6 do
		table.insert(self.heroUI.skills, showScript.monos[i]);
	end
	--- 血/攻击/物防/魔防
	self.heroUI.hp = showScript.monos[7];
	self.heroUI.attack = showScript.monos[8];
	self.heroUI.defence = showScript.monos[9];
	self.heroUI.mdefence = showScript.monos[10];
	---------------------------------------------
	--- 技能信息弹出面板 obj_整体坐标/obj_镜像/lable_信息
	self.heroUI.pop = {};
	self.heroUI.pop["xPos"] = heroScript.refers[1];
	self.heroUI.pop["mirror"] = popScript.monos[0].gameObject;
	self.heroUI.pop["info"] = popScript.monos[1];
end

--- 设置默认的场景切换(主场景<--->英雄场景)
function teamCompose:setSceneShow(isMain)
	if isMain then
		self.mainUI:SetActive(true);
		self.heroScene:SetActive(false);
		self.heroUI.root:SetActive(false);
		self:resetReq();
	else
		self.mainUI:SetActive(false);
		self.heroScene:SetActive(true);
		self.heroUI.root:SetActive(true);
	end
end

--- 设置强化消耗
function teamCompose:setComposeCost()
	self.mPreviews["costLable"].text = 0;
	if self.selMain and self.selDeputy then
		local hData = localTeam.models[tostring(self.selMain)];
		if hData == nil then return end
		local localData = Model.units[tostring(hData.netData.system_hero_id)];
		if localData == nil then return end
		local compData = Model.discreteData["900019"];
		if compData == nil then return end
		self.mPreviews["costLable"].text = compData.data[localData.star];
	end
end

--- 显示对应选中的英雄卡牌信息
function teamCompose:setCardShow(player_hero_id, isMain)
	local function getIconName(name)
		local newIndex = tonumber(string.sub(name, -4));
		if newIndex > 3 then newIndex = 3 end
			return "icon_role_" .. GetSpecifyStr(newIndex, 4);
	end
	----------------- normal set
	local views;
	if isMain then
		views = self.mPreviews["main"];
	else
		views = self.mPreviews["deputy"] 
	end
	local trans = LuaHelper.GetAllChild(views.icon.gameObject);
	------------------------------
	if player_hero_id == nil then
		-------- 头像 默认初始化
		views.icon.spriteName = "";
		for i=0, trans.Length-1 do
			trans[i].gameObject:SetActive(false);  
		end
		---- 名字/星级默认初始化
		views.name.gameObject:SetActive(false);
		views.starLv.transform.parent.gameObject:SetActive(false);
		---- 无数据的
		if isMain then 
			self:setHeroInfo(nil);
		end
		return;
	end
	local hData = localTeam.models[tostring(player_hero_id)];
	if hData == nil then return end
	local localData = Model.units[tostring(hData.netData.system_hero_id)];
	if localData == nil then return end
	------------------------------
	for i=0, trans.Length-1 do
		trans[i].gameObject:SetActive(true);  
	end
	views.name.gameObject:SetActive(true);
	views.starLv.transform.parent.gameObject:SetActive(true);
	----- 头像/元素/强化次数/名字/星级
	views.icon.spriteName = getIconName(localData.icon);
	views.elem.spriteName = GetHeroElemName(localData.category2);
	if hData.netData.player_hero_strengthen > 0 then
		views.add.gameObject:SetActive(true);
		views.add.text = "+ " .. hData.netData.player_hero_strengthen;
	else
		views.add.gameObject:SetActive(false);
	end
	views.name.text = getValue(localData.name);
	views.starLv.text = "X " .. localData.star;
	---- 有数据的
	if isMain then 
		self:setHeroInfo(hData);
	end
end

--- 更新显示信息面板
function teamCompose:setHeroInfo(hData)
  local starTxt = 0;
  local powerTxt = 0;
  local hpTxt = 0;
  local damageTxt = 0;
  local defendTxt = 0;
  local magicDTxt = 0;

  local isMagic = false;
  if hData ~= nil then
  	local localData = Model.units[tostring(hData.netData.system_hero_id)];
  	starTxt = tonumber(localData.star);
  	powerTxt = hData.power;
  	hpTxt = hData.netData.player_hero_attribute.maxHp;
  	damageTxt = hData.netData.player_hero_attribute.damage;
  	local magicDamage = hData.netData.player_hero_attribute.magicDamage;
  	if damageTxt < magicDamage then
  		damageTxt = magicDamage;
  		isMagic = true;
  	end
  	defendTxt = hData.netData.player_hero_attribute.defend;
  	magicDTxt = hData.netData.player_hero_attribute.magicDefend;
  end

  
  --- 星级/战力/hp
  SetHeroNormalInfo(self.mInfo.lv, starTxt);
  SetHeroNormalInfo(self.mInfo.power, powerTxt);
  SetHeroNormalInfo(self.mInfo.hp, hpTxt);
  --- 攻击/物防/魔防
  local text = math.floor(damageTxt);
  SetHeroNormalInfo(self.mInfo.attack, text);
  text = math.floor(defendTxt);
  SetHeroNormalInfo(self.mInfo.defence, text);
  text = math.floor(magicDTxt);
  SetHeroNormalInfo(self.mInfo.mdefence, text);

  ---- 设置为魔法攻击 or 物理攻击
  if isMagic then

  else

  end
end

--- 根据当前类型重新排序
function teamCompose:sortAllHero()
	--- 初始化英雄显示列表
	self.heroTable = {};
 	--------------------------------------------
	---生成一张乱序新表, 只记录有效的下阵英雄
	local downHeroDatas = {};
	local upHeroDatas = {};
	for i, v in pairs(localTeam.models) do
		-- 查找配置表数据
		local localData = Model.units[tostring(v.netData.system_hero_id)];
		if localData then
			--- 生成基本表
			local hData = {};
			hData.netData = v.netData;
			hData.power = v.power;
			hData.star = tonumber(localData.star);
			hData.player_hero_strengthen = v.netData.player_hero_strengthen;
			hData.pos = v.pos;
			--- 需要强化等级满/星级不超过最大等级/英雄等级满			
			if v.netData.player_hero_strengthen	== MaxStren 
				and localData.star < MaxStar and v.netData.player_hero_lv == MaxLv then 
				if self.selMain == nil then
					------------ 没有主卡的时候(下阵列表)
					if v.pos == 0 then table.insert(downHeroDatas, hData); end
				elseif v.netData.player_hero_id ~= self.selMain then
					------------ 有主卡的时候(首先排除掉主卡)
					local mHData = localTeam.models[tostring(self.selMain)];
					local mLData = Model.units[tostring(mHData.netData.system_hero_id)];
					if mLData.star == hData.star and v.pos == 0 then
						-- 插入星级一样的卡(下阵列表)
						table.insert(downHeroDatas, hData);
					end
				end
			end
		end
	end
	----------------------
	--- 根据类型更新排序
	local sorFun = sortPower;
	if self.selType == "BtnStar" then
		sorFun = sortStar;
	elseif self.selType == "BtnStenLen" then
		sorFun = sortStrenCount;
	end
	if #downHeroDatas > 1 then table.sort(downHeroDatas, sorFun) end
	---------------------
	--- 生成最终表, 上阵列表在最前面
	--- 按序列生成blocks，和数据一一对应
	for i, hData in ipairs(downHeroDatas) do
		table.insert(self.heroTable, hData);
	end
end

--- 设置英雄view的显示
function teamCompose:setHeroBlock(i, hData)
	local function getIconName(name)
		 local newIndex = tonumber(string.sub(name, -4));
		 if newIndex > 3 then newIndex = 3 end
		 return "icon_role_" .. GetSpecifyStr(newIndex, 4);
	end
	-----------------------------------
	if i < 1 or i > #self.blocks then return end
	local obj = self.blocks[i];
	local refer = LuaHelper.GetComponent(obj,"ReferGameObjects");
	local localData = Model.units[tostring(hData.netData.system_hero_id)];
	local isUp = false;
	if hData.pos > 0 and hData.pos < MTeamLen + 1 then isUp = true end
	-- 头像/五行
	refer.monos[0].spriteName = getIconName(localData.icon);
	refer.monos[1].spriteName = GetHeroElemName(localData.category2);
	--- 强化次数/星级/名字
	if hData.player_hero_strengthen > 0 then
		refer.monos[2].gameObject:SetActive(true);
		refer.monos[2].text = "+ " .. hData.player_hero_strengthen;
	else
		refer.monos[2].gameObject:SetActive(false);
	end
	refer.monos[3].text = tostring(hData.star);
	refer.monos[4].text = getValue(localData.name);
end

--- 根据当前排序决定显示那些英雄
function teamCompose:updateHeroBySort()
	---- 当前显示的block 数量
	local curShowLen = 0;
	--- 重新设置需要显示的view内容
	for i, hData in ipairs(self.heroTable) do
		local view = self.blocks[i];
		view:SetActive(true);
		view.name = self.mFilter["prefab"].name .. GetSpecifyStr(i, 4);
		SetChildAndBoxCollider(view, true);
		self:setHeroBlock(i, hData);
		curShowLen = curShowLen + 1;
	end
	---- 给空白区增加板子
	for i = curShowLen+1, #self.blocks do
		self.blocks[i]:SetActive(false);
		local addLen = GetNeedAddBlock(curShowLen);
		if addLen ~= 0 then
			self.blocks[i].name = self.mFilter["prefab"].name .. "9999";
			self.blocks[i]:SetActive(true);
			SetChildAndBoxCollider(self.blocks[i], false);
			curShowLen = curShowLen + 1;
		end
	end

	---- 重新排序
  	local copyBlock = self.mFilter["prefab"];
  	local sortGrid = LuaHelper.GetComponent(copyBlock.transform.parent.gameObject,"UIGrid");
  	if sortGrid then sortGrid:Reposition() end
  	---- scollview 部分
  	local parTran = copyBlock.transform.parent.parent;
  	if parTran then
  		local scollview = LuaHelper.GetComponent(parTran.gameObject,"UIScrollView");
  		if scollview then
			scollview:ResetPosition();
  		end
  	end
end

---hero btn的刷新改变
function teamCompose:heroTopBtnSetView()
	for i,v in pairs(self.mFilter["setBtn"]) do
		local uiSprite  = LuaHelper.GetComponentInChildren(v,"UISprite");
		if uiSprite then
			local position = v.transform.localPosition;
			if v.name == self.selType then
				position.y = -23;
				uiSprite.transform.localScale = Vector3(1, 1.5, 1);
				uiSprite.spriteName = btnSpriteNames[2];
			else
				position.y = -20;
				uiSprite.transform.localScale = Vector3(1, 1, 1);
				uiSprite.spriteName = btnSpriteNames[1];
			end
			v.transform.localPosition = position;
		end
	end 
end

--- 更新可选block
function teamCompose:updateBlocks()
	--- 更新显示表
	self:sortAllHero();
	-------------------------------------
	if self.blocks == nil then self.blocks = {} end
	--- 增加新的数量的blocks, 保证添加的空格数足够
	local newHeroCount = #self.heroTable;
	newHeroCount = GetNewCountInfact(newHeroCount, 10, 5);
	if newHeroCount > #self.blocks then
		local startId = #self.blocks + 1;
		local copyBlock = self.mFilter["prefab"];
		for i=startId, newHeroCount do
			local clone = LuaHelper.InstantiateLocal(copyBlock, copyBlock.transform.parent.gameObject);
			clone.name = copyBlock.name .. "9999";
			clone:SetActive(true);
			table.insert(self.blocks, clone);
		end
	end

	self:updateHeroBySort();
	self:heroTopBtnSetView();
end

--- 检查是否有效的合成数据
function teamCompose:checkComposeData(netData)
	self.newCard = nil;
	local delCount = 0;
	local addCount = 0;
	local len = 0;
	for i, v in pairs(netData.heros) do
		if v.player_hero_num == 0 then
			delCount = delCount + 1;
		elseif v.player_hero_num == 1 then
			addCount = addCount + 1;
			self.newCard = v.player_hero_id;
		end
		len = len + 1;
		if len > 3 then
			---- 数据不合标准
			self.newCard = nil;
			return;  
		end 
	end
	
	if len == 3 and addCount == 1 and delCount == 2 then
		print("_____" .. self.newCard);
		return;
	else
		self.newCard = nil;
	end
end

--- 处理新的英雄生成的相关显示
function teamCompose:handleCardSpawn()
	--- 2D特效启动
	--- delaydo
	--- after delaydo 显示3D特效
	local hData = localTeam.models[tostring(self.newCard)];
	local localData = Model.units[tostring(hData.netData.system_hero_id)];
	self:addToList(tostring(localData.model));
	self:loadRes();
	--- 显示场景
	self:setSceneShow(false);
	self:setSceneCardShow();
end

--- 刷新英雄界面UI显示
function teamCompose:setSceneCardShow()
	local hData = localTeam.models[tostring(self.newCard)];
	local localData = Model.units[tostring(hData.netData.system_hero_id)];
	--- 英雄 名字/信息/图标
	self.heroUI.name.text = getValue(localData.name);
	self.heroUI.info.text = getValue(localData.desc);
	self.heroUI.icon.spriteName = localData.icon;
	--- 技能[没有暂时显示为隐藏]
	for i=1, 4 do
		if hData.netData.hero_skill[i] then
			self.heroUI.skills[i].gameObject:SetActive(true);
			local pt_hero_skill = hData.netData.hero_skill[i];
			local skillData = Model.skills[tostring(pt_hero_skill.id)];
			self.heroUI.skills[i].spriteName = skillData.icon;
		else
			self.heroUI.skills[i].gameObject:SetActive(false);
		end
	end
	--- 血/攻击/物防/魔防
	local isMagic = false;
	self.heroUI.hp.text = math.floor(hData.netData.player_hero_attribute.maxHp);
	local damageTxt = hData.netData.player_hero_attribute.damage;
	local magicDamage = hData.netData.player_hero_attribute.magicDamage;
	if damageTxt < magicDamage then
	   damageTxt = magicDamage;
	   isMagic = true;
	end
	self.heroUI.attack.text = math.floor(damageTxt);
	self.heroUI.defence.text = math.floor(hData.netData.player_hero_attribute.defend);
	self.heroUI.mdefence.text = math.floor(hData.netData.player_hero_attribute.magicDefend);
end

function teamCompose:skillOnPress(obj, arg)
	if arg then
		local cmd =obj.name;
		local tran = obj.transform.parent;
		local strTitle = string.sub(obj.name, 1, 5);
		if strTitle == "skill" and tran then
			local index = tonumber(string.sub(obj.name, 6));
			local hData = localTeam.models[tostring(self.newCard)];
			local pt_hero_skill = hData.netData.hero_skill[index];
			if pt_hero_skill then
				local skillData = Model.skills[tostring(pt_hero_skill.id)];
				self.heroUI.pop["info"].text = getValue(skillData.description);
				local pos = self.heroUI.pop["mirror"].transform.localPosition;
				if index == 1 or index == 2 then
					self.heroUI.pop["mirror"].transform.localPosition = Vector3(100, pos.y, pos.z);
				else
					self.heroUI.pop["mirror"].transform.localPosition = Vector3(-100, pos.y, pos.z);
				end
				pos = self.heroUI.pop["xPos"].transform.localPosition;
				self.heroUI.pop["xPos"].transform.localPosition = Vector3(-357 + index *140, pos.y, pos.z);
			end
		end
	end
end

--- 根据当前情况刷新界面
function teamCompose:updateViewsByState()
	if self.panelState == PanelStates["normal"] then
		self:updateCardViews();
		self:updateBlocks(); 
	elseif self.panelState == PanelStates["compose"] then
		self.selMain = nil;
		self.selDeputy = nil;
		self.panelState = PanelStates["normal"];
		if self.newCard then
			--- 切换到合成的特效处理
			self.panelState = PanelStates["comScene"];
			self:updateViewsByState();
		else
			self:updateCardViews();
			self:updateBlocks(); 
		end
	elseif self.panelState == PanelStates["comScene"] then
		self:handleCardSpawn();
		self.panelState = PanelStates["normal"];
	end
end

--- 更新所有界面显示
function teamCompose:updateCardViews()
	self:setCardShow(self.selMain,true);
	self:setCardShow(self.selDeputy,false);
	self:setComposeCost();    
end

--- 点击合成
function teamCompose:compClick()
	if self.selMain == nil then
		showTips("请选择用来合成的英雄");
	elseif self.selDeputy == nil then
		showTips("请放入两个英雄!");
	else
		self:setPanelState("compose");
		Sendplayer_hero_compose(self.selMain, self.selDeputy);
	end
end

---------------------------------------- 加载相关
--- 需要链接多个parent(gameObject)
function teamCompose:getModelParent(key)
	if self.modelParent then
		for i, v in pairs(self.modelParent) do
			if v.key == key then
				return v.obj;
			end
		end
	end

	return nil;
end

--- 重置本地表
function teamCompose:resetReq()
  --- req 清空
  self.reqs = {};
  --- 删除掉上次生成的prefab
  for i, v in pairs(self.prefabPool) do
    LuaHelper.Destroy(v);
  end
  self.prefabPool = {};
end

function teamCompose.onModelComplete(req)
  local key = req.key
  if req.data then
    local mainAsset = req.data.assetBundle.mainAsset;
    LuaHelper.RefreshShader(req.data);
    ---- 复制原件
    -- local objParent = teamCompose:getModelParent(key);
    local clone = LuaHelper.InstantiateLocal(req.data.assetBundle.mainAsset,
    	teamCompose.modelParent);
    clone.gameObject:SetActive(true)
    local nav = LuaHelper.GetComponent(clone,"NavMeshAgent")
    if(nav) then nav.enabled = false end

    clone.name = "Clone_Modle_";
    LuaHelper.GetComponent(clone.gameObject,"BoxCollider").size = Vector3(0.4, 1,1);
    LuaHelper.GetComponent(clone.gameObject,"BoxCollider").center = Vector3(0, 0.5,0);
    clone.transform.position = teamCompose.copyObj.transform.position;
    clone.transform.localRotation = Quaternion.Euler(0, 180, 0);
    clone.transform.localScale = teamCompose.copyObj.transform.localScale;
    ---------------
    teamCompose.prefabPool[tostring(key)] = clone;
    disposeWWW(req.data)
  end
end 

function teamCompose:addToList(key)
  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      self.reqs[key]={CUtils.GetAssetFullPath(key..".u3d"), self.onModelComplete}
  end
end

function teamCompose:loadRes( ... )
  local switch = false;
  for i, v in pairs(self.reqs) do
    switch = true;
    break;
  end
  if not switch then return end

  print(" begin loadRes in compose ")
  Loader:getResource(self.reqs,false)
end

-----------------------------------加载end----------------
-------------------------------------------------------


-------------------- show/hide
function teamCompose:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end
end

function teamCompose:hideAll()
	self:removeFromState();
	self.isShow = false;
	--- reset
	self:setPanelState("normal");
	self.selType = "BtnPower";
	self.selMain = nil;
	self.selDeputy = nil;
end
----------------------------------- system call
---- 根据英雄信息更新上阵列表的表(副)
function teamCompose.getHeroDatas(netData)
	--- 避免接收消息后刷新队伍界面
	if localTeam.isShow then return end
	-------------- data handle
	localTeam.getHeroDatas(netData);
	---------------- view handle
	if teamCompose.isShow then
		-------------- 可能的合成数据检查
		teamCompose:checkComposeData(netData);
		teamCompose:updateViewsByState();
	end
end

-- 资源加载完成时候调用方法
function teamCompose:onAssetsLoad(items)
	---- 主UI
	local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
	if(referScript == nil)  then print("erro config"); end
	
	self.mainUI = self.assets[1].root;
	-- panel, 这里只包含需要设置的title/upPanel/downPanel
	for i=0, referScript.refers.Count - 1 do
		table.insert(self.panels, referScript.refers[i]);
	end

	--- 标题头 "英雄强化"
	-- referScript.monos[1].text = getValue("");
	--- 标题提示 "规则"
	-- local subRef = LuaHelper.GetComponent(self.panels[1],"ReferGameObjects");
	-- subRef.monos[0] = getValue("");

	--- 合成场景 记录位置标记坐标和父parent
	self.heroScene = self.assets[2].root;
	local sceneScript = LuaHelper.GetComponent(self.heroScene,"ReferGameObjects");
	self.copyObj = sceneScript.refers[0];
	self.modelParent = self.copyObj.transform.parent.gameObject;
	--- 合成场景UI
	self.heroUI = {};
	self.heroUI.root = self.assets[3].root;
	local heroScript = LuaHelper.GetComponent(self.assets[3].items["Refers"],"ReferGameObjects");
	---- 初始化每个panel界面
	self:initMainPan();
	self:initHeroUI(heroScript);
end

-- 第一次注册的时候调用
function teamCompose:initialize()
	self:setPanelState("normal");
	self.selType = "BtnPower";
	self.selMain = nil;
	self.selDeputy = nil;
	--- 注册接收英雄属性更新消息, 包括卡片数量更新
	Proxy:binding(NetAPIList.recv_player_hero_change, self.getHeroDatas);
end

--- 每次显示都会调用
function teamCompose:onShowed( ... )
	if localTeam and localTeam.isShow then
		localTeam:hideAll();
	end

	---- 做默认的场景资源管理
	self:setSceneShow(true);
	self:updateViewsByState();
end

function teamCompose:heroBtnOnClick(obj)
	local cmd = obj.name;
	local tran = obj.transform.parent;

	if (cmd == "BtnPower" or cmd == "BtnStar" or cmd == "BtnStenLen")
		and tran and tran.name == "downPanel" then
		if self.selType ~= cmd then
			self.selType = cmd;
			self:updateBlocks();
		end
	end
end

function teamCompose:blockOnPress(obj, arg)
	if not arg then
		local cmd =obj.name;
		local tran = obj.transform.parent;
		local strTitle = string.sub(obj.name, 1, 11);
		if strTitle == "blockPrefab" and tran and tran.name == "grid" then
			local index = tonumber(string.sub(obj.name, 12));
			local hData = self.heroTable[index];
			---------------------------
			if self.selMain == nil then 
				self.selMain = hData.netData.player_hero_id;
			else
				self.selDeputy = hData.netData.player_hero_id;
			end
			self:updateViewsByState();
		end
	end
end

function teamCompose:onPress(obj, arg)
	if not self.isShow then return end
	--- 英雄上阵界面
	self:blockOnPress(obj, arg);

	self:skillOnPress(obj, arg);
end

---- 这里是队伍的2级界面， 会屏蔽5个主功能键
function teamCompose:onClick(obj,arg)
	local cmd =obj.name;
	local tran = obj.transform.parent;

	if cmd == "BtnBack" and tran and tran.name == "ornament" then
		-- 临时使用， 返回组队界面
		self:hideAll();
		if not localTeam.isShow then
			localTeam:setPanelState("normal");
			localTeam:showAll();
		end
	elseif cmd == "btnComp" and tran and tran.name == "upPanel" then
		self:compClick();
	elseif cmd == "icon"  and tran and tran.name == "Lperson" then
		if self.selMain then
			self.selMain = nil;
			self.selDeputy = nil;
			self:updateViewsByState(); 
		else
			showTips("请选择用来合成的英雄"); 
		end
	elseif cmd == "back_btn" and tran and tran.name == "top01" then
		self:setSceneShow(true);
		self:updateViewsByState();
	end

	self:heroBtnOnClick(obj);
end