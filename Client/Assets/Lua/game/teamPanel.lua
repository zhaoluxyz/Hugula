local teamPanel = LuaItemManager:getItemObject("teamPanel")
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local Vector3 = UnityEngine.Vector3
local Proxy=Proxy
local Model = Model
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local common_fun = common_fun
local showTips = showTips
--==================================================================================================
teamPanel.assets=
{
   Asset("TeamUI.u3d", {"Config"}),
}
-- 检查界面是否打开， 0/1/2 分别是隐藏/启动/显示
teamPanel.isShow = 0;
-- 需要操作的panel
teamPanel.panels = {};
--- 队伍面板(view)
teamPanel.teams = {};
--- 选中英雄的位置ID
teamPanel.selectId = 0;
--------------------------
--- 记录正在上阵的英雄原始表索引(data index)
teamPanel.hUpTable = {};
--- 申请www的table
teamPanel.reqs = {};
--------------------------------------------------------------------------------------------------
-----------------------------------  local
local MTeamLen = 5;

--- 获得星级对应的加成信息
local function GetStarAddition(starData)
  for i, v in pairs(Model.teamBuff) do
    local strIndex = tostring(v.star);
      if v.star > 0 and starData[strIndex] and starData[strIndex] == v.number then
      return v;      
    end
  end

  return nil;
end

--- 获得种族对应的加成信息
local function GetRaceAddition(raceData)
  for i, v in pairs(Model.teamBuff) do
    local strIndex = tostring(v.race);
    if v.race > 0 and raceData[strIndex] and raceData[strIndex] == v.number then
      return v;
    end
  end

  return nil;
end

--- 发送获取英雄列表的消息 2218 
local function SendPlayer_hero_list(profession_category,page,size)
  local cont = NetMsgHelper:makesend_player_hero_list(profession_category, page, size);
  Proxy:send(NetAPIList.player_hero_list,cont);
end
--------------------------------------------------------------------------------------------------
-----------------------------------  proxy callback
teamPanel.proxy = {};
function teamPanel:msgBinding(api,fun)
	if self.proxy[api.Code] == nil then 
        self.proxy[api.Code] = {};
    end
	local msgTable = self.proxy[api.Code];
	table.insert(msgTable,fun)
end

function teamPanel:msgUnbinding(api,fun)
	local msgTable = self.proxy[api.Code];
	if msgTable then
		local len= #msgTable;
        local funitem;
        local reindex;
		for i = 1, len do
            funitem = msgTable[i];
            if funitem == fun then 
                reindex = i; 
            end		
        end
		if reindex then table.remove(msgTable,reindex) end
	end
end

function teamPanel:callMsgHandle(api, data)
	local funTable = self.proxy[api.Code];
	if funTable then
		local len = #funTable; 
        local funitem;		
		for i=1,len do	
			funitem = funTable[i];	
			if funitem then  
				funitem(data);
			end		
		end
	end
end
--------------------------------------------------------------------------------------------------
---------------------------------------- www load
---- 重置本地表/半身像
function teamPanel:resetReq()
  self.reqs = {};
  if #self.teams < MTeamLen then return end
  for i = 1, MTeamLen do
    local uiTexture = LuaHelper.GetComponent(self.teams[i].root, "UITexture");
    uiTexture.mainTexture = nil;
  end
end

---- load 的回调
function teamPanel.onModelComplete(req)
  local key = req.key
  if req.data then
    local mainAsset = req.data.assetBundle.mainAsset
    ---------- texture2d 
    req.head.mainTexture = mainAsset;
    disposeWWW(req.data);
  end
end 

---- 添加到load 请求表
function teamPanel:addToList(key, uiTexture)
  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      self.reqs[key]={CUtils.GetAssetFullPath(key..".u3d"), self.onModelComplete, nil, uiTexture}
  end
end

---- 开始加载
function teamPanel:loadRes( ... )
  local switch = false;
  for i, v in pairs(self.reqs) do
    switch = true;
    break;
  end
  if not switch then return end

  print(" begin loadRes in teams ")
  Loader:getResource(self.reqs,false)
