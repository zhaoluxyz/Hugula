local teamStrenth = LuaItemManager:getItemObject("teamStrenth")
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
teamStrenth.assets=
{
	 Asset("TStrengthUI.u3d", {"Config"}),
}
-- 检查界面是否打开
teamStrenth.isShow = false;
-- panel
teamStrenth.panels = {};
-- 要强化的主卡的信息, 包含服务器ID， 强化等级
teamStrenth.selMain = 
{
	player_hero_id = nil;
	player_hero_strengthen = 0;
};
-- 材料副卡唯一ID[服务器ID]
teamStrenth.selDeputy = nil;
--- 当前界面状态
teamStrenth.panelState = 1;
--- 当前的基本强化需要数据
teamStrenth.rateData = nil;
--- 当前选中的分类方式, 默认是战力
teamStrenth.selType = "BtnPower";
------------------private-----------------
-- 记录当前界面操作的状态， 分别是 一般/强化
local PanelStates =
{
	normal = 1;
	stren = 2;
};
--- 英雄顶部按钮的精灵名
local btnSpriteNames = 
{
	"pack_tab1",
	"pack_tab2",  
};
-- 最大上阵
local MTeamLen = 5;
-- 最大强化等级
local MaxUpLv = 5;
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

--- 按位置排序
local function sortPos(a,b)  
	if a~=nil and b~=nil and a.pos and b.pos then  
		return tonumber(a.pos)<tonumber(b.pos) 
	else
		return false
	end
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

--- 根据当前显示英雄数量, 获得需要额外添加的板子块数
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

--- 返回某个组合的基本成功率
local function GetLocalStrenData(main, deputy)
	if main == nil or deputy == nil then 
		return nil;
	end

		local mHData = localTeam.models[tostring(main)];
		local mlocalData = Model.units[tostring(mHData.netData.system_hero_id)];
		local dHData = localTeam.models[tostring(deputy)];
		local dlocalData = Model.units[tostring(dHData.netData.system_hero_id)];
		for i, v in pairs(Model.heroStren) do
			--- 检查星级/下一级的强化LV
			if tonumber(v.strengthen_card_star_1) == mlocalData.star 
				and tonumber(v.strengthen_card_star_2) == dlocalData.star
				and tonumber(v.str_level) == mHData.netData.player_hero_strengthen + 1 then
					return v;
			end
		end
end

--- 返回某个索引英雄的强化后会增加的属性信息
local function GetLocalStrenUp(localData, upLv)
	if upLv > MaxUpLv then return nil end;
	return localData["str_property" .. upLv];
end

--- 发送英雄强化的消息 2239 
local function Sendplayer_hero_strengthen(player_hero_idl, player_hero_idr)
	local cont = NetMsgHelper:makesend_player_hero_strengthen(player_hero_idl,player_hero_idr);
	Proxy:send(NetAPIList.player_hero_strengthen,cont);
end

------------------public------------------
--- 根据需要设置当前进入UI的状态, 传入字符串
function teamStrenth:setPanelState(state)
	self.panelState = PanelStates[state];
end

function teamStrenth:getMTitle()
	local referScript = LuaHelper.GetComponent(self.panels[1],"ReferGameObjects");
	self.mTitle = {}; 
	if referScript then
		--- 强化基本成功率
			self.mTitle["baseStren"] = referScript.monos[0];
				self.mTitle["baseLable"] = referScript.monos[1];
				--- 额外强化成功率
				self.mTitle["addStren"] = referScript.monos[2];
				self.mTitle["addLable"] = referScript.monos[3];
		end
end

