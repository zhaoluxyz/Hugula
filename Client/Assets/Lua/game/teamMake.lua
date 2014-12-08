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
-- �������Ƿ�򿪣� 0/1/2 �ֱ�������/����/��ʾ
teamMake.isShow = 0;
-- ��Ҫ������panel
teamMake.panels = {};
-- Ӣ����� view(����hero)
teamMake.blocks = {};
-- ��ǰѡ��Ӣ������(view)
teamMake.selHero = -1;
--- ��ǰ����״̬
teamMake.panelState = 1;
--- ��ǰѡ�еĵ�hero Btn ����
teamMake.heroBtnName = "BtnTopAll";
--- �ϼ����ؽ����ʾ, Ĭ�Ϸ��ض���������
teamMake.backPanelName = "teamPanel";
--------------------------------------------------------------------------------------------------
-----------------------------------  local
local MTeamLen = 5;

-- ��¼��ǰ���������״̬�� �ֱ��� һ��/����
local PanelStates =
{
    normal = 1,
    heroUp = 2,
    heroDown = 3,
    heroSell = 4,
};

--- ���ʵ������Ҫ������, ������Ҫ����ֵ�� ��׼ֵ�� �仯ֵ
local function GetNewCountInfact(check, normal, add)
    --- ������׼���������׼����
    if check < normal then return normal end
    --- ����ǰ��Ҫ���
    local checkEnd = check - normal;
    --- �պ���add Ҳ��Ҫ�۳�
    while checkEnd > add - 1 do
        checkEnd = checkEnd - add;
    end
    local reValue = check;
    if checkEnd > 0 then
        reValue = reValue + add - checkEnd;
    end
    return reValue;
end

--- ���ݵ�ǰview����, �����Ҫ������ʾ�İ�����
local function GetNeedAddBlock(curLen)
    if curLen < 20 then return 20-curLen end
    local newAdd = curLen - 20;
    --- �պ���5Ҳ��Ҫ�۳�
    while newAdd > 4 do
        newAdd = newAdd - 5;
    end
    if newAdd == 0 then return 0;
    else return 5 - newAdd end
end

--- ������Ҫ��ʾ��Ӣ�����ͣ� 0��ȫ���� ����������������
local function GetCheckHeroType(btnName)
    local curType = 0;
    if btnName == "BtnWatter" then curType = 3;
    elseif btnName == "BtnWood" then curType = 2;
    elseif btnName == "BtnFire" then curType = 1 end
    return curType;
end

--- ��λ������
local function sortPos(a,b)  
    if a~=nil and b~=nil and a.pos and b.pos then  
        return tonumber(a.pos) < tonumber(b.pos) 
    else
        return false
    end
end

--- ��ս������
local function sortPower(a,b)  
  if a~=nil and b~=nil and a.power and b.power then  
    return tonumber(a.power)>tonumber(b.power) 
  else
    return false
  end
end

--- spriteName ������/˫������
local function GetHeroUporDown(flag)
  if flag then return "inTeam" 
  else return "wait" end
end

--- ����Ӣ���������Ϣ 2219
local function SendChange_player_team_up(player_hero_id,pos)
  local cont = NetMsgHelper:makesend_change_player_team_up(player_hero_id, pos);
  Proxy:send(NetAPIList.change_player_team_up,cont);
end

--- ����Ӣ���������Ϣ 2220 
local function SendChange_player_team_down(pos)
  local cont = NetMsgHelper:makesend_change_player_team_down(pos);
  Proxy:send(NetAPIList.change_player_team_down,cont);
end

---���ͳ���Ӣ����Ϣ 22102
local function SendPlayerSell(player_hero_id)
  local cont = NetMsgHelper:makesend_player_hero_sell(player_hero_id);
  Proxy:send(NetAPIList.hero_sell,cont);