end
--------------------------------------------------------------------------------------------------
-----------------------------------  normal
---- 获得队伍层的view信息
function teamPanel:getMTeamPanel()
    self.teams = {};
    local referScript = LuaHelper.GetComponent(self.panels[1], "ReferGameObjects");
    if referScript == nil then return end
    for i=0, referScript.refers.Count - 1 do
        --- 英雄全身像 obj/英雄名字 lable/英雄等级 lable/英雄种族 sprite/英雄星级 lable
        local views = {};
        views.root = referScript.refers[i];
        local subRef = LuaHelper.GetComponent(views.root, "ReferGameObjects");
        views.name = subRef.monos[0];
        views.lv = subRef.monos[1];
        views.race = subRef.monos[2];
        views.starLv = subRef.monos[3];
        table.insert(self.teams, views);
    end
end

--- 获得信息层的view信息(包含队伍加成， 队伍战力)
function teamPanel:getMInfoPanel()
    self.infos = {};
    local referScript = LuaHelper.GetComponent(self.panels[2], "ReferGameObjects");
    if referScript == nil then return end
    ---- 星级加成 lable/种族加成 lable/队伍总战力 lable
    self.infos.star = referScript.monos[0];
    self.infos.race = referScript.monos[1];
    self.infos.powers = referScript.monos[2];
end

--- 获得主要的队伍功能views(针对技能，装备这些具体的功能， 便于处理解锁和加锁)
function teamPanel:getMControlPanel()
    self.controls = {};
    local referScript = LuaHelper.GetComponent(self.panels[3], "ReferGameObjects");
    if referScript == nil then return end
    --- 依次分别为 技能/装备/神兽/强化/合成
    for i=0, referScript.refers.Count - 1 do
        --- 具体按钮 obj/底板 sprite/锁 sprite anim
        local views = {};
        views.root = referScript.refers[i];
        local subRef = LuaHelper.GetComponent(views.root, "ReferGameObjects");
        views.icon = subRef.monos[0];
        views.lock = subRef.monos[1];
        table.insert(self.controls, views);
    end
end

function teamPanel:initMainPan()
  --- 队伍
  self:getMTeamPanel();
  --- 信息
  self:getMInfoPanel();
  --- 功能按钮
  self:getMControlPanel();
end

--- 更新队伍英雄显示
function teamPanel:updateTeam()
  if #self.teams < MTeamLen then return end
  for i=1, MTeamLen do
    local heroView = self.teams[i];
    heroView.root:SetActive(false);
    ------------------------------
    local strIndex = self.hUpTable[i];
    if strIndex then
        local heroModel = self.models[strIndex];
        if heroModel then
            ----- 具体设置
            local localData = Model.units[tostring(heroModel.netData.system_hero_id)];
            local uiTexture = LuaHelper.GetComponent(heroView.root,"UITexture");
            heroView.root:SetActive(true);
            --- 英雄全身像 obj/英雄名字 lable/英雄等级 lable/英雄种族 sprite/英雄星级 lable
            self:addToList(localData.photo, uiTexture);
            heroView.name.text = getValue(localData.name);
            heroView.lv.text = "Lv:" .. tostring(heroModel.netData.player_hero_lv);
            heroView.race.spriteName = common_fun.getRaceName(localData.category1);
            heroView.starLv.text = localData.star;
        end
    end
  end
  ---- 启动加载
  self:loadRes();
end

function teamPanel:updateInfos()
    ---- 队伍的总战力
    local total = 0;
    local buff = self:getTeamBuffer();
    for i, v in pairs(self.hUpTable) do
        local heroModel = self.models[v];
        local powerdata = common_fun.getFinalHeroData(heroModel.netData, buff);
        total = total + common_fun.getFightPower(powerdata);
    end
    self.infos.powers.text = total;
    
    ---- 加成
    self.infos.star.text = "[646464]没有增益";
    self.infos.race.text = "[646464]没有增益";
    if buff.starBuff then self.infos.star.text = getValue(buff.starBuff.desc) end
    if buff.raceBuff then self.infos.race.text = getValue(buff.raceBuff.desc) end
end

function teamPanel:updateControl()

end