function teamStrenth:getMUpPanel()
	local referScript = LuaHelper.GetComponent(self.panels[2],"ReferGameObjects");
	self.mPreviews = {};
	if referScript then
		--- 提示/消耗/消耗金币/开始强化/开始强化的按钮
		self.mPreviews["tip"] = referScript.monos[0];
		self.mPreviews["cost"] = referScript.monos[1];
		self.mPreviews["costLable"] = referScript.monos[2];
		self.mPreviews["sBtnText"] = referScript.monos[3];
		self.mPreviews["btnStren"] = referScript.refers[3];
		---------------- 主卡
		self.mPreviews["main"] = {};
			local subRef = LuaHelper.GetComponent(referScript.refers[0],"ReferGameObjects");
			--- 头像/元素/强化等级/名字/星级(x?)/提示主卡的标签
			self.mPreviews["main"].icon = subRef.monos[0];
			self.mPreviews["main"].elem = subRef.monos[1];
			self.mPreviews["main"].add = subRef.monos[2];
			self.mPreviews["main"].name = subRef.monos[3];
			self.mPreviews["main"].starLv = subRef.monos[4];
			self.mPreviews["main"].tab = subRef.monos[5];
			----------------- 副卡
			self.mPreviews["deputy"] = {};
			subRef = LuaHelper.GetComponent(referScript.refers[1],"ReferGameObjects");
			--- 头像/元素/强化等级/名字/星级(x?)/提示副卡的标签
			self.mPreviews["deputy"].icon = subRef.monos[0];
			self.mPreviews["deputy"].elem = subRef.monos[1];
			self.mPreviews["deputy"].add = subRef.monos[2];
			self.mPreviews["deputy"].name = subRef.monos[3];
			self.mPreviews["deputy"].starLv = subRef.monos[4];
			self.mPreviews["deputy"].tab = subRef.monos[5];
			----------------- 合成信息面板
			self.mPreviews["info"] = {};
			subRef = LuaHelper.GetComponent(referScript.refers[2],"ReferGameObjects");
			--- 提示/HP/defence/attack/speed
				self.mPreviews["info"].tip = subRef.monos[0];
			self.mPreviews["info"].hp = subRef.monos[1];
			self.mPreviews["info"].defence = subRef.monos[2];
			self.mPreviews["info"].attack = subRef.monos[3];
			self.mPreviews["info"].speed = subRef.monos[4];
	end 	
end

function teamStrenth:getMDownPanel()
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

function teamStrenth:InitMainPan()
	-------- 面板初始化
		--- 成功率提示
		self:getMTitle();
		--- 预览面板
		self:getMUpPanel();
		--- 筛选面板
		self:getMDownPanel();
end

---- 传入一个千分值， 比如 333/1000
function teamStrenth:getRate(rateNum)
	leftEnd = rateNum%10;
	local text = "0%";
	if leftEnd == 0 then
		text = rateNum/10 .. "%";
	else
		local show = rateNum*1.0/10;
		text = string.format("%.1f", show) .. "%";
	end
	return text;
end

--- 更新title显示的强化几率
function teamStrenth:updateTitlePanel()
		--- 基本强化率/额外强化率
		self.mTitle["baseLable"].text = "0%";
		self.mTitle["addLable"].text = "0%";
		if self.selMain.player_hero_id ~= nil then
			local strIndex = tostring(self.selMain.player_hero_id);
			local hData = localTeam.models[strIndex];
			if hData then
				self.mTitle["addLable"].text = self:getRate(hData.netData.player_hero_strengthen_rate);
					--- 获得满足条件的强化率(不包含超过强化次数)
				self.rateData = GetLocalStrenData(self.selMain.player_hero_id, self.selDeputy);
				if self.rateData then
					self.mTitle["baseLable"].text = self:getRate(self.rateData.strengthen_base_rate);
				end
			end
		end
end

--- 设置预览的头像显示
function teamStrenth:setStrenCard(player_hero_id, isMain)
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
		--- 打开后默认开启闪烁
		views.add.gameObject:SetActive(true);
		views.add.text = "+ " .. hData.netData.player_hero_strengthen;
	else
		views.add.gameObject:SetActive(false);
	end
	views.name.text = getValue(localData.name);
	views.starLv.text = "X " .. localData.star;
end