end
--------------------------------------------------------------------------------------------------
-----------------------------------  normal
---- ���Ӣ�۲�Ļ���view��Ϣ
function teamMake:getMHeroPanel()
    self.hViews = {};
    local referScript = LuaHelper.GetComponent(self.panels[1], "ReferGameObjects");
    if referScript == nil then return end
    --- ����/������prefab
    self.hViews.btnDown = referScript.refers[0];
    self.hViews.prefab = referScript.refers[1];
    ---- scollView/scollBar/grid  script
    self.hViews.scollView = referScript.monos[0];
    self.hViews.scollBar = referScript.monos[1];
    self.hViews.grid = referScript.monos[2];
end
--- �����Ϣ���view��Ϣ(Ӣ����Ϣ)
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
    ---- ����/����
    self.infos.btnUp = subRef.refers[0];
    self.infos.btnSell = subRef.refers[1];
    ---- �Ǽ� lable/ս�� lable/hp lable/���� lable/��� lable/ħ�� lable
    self.infos.starLv = subRef.monos[0];
    self.infos.power = subRef.monos[1];
    self.infos.hp = subRef.monos[2];
    self.infos.attack = subRef.monos[3];
    self.infos.def = subRef.monos[4];
    self.infos.mdef = subRef.monos[5];
end
--- �����Ҫ�ı�ǩ���� views(�����������)
function teamMake:getMControlPanel()
    self.controls = {};
    local referScript = LuaHelper.GetComponent(self.panels[3], "ReferGameObjects");
    if referScript == nil then return end
    --- ���ηֱ�Ϊ ȫ��/ˮ/ľ/��
    for i=0, referScript.refers.Count - 1 do
        table.insert(self.controls, referScript.refers[i]);
    end
end

function teamMake:initMainPan()
    self:getMHeroPanel();
    self:getMInfoPanel();
    self:getMControlPanel();
end

--- ����ԭʼ�����ɱ�����ʾ��[���󲿷�]
function teamMake:sortAllHero()
    --- ��ʼ��Ӣ����ʾ��
    self.heroTable = {};
    --------------------------------------------
    --- ɸѡ��Ҫ��Ӣ��
    local upHero = {};
    local downHero = {};
    for i, v in pairs(localTeam.models) do
        -- �������ñ�����
        local localData = Model.units[tostring(v.netData.system_hero_id)];
        if localData then
            --- ���ɻ�����
            local hData = {};
            hData.netData = v.netData;
            hData.type = localData.category2;
            hData.power = v.power;
            hData.pos = v.pos;
            --- ��¼�����Ӣ��
            if hData.pos > 0 and hData.pos < MTeamLen + 1 then
                table.insert(upHero, hData);
            else
                --- �����ͼ�¼��ǰ��Ҫ������
                local curType = GetCheckHeroType(self.heroBtnName);
                if hData.type == curType or curType == 0 then
                    table.insert(downHero, hData);
                end
            end
        end
    end
    --- ����Ӣ������
    if #upHero > 1 then table.sort(upHero, sortPos) end
    --- ����Ӣ������
    if #downHero > 1 then table.sort(downHero, sortPower) end
    --- ����Ӣ������ǰ��, ����Ӣ�۸���ս������-->�������ձ�
    for i, hData in ipairs(upHero) do
        table.insert(self.heroTable, hData);
    end
    for i, hData in ipairs(downHero) do
        table.insert(self.heroTable, hData);
    end
end

