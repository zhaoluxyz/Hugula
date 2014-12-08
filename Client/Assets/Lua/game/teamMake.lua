local teamMake = LuaItemManager:getItemObject("teamMake")
local localTeam = LuaItemManager:getItemObject("teamPanel")
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
teamMake.assets=
{
   Asset("teamMakeUI.u3d", {"Config"}),
}
-- 检查界面是否打开， 0/1/2 分别是隐藏/启动/显示
teamMake.isShow = 0;
-- 需要操作的panel
teamMake.panels = {};
-- 英雄面板 view(所有hero)
teamMake.blocks = {};
-- 当前选中英雄索引(view)
teamMake.selHero = -1;
--- 当前界面状态
teamMake.panelState = 1;
--- 当前选中的的hero Btn 名字
teamMake.heroBtnName = "BtnTopAll";
--- 上级返回界面表示, 默认返回队伍主界面
teamMake.backPanelName = "teamPanel";
--------------------------------------------------------------------------------------------------
-----------------------------------  local
local MTeamLen = 5;

-- 记录当前界面操作的状态， 分别是 一般/上阵
local PanelStates =
{
    normal = 1,
    heroUp = 2,
    heroDown = 3,
    heroSell = 4,
};

--- 获得实际上需要的数量, 传入需要检查的值， 标准值， 变化值
local function GetNewCountInfact(check, normal, add)
    --- 不够标准数量补足标准数量
    if check < normal then return normal end
    --- 按当前需要添加
    local checkEnd = check - normal;
    --- 刚好是add 也需要扣除
    while checkEnd > add - 1 do
        checkEnd = checkEnd - add;
    end
    local reValue = check;
    if checkEnd > 0 then
        reValue = reValue + add - checkEnd;
    end
    return reValue;
end

--- 根据当前view数量, 获得需要额外显示的板子数
local function GetNeedAddBlock(curLen)
    if curLen < 20 then return 20-curLen end
    local newAdd = curLen - 20;
    --- 刚好是5也需要扣除
    while newAdd > 4 do
        newAdd = newAdd - 5;
    end
    if newAdd == 0 then return 0;
    else return 5 - newAdd end
end

--- 返回需要显示的英雄类型， 0是全部， 其他根据配置所得
local function GetCheckHeroType(btnName)
    local curType = 0;
    if btnName == "BtnWatter" then curType = 3;
    elseif btnName == "BtnWood" then curType = 2;
    elseif btnName == "BtnFire" then curType = 1 end
    return curType;
end

--- 按位置排序
local function sortPos(a,b)  
    if a~=nil and b~=nil and a.pos and b.pos then  
        return tonumber(a.pos) < tonumber(b.pos) 
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

--- spriteName 上阵中/双击上阵
local function GetHeroUporDown(flag)
  if flag then return "inTeam" 
  else return "wait" end
end

--- 发送英雄上阵的消息 2219
local function SendChange_player_team_up(player_hero_id,pos)
  local cont = NetMsgHelper:makesend_change_player_team_up(player_hero_id, pos);
  Proxy:send(NetAPIList.change_player_team_up,cont);
end

--- 发送英雄下阵的消息 2220 
local function SendChange_player_team_down(pos)
  local cont = NetMsgHelper:makesend_change_player_team_down(pos);
  Proxy:send(NetAPIList.change_player_team_down,cont);
end

---发送出售英雄消息 22102
local function SendPlayerSell(player_hero_id)
  local cont = NetMsgHelper:makesend_player_hero_sell(player_hero_id);
  Proxy:send(NetAPIList.hero_sell,cont);
end
--------------------------------------------------------------------------------------------------
-----------------------------------  normal
---- 获得英雄层的基本view信息
function teamMake:getMHeroPanel()
    self.hViews = {};
    local referScript = LuaHelper.GetComponent(self.panels[1], "ReferGameObjects");
    if referScript == nil then return end
    --- 下阵/复制用prefab
    self.hViews.btnDown = referScript.refers[0];
    self.hViews.prefab = referScript.refers[1];
    ---- scollView/scollBar/grid  script
    self.hViews.scollView = referScript.monos[0];
    self.hViews.scollBar = referScript.monos[1];
    self.hViews.grid = referScript.monos[2];