--- 根据队伍数据刷新面板显示
function teamPanel:updatePanel()
    ----------------view handle-----------------
    --- 清理已有的半身像
    self:resetReq();
    --- 刷新上阵英雄
    self:updateTeam();
    --- 刷新英雄加成信息，战力信息
    self:updateInfos();
    --- 刷新功能按钮
    self:updateControl();
end

--- 当收到新消息后， 根据当前的状态更新显示
--- 目前队伍界面的主入口只有一种状态
function teamPanel:updateViewsByState()
    self:updatePanel();
end

--- 更新上阵下阵信息
function teamPanel:updateHeroUp(newTable)
-------------------------------------
    for i=1, MTeamLen do
        local newStrIndex = newTable[i];
        local oldStrIndex = self.hUpTable[i];
        if oldStrIndex == nil and newStrIndex then
            --- 0->上阵
            self.hUpTable[i] = newStrIndex;
        elseif oldStrIndex and newStrIndex == nil then
            --- 上阵-> 0
            local oldHData = self.models[oldStrIndex];
            if oldHData then oldHData.pos = 0 end
            self.hUpTable[i] = nil;
        elseif oldStrIndex and newStrIndex then
            if oldStrIndex ~= newStrIndex then
                local oldHData = self.models[oldStrIndex];
                if oldHData then oldHData.pos = 0 end
            end
            self.hUpTable[i] = newStrIndex;
        end
    end
end

---- 请求所有的英雄数据
function teamPanel:requestHeroData()
    SendPlayer_hero_list(0, 1, 1000);
end

--- 获得当前上阵的英雄数量
function teamPanel:getHeroNumInTeam()
    local count = 0;
    for i, v in pairs(self.hUpTable) do
        count = count + 1;
    end
    
    return count;
end

--- 检查当前英雄是否可以上阵
function teamPanel:checkTeamIn(player_hero_id)
  local hData;
  local checkData = self.models[tostring(player_hero_id)];
  --- 检查当前位置的英雄， 是相同可以替换
  local strIndex = self.hUpTable[self.selectId];
  if strIndex then
    hData = self.models[strIndex];
    if checkData.netData.system_hero_id == hData.netData.system_hero_id then
      return true;
    end
  end
  --- 如果不是同等替换， 检查所有的上阵英雄
  for i, v in pairs(self.hUpTable) do
    hData = self.models[v];
    if checkData.netData.system_hero_id == hData.netData.system_hero_id then
      return false;
    end
  end

  return true;
end

--- 获得当前队伍的加成信息[作用到每个英雄上]
function teamPanel:getTeamBuffer()
  local buffer = 
  {
    maxHp = 1;
    defence = 1;
    magicDefense = 1;
    damage = 1;
    magicDamage = 1;
    critValue = 1;
    dodgeValue= 1;
  };

  ---- 统计星级, 种族
  local starData = {};
  local raceData = {};
  for i, v in pairs(self.hUpTable) do
    local strIndex = tostring(self.models[v].netData.system_hero_id);
    local localData = Model.units[strIndex];
    ---- 星级
    strIndex = tostring(localData.star);
    if starData[strIndex] == nil then starData[strIndex] = 0 end
    starData[strIndex] = starData[strIndex] + 1;
    ---- 种族
    strIndex = tostring(localData.category1);
    if raceData[strIndex] == nil then raceData[strIndex] = 0 end
    raceData[strIndex] = raceData[strIndex] + 1;
  end
  --- 从本地表获得加成
  local starBuff = GetStarAddition(starData);
  if starBuff then
    for i, v in ipairs(starBuff.attribute_key) do
      if buffer[v] then
        buffer[v] = buffer[v] + starBuff.attribute_value[i]*1.0/100;
      end
    end
  end
  local raceBuff = GetRaceAddition(raceData);
  if raceBuff then
    for i, v in ipairs(raceBuff.attribute_key) do
      if buffer[v] then
        buffer[v] = buffer[v] + raceBuff.attribute_value[i]*1.0/100;
      end
    end
  end
  --------------------------
  buffer.starBuff = starBuff;
  buffer.raceBuff = raceBuff;
  return buffer;
end