--- 设置强化预览显示
function teamStrenth:setPreviewShow()
	--- 获得组合字符串
	local function getEndText(base, color, upData, strKey)
		local text = "";
		if upData ~= nil then
			if tonumber(upData[strKey]) > 0 then
				text = "+" .. upData[strKey];
			end
		end
		text = base ..  GetColorString(color, text);
		return text;
	end

	----------------- normal set
	local views = self.mPreviews["info"];
		views.hp.text = 0;
		views.defence.text = 0;
		views.attack.text = 0;
		views.speed.text = 0;
		------------------------------
		if self.selMain.player_hero_id == nil then return end
		local hData = localTeam.models[tostring(self.selMain.player_hero_id)];
		local localData = Model.units[tostring(hData.netData.system_hero_id)];
		if hData == nil or localData == nil then return end
		local nextStrenLv = hData.netData.player_hero_strengthen + 1;
		local upData = GetLocalStrenUp(localData,  nextStrenLv);
		--- hp
		local showText = hData.netData.player_hero_attribute.maxHp;
		showText = getEndText(showText, "[1EC810]", upData, "maxHp");
		views.hp.text = showText;
		--- defence
		showText = hData.netData.player_hero_attribute.defend;
		showText = getEndText(showText, "[1EC810]", upData, "defend");
		views.defence.text = showText;
		--- attack
		showText = hData.netData.player_hero_attribute.damage;
		showText = getEndText(showText, "[1EC810]", upData, "damage");
		views.attack.text = showText;
		--- speed
		showText = hData.netData.player_hero_attribute.speed;
		showText = getEndText(showText, "[1EC810]", upData, "speed");
		views.speed.text = showText;
end

--- 设置强化消耗
function teamStrenth:setStrenCost()
	self.mPreviews["costLable"].text = 0;
	if self.rateData then self.mPreviews["costLable"].text = self.rateData.strengthen_consume end
end

--- 根据当前类型重新排序
function teamStrenth:sortAllHero()
	--- 初始化英雄显示列表
	self.heroTable = {};
 --------------------------------------------
	---生成一张乱序新表, 并将上阵的英雄独立出来
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
			--- 排除掉作为主卡的卡片
			if self.selMain.player_hero_id == nil or 
				self.selMain.player_hero_id ~= v.netData.player_hero_id then
				if v.pos > 0 and v.pos < MTeamLen + 1 then
					--- 上阵列表
					table.insert(upHeroDatas, hData);
				else
					--- 下阵列表
					table.insert(downHeroDatas, hData);
				end
			end
		end
	end
	--- 上阵列表重新排序
	if #upHeroDatas > 1 then table.sort(upHeroDatas, sortPos) end
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
	if self.selMain.player_hero_id == nil then
		--- 但更没有选择卡的时候需要插入上阵数据
		for i, hData in ipairs(upHeroDatas) do
			table.insert(self.heroTable, hData);
		end
	end
	for i, hData in ipairs(downHeroDatas) do
		table.insert(self.heroTable, hData);
	end
end

--- 设置英雄view的显示
function teamStrenth:setHeroBlock(i, hData)
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
	-- 头像/五行/上阵提示
	refer.monos[0].spriteName = getIconName(localData.icon);
	refer.monos[1].spriteName = GetHeroElemName(localData.category2);
	refer.monos[2].gameObject:SetActive(isUp);
	--- 强化次数/星级/名字
	if hData.player_hero_strengthen > 0 then
		refer.monos[3].gameObject:SetActive(true);
		refer.monos[3].text = "+ " .. hData.player_hero_strengthen;
	else
		refer.monos[3].gameObject:SetActive(false);
	end
	refer.monos[4].text = tostring(hData.star);
	refer.monos[5].text = getValue(localData.name);
end

--- 根据当前排序决定显示那些英雄
function teamStrenth:updateHeroBySort()
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
end

---hero btn的刷新改变
function teamStrenth:heroTopBtnSetView()
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
function teamStrenth:updateBlocks()
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

--- 根据当前情况刷新界面
function teamStrenth:updateViewsByState()
	if self.panelState == PanelStates["normal"] then
		self:updateCardViews();
		self:updateBlocks(); 
	elseif self.panelState == PanelStates["stren"] then
		--- 当有选中主卡的时候才会更新
		if self.selMain.player_hero_id then
			local strIndex = tostring(self.selMain.player_hero_id);
			local hModel = localTeam.models[strIndex];
			if hModel.netData.player_hero_strengthen > self.selMain.player_hero_strengthen then
				---- 强化成功
				print("ok");
				self.selMain.player_hero_strengthen = hModel.netData.player_hero_strengthen;
			else
				---- 强化失败
				print("fail");
			end
			----------------- 这个部分应该在对应的动画处理完后调用
			---- 更新
			self.selDeputy = nil;
			self.panelState = PanelStates["normal"];
		end
		self:updateCardViews();
		self:updateBlocks();
	end
	
end