end
--- 获得信息层的view信息(英雄信息)
function teamMake:getMInfoPanel()
    self.infos = {};
    local referScript = LuaHelper.GetComponent(self.panels[2], "ReferGameObjects");
    if referScript == nil then return end
    ---- scollView/scollBar/grid
    self.infos.scollView = referScript.monos[0];
    self.infos.scollBar = referScript.monos[1];
    self.infos.grid = referScript.monos[2];
    ---------------------------------------------
    local subRef = LuaHelper.GetComponent(referScript.refers[0], "ReferGameObjects");
    ---- 上阵/出售
    self.infos.btnUp = subRef.refers[0];
    self.infos.btnSell = subRef.refers[1];
    ---- 星级 lable/战力 lable/hp lable/攻击 lable/物防 lable/魔防 lable
    self.infos.starLv = subRef.monos[0];
    self.infos.power = subRef.monos[1];
    self.infos.hp = subRef.monos[2];
    self.infos.attack = subRef.monos[3];
    self.infos.def = subRef.monos[4];
    self.infos.mdef = subRef.monos[5];
end
--- 获得主要的标签控制 views(针对重新排序)
function teamMake:getMControlPanel()
    self.controls = {};
    local referScript = LuaHelper.GetComponent(self.panels[3], "ReferGameObjects");
    if referScript == nil then return end
    --- 依次分别为 全部/水/木/火
    for i=0, referScript.refers.Count - 1 do
        table.insert(self.controls, referScript.refers[i]);
    end
end

function teamMake:initMainPan()
    self:getMHeroPanel();
    self:getMInfoPanel();
    self:getMControlPanel();
end

--- 根据原始表生成本地显示表[上阵部分]
function teamMake:sortAllHero()
    --- 初始化英雄显示表
    self.heroTable = {};
    --------------------------------------------
    --- 筛选需要的英雄
    local upHero = {};
    local downHero = {};
    for i, v in pairs(localTeam.models) do
        -- 查找配置表数据
        local localData = Model.units[tostring(v.netData.system_hero_id)];
        if localData then
            --- 生成基本表
            local hData = {};
            hData.netData = v.netData;
            hData.type = localData.category2;
            hData.power = v.power;
            hData.pos = v.pos;
            --- 记录上阵的英雄
            if hData.pos > 0 and hData.pos < MTeamLen + 1 then
                table.insert(upHero, hData);
            else
                --- 按类型记录当前需要的数据
                local curType = GetCheckHeroType(self.heroBtnName);
                if hData.type == curType or curType == 0 then
                    table.insert(downHero, hData);
                end
            end
        end
    end
    --- 上阵英雄排序
    if #upHero > 1 then table.sort(upHero, sortPos) end
    --- 其他英雄排序
    if #downHero > 1 then table.sort(downHero, sortPower) end
    --- 上阵英雄在最前面, 其他英雄根据战力排序-->生成最终表
    for i, hData in ipairs(upHero) do
        table.insert(self.heroTable, hData);
    end
    for i, hData in ipairs(downHero) do
        table.insert(self.heroTable, hData);
    end
end

--- 刷新英雄显示
function teamMake:updateHeroShow()
    --- 默认没有选中/隐藏下阵按钮
    self.selHero = -1;
    self.hViews.btnDown:SetActive(false);
    ---- 当前显示的view数量
    local curShowLen = 0;
   
    for i, hData in ipairs(self.heroTable) do
        ---- 一般显示设置
		local view = self.blocks[i];
		view:SetActive(true);
		view.name = self.hViews.prefab.name .. common_fun.getSpecifyStr(i, 4);
		common_fun.setChildAndBoxCollider(view, true);
		self:setHeroBlock(i, hData);
        ---- 更新显示数量
        curShowLen = curShowLen + 1;
        ---- 默认选中最前面的英雄
        if self.selHero < 0 then self.selHero = i end
        ---- 更新上阵英雄显示
        local isUp = false;
        if hData.pos > 0 and hData.pos < MTeamLen + 1 then isUp = true end
        if isUp then
            --- 检查是否选中的上阵英雄
            if hData.pos == localTeam.selectId then
                self.hViews.btnDown:SetActive(true);
                self.selHero = i;
                curShowLen = curShowLen + 1;
            end
            --- 显示上阵中_set/关闭tween
            local refer = LuaHelper.GetComponent(view, "ReferGameObjects");
            refer.monos[3].gameObject:SetActive(true);
            local ta = LuaHelper.GetComponent(refer.monos[3].gameObject,"TweenAlpha");
            ta.enabled = false;
            ta.value = 1;
        end
	end

    ---------------- 尾部添加花纹板
    ---- heroTable的英雄都会被显示， blocks里面不包含下阵按钮
    ---- 所以这里从heroTable尾部开始
    local start = #self.heroTable + 1;
    for i = start, #self.blocks do
        local view = self.blocks[i];
        view.name = self.hViews.prefab.name .. "9999";
        view:SetActive(false);
        local addLen = GetNeedAddBlock(curShowLen);
        if addLen ~= 0 then
            view:SetActive(true);
            common_fun.setChildAndBoxCollider(view, false);
            curShowLen = curShowLen + 1;
        end
    end
    
    ---- 重新排序
    if self.hViews.grid then self.hViews.grid:Reposition() end
    if self.hViews.scollView then self.hViews.scollView:ResetPosition() end