--------------------------------------------------------------------------------------------------
-----------------------------------   show/hide
--- 重置
function teamPanel:reset()
    self:resetReq();
end

--- 准备显示当前界面
function teamPanel:showAll()
	if self.isShow > 0 then return end
	self.isShow = 1;
	self:addToState();
end

--- 隐藏当前界面
function teamPanel:hideAll()
    if self.isShow == 0 then return end
	self:removeFromState();
	self.isShow = 0;
    self:reset();
end
--------------------------------------------------------------------------------------------------
----------------------------------- data event callBack
---- 获得上阵英雄数据
function teamPanel.getTeamDatas(netData)
  -------------- data handle
  --- 生成临时的新上阵表
  local teamUp = {};
  --- 生成服务器原始表
  if teamPanel.models == nil then teamPanel.models = {} end
  for i, v in ipairs(netData.team) do
    local strIndex = tostring(v.player_hero_id);
    local pos = 0;
    if v.pos then pos = v.pos end
    local newData = {};
    --- 服务器数据/战力/上阵位置
    newData.netData = v;
    newData.power = common_fun.getFightPower( common_fun.getFinalHeroData(v) );
    newData.pos = pos;
    teamPanel.models[strIndex] = newData;
    -------------------
    if pos > 0 then teamUp[pos] = strIndex end
  end
  --- 处理上阵列表信息
  teamPanel:updateHeroUp(teamUp);
  ---------------- event handle
  teamPanel:callMsgHandle(NetAPIList.player_team, netData);
  ---------------- view handle
  if teamPanel.isShow == 2 then teamPanel:updateViewsByState() end
end

---- 获得所有的英雄数据和英雄数据更新消息
function teamPanel.getHeroDatas(netData)
  -------------- data handle
  --- 生成服务器原始表
  if teamPanel.models == nil then teamPanel.models = {} end
  for i, v in ipairs(netData.heros) do
    local strIndex = tostring(v.player_hero_id);
    local pos = 0;
    if v.pos then pos = v.pos end
    --- 检查英雄数据
    if v.player_hero_num > 0 then
        local newData = {};
        --- 服务器数据/战力/上阵位置
        newData.netData = v;
        newData.power = common_fun.getFightPower( common_fun.getFinalHeroData(v) );
        newData.pos = pos;
        teamPanel.models[strIndex] = newData;
    else
        --- 清空
        teamPanel.models[strIndex] = nil;
    end
  end
  ---------------- event handle
  teamPanel:callMsgHandle(NetAPIList.player_hero, netData);
  teamPanel:callMsgHandle(NetAPIList.recv_player_hero_change, netData);
  ---------------- view handle
  if teamPanel.isShow == 2 then teamPanel:updateViewsByState() end
end

---- 技能点信息
function teamPanel.getSkillPData(netData)
    ---------------- event handle
    teamPanel:callMsgHandle(NetAPIList.recv_player_attribute1, netData);
end

---- 技能冷却
function teamPanel.getSkillPCData(netData)
	---------------- event handle
    teamPanel:callMsgHandle(NetAPIList.recv_player_hero_skill_time, netData);
end

---- 道具更新
function teamPanel.getGoodsChange(netData)
	---------------- event handle
    teamPanel:callMsgHandle(NetAPIList.recv_player_bag_change_goods, netData);
end
--------------------------------------------------------------------------------------------------
----------------------------------- event callBack
---- 绑定消息回调
function teamPanel.msgCallBackBind()
  --- 注册接收所有上阵英雄消息
  Proxy:binding(NetAPIList.player_team, teamPanel.getTeamDatas);
  --- 注册接收所有英雄消息
  Proxy:binding(NetAPIList.player_hero, teamPanel.getHeroDatas);
  --- 注册接收英雄列表更新消息
  Proxy:binding(NetAPIList.recv_player_hero_change, teamPanel.getHeroDatas);
  --- 注册接收(技能点)玩家数据更新
  Proxy:binding(NetAPIList.recv_player_attribute1, teamPanel.getSkillPData);
  --- 注册接收(技能冷却)
  Proxy:binding(NetAPIList.recv_player_hero_skill_time, teamPanel.getSkillPCData);
  --- 注册接收道具更新消息， 这里修改为注册到道具背包里面
  Proxy:binding(NetAPIList.recv_player_bag_change_goods, teamPanel.getGoodsChange);
