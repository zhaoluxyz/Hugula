local teamWeapon = LuaItemManager:getItemObject("teamWeapon")
local localTeam = LuaItemManager:getItemObject("teamPanel")
local localPack = LuaItemManager:getItemObject("packPanel")
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
teamWeapon.assets=
{
   Asset("TWeaponUI.u3d", {"Config"}),
}
-- 检查界面是否打开
teamWeapon.isShow = false;
-- panel
teamWeapon.panels = {};
-- 当前选中的英雄id
teamWeapon.selIndex = 1;
-- 当前英雄的装备栏状态， 装备/未装备等等
teamWeapon.weaponStates = {};
-- 当前点击的装备栏位置
teamWeapon.weaponSel = 0;
-- 当前的装备弹出框状态。 为空表示没有子窗口弹出
teamWeapon.popStates = {};
--- 当前界面状态
teamWeapon.panelState = 1;
------------------private-----------------
local MTeamLen = 5;
-- 记录当前界面操作的状态， 分别是 一般/合成/穿戴/点击英雄切换/英雄进阶
local PanelStates =
{
	normal = 1,
	compose = 2,
	wear = 3,
	heroTab = 4,
	heroUp = 5,
};

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
  local colorStr = color .. str .. "[-]"
  return colorStr
end

--- 设置英雄星阶
local function SetHeroStarLv(obj, lv)
  local childs = LuaHelper.GetAllChild(obj);
  for i=0, childs.Length-1 do
     local index = tonumber(string.sub(childs[i].name, -1));
     if index < lv then childs[i].gameObject:SetActive(true);
     else childs[i].gameObject:SetActive(false) end
  end
end

--- 设置英雄的其他属性显示
local function SetHeroNormalInfo(obj, text)
  local childs = LuaHelper.GetAllChild(obj);
  local uiLable = LuaHelper.GetComponent(childs[0].gameObject,"UILabel");
  uiLable.text = text;
end

--- 设置状态栏没装备的时候的显示
---- 0 无装备/1 可合成/2 可装备/3 未装备
local function SetHeroWeaponShow(addIcon, lable, state)
	local addIconNames = 
	{
	  "weaponS0",
	  "weaponS1",  
	};

	local tTexts =
	{
		"无装备",
	    "可合成",
	    "可装备",
	    "未装备",
	};

	local color = "[2be863]";
	if state == 0 then
		---- 灰色
		addIcon.gameObject:SetActive(false);
		color = "[505050]";
		lable.text = GetColorString(color, tTexts[1]);
	elseif state == 1 then
		--- 黄色
		addIcon.spriteName = addIconNames[1];
		color = "[B4B414]";
		lable.text = GetColorString(color, tTexts[2]);
	elseif state == 2 then
		--- 绿色
		addIcon.spriteName = addIconNames[2];
		color = "[1CB408]";
		lable.text = GetColorString(color, tTexts[3]);
	elseif state == 3 then
		--- 黄色
		addIcon.spriteName = addIconNames[1];
		color = "[B4B414]";
		lable.text = GetColorString(color, tTexts[4]);
	end	
end

--- 返回1表示可用， 返回0不可用
--- 注意： 不会检查某个合成的物件需要多个的情况， 会引起问题
local GetComposeState;
GetComposeState = function(goods_id, num)
	local goodModel = localPack:getGoodDataById(goods_id);
	---- 获得合成表
	local localCData = Model.goodComp[tostring(goods_id)];
	if goodModel then
		--- 检查背包内的数量是否足够
		if goodModel.netData.goods_num > num - 1 then return 1 end
	elseif localCData == nil then
		--- 检查合成表
	 	return 0;
	end
	--- 检查合成表内的物件
	for i, good in pairs(localCData.goods) do
		local needNum = localCData.num[i];
		if GetComposeState(good, needNum) == 0 then
			return 0;
		end
	end
	return 1;
end

--- 发送获得英雄穿戴某个装备的消息 2223 
local function SendPlayer_hero_equip_up(goods_id,player_hero_id)
  local cont = NetMsgHelper:makesend_player_hero_equip_up(goods_id, player_hero_id);
  Proxy:send(NetAPIList.use_equip_api,cont);