end

--- 更新英雄信息显示
function teamMake:updateHeroInfo()
  --- 重新标记当前选中英雄
  self:setMarkHero(self.selHero, true);
  --- 刷新英雄信息显示
  local hData = self.heroTable[self.selHero];
  common_fun.setHeroInfo(self.infos, hData);
  --- 刷新出售/上阵按钮的显示
  self:updateSellAndUp(hData);
end

--- hero btn的刷新改变
function teamMake:updateControl()
    common_fun.setSortBtnShow(self.controls, self.heroBtnName);
end

--- 更新整个界面显示
function teamMake:updatePanel()
    --- 重置显示表
    self:sortAllHero();
    -------------------------------------
    --- 检查blocks， 当前界面最大显示的数量是20
    --- 这里需要算上下阵按钮
    local newHeroCount = #self.heroTable + 1;
    newHeroCount = GetNewCountInfact(newHeroCount, 20, 5);
    if newHeroCount > #self.blocks then
        local startId = #self.blocks + 1;
        local copyBlock = self.hViews.prefab;
        for i=startId, newHeroCount do
            local clone = LuaHelper.InstantiateLocal(copyBlock, copyBlock.transform.parent.gameObject);
            clone.name = copyBlock.name .. "9999";
            table.insert(self.blocks, clone);
        end
    end
    --- 英雄显示刷新
    self:updateHeroShow();
    --- 英雄信息更新
    self:updateHeroInfo();
    --- 排序btn显示更新
    self:updateControl();
end

function teamMake:setPanelState(state)
  self.panelState = PanelStates[state];
end

--- 当收到新消息后， 根据当前的状态更新显示
function teamMake:updateViewsByState()
    if self.panelState == PanelStates["normal"] then
        self:updatePanel();
    elseif self.panelState == PanelStates["heroUp"] 
        or self.panelState == PanelStates["heroDown"] then
        ---- 界面切换
        self:back();
    elseif self.panelState == PanelStates["heroSell"] then
        self:updatePanel();
    end
end

--- 设置英雄Icon的显示, 默认隐藏选中
function teamMake:setHeroBlock(index, hData)
    local obj = self.blocks[index];
    if obj == nil then return end
    local refer = LuaHelper.GetComponent(obj,"ReferGameObjects");
    local localData = Model.units[tostring(hData.netData.system_hero_id)];
    local isUp = false;
    if hData.pos > 0 and hData.pos < MTeamLen + 1 then isUp = true end
    -- 头像/边框/五行/上阵提示/等级/种族/选中/星级/名字
    refer.monos[0].spriteName = localData.icon;
    refer.monos[1].spriteName = common_fun.getHeroColor(hData.netData.player_hero_color);
    refer.monos[2].spriteName = common_fun.getElemName(localData.category2);
    refer.monos[3].spriteName = GetHeroUporDown(isUp);
    refer.monos[4].text = "Lv:" .. tostring(hData.netData.player_hero_lv);
    refer.monos[5].spriteName = common_fun.getRaceName(localData.category1);
    --- 默认关闭选中
    refer.monos[6].gameObject:SetActive(false);
    refer.monos[7].text = localData.star;
    refer.monos[8].text = getValue(localData.name);
    --- 根据英雄信息激活上阵提示
    refer.monos[3].gameObject:SetActive(isUp);
end