end

-- 第一次注册的时候调用
function teamPanel:initialize()

end

-- 资源加载完成时候调用方法
function teamPanel:onAssetsLoad(items)
    referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
    if(referScript == nil)  then print("erro config"); end
    
    -- get panel
    for i=0, referScript.refers.Count - 1 do
        table.insert(self.panels, referScript.refers[i]);
    end
    
    --- 提示 Lable 显示
    --- 玩家队伍/队伍增益/队伍战力/技能/装备/神兽/强化/合成
----    referScript.monos[0].text = getValue("");
----    referScript.monos[1].text = getValue("");
----    referScript.monos[2].text = getValue("");
----    referScript.monos[3].text = getValue("");
----    referScript.monos[4].text = getValue("");
----    referScript.monos[5].text = getValue("");
----    referScript.monos[6].text = getValue("");
----    referScript.monos[7].text = getValue("");
    
    self:initMainPan();
end

--- 显示的时候调用
function teamPanel:onShowed( ... )
    if self.isShow ~= 2 then 
        self.isShow = 2;
        self:updateViewsByState();
    end
end

function teamPanel:enterSkill(heroCount)
    if heroCount < 1 then
        showTips("没有英雄在队伍中!");
    else
        local teamSkill = LuaItemManager:getItemObject("teamSkill");
        teamSkill:sendSkillGet();
        teamSkill:setPanelState("normal");
        teamSkill:showAll();
    end
end

function teamPanel:enterWeapon(heroCount)
    if heroCount < 1 then
        showTips("没有英雄在队伍中!");
    else
        local teamWeapon = LuaItemManager:getItemObject("teamWeapon");
        teamWeapon:setPanelState("normal");
        teamWeapon:showAll();
    end
end

function teamPanel:enterMon()
    local mmonsterPanel = LuaItemManager:getItemObject("mmonsterPanel")
    mmonsterPanel:showAll();
end

function teamPanel:enterStrenth()
    local teamStrenth = LuaItemManager:getItemObject("teamStrenth");
    teamStrenth:setPanelState("normal");
    teamStrenth:showAll();
end

function teamPanel:enterCompose()
   local teamCompose = LuaItemManager:getItemObject("teamCompose");
   teamCompose:setPanelState("normal");
   teamCompose:showAll();
end

function teamPanel:enterTeam(obj, arg)
    if self.isShow ~= 2 then return end
    local cmd = obj.name;
    local tran = obj.transform.parent;    
    local strTitle = string.sub(obj.name, 1, 6);
    local isOk = false;
    
    if strTitle == "person" and tran then
        isOk = true;
    elseif strTitle == "select" and tran and tran.name == "topTeam" then
        isOk = true;
    end
    
    if isOk then   
        self.selectId = tonumber(string.sub(obj.name, -1));
        local teamMake = LuaItemManager:getItemObject("teamMake");
        teamMake:setPanelState("normal");
        teamMake:showAll();
    end
end

function teamPanel:onClick(obj,arg)
    if self.isShow ~= 2 then return end
   	local cmd = obj.name;
	local tran = obj.transform.parent;

    if cmd == "BtnTopClose" and tran and tran.name == "ornament" then
        --- 关闭界面
        self:hideAll();
    elseif tran and tran.name == "controlPanel" then
        --- 二级功能菜单
        local heroCount = self:getHeroNumInTeam();
        if cmd == "BtnSkill" then self:enterSkill(heroCount);
        elseif cmd == "BtnWeapon" then self:enterWeapon(heroCount);
        elseif cmd == "BtnMon" then self:enterMon();
        elseif cmd == "BtnPower" then self:enterStrenth();
        elseif cmd == "BtnComp" then self:enterCompose() end
    elseif cmd == "BtnCheck" and tran and tran.name == "infoPanel" then
        --- 增益面板
    end

    --- 英雄上阵
    self:enterTeam(obj, arg);
end