--- ˢ��Ӣ����ʾ
function teamMake:updateHeroShow()
    --- Ĭ��û��ѡ��/��������ť
    self.selHero = -1;
    self.hViews.btnDown:SetActive(false);
    ---- ��ǰ��ʾ��view����
    local curShowLen = 0;
   
    for i, hData in ipairs(self.heroTable) do
        ---- һ����ʾ����
		local view = self.blocks[i];
		view:SetActive(true);
		view.name = self.hViews.prefab.name .. common_fun.getSpecifyStr(i, 4);
		common_fun.setChildAndBoxCollider(view, true);
		self:setHeroBlock(i, hData);
        ---- ������ʾ����
        curShowLen = curShowLen + 1;
        ---- Ĭ��ѡ����ǰ���Ӣ��
        if self.selHero < 0 then self.selHero = i end
        ---- ��������Ӣ����ʾ
        local isUp = false;
        if hData.pos > 0 and hData.pos < MTeamLen + 1 then isUp = true end
        if isUp then
            --- ����Ƿ�ѡ�е�����Ӣ��
            if hData.pos == localTeam.selectId then
                self.hViews.btnDown:SetActive(true);
                self.selHero = i;
                curShowLen = curShowLen + 1;
            end
            --- ��ʾ������_set/�ر�tween
            local refer = LuaHelper.GetComponent(view, "ReferGameObjects");
            refer.monos[3].gameObject:SetActive(true);
            local ta = LuaHelper.GetComponent(refer.monos[3].gameObject,"TweenAlpha");
            ta.enabled = false;
            ta.value = 1;
        end
	end

    ---------------- β����ӻ��ư�
    ---- heroTable��Ӣ�۶��ᱻ��ʾ�� blocks���治��������ť
    ---- ���������heroTableβ����ʼ
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
    
    ---- ��������
    if self.hViews.grid then self.hViews.grid:Reposition() end
    if self.hViews.scollView then self.hViews.scollView:ResetPosition() end
end

--- ����Ӣ����Ϣ��ʾ
function teamMake:updateHeroInfo()
  --- ���±�ǵ�ǰѡ��Ӣ��
  self:setMarkHero(self.selHero, true);
  --- ˢ��Ӣ����Ϣ��ʾ
  local hData = self.heroTable[self.selHero];
  common_fun.setHeroInfo(self.infos, hData);
  --- ˢ�³���/����ť����ʾ
  self:updateSellAndUp(hData);
end

--- hero btn��ˢ�¸ı�
function teamMake:updateControl()
    common_fun.setSortBtnShow(self.controls, self.heroBtnName);
end

--- ��������������ʾ
function teamMake:updatePanel()
    --- ������ʾ��
    self:sortAllHero();
    -------------------------------------
    --- ���blocks�� ��ǰ���������ʾ��������20
    --- ������Ҫ��������ť
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
    --- Ӣ����ʾˢ��
    self:updateHeroShow();
    --- Ӣ����Ϣ����
    self:updateHeroInfo();
    --- ����btn��ʾ����
    self:updateControl();
end

function teamMake:setPanelState(state)
  self.panelState = PanelStates[state];
end

--- ���յ�����Ϣ�� ���ݵ�ǰ��״̬������ʾ
function teamMake:updateViewsByState()
    if self.panelState == PanelStates["normal"] then
        self:updatePanel();
    elseif self.panelState == PanelStates["heroUp"] 
        or self.panelState == PanelStates["heroDown"] then
        ---- �����л�
        self:back();
    elseif self.panelState == PanelStates["heroSell"] then
        self:updatePanel();
    end
end

--- ����Ӣ��Icon����ʾ, Ĭ������ѡ��
function teamMake:setHeroBlock(index, hData)
    local obj = self.blocks[index];
    if obj == nil then return end
    local refer = LuaHelper.GetComponent(obj,"ReferGameObjects");
    local localData = Model.units[tostring(hData.netData.system_hero_id)];
    local isUp = false;
    if hData.pos > 0 and hData.pos < MTeamLen + 1 then isUp = true end
    -- ͷ��/�߿�/����/������ʾ/�ȼ�/����/ѡ��/�Ǽ�/����
    refer.monos[0].spriteName = localData.icon;
    refer.monos[1].spriteName = common_fun.getHeroColor(hData.netData.player_hero_color);
    refer.monos[2].spriteName = common_fun.getElemName(localData.category2);
    refer.monos[3].spriteName = GetHeroUporDown(isUp);
    refer.monos[4].text = "Lv:" .. tostring(hData.netData.player_hero_lv);
    refer.monos[5].spriteName = common_fun.getRaceName(localData.category1);
    --- Ĭ�Ϲر�ѡ��
    refer.monos[6].gameObject:SetActive(false);
    refer.monos[7].text = localData.star;
    refer.monos[8].text = getValue(localData.name);
    --- ����Ӣ����Ϣ����������ʾ
    refer.monos[3].gameObject:SetActive(isUp);