--- 设置英雄选中或取消
function teamMake:setMarkHero(index, flag)
    if index == nil or index < 1 or index > #self.heroTable then return end 
    local hData = self.heroTable[index];
    local refer = LuaHelper.GetComponent(self.blocks[index],"ReferGameObjects");
    ------------------------------- select
    if flag then 
      --- 选中
      refer.monos[6].gameObject:SetActive(true);
      if hData.pos < 1 or hData.pos > MTeamLen  then
        --- 提示双击上阵
        refer.monos[3].gameObject:SetActive(true);
        local ta = LuaHelper.GetComponent(refer.monos[3].gameObject,"TweenAlpha");
        ta.enabled = true;
        ta.value = 1;
      end
    else
      --- 隐藏选中
      refer.monos[6].gameObject:SetActive(false);
      if hData.pos < 1 or hData.pos > MTeamLen then
        --- 隐藏双击上阵
        refer.monos[3].gameObject:SetActive(false);
      end
    end
end

function teamMake:updateSellAndUp(hData)
    local upSwitch = false;
    local sellSwitch = false;
    if hData then
        if hData.pos < 1 or hData.pos > MTeamLen  then
            ---- 未上阵
            upSwitch = true;
            sellSwitch = true;
        end
    end
    ---- 只要不是从主队伍界面进入都不能出售
    if self.backPanelName ~= "teamPanel" then
        sellSwitch = false;
    end
    common_fun.setBtnEnable(self.infos.btnUp, upSwitch);
    common_fun.setBtnEnable(self.infos.btnSell, sellSwitch);
end

--- 处理英雄上阵
function teamMake:handleHeroUp(hData)
    if hData and hData.pos == 0 then
        if localTeam:checkTeamIn(hData.netData.player_hero_id) then
            self:setPanelState("heroUp");
            SendChange_player_team_up(hData.netData.player_hero_id, localTeam.selectId);
        else
            showTips("同样的英雄不能一起上阵!");
        end 
    else
        showTips("当前英雄不能上阵!");
    end
end

--- 处理英雄下阵
function teamMake:handleHeroDown()
    local strIndex = localTeam.hUpTable[localTeam.selectId];
    if strIndex then
         --- 英雄下阵
        local heroCount = localTeam:getHeroNumInTeam();
        if heroLen == 1 then
            showTips("必须有一个英雄在队伍中");
        else
            self:setPanelState("heroDown");
            SendChange_player_team_down(localTeam.selectId);
        end
    else
        showTips("英雄数据异常!");
    end
end

--- 处理英雄出售
function teamMake:handleHeroSell(hData)
    if hData and hData.pos == 0 then
        local localData = Model.units[tostring(hData.netData.system_hero_id)];
        if localData.star > 3 then
            --- 高星出售判断
        end
        --- 英雄出售
        self:setPanelState("heroSell");
        print(hData.netData.player_hero_id);
        SendPlayerSell(hData.netData.player_hero_id);
    else
        showTips("当前英雄不能出售!");
    end
end
--------------------------------------------------------------------------------------------------
-----------------------------------   show/hide
--- 重置
function teamMake:reset()
    self.heroBtnName = "BtnTopAll";
    self:setPanelState("normal");
    self.backPanelName = "teamPanel";
end

--- 返回
function teamMake:back()
    if self.backPanelName == "teamPanel" then
        localTeam:showAll();
    elseif self.backPanelName == "teamSkill" then
        local teamSkill = LuaItemManager:getItemObject("teamSkill");
        teamSkill:sendSkillGet();
        teamSkill:setPanelState("normal");
        teamSkill:showAll();
    elseif self.backPanelName == "teamWeapon" then
        local teamWeapon = LuaItemManager:getItemObject("teamWeapon");
        teamWeapon:setPanelState("normal");
        teamWeapon:showAll();
    end

    self:hideAll();
end

--- 准备显示当前界面
function teamMake:showAll(backPanelName)
	if self.isShow > 0 then return end
    if backPanelName then self.backPanelName = backPanelName end
	self.isShow = 1;
	self:addToState();
end

--- 隐藏当前界面
function teamMake:hideAll()
    if self.isShow == 0 then return end
	self:removeFromState();
	self.isShow = 0;
    self:reset();
end
--------------------------------------------------------------------------------------------------
----------------------------------- data event callBack
---- 获得队伍列表更新消息
function teamMake:getTeamDatas(netData)
    if teamMake.isShow ~= 2 then return end
    -------------- data handle(数据分析__只针对上阵，下阵)
    -------------- view handle-->界面更新
    teamMake:updateViewsByState()
end