end

--- 发送合成某个装备的消息 2233
local function SendHero_equip_synthesis(goods_id)
  local cont = NetMsgHelper:makesend_hero_equip_synthesis(goods_id);
  Proxy:send(NetAPIList.hero_equip_synthesis,cont);
end

--- 发送合成某个装备的消息 2224
local function SendHero_equip_Allup(player_hero_id)
  local cont = NetMsgHelper:makesend_player_hero_advanced(player_hero_id);
  Proxy:send(NetAPIList.player_hero_advanced,cont);
end 


-----------------------------------------------------

------------------public------------------
function teamWeapon:getMHeadPanel()
	local referScript = LuaHelper.GetComponent(self.panels[1],"ReferGameObjects");
	self.mHeadViews = {}; 
	if referScript then
       	for i=0, referScript.refers.Count - 1 do
       		local subRef = LuaHelper.GetComponent(referScript.refers[i],"ReferGameObjects");
       		local subView = {};
     		subView.icon = subRef.monos[0];
       		subView.select = subRef.monos[1].gameObject;
       		table.insert(self.mHeadViews, subView);
    	end
   	end
end

function teamWeapon:getMHeroPanel()
	local referScript = LuaHelper.GetComponent(self.panels[2],"ReferGameObjects");
	self.mHeroViews = {}; 
	if referScript then
		-- 角色名
		self.mHeroViews.name = referScript.monos[0];
		-- 角色等级
		self.mHeroViews.lv = referScript.monos[1];
		-- 角色经验(exp.value)
		self.mHeroViews.exp = LuaHelper.GetComponent(referScript.refers[0], "UISlider");
		self.mHeroViews.expLable = referScript.monos[2];
		--- 升阶按钮
		self.mHeroViews.upLable = referScript.monos[3];
		-- 装备区
		self.mHeroViews.weapons = {};
		local subRef = LuaHelper.GetComponent(referScript.refers[1], "ReferGameObjects");
		for i=0, subRef.refers.Count - 1 do
			local wRef = LuaHelper.GetComponent(subRef.refers[i], "ReferGameObjects");
			local weaponView = {};
			weaponView.icon = wRef.monos[0];
			weaponView.stateIcon = wRef.monos[1];
			weaponView.lable = wRef.monos[2];
			table.insert(self.mHeroViews.weapons, weaponView);
		end
	end	
end

function teamWeapon:getMInfoPanel()
	local referScript = LuaHelper.GetComponent(self.panels[3],"ReferGameObjects");
	self.mHeroInfo = {};
	if referScript then
		local info = LuaHelper.GetComponent(referScript.refers[0],"ReferGameObjects");
		self.mHeroInfo.starLv = info.refers[0];
		self.mHeroInfo.power = info.refers[1];
		self.mHeroInfo.hp = info.refers[2];
		self.mHeroInfo.defence = info.refers[3];
		self.mHeroInfo.attack = info.refers[4];
		self.mHeroInfo.speed = info.refers[5];
		--- "星阶"
		self.mHeroInfo.starLable = info.monos[0];
		--- "战力"
		self.mHeroInfo.powerLable = info.monos[1];
	end
end