end

--- ����Ӣ��ѡ�л�ȡ��
function teamMake:setMarkHero(index, flag)
    if index == nil or index < 1 or index > #self.heroTable then return end 
    local hData = self.heroTable[index];
    local refer = LuaHelper.GetComponent(self.blocks[index],"ReferGameObjects");
    ------------------------------- select
    if flag then 
      --- ѡ��
      refer.monos[6].gameObject:SetActive(true);
      if hData.pos < 1 or hData.pos > MTeamLen  then
        --- ��ʾ˫������
        refer.monos[3].gameObject:SetActive(true);
        local ta = LuaHelper.GetComponent(refer.monos[3].gameObject,"TweenAlpha");
        ta.enabled = true;
        ta.value = 1;
      end
    else
      --- ����ѡ��
      refer.monos[6].gameObject:SetActive(false);
      if hData.pos < 1 or hData.pos > MTeamLen then
        --- ����˫������
        refer.monos[3].gameObject:SetActive(false);
      end
    end
end

function teamMake:updateSellAndUp(hData)
    local upSwitch = false;
    local sellSwitch = false;
    if hData then
        if hData.pos < 1 or hData.pos > MTeamLen  then
            ---- δ����
            upSwitch = true;
            sellSwitch = true;
        end
    end
    ---- ֻҪ���Ǵ������������붼���ܳ���
    if self.backPanelName ~= "teamPanel" then
        sellSwitch = false;
    end
    common_fun.setBtnEnable(self.infos.btnUp, upSwitch);
    common_fun.setBtnEnable(self.infos.btnSell, sellSwitch);
end

--- ����Ӣ������
function teamMake:handleHeroUp(hData)
    if hData and hData.pos == 0 then
        if localTeam:checkTeamIn(hData.netData.player_hero_id) then
            self:setPanelState("heroUp");
            SendChange_player_team_up(hData.netData.player_hero_id, localTeam.selectId);
        else
            showTips("ͬ����Ӣ�۲���һ������!");
        end 
    else
        showTips("��ǰӢ�۲�������!");
    end
end

--- ����Ӣ������
function teamMake:handleHeroDown()
    local strIndex = localTeam.hUpTable[localTeam.selectId];
    if strIndex then
         --- Ӣ������
        local heroCount = localTeam:getHeroNumInTeam();
        if heroLen == 1 then
            showTips("������һ��Ӣ���ڶ�����");
        else
            self:setPanelState("heroDown");
            SendChange_player_team_down(localTeam.selectId);
        end
    else
        showTips("Ӣ�������쳣!");
    end
end

--- ����Ӣ�۳���
function teamMake:handleHeroSell(hData)
    if hData and hData.pos == 0 then
        local localData = Model.units[tostring(hData.netData.system_hero_id)];
        if localData.star > 3 then
            --- ���ǳ����ж�
        end
        --- Ӣ�۳���
        self:setPanelState("heroSell");
        print(hData.netData.player_hero_id);
        SendPlayerSell(hData.netData.player_hero_id);
    else
        showTips("��ǰӢ�۲��ܳ���!");
    end
end
--------------------------------------------------------------------------------------------------
-----------------------------------   show/hide
--- ����
function teamMake:reset()
    self.heroBtnName = "BtnTopAll";
    self:setPanelState("normal");
    self.backPanelName = "teamPanel";
end

--- ����
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

