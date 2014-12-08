local teamSkill = LuaItemManager:getItemObject("teamSkill")
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
local Color = UnityEngine.Color
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
teamSkill.assets=
{
   Asset("TSkillUI.u3d", {"Config"}),
}
-- 检查界面是否打开
teamSkill.isShow = false;
-- panel
teamSkill.panels = {};
-- 当前选中的英雄的位置id
teamSkill.selIndex = 1;
-- 当前点击的技能栏位置
teamSkill.skillSel = -1;
--- 当前界面状态
teamSkill.panelState = 1;
--- 技能点
teamSkill.sPoint = 0;
--- 技能点冷却时间
teamSkill.pTimeCold = -1;
--- 倒计时开关
teamSkill.coldSwitch = false;
---------------------------------------------------------------
------------------private-----------------
local MTeamLen = 5;
local MaxPoint = 10;
-- 记录当前界面操作的状态， 分别是 一般/点击英雄切换/技能升级/经验背包
local PanelStates =
{
	normal = 1,
	heroTab = 2,
	skillUp = 3,
    expBag = 4,
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

--- 发送英雄合成的消息 2287
local function Sendplayer_skill_up(player_hero_id, skill_id)
	local cont = NetMsgHelper:makesend_player_hero_skill_up(player_hero_id,skill_id);
	Proxy:send(NetAPIList.player_hero_skill_up,cont);
end

--- 发送获得英雄信息的消息 2288, 传入0
local function Sendplayer_player_skill_release_up(a)
	local cont = NetMsgHelper:makesend_player_skill_release_up(a) 
	Proxy:send(NetAPIList.player_skill_release_up,cont);
end

---------------------------------------------------------------
------------------public------------------
function teamSkill:sendSkillGet()
	Sendplayer_player_skill_release_up(1);
end

--- 设置技能点显示
function teamSkill:setPointShow()
	if self.mHeroInfo == nil or self.mHeroInfo.timeCold == nil then return end
	if self.sPoint < 0 then self.sPoint = 0 end
	if self.pTimeCold < 0 or self.sPoint == MaxPoint then
		self.mHeroInfo.timeCold.text = self.sPoint;
	else
		local min = GetSpecifyStr(math.floor(self.pTimeCold/60), 2);
		local sec = GetSpecifyStr(math.floor(self.pTimeCold%60), 2);
		self.mHeroInfo.timeCold.text = self.sPoint .. " (" .. min ..":" .. sec .. ")" ;
	end
	---- 关闭倒计时
	if self.sPoint == MaxPoint then
		self.coldSwitch = false;
	elseif self.sPoint < MaxPoint then
		self:startPointCold();
	end
end

function teamSkill.pointColdDown()
	if not teamSkill.coldSwitch then return end
	teamSkill.pTimeCold = teamSkill.pTimeCold - 1;
	teamSkill:setPointShow();
	if teamSkill.pTimeCold < 1 then
		teamSkill.pTimeCold = 300;
		teamSkill:sendSkillGet();
	end
	delay(teamSkill.pointColdDown, 1, nil);
end


function teamSkill:startPointCold()
	if self.sPoint == MaxPoint then return end
	if not self.coldSwitch then
		self.coldSwitch = true;
		delay(teamSkill.pointColdDown, 1, nil);
	end
end

function teamSkill:stopPointCold()
	self.coldSwitch = false;
end

--- 队伍栏
function teamSkill:getMHeadPanel()
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

--- 英雄信息栏
function teamSkill:getMHeroPanel()
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
		-- 技能区
		self.mHeroViews.skills = {};
		local subRef = LuaHelper.GetComponent(referScript.refers[1], "ReferGameObjects");
		for i=0, subRef.refers.Count - 1 do
			local sRef = LuaHelper.GetComponent(subRef.refers[i], "ReferGameObjects");
			local skillView = {};
			skillView.icon = sRef.monos[0];
			skillView.sel = sRef.monos[1].gameObject;
			skillView.lock = sRef.monos[2].gameObject;
			table.insert(self.mHeroViews.skills, skillView);
		end
	end	
end

--- 技能信息栏/经验背包
function teamSkill:getMInfoPanel()
	local info = LuaHelper.GetComponent(self.panels[3],"ReferGameObjects");
	self.mHeroInfo = {};
    self.mExpBag = {};
    if info then
        ---------------------------------- 技能提示相关 -------------------------------
        self.mHeroInfo.root = info.refers[0];
		-- 技能等级/技能名字/技能信息/升级消费/技能点及冷却时间显示
		self.mHeroInfo.skillLv = info.monos[0];
		self.mHeroInfo.skillName = info.monos[1];
		self.mHeroInfo.skillInfo = info.monos[2];
		self.mHeroInfo.upCost = info.monos[3];
		self.mHeroInfo.timeCold = info.monos[4];
        --------------------------------- 道具背包相关 ---------------------------------
        self.mExpBag.root = info.refers[1];
        self.mExpBag.prop = {};
        local propRef = LuaHelper.GetComponent(self.mExpBag.root, "ReferGameObjects");
        --- 提示:经验背包
        -- propRef.monos[0].text = getValue("");
        for i=0, 4 do
            local view = {};
            view.root = propRef.refers[i];
            local subRef = LuaHelper.GetComponent(view.root, "ReferGameObjects");
            view.icon = subRef.monos[0];
            view.num = subRef.monos[1];
            view.info = subRef.monos[2];
            table.insert(self.mExpBag.prop, view);
        end
	end
end

function teamSkill:InitMainPan()
  -------- 主装备面板
  --- 头像栏
  self:getMHeadPanel();
  -- 英雄技能栏
  self:getMHeroPanel();
  -- 技能信息面板
  self:getMInfoPanel();
  --- 弹出面板
  -- self:getPopPanel();
end

--- 根据需要设置当前进入UI的状态, 传入字符串
function teamSkill:setPanelState(state)
	self.panelState = PanelStates[state];
end

function teamSkill:setDefault()
	--- 默认选中第一个技能
	self.skillSel = 1;
	--- 默认选中上阵的最左边英雄
	self.selIndex = 1;
	for i=1, MTeamLen do
		if localTeam.hUpTable[i] then
			self.selIndex = i;
			return;
		end
	end
end

--- 检查技能是否激活
function teamSkill:isActiveSkill(skillid, hData)
	if skillid == nil or hData == nil then return false end
	if hData.netData.player_hero_skill == nil then return false end
	for i, v in ipairs(hData.netData.player_hero_skill) do
		if v.id == skillid then return true end
	end

	return false;
end

--- 获得激活技能的数据
function teamSkill:getActiveSkillData(skillid, hData)
	if skillid == nil or hData == nil then return nil end
	if hData.netData.player_hero_skill == nil then return nil end
	for i, v in ipairs(hData.netData.player_hero_skill) do
		if v.id == skillid then return v end
	end

	return nil;
end

--- 显示当前技能栏的信息, 同时记录当前英雄的技能栏的状态信息
function teamSkill:setSkillShow(sIndex, hData)
	local skillView = self.mHeroViews.skills[sIndex];
	-- 默认初始化(隐藏选中和图标/技能默认显示为灰度图， 锁定)
	skillView.icon.color = Color(0, 0, 0);
	skillView.sel:SetActive(false);
	skillView.icon.gameObject:SetActive(false);
	skillView.lock:SetActive(true);
	local pt_hero_skill = hData.netData.hero_skill[sIndex];
	if pt_hero_skill then
		local skillData = Model.skills[tostring(pt_hero_skill.id)];
		if skillData then 
			--- 更新技能图标显示， 解除锁定
			skillView.icon.gameObject:SetActive(true);
			skillView.icon.spriteName = skillData.icon;
			skillView.lock:SetActive(false);
			--- 如果技能被激活， 显示
			local isActive = self:isActiveSkill(pt_hero_skill.id, hData);
			if isActive then
				skillView.icon.color = Color(1, 1, 1);
			end
		end
	end
	--- 显示选中
	if self.skillSel == sIndex then
		skillView.sel:SetActive(true);
	end
end

--- 更新头像 view
function teamSkill:updateHeadPanel()
    for i, subView in ipairs(self.mHeadViews) do
    	subView.icon.gameObject:SetActive(false);
    	subView.select.gameObject:SetActive(false);
    	local strIndex = localTeam.hUpTable[i];
    	local hData = localTeam.models[strIndex];
    	if hData then
    		--- 有英雄上阵
			local localHData = Model.units[tostring(hData.netData.system_hero_id)];
    		subView.icon.gameObject:SetActive(true);
	     	subView.icon.spriteName = localHData.icon;
	     	--- 选中位置
	       	if i == self.selIndex then
	       	   subView.select.gameObject:SetActive(true);
	       	end
       	end
   	end
end

--- 显示英雄当前的状态
function teamSkill:updateHeroPanel()
	local strIndex = localTeam.hUpTable[self.selIndex];
    local hData = localTeam.models[strIndex]; 
	if hData == nil then return end
	local localHData = Model.units[tostring(hData.netData.system_hero_id)];
	--- 名字/等级/经验/经验数字提示
	self.mHeroViews.name.text = getValue(localHData.name);
	self.mHeroViews.lv.text = "Lv:" .. tostring(hData.netData.player_hero_lv);
	local nextExp = hData.netData.player_hero_next_exp;
	if nextExp == 0 then nextExp = 99999 end
	self.mHeroViews.exp.value = 1.0 * hData.netData.player_hero_exp/nextExp;
	self.mHeroViews.expLable.text = tostring(hData.netData.player_hero_exp) .. "/" .. nextExp;
	---- 技能栏栏
	for sIndex = 1, #self.mHeroViews.skills do
		self:setSkillShow(sIndex, hData);
	end
end

--- 更新技能提示
function teamSkill:updateInfoPanel()
	local strIndex = localTeam.hUpTable[self.selIndex];
    local hData = localTeam.models[strIndex]; 
	---- normal set
	self.mHeroInfo.skillLv.text = "Lv.0";
	self.mHeroInfo.skillName.text = "none"
	self.mHeroInfo.skillInfo.text = "";
	self.mHeroInfo.upCost.text = 0;
	------------------
	if hData == nil or self.skillSel < 1 then return end
	local pt_hero_skill = hData.netData.hero_skill[self.skillSel];
	if pt_hero_skill == nil then return end
	local skillData = Model.skills[tostring(pt_hero_skill.id)];
	if skillData == nil then return end
	local upIndex = 900022 + self.skillSel - 1;
	local upData = Model.discreteData[tostring(upIndex)];
	if upData == nil or upData.data == nil then return end
	local costIndex = pt_hero_skill.lv + 1;
	if costIndex > 30 then costIndex = 30 end
	local activeSkill = self:getActiveSkillData(pt_hero_skill.id, hData);
	local showLv = 1;
	if activeSkill then showLv = activeSkill.lv; end;
	-- 技能等级/技能名字/技能信息/升级消费/技能点及冷却时间显示
	self.mHeroInfo.skillLv.text = "Lv." .. showLv;
	self.mHeroInfo.skillName.text = getValue(skillData.name);
	self.mHeroInfo.skillInfo.text = getValue(skillData.description);
	self.mHeroInfo.upCost.text = upData.data[costIndex];
end

--- 关闭经验背包后
function teamSkill.onExpBagHide()
    teamSkill.mHeroInfo.root:SetActive(true);
    teamSkill:setPanelState("normal");
    teamSkill:updateInfoPanel();
end

--- 更新经验背包的英雄ID
function teamSkill:updateHeroId()
    self.expBag.heroId = 0;
   	local strIndex = localTeam.hUpTable[self.selIndex];
    if strIndex == nil then return end
    local hData = localTeam.models[strIndex];
    if hData == nil then return end 
    self.expBag.heroId = hData.netData.player_hero_id;
end

--- 当收到新消息后， 根据当前的状态更新显示
function teamSkill:updateViewsByState()
	if self.panelState == PanelStates["normal"] then
		---- 基本的初始化
		self:setDefault();
		self:updateHeadPanel();
	  	self:updateHeroPanel();
	  	self:updateInfoPanel();
	  	-- self.panels[4]:SetActive(false);
	elseif self.panelState == PanelStates["heroTab"] then
		--- 切换选中英雄
		self.skillSel = 1;
		self:updateHeadPanel();
	  	self:updateHeroPanel();
	  	self:updateInfoPanel();
	  	-- self.panels[4]:SetActive(false);
	elseif self.panelState == PanelStates["skillUp"] then
		--- 技能升级
		self:updateHeroPanel();
		self:updateInfoPanel();
		self.panelState = PanelStates["normal"];
    elseif self.panelState == PanelStates["expBag"] then
        if self.expBag.isActive then
            self:updateHeroPanel();
            self.expBag:handleProp();
        else 
            --- 隐藏技能信息面板
            self.mHeroInfo.root:SetActive(false);
            ---- view 视图/绑定回调
            self.expBag:defaultInit(self.mExpBag, self.onExpBagHide);
            self:updateHeroId();
            --- 获得最新的数据/更新显示
            self.expBag:show();
            self.expBag:handleProp();
        end
	end

	self:setPointShow();
end

-------------------- show/hide
function teamSkill:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end
end

function teamSkill:hideAll()
	self:removeFromState();
	self.isShow = false;
    --- 隐藏对应的界面
    self.expBag:hide();
	--- reset
	self:setPanelState("normal");
	self.selIndex = 1;
	self.skillSel = -1;
	self.sPoint = 0;
	--- 技能点冷却时间
	teamSkill.pTimeCold = -1;
	--- 倒计时开关
	teamSkill.coldSwitch = false;
end
----------------------------------- system call
---- 根据英雄信息更新上阵列表的表(副)
function teamSkill.getHeroDatas(netData)
	--- 避免接收消息后刷新队伍界面
	if localTeam.isShow then return end
	-------------- data handle
	localTeam.getHeroDatas(netData);
	---------------- view handle
	if teamSkill.isShow then teamSkill:updateViewsByState() end
end

--- 技能点
function teamSkill.getSkillPData(netData)
	teamSkill.sPoint = netData.player_skill_points;
	if not teamSkill.isShow then return end
	teamSkill:setPointShow();
end

--- 冷却时间
function teamSkill.getSkillPCData(netData)
	teamSkill.pTimeCold = netData.time;
	teamSkill:startPointCold();
end

--- 获得背包物品变化消息
function teamSkill.getGoodsChange(netData)
	localPack.getGoodsChange(netData);
    -------- view handle
	if teamSkill.isShow then
        --- 经验背包显示刷新
        teamSkill:updateViewsByState();
    end
end

-- 资源加载完成时候调用方法
function teamSkill:onAssetsLoad(items)
	local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
	if(referScript == nil)  then print("erro config"); end
	
	-- panel, 这里只包含需要设置的title/upPanel/downPanel
	for i=0, referScript.refers.Count - 1 do
		table.insert(self.panels, referScript.refers[i]);
	end

	--- 文字提示: "技能升级"/消耗/金币/技能点/升级
	-- referScript.monos[0].text = getValue("");
	-- referScript.monos[1].text = getValue("");
	-- referScript.monos[2].text = getValue("");
	-- referScript.monos[3].text = getValue("");
	-- referScript.monos[4].text = getValue("");
	---- 初始化每个panel界面
	self:InitMainPan();
end

-- 第一次注册的时候调用
function teamSkill:initialize()
    --- 道具背包对象
    self.expBag = self:addComponent("expBag");
	self:setPanelState("normal");
	--- 注册接收英雄属性更新消息, 包括卡片数量更新
	Proxy:binding(NetAPIList.recv_player_hero_change, self.getHeroDatas);
	--- 注册接收玩家信息更新消息， 主要是检查玩家的技能点
	Proxy:binding(NetAPIList.recv_player_attribute1, self.getSkillPData);
	--- 注册接收玩家信息更新消息， 主要是检查玩家的技能点冷却
	Proxy:binding(NetAPIList.recv_player_hero_skill_time, self.getSkillPCData);
    --- 注册接收道具更新消息， 主要是处理经验背包使用反馈
    Proxy:binding(NetAPIList.recv_player_bag_change_goods, self.getGoodsChange);
end

--- 每次显示都会调用
function teamSkill:onShowed( ... )
	if localTeam and localTeam.isShow then
		localTeam:hideAll();
	end

	self:updateViewsByState();
end

function teamSkill:upClick()
	local strIndex = localTeam.hUpTable[self.selIndex];
    local hData = localTeam.models[strIndex]; 
	if hData == nil or self.skillSel < 1 then
		showTips("英雄数据异常");
		return;
	end
	local pt_hero_skill = hData.netData.hero_skill[self.skillSel];
	if pt_hero_skill == nil then
		showTips("技能数据异常");
		return;
	end
	local skillData = Model.skills[tostring(pt_hero_skill.id)];
	if skillData == nil then
		showTips("本地数据异常");
		return;
	end
	local upIndex = 900022 + self.skillSel - 1;
	local upData = Model.discreteData[tostring(upIndex)];
	if upData == nil or upData.data == nil then
		showTips("升级数据异常");
		return;
	end

	if self.sPoint < 1 then 
		showTips("技能点数不足!");
		return;
	end

	local costIndex = pt_hero_skill.lv + 1;
	if costIndex > 30 then 
		showTips("技能已升到满级");
		return;
	end

	local isActive = self:isActiveSkill(pt_hero_skill.id, hData);
    print(isActive);
	if not isActive then 
		showTips("还没有学会当前技能");
		return;
	end


	local activeSkill = self:getActiveSkillData(pt_hero_skill.id, hData);
	if activeSkill == nil or activeSkill.lv > hData.netData.player_hero_lv - 1 then
		showTips("技能不能超过英雄等级");
		return;
	end
	
	Sendplayer_skill_up(hData.netData.player_hero_id, pt_hero_skill.id);
end

--- 点击对应的技能按钮
function teamSkill:skillOnClick(obj)
	local cmd =obj.name;
	local tran = obj.transform.parent;

	local preStr = string.sub(obj.name, 1, 5);
	if preStr == "skill" and tran and tran.name == "skillContain" then
		local newSkill = tonumber(string.sub(obj.name, 6));
		if newSkill ~= self.skillSel then
			self.skillSel = newSkill;
			self:updateHeroPanel();
			self:updateInfoPanel();
		end
        ---------------------------------------------------
        -- 点击技能的时候关闭expBag
        if self.expBag.isActive then
            self.expBag:hide();
        end
	end
end

---- 这里是队伍的2级界面， 会屏蔽5个主功能键
function teamSkill:onClick(obj,arg)
	local cmd =obj.name;
	local tran = obj.transform.parent;

	if cmd == "BtnWBack" and tran and tran.name == "ornament" then
  		-- 临时使用， 返回组队界面
	  	self:hideAll();
	  	if not localTeam.isShow then
	  		localTeam:setPanelState("normal");
	  		localTeam:showAll();
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
            self:updateHeroId();
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
	elseif cmd == "btnUp" and tran and tran.name == "skillInfo" then
		--- 技能升级
        self:upClick();
    elseif cmd == "expBtn" and tran and tran.name == "slider" then
        if self.panelState ~= PanelStates["expBag"] then
            self.panelState = PanelStates["expBag"];
            self:updateViewsByState();
        end
  	end

  	self:skillOnClick(obj);
    self.expBag:OnClick(obj, arg);
end