function teamWeapon:getPopPanel()
	local referScript = LuaHelper.GetComponent(self.panels[4],"ReferGameObjects");
	self.mPopView = {};
	self.mPopSubView = {};
	if referScript then
		------ 装备信息栏
		local popRef = LuaHelper.GetComponent(referScript.refers[0],"ReferGameObjects");
		self.mPopView.obj = referScript.refers[0];
		--- 装备图标/名字/..数量../信息描述/等级描述/按钮信息
		self.mPopView.wIcon = popRef.monos[0];
		self.mPopView.wName = popRef.monos[1];
		self.mPopView.haveLable0 = popRef.monos[2];
		self.mPopView.wNum = popRef.monos[3];
		self.mPopView.haveLable1 = popRef.monos[4];
		self.mPopView.attribute = popRef.monos[5];
		self.mPopView.wLvInfo = popRef.monos[6];
		self.mPopView.wState = popRef.monos[7];
		self.mPopView.wInfo = popRef.monos[8];
		----- 装备合成栏
		local popSubRef = LuaHelper.GetComponent(referScript.refers[1],"ReferGameObjects");
		self.mPopSubView.obj = referScript.refers[1];
		--- 记录分页栏 title
		self.mPopSubView.titles = {};
		local titleRef = LuaHelper.GetComponent(popSubRef.refers[0],"ReferGameObjects");
		for i=0, 3 do
			local itemSel = {};
			local itemRef = LuaHelper.GetComponent(titleRef.refers[i],"ReferGameObjects");
			itemSel.obj = titleRef.refers[i];
			itemSel.wIcon = itemRef.monos[0];
			itemSel.select = itemRef.monos[1].gameObject;
			table.insert(self.mPopSubView.titles, itemSel);
		end
		
		--- 记录每个合成目录的具体信息
		self.mPopSubView.subItemViews = {};
		for i=1, 4 do
			local itemHandle = {};
			local subItemRef = LuaHelper.GetComponent(popSubRef.refers[i],"ReferGameObjects");
			--- 记录具体的合成目录的obj
			itemHandle.obj = popSubRef.refers[i];
			itemHandle.wIcon = subItemRef.monos[0];
			itemHandle.wName = subItemRef.monos[1];
			itemHandle.cost = subItemRef.monos[2];
			itemHandle.costLable =  subItemRef.monos[3];
			itemHandle.wState = subItemRef.monos[4];
			itemHandle.items = {};
			--- 每个合成子装备的信息
			for count=0, subItemRef.refers.Count - 1 do
				local itemView = {};
				local itemRef = LuaHelper.GetComponent(subItemRef.refers[count],"ReferGameObjects");
				itemView.wIcon = itemRef.monos[0];
				itemView.wNum = itemRef.monos[1];
				table.insert(itemHandle.items, itemView);
			end
			table.insert(self.mPopSubView.subItemViews , itemHandle);
		end

		--- 掉落表
		self.mPopSubView.drops = {};
		local dropRef = LuaHelper.GetComponent(popSubRef.refers[5],"ReferGameObjects");
		self.mPopSubView.drops["obj"] = popSubRef.refers[5];
		self.mPopSubView.drops["wIcon"] = dropRef.monos[0];
		self.mPopSubView.drops["wName"] = dropRef.monos[1];
		self.mPopSubView.drops["drop"] = dropRef.monos[2];
		self.mPopSubView.drops["dropBtn0"] = dropRef.monos[3];
		self.mPopSubView.drops["dropBtn1"] = dropRef.monos[4];
		self.mPopSubView.drops["dropBtn2"] = dropRef.monos[5];
	end
end

function teamWeapon:InitMainPan()
  -------- 主装备面板
  --- 头像栏
  self:getMHeadPanel();
  -- 英雄装备栏
  self:getMHeroPanel();
  -- 英雄信息面板
  self:getMInfoPanel();
  --- 装备合成面板
  self:getPopPanel();
end

--- 设置默认选中的头像
function teamWeapon:setDefaultSelIndex()
	self.selIndex = 1;
	for i=1, MTeamLen do
		if localTeam.hUpTable[i] then
			self.selIndex = i;
			return;
		end
	end
end

--- 显示头像 view
function teamWeapon:updateHeadPanel()
	local function getIconName(name)
		local newIndex = tonumber(string.sub(name, -4));
		if newIndex > 3 then newIndex = 3 end
	    return "icon_role_" .. GetSpecifyStr(newIndex, 4);
	end

    for i, subView in ipairs(self.mHeadViews) do
    	subView.icon.gameObject:SetActive(false);
    	subView.select.gameObject:SetActive(false);
    	local strIndex = localTeam.hUpTable[i];
    	local hData = localTeam.models[strIndex];
    	if hData then
    		--- 有英雄上阵
			local localHData = Model.units[tostring(hData.netData.system_hero_id)];
    		subView.icon.gameObject:SetActive(true);
	     	subView.icon.spriteName = getIconName(localHData.icon);
	     	--- 选中位置
	       	if i == self.selIndex then
	       	   subView.select.gameObject:SetActive(true);
	       	end
       	end
   	end