--- ׼����ʾ��ǰ����
function teamMake:showAll(backPanelName)
	if self.isShow > 0 then return end
    if backPanelName then self.backPanelName = backPanelName end
	self.isShow = 1;
	self:addToState();
end

--- ���ص�ǰ����
function teamMake:hideAll()
    if self.isShow == 0 then return end
	self:removeFromState();
	self.isShow = 0;
    self:reset();
end
--------------------------------------------------------------------------------------------------
----------------------------------- data event callBack
---- ��ö����б������Ϣ
function teamMake:getTeamDatas(netData)
    if teamMake.isShow ~= 2 then return end
    -------------- data handle(���ݷ���__ֻ�����������)
    -------------- view handle-->�������
    teamMake:updateViewsByState()
end

---- ������е�Ӣ�����ݺ�Ӣ�����ݸ�����Ϣ
function teamMake.getHeroDatas(netData)
    if teamMake.isShow ~= 2 then return end   
    -------------- data handle(���ݷ���__ֻ��Գ���)
    -------------- view handle
    teamMake:updateViewsByState()
end
--------------------------------------------------------------------------------------------------
----------------------------------- event callBack
---- ����Ϣ�ص�
function teamMake.msgCallBackBind()
    --- ע�������������Ӣ����Ϣ
    localTeam:msgUnbinding(NetAPIList.player_team, teamMake.getTeamDatas);
    localTeam:msgBinding(NetAPIList.player_team, teamMake.getTeamDatas);
    --- ע�����Ӣ���б������Ϣ
    localTeam:msgUnbinding(NetAPIList.recv_player_hero_change, teamMake.getHeroDatas);
    localTeam:msgBinding(NetAPIList.recv_player_hero_change, teamMake.getHeroDatas);
end

-- ��һ��ע���ʱ�����
function teamMake:initialize()
    self:msgCallBackBind();
end

-- ��Դ�������ʱ����÷���
function teamMake:onAssetsLoad(items)
    referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
    if(referScript == nil)  then print("erro config"); end
    
    -- get panel
    for i=0, referScript.refers.Count - 1 do
        table.insert(self.panels, referScript.refers[i]);
    end
    
    --- ��ʾ Lable ��ʾ
    --- Ӣ������/����/�ǽ�/ս��/����/����/ȫ��/ˮ/ľ/��
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

--- ��ʾ��ʱ�����
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

--- �����л�Ӣ�۵ĵ��ˢ��
function teamMake:onPress(obj, arg)
    if self.isShow ~= 2 then return end
    local cmd = obj.name;
    local tran = obj.transform.parent;
    if tran and tran.name == "grid" then
        local strTitle = string.sub(cmd, 1, 8);
        --- ��Ч���
        if strTitle ~= "heroPreb" then return end
        if arg then
            local newSel = tonumber(string.sub(cmd, 9));
            if self.selHero == newSel then return end
            --- ����ѡ��
            self:setMarkHero(self.selHero, false);
            self.selHero = newSel;
            --- ˢ��Ӣ����Ϣ
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
        --- info ��ť
        if cmd == "BtnUp" then
            local hData = self.heroTable[self.selHero];
            self:handleHeroUp(hData);
        elseif cmd == "BtnSell" then
            local hData = self.heroTable[self.selHero];
            self:handleHeroSell(hData);
        end
    elseif tran and tran.name == "grid" and cmd  == "blockBtn" then
        --- ����
        self:handleHeroDown();
    end
end

--- ˫������
function teamMake:onDouble(obj,arg)
    if self.isShow ~= 2 then return end
    local cmd = obj.name;
    local tran = obj.transform.parent;
    if tran and tran.name == "grid" then
        local strTitle = string.sub(cmd, 1, 8);
        --- ��Ч���
        if strTitle ~= "heroPreb" then return end
        local hData = self.heroTable[self.selHero];
        self:handleHeroUp(hData);
    end
end