--- 更新所有界面显示
function teamStrenth:updateCardViews()
	self:updateTitlePanel();
	self:setStrenCard(self.selMain.player_hero_id,true);
	self:setStrenCard(self.selDeputy,false);
	self:setPreviewShow();
	self:setStrenCost();    
end

-------------------- show/hide
function teamStrenth:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end
end

function teamStrenth:hideAll()
	self:removeFromState();
	self.isShow = false;
	--- reset
	self:setPanelState("normal");
	self.selType = "BtnPower";
	self.selMain.player_hero_id = nil;
	self.selDeputy = nil;
end
----------------------------------- system call
---- 根据英雄信息更新上阵列表的表(副)
function teamStrenth.getHeroDatas(netData)
	--- 避免接收消息后刷新队伍界面
	if localTeam.isShow then return end
	-------------- data handle
	localTeam.getHeroDatas(netData);
	---------------- view handle
	if teamStrenth.isShow then teamStrenth:updateViewsByState() end
end

-- 资源加载完成时候调用方法
function teamStrenth:onAssetsLoad(items)
	local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
		if(referScript == nil)  then print("erro config"); end
	
		-- panel, 这里只包含需要设置的title/upPanel/downPanel
		for i=0, referScript.refers.Count - 1 do
			table.insert(self.panels, referScript.refers[i]);
		end

	--- 标题头 "英雄强化"
		-- referScript.monos[1].text = getValue("");

		---- 初始化每个panel界面
		self:InitMainPan();
end

-- 第一次注册的时候调用
function teamStrenth:initialize()
	self:setPanelState("normal");
	self.selType = "BtnPower";
	self.selMain.player_hero_id = nil;
	self.selDeputy = nil;
	--- 注册接收英雄属性更新消息, 包括卡片数量更新
	Proxy:binding(NetAPIList.recv_player_hero_change, self.getHeroDatas);
end

--- 每次显示都会调用
function teamStrenth:onShowed( ... )
	if localTeam and localTeam.isShow then
		localTeam:hideAll();
	end

	self:updateViewsByState();
end

function teamStrenth:strenClick()
	if self.selMain.player_hero_id == nil then
		showTips("没有选择主卡!");
	elseif self.selDeputy == nil then
		showTips("没有选择副卡!");
	else
		--- 检查强化次数
		if self.selMain.player_hero_strengthen > MaxUpLv -1 then
			showTips("已强化到最大等级!");
			return;
		end
		self:setPanelState("stren");
		Sendplayer_hero_strengthen(self.selMain.player_hero_id, self.selDeputy);
	end
end

function teamStrenth:heroBtnOnClick(obj)
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

function teamStrenth:blockOnPress(obj, arg)
	if not arg then
		local cmd =obj.name;
		local tran = obj.transform.parent;
		local strTitle = string.sub(obj.name, 1, 11);
		if strTitle == "blockPrefab" and tran and tran.name == "grid" then
			local index = tonumber(string.sub(obj.name, 12));
			local hData = self.heroTable[index];
			---------------------------
			if self.selMain.player_hero_id == nil then
				self.selMain.player_hero_id = hData.netData.player_hero_id;
				self.selMain.player_hero_strengthen = hData.netData.player_hero_strengthen;
			else
				self.selDeputy = hData.netData.player_hero_id;
			end
			self:updateViewsByState();
		end
	end
end

function teamStrenth:onPress(obj, arg)
	if not self.isShow then return end
	--- 英雄上阵界面
	self:blockOnPress(obj, arg);
end

---- 这里是队伍的2级界面， 会屏蔽5个主功能键
function teamStrenth:onClick(obj,arg)
	local cmd =obj.name;
	local tran = obj.transform.parent;

	if cmd == "BtnBack" and tran and tran.name == "ornament" then
		-- 临时使用， 返回组队界面
		self:hideAll();
		if not localTeam.isShow then
			localTeam:setPanelState("normal");
			localTeam:showAll();
		end
	elseif cmd == "btnStren" and tran and tran.name == "upPanel" then
		self:strenClick();
	elseif cmd == "icon"  and tran and tran.name == "Lperson" then
		if self.selMain.player_hero_id then
			self.selMain.player_hero_id = nil;
			self.selDeputy = nil;
			self:updateViewsByState(); 
		else
			showTips("请选择需要强化的英雄!"); 
		end
	end

	self:heroBtnOnClick(obj);
end