end

--- 检查对应装备可装备状态
function teamWeapon:checkWeaponState(goods_id)
	local goodModel = localPack:getGoodDataById(goods_id);
	if goodModel ~= nil then
		local localGData = Model.itemData[tostring(goodModel.netData.goods_id)];
		--- 检查玩家等级
		if Model.PlayerInfo.lv > localGData.usable_level - 1 then
			--- 可装备
			return 2;
		else 
			--- 未装备
			return 3;
		end
	else
		--- 检查合成状态
		if GetComposeState(goods_id, 1) == 0 then
			--- 无装备
			return 0;
		else
			--- 可合成
			return 1;
		end
	end

	return 0;
end

--- 显示当前装备栏的信息, 同时记录当前英雄的装备栏状态信息
function teamWeapon:setWeaponShow(wIndex, hData)
	--- 若英雄当前位置有装备(则 > 0)
	local curGood = hData.netData.player_hero_equip[wIndex].id;
	local localHData = Model.units[tostring(hData.netData.system_hero_id)];
	--- 玩家等级
	local colorlv = hData.netData.player_hero_color;
	--- view 初始化
	local weaponView = self.mHeroViews.weapons[wIndex];
	weaponView.icon.gameObject:SetActive(false);
	weaponView.stateIcon.gameObject:SetActive(true);
	weaponView.lable.gameObject:SetActive(true);
	--- 获得当前装备的ID和数量
	local wData = {};
	wData.goods_id = localHData.equip[colorlv][2][wIndex];
	local goodModel = localPack:getGoodDataById(wData.goods_id);
	wData.goods_num = 0;
	if goodModel then wData.goods_num = goodModel.netData.goods_num end
	if curGood > 0 then
		---- view显示刷新
		local localGData = Model.itemData[tostring(wData.goods_id)];
		weaponView.icon.gameObject:SetActive(true);
		weaponView.icon.spriteName = localGData.icon;
		weaponView.stateIcon.gameObject:SetActive(false);
		weaponView.lable.gameObject:SetActive(false);
		---- 记录已装备
		wData.state = -1;
		table.insert(self.weaponStates, wData);
	else
		--- 获得没有装备的状态
		local state = self:checkWeaponState(wData.goods_id);
		wData.state = state;
		table.insert(self.weaponStates, wData);
		SetHeroWeaponShow(weaponView.stateIcon, weaponView.lable, state);
	end
end

--- 显示英雄当前的状态
function teamWeapon:updateHeroPanel()
	local strIndex = localTeam.hUpTable[self.selIndex];
    local hData = localTeam.models[strIndex]; 
	if hData == nil then return end
	local localHData = Model.units[tostring(hData.netData.system_hero_id)];
	self.mHeroViews.name.text = getValue(localHData.name);
	self.mHeroViews.lv.text = "Lv:" .. tostring(hData.netData.player_hero_lv);
	local nextExp = hData.netData.player_hero_next_exp;
	if nextExp == 0 then nextExp = 99999 end
	self.mHeroViews.exp.value = 1.0 * hData.netData.player_hero_exp/nextExp;
	self.mHeroViews.expLable.text = tostring(hData.netData.player_hero_exp) .. "/" .. nextExp;
	---- 装备栏
	self.weaponStates = {};
	for wIndex = 1, #self.mHeroViews.weapons do
		self:setWeaponShow(wIndex, hData);
	end
end