---- 获得所有的英雄数据和英雄数据更新消息
function teamMake.getHeroDatas(netData)
    if teamMake.isShow ~= 2 then return end   
    -------------- data handle(数据分析__只针对出售)
    -------------- view handle
    teamMake:updateViewsByState()
end
--------------------------------------------------------------------------------------------------
----------------------------------- event callBack
---- 绑定消息回调
function teamMake.msgCallBackBind()
    --- 注册接收所有上阵英雄消息
    localTeam:msgUnbinding(NetAPIList.player_team, teamMake.getTeamDatas);
    localTeam:msgBinding(NetAPIList.player_team, teamMake.getTeamDatas);
    --- 注册接收英雄列表更新消息
    localTeam:msgUnbinding(NetAPIList.recv_player_hero_change, teamMake.getHeroDatas);
    localTeam:msgBinding(NetAPIList.recv_player_hero_change, teamMake.getHeroDatas);
end

-- 第一次注册的时候调用
function teamMake:initialize()
    self:msgCallBackBind();
end

-- 资源加载完成时候调用方法
function teamMake:onAssetsLoad(items)
    referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
    if(referScript == nil)  then print("erro config"); end
    
    -- get panel
    for i=0, referScript.refers.Count - 1 do
        table.insert(self.panels, referScript.refers[i]);
    end
    
    --- 提示 Lable 显示
    --- 英雄上阵/下阵/星阶/战力/下阵/出售/全部/水/木/火
--    referScript.monos[0].text = getValue("");
--    referScript.monos[1].text = getValue("");
--    referScript.monos[2].text = getValue("");
--    referScript.monos[3].text = getValue("");
--    referScript.monos[4].text = getValue("");
--    referScript.monos[5].text = getValue("");
--    referScript.monos[6].text = getValue("");
--    referScript.monos[7].text = getValue("");
--    referScript.monos[8].text = getValue("");
--    referScript.monos[9].text = getValue("");

    self:initMainPan();
end

--- 显示的时候调用
function teamMake:onShowed( ... )
    if self.isShow ~= 2 then
        self.isShow = 2;
        if self.backPanelName then
             local itemObj = LuaItemManager:getItemObject(self.backPanelName);
             if itemObj then itemObj:hideAll() end
        end

        self:updateViewsByState();
    end
end

--- 处理切换英雄的点击刷新
function teamMake:onPress(obj, arg)
    if self.isShow ~= 2 then return end
    local cmd = obj.name;
    local tran = obj.transform.parent;
    if tran and tran.name == "grid" then
        local strTitle = string.sub(cmd, 1, 8);
        --- 有效点击
        if strTitle ~= "heroPreb" then return end
        if arg then
            local newSel = tonumber(string.sub(cmd, 9));
            if self.selHero == newSel then return end
            --- 更新选中
            self:setMarkHero(self.selHero, false);
            self.selHero = newSel;
            --- 刷新英雄信息
            self:updateHeroInfo();
        end
    end
end

function teamMake:onClick(obj,arg)
    if self.isShow ~= 2 then return end
   	local cmd = obj.name;
	local tran = obj.transform.parent;

    if tran and tran.name == "controlPanel" and cmd  == "BtnTSetClose" then
        self:back();
    elseif tran and tran.name == "backPanel" then
        if cmd == "BtnTopAll" or cmd == "BtnWatter" or cmd == "BtnWood" or cmd == "BtnFire" then
            if self.heroBtnName ~= cmd then
                self.heroBtnName = cmd;
                self:setPanelState("normal");
                self:updateViewsByState();
            end
        end
    elseif tran and tran.name == "info" then
        --- info 按钮
        if cmd == "BtnUp" then
            local hData = self.heroTable[self.selHero];
            self:handleHeroUp(hData);
        elseif cmd == "BtnSell" then
            local hData = self.heroTable[self.selHero];
            self:handleHeroSell(hData);
        end
    elseif tran and tran.name == "grid" and cmd  == "blockBtn" then
        --- 下阵
        self:handleHeroDown();
    end
end

--- 双击上阵
function teamMake:onDouble(obj,arg)
    if self.isShow ~= 2 then return end
    local cmd = obj.name;
    local tran = obj.transform.parent;
    if tran and tran.name == "grid" then
        local strTitle = string.sub(cmd, 1, 8);
        --- 有效点击
        if strTitle ~= "heroPreb" then return end
        local hData = self.heroTable[self.selHero];
        self:handleHeroUp(hData);
    end
end