--- 显示英雄当前的信息
function teamWeapon:updateInfoPanel()
	local strIndex = localTeam.hUpTable[self.selIndex];
    local hData = localTeam.models[strIndex]; 
	if hData == nil then return end
	local localHData = Model.units[tostring(hData.netData.system_hero_id)];
	--- 星级/战力
	SetHeroStarLv(self.mHeroInfo.starLv, tonumber(localHData.star));
	SetHeroNormalInfo(self.mHeroInfo.power, hData.power);
	--- hp/防御/攻击/速度
	SetHeroNormalInfo(self.mHeroInfo.hp, hData.netData.player_hero_attribute.maxHp);
	local text = string.format("%.2f", hData.netData.player_hero_attribute.defend);
	SetHeroNormalInfo(self.mHeroInfo.defence, text);
	text = string.format("%.2f", hData.netData.player_hero_attribute.damage);
	SetHeroNormalInfo(self.mHeroInfo.attack, text);
	text = string.format("%.2f", hData.netData.player_hero_attribute.speed);
	SetHeroNormalInfo(self.mHeroInfo.speed, text);
end

--- 当收到新消息后， 根据当前的状态更新显示
function teamWeapon:updateViewsByState()
	if self.panelState == PanelStates["normal"] then
		---- 基本的初始化
		self:setDefaultSelIndex();
		self:updateHeadPanel();
	  	self:updateHeroPanel();
	  	self:updateInfoPanel();
	  	self.panels[4]:SetActive(false);
	elseif self.panelState == PanelStates["heroTab"] then
		self:updateHeadPanel();
	  	self:updateHeroPanel();
	  	self:updateInfoPanel();
	  	self.panels[4]:SetActive(false);
	elseif self.panelState == PanelStates["wear"] then
		--- 穿戴装备
		--- 启动属性变化的UI动画 ---> 这块需要放到英雄数据刷新部分
		--- 关联界面刷新, 关闭弹出界面
		self:updateHeroPanel();
	  	self:updateInfoPanel();
	  	self.panels[4]:SetActive(false);
	elseif self.panelState == PanelStates["compose"] then
		--- 更新弹出界面部分
		local len = #self.popStates;
		if len > 1 then 
			table.remove(self.popStates, #self.popStates);
		end 
		self:updateSubPopPanel(self.popStates[#self.popStates], false);
		--- 根据当前的状态更新主弹出页面, 并关闭碰撞块
		if len == 1 then self:setMainPopBtn(2, false);
		else self:setMainPopBtn(2, true, "[505050]") end
		--- 更新weaponData
		self:updateHeroPanel();
	end
end

---- 英雄列表更新消息(副)
function teamWeapon.getHeroDatas(netData)
	--- 避免接收消息后刷新队伍界面
	if localTeam.isShow then return end
    -------------- data handle
  	localTeam.getHeroDatas(netData);
 	---------------- view handle
 	if teamWeapon.isShow then teamWeapon:updateViewsByState() end
end

--- 获得背包物品变化消息(副)
function teamWeapon.getGoodsChange(netData)
	--- 避免接收消息后刷新商品界面
	if localPack.isShow then return end
	-------------- data handle
	localPack.getGoodsChange(netData);
	-------------- view handle
	if teamWeapon.isShow then teamWeapon:updateViewsByState() end
end

-------------------- show/hide
function teamWeapon:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end
end

function teamWeapon:hideAll()
	self:removeFromState();
	self.isShow = false;
end

----------------------------------- system call
-- 资源加载完成时候调用方法
function teamWeapon:onAssetsLoad(items)
  local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
  if(referScript == nil)  then print("erro config"); end
  
  -- panel
  for i=0, referScript.refers.Count - 1 do
    table.insert(self.panels, referScript.refers[i]);
  end

  --- 标题头 "装备穿戴"
  -- referScript.monos[1].text = getValue("");

  ---- 初始化每个panel界面
  self:InitMainPan();
end

-- 第一次注册的时候调用
function teamWeapon:initialize()
	self:setPanelState("normal");
	--- 注册接收英雄列表更新消息
  	Proxy:binding(NetAPIList.recv_player_hero_change, self.getHeroDatas);
  	--- 注册接收道具更新消息
  	Proxy:binding(NetAPIList.recv_player_bag_change_goods, self.getGoodsChange);
end

--- 每次显示都会调用
function teamWeapon:onShowed( ... )
	if localTeam and localTeam.isShow then
		localTeam:hideAll();
	end
	--- 界面刷新
	self:updateViewsByState();
end

--- 根据当前的装备位状态设置主弹出框的按钮显示
--- 当flag为true的时候， 关闭碰撞块
function teamWeapon:setMainPopBtn(state, flag, color)
	local function getText(color, text)
		if color then return GetColorString(color, text);
		else return text end
	end

	local btn = self.mPopView.wState.transform.parent.gameObject;
	--- 碰撞
	local collider = LuaHelper.GetComponent(btn, "BoxCollider");
	if flag then collider.enabled = false;
	else collider.enabled = true end


	if state == nil then return end
	-- 确定[已装备]
	if state == -1 then
		self.mPopView.wState.text = getText(color, "确定");
	--- 装备[可装备2/未装备3]
	elseif state == 2 or state == 3 then
		self.mPopView.wState.text = getText(color, "装备");
	else
	--- 合成公式[可合成1/无装备 0]
		self.mPopView.wState.text = getText(color, "合成公式");
	end
end

--- 根据点击的装备栏 初始化弹出表
function teamWeapon:showPopPanel(weaponData)
	self.panels[4]:SetActive(true);
	--- 刷新主面板显示
	local localGData = Model.itemData[tostring(weaponData.goods_id)];
	self.mPopView.obj:SetActive(true);
	--- 装备图标/名字/..数量../信息描述/等级限制
	self.mPopView.wIcon.spriteName = localGData.icon;
	self.mPopView.wName.text = getValue(localGData.name);
	self.mPopView.wNum.text = weaponData.goods_num;
	self.mPopView.attribute.text = getValue(localGData.attributeDesc);
	self.mPopView.wInfo.text = getValue(localGData.Desc2);
	self.mPopView.wLvInfo.text = "等级限制  " .. localGData.usable_level .. "  级";
	self:setMainPopBtn(weaponData.state);
	--- 隐藏子面板
	self.mPopSubView.obj:SetActive(false);
end

--- 处理合成子界面的按钮栏的显示和关闭
--- 参数2决定是打开当前索引， 还是关闭到当前索引
function teamWeapon:handlePopTitle(index, goods_id, isShow)
	if index < 1 or index > 4 then return end
	for count = 1, 4 do
		local itemData = self.mPopSubView.titles[count];
		--- 关闭当前索引的选中
		if count ~= index then itemData.select:SetActive(false) end
		--- 隐藏高于当前索引的title
		if count > index then itemData.obj:SetActive(false) end
	end

	if isShow then
		---- title显示动画
		local itemData = self.mPopSubView.titles[index];
		local localData = Model.itemData[tostring(goods_id)];
		--- 显示/图标改变/设置选中
		itemData.obj:SetActive(true);
		itemData.wIcon.spriteName = localData.icon;
		itemData.select:SetActive(true);
	else
		--- 无title显示动画
		local itemData = self.mPopSubView.titles[index];
		--- 选中更改
		itemData.select:SetActive(true);
	end

	--- 设置合成界面
	self:setComposeShow(goods_id); 
end

--- 设置合成界面的显示
function teamWeapon:setComposeShow(goods_id)
	--- 获得物品的本地数据
	local localGData = Model.itemData[tostring(goods_id)];
	--- 获得物品的合成数据， 没有则显示物品的掉落
	local localCData = Model.goodComp[tostring(goods_id)];
	--- 默认隐藏掉落界面
	self.mPopSubView.drops["obj"]:SetActive(false);

	if localCData == nil then
		--- 显示掉落的界面
		for i=1, #self.mPopSubView.subItemViews do
			local itemHandle = self.mPopSubView.subItemViews[i];
			if i ~= 5 then itemHandle.obj:SetActive(false);
			else itemHandle.obj:SetActive(true); end
		end
		--- drop view set
		self.mPopSubView.drops["obj"]:SetActive(true);
		self.mPopSubView.drops["wIcon"].spriteName = localGData.icon;
		self.mPopSubView.drops["wName"].text = getValue(localGData.name);
		--- 更新掉落的位置显示
		self.mPopSubView.drops["dropBtn0"].text = "掉落位置1";
		self.mPopSubView.drops["dropBtn1"].text = "掉落位置2";
		self.mPopSubView.drops["dropBtn2"].text = "掉落位置3";
		return;
	end

	--- 显示对应的合成界面
	local len = #localCData.goods;
	for i=1, #self.mPopSubView.subItemViews do
		local itemHandle = self.mPopSubView.subItemViews[i];
		if i ~= len then itemHandle.obj:SetActive(false);
		else itemHandle.obj:SetActive(true); end
	end
	--- view
	local itemHandle = self.mPopSubView.subItemViews[len];
	itemHandle.wIcon.spriteName = localGData.icon;
	itemHandle.wName.text = getValue(localGData.name);
	itemHandle.costLable.text = localCData.cost.gold;
	for i=1, #itemHandle.items do
		local subLocal = Model.itemData[tostring(localCData.goods[i])];
		itemHandle.items[i].wIcon.spriteName = subLocal.icon;
		local max = localCData.num[i];
		--- 检查数量
		local goodModel = localPack:getGoodDataById(localCData.goods[i]);
		local count = 0;
		if goodModel then count = goodModel.netData.goods_num end
		itemHandle.items[i].wNum.text = count .. "/" .. max;
	end
end

--- 检查当数据变化时， 更新子 弹出框
--- true 是增加， false是减少
function teamWeapon:updateSubPopPanel(goods_id, addSwitch)
	local len = #self.popStates;
	--- 关闭窗口
	if len == 0 then self.mPopSubView.obj:SetActive(false) end
	if len == 1 and addSwitch then
		---激活窗口 
		self.mPopSubView.obj:SetActive(true);
	end
	self:handlePopTitle(len, goods_id, addSwitch);
end

--- 检查是否可以升级
function teamWeapon:checkHeroWearAll()
	local len = 0;
	for i, v in ipairs(self.weaponStates) do
		len = len + 1;
		if v.state == nil or v.state ~= -1 then
			--- 没有穿上装备
			return false;
		end
	end
	--- 检查是否全部检查到
	if len < 6 then 
		return false;
	else 
		return true; 
	end
end

--- 点击升阶
function teamWeapon:handleHeroUp()
	local isOk = self:checkHeroWearAll();
	if isOk then
		local strIndex = localTeam.hUpTable[self.selIndex];
		local hData = localTeam.models[strIndex];
		if hData then
			print("heroid__ " .. hData.netData.player_hero_id);
			SendHero_equip_Allup(hData.netData.player_hero_id);
		end
	else
		showTips("装备没有穿戴完毕， 不能升级");
	end
end

--- 点击主弹出框的按钮响应
function teamWeapon:checkMainPopBtn(weaponData)
	--- 确定[已装备]
	if weaponData.state == -1 then
		self.panels[4]:SetActive(false);
	--- 装备[可装备]
	elseif weaponData.state == 2 then
		local strIndex = localTeam.hUpTable[self.selIndex];
		local hData = localTeam.models[strIndex];
		if hData then 
			self:setPanelState("wear");
			print(weaponData.goods_id .. "__" .. hData.netData.player_hero_id);
			SendPlayer_hero_equip_up(weaponData.goods_id, hData.netData.player_hero_id);
		end
	elseif weaponData.state == 3 then
	--- 装备[未装备]
		showTips("你的等级没有达到装备要求");
	else
	--- 合成公式[可合成1/无装备 0]
		self.popStates = {};
		table.insert(self.popStates, weaponData.goods_id);
		self:updateSubPopPanel(weaponData.goods_id, true);
		--- 同时更新按钮显示， 并关闭碰撞
		self:setMainPopBtn(2, true, "[505050]");
	end
end

--- 检查子合成item
function teamWeapon:checkSubItem(index)
	--- 获得合成列表的尾部商品的合成信息
	local goods_id = self.popStates[#self.popStates];
	local localCData = Model.goodComp[tostring(goods_id)];
	if localCData == nil or #self.popStates == 4 then return end
	--- 将下一级合成商品ID插入
	local newInset = tonumber(localCData.goods[index]);
	table.insert(self.popStates, newInset);
	self:updateSubPopPanel(newInset, true);
end

--- 返回到某子合成窗口
function teamWeapon:backSubItem(index)
	if index == #self.popStates then return end
	while #self.popStates > index do
		table.remove(self.popStates, #self.popStates);
	end
	local goods_id = self.popStates[index];
	self:updateSubPopPanel(goods_id, false);
end

function teamWeapon:popOnClick(obj)
	local cmd = obj.name;
	local tran = obj.transform.parent;

	--- 主弹出菜单的btn点击
	if cmd == "wearBtn" and tran and tran.name == "wear" then
		local wData = self.weaponStates[self.weaponSel];
		self:checkMainPopBtn(wData);
		return;
	end

	--- 关闭弹出窗口
	if cmd == "Mask" and tran and tran.name == "popPanel" then
		self.panels[4]:SetActive(false);
		return;
	end

	--- title 关闭
	if cmd == "itemBtn" and tran and string.sub(tran.name, 1, 7) == "itemSel" then
		local subIndex = tonumber(string.sub(tran.name, 8));
		self:backSubItem(subIndex);
		return;
	end

	--- 子物件
	if cmd == "itemBtn" and tran and string.sub(tran.name, 1, 7) == "subItem" then
		local subIndex = tonumber(string.sub(tran.name, 8));
		self:checkSubItem(subIndex);
		return;
	end

	---- 合成
	if cmd == "funBtn" and tran and string.sub(tran.name, 1, 10) == "itemHandle" then
		local goods_id = self.popStates[#self.popStates];
		--- 检查是否可以合成
		if GetComposeState(goods_id, 1) == 1 then
			--- 可
			self:setPanelState("compose");
			SendHero_equip_synthesis(goods_id);
		else
			--- 非
			showTips("要合成的材料不足");
		end
	end
end

--- 根据需要设置当前进入UI的状态, 传入字符串
function teamWeapon:setPanelState(state)
	self.panelState = PanelStates[state];
end

--- 点击对应的装备按钮
function teamWeapon:weaponOnClick(obj)
	local cmd =obj.name;
	local tran = obj.transform.parent;

	local preStr = string.sub(obj.name, 1, 6);
	if preStr == "weapon" and tran and tran.name == "weaponContain" then
		--- 获得位置
		self.weaponSel = tonumber(string.sub(obj.name, 7));
		local wData = self.weaponStates[self.weaponSel];
		if wData then self:showPopPanel(wData) end
	end
end

---- 这里是队伍的2级界面， 会屏蔽5个主功能键
function teamWeapon:onClick(obj,arg)
  local cmd =obj.name;
  local tran = obj.transform.parent;

  if cmd == "BtnWBack" and tran and tran.name == "ornament" then
  	-- 临时使用， 返回组队界面
  	self:hideAll();
  	if not localTeam.isShow then
  		localTeam:setPanelState("normal");
  		localTeam:showAll() 
  	end
  elseif string.sub(cmd, 1, 8) == "heroIcon" and tran and tran.name == "IconPanel" then
  	-- 切换当前英雄
  	local newSelIndex = tonumber(string.sub(obj.name, 9));
  	if newSelIndex == self.selIndex then return end
  	local strIndex = localTeam.hUpTable[newSelIndex];
    local hData = localTeam.models[strIndex];
    if hData then
    	--- 有英雄上阵
    	self.selIndex = newSelIndex;
    	self:setPanelState("heroTab");
    	self:updateViewsByState();
    else
    	--- 回到队伍界面
    	self:hideAll();
  		if not localTeam.isShow then
  			localTeam.selectId = newSelIndex;
  			localTeam:setPanelState("heroUp");
  			localTeam:showAll();
  		end
    end
  elseif cmd == "heroUpBtn" and tran and tran.name == "heroPanel" then
  	self:handleHeroUp();
  end

  self:weaponOnClick(obj);
  self:popOnClick(obj);
end

