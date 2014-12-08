---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: mainPanel.lua
--data:2014.7.1
--author:yue an bang
--desc:主场景界面功能
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local mainScene = LuaItemManager:getItemObject("mainScene")
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
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local PrefabPool = luanet.PrefabPool.instance
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
local Refer,progressVit,progressExp,lableLV,lableName,lableCoin,lableYu,lableVit,lableExp
local sceneRefer
local teamModel = {} --模型对象缓存，方便清理
mainScene.assets=
{
   Asset("Main.u3d"),
   Asset("Main3DScene.u3d")
}

mainScene.arrPanel=
{
  ["BtnMail"]="mailPanel",
  ["BtnTask"]="taskPanel",
  ["Treasurebox"]="packPanel",
  ["BtnTeam"]="teamPanel",
  ["BtnTuJian"]="handbookScene",
  ["BtnFriend"]="friendPanel",
  ["BtnShop"]="shopPanel",
  ["BtnHuodong"]="activityPanel",
  ["BtnRisk"]="mapScene",
}

mainScene.btnSwitch = false
mainScene.bShow = false
--==================================================================================================
function mainScene:onAssetsLoad(items)
  common_fun:debugTimeBegin()
  local UIRoot = self.assets[1].items["RootPanel"]
  UIRoot.gameObject:SetActive(false)
  sceneRefer = LuaHelper.GetComponent(self.assets[2].root,"ReferGameObjects")
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  lableName = Refer.monos[0]
  lableCoin = Refer.monos[1]
  progressExp = LuaHelper.GetComponent(Refer.monos[2].gameObject,"UISlider")
  progressVit = LuaHelper.GetComponent(Refer.monos[3].gameObject,"UISlider")
  lableYu = Refer.monos[4]
  lableLV = Refer.monos[5]
  lableVit = Refer.monos[6]
  lableExp = Refer.monos[7]
  local rask = Refer.monos[8]
  local back = Refer.monos[9]
  rask.gameObject:SetActive(true)
  back.gameObject:SetActive(false)
  --
  mainScene:updateView()
  mainScene.bShow = true
  local function setSwitch() mainScene.btnSwitch = true end
  local function animationEnd() mainScene:IntoPlay() end
  delay(animationEnd, 4, nil)
  delay(setSwitch, 5, nil)
  
  self:requestSeverData();
  --load model to prefabpool
  mainScene:loadModelData()
  waitingPanelEnd()
  common_fun:debugTime()
end

--向服务器请求数据
function mainScene:requestSeverData()
  --请求活动
  Proxy:send(NetAPIList.player_activity_list, NetMsgHelper:makeplayer_activity_list(1));
  --请求好友
  Proxy:send(NetAPIList.player_friends_list, NetMsgHelper:makesend_friends_list(1,1000));
end

function mainScene:loadModelData()
  PrefabPool:Clear()
  PrefabPool:ClearCache()
  Model.getTeamModel().loadComFun = mainScene.callBackLoadModel
  Model.getTeamModel().iLoadNum = 0
  updateTeamPrefabData()
end

function mainScene:updateTeamModel()
  if Model.getTeamModel().bRefer == true then
    for k,v in pairs(teamModel) do
    LuaHelper.Destroy(v.gameObject)
    end
    teamModel = {}
  end
end

function mainScene:callBackLoadModel(key)
  --common_fun:debugTimeBegin()
  Model.getTeamModel().iLoadNum = Model.getTeamModel().iLoadNum + 1
  local len=#Model.battleGroup["team"]
  --
  print(" mainScene:callBackLoadModel++++loaded,name:" .. key .. 
    Model.getTeamModel().iLoadNum .. ":len:" .. len )
  --
  if Model.getTeamModel().iLoadNum >= len then
    Model.getTeamModel().bRefer = false
    if mainScene.bShow then
      mainScene:UpdateModel()
    end
  end
  --common_fun:debugTime()
end

function mainScene:msgCallbackBind()
  
end

function mainScene:UpdateModel()
  local index = 0
  local data = Model.battleGroup
  for k,v in ipairs(data["team"]) do
    local roleid = v["system_hero_id"]
    local modleName = Model.getUnit(roleid).model
    local role = PrefabPool:Get(modleName)
    print("modle name:" .. modleName )
    if role ~= nil and sceneRefer.refers[index] ~= nil then
      local clone = LuaHelper.InstantiateLocal(role,
        sceneRefer.refers[0].transform.parent.gameObject)
      clone.gameObject:SetActive(true)
      local nav = LuaHelper.GetComponent(clone,"NavMeshAgent")
      if(nav) then nav.enabled = false end
      clone.name = "Clone_Modle" .. index
      LuaHelper.GetComponent(clone.gameObject,"BoxCollider").size = Vector3(0.4, 1,1)
      LuaHelper.GetComponent(clone.gameObject,"BoxCollider").center = Vector3(0, 0.5,0)
      print(modleName)
      print("x:" .. sceneRefer.refers[index].transform.position.x .. " y:" .. sceneRefer.refers[index].transform.position.y)
      clone.transform.position = sceneRefer.refers[index].transform.position
      clone.transform.localScale = sceneRefer.refers[index].transform.localScale
      
      index = index + 1   
      table.insert(teamModel,clone)  
    end
  end
end

function mainScene:updateView()
  local playerInfo = Model:getPlayerInfo()
  lableName.text = playerInfo.name
  lableCoin.text = playerInfo.coin
  progressExp.Value = playerInfo.exp / playerInfo.maxExp
  progressVit.Value = playerInfo.vit / playerInfo.vit_m
  lableLV.text = playerInfo.lv
  lableYu.text = playerInfo.yu
  lableVit.text = playerInfo.vit .. "/" .. playerInfo.vit_m
  lableExp.text = (string.format("%2.2f", progressExp.Value) * 100 ) .. "%"

   --体力小于10的阀值，打开主界面提示购买入口
  if playerInfo.vit <= 10 then
    Refer.monos[12].gameObject:SetActive(true)
  else
    Refer.monos[12].gameObject:SetActive(false)
  end
end

function mainScene:setPlayerName( name )
  Modle:getPlayerInfo().name = name
  mainScene:updateView()
end

function mainScene:setPlayerCoin( coin )
  Modle:getPlayerInfo().coin = coin
  mainScene:updateView()
end

function mainScene:setPlayerTili( tili )
  Modle:getPlayerInfo().tili = tili
  mainScene:updateView()
end

function mainScene:setPlayerLv( lv )
  Modle:getPlayerInfo().lv = lv
  mainScene:updateView()
end

function mainScene:setPlayerYu( yu )
  Modle:getPlayerInfo().yu = yu
  mainScene:updateView()
end

function mainScene:onClick(obj,arg)
  mainUIProcess(obj,arg)
end

function mainScene:IntoPlay()
  local UIRoot = self.assets[1].items["RootPanel"]
  mainScene:openSignIn();
  --RenderSettingsHelper.Fog(true) --打开迷雾

  UIRoot:SetActive(true)

  local function f()  print("-----------guid  finish ed ") end
--  showGuide(10,f)
end

--签到界面
function mainScene:openSignIn()
      if Model.signInData.reward_status then
      print("今天已签到");
      return;
      end
      
      if Model.signInData.reward_status == nil then
      print("没有发送签到消息");
      return;
      end

  local signIn = LuaItemManager:getItemObject("signInPanel")
  if signIn    == nil then return end
  signIn:showAll();
end

function mainScene:onHide(...)
  Refer.monos[10].gameObject:SetActive(false)
  Refer.monos[11].gameObject:SetActive(false)
  --mainScene:destoryAll()
  --self:clear()
end

function mainScene:destoryAll()
  PrefabPool:Clear()
  PrefabPool:ClearCache()

  for k,v in pairs(teamModel) do
    LuaHelper.Destroy(v.gameObject)
  end
  teamModel = {}

  mainScene.bShow = false
end

function mainScene:closeAllPanel()
  Refer.monos[10].gameObject:SetActive(false)
  Refer.monos[11].gameObject:SetActive(false)
  --mailPanel
  local mail = LuaItemManager:getItemObject("mailPanel")
  print(mail)
  mail:hideAll()
  --friendPanel
  local friendPanel = LuaItemManager:getItemObject("friendPanel")
  friendPanel:hideAll()
  --teamPanel
  local team = LuaItemManager:getItemObject("teamPanel")
  team:hideAll()
  --settingPanel
  --chatPanel
  local chat = LuaItemManager:getItemObject("chatPanel")
  chat:hideAll()
  --signInPanel
  --packPanel
  local pack = LuaItemManager:getItemObject("packPanel")
  pack:hideAll();
  --taskPanel
  local task = LuaItemManager:getItemObject("taskPanel")
  task:hideAll();
  --shopPanel
  local shopPanel = LuaItemManager:getItemObject("shopPanel")
  shopPanel:hideAll();
  --........
end

function mainScene:showMainPanel()
  local UIRoot = self.assets[1].root
  UIRoot.gameObject:SetActive(true)
end

function mainScene:OnBuyVitClick()
  local refer = LuaHelper.GetComponent(Refer.monos[10].gameObject,"ReferGameObjects")
  local shopPanel = LuaItemManager:getItemObject("shopPanel")
  local data = shopPanel:getShopDataOfShopNo(7)[1]
  if Model:getPlayerInfo().yu >= data.goods_price.price then
    local cont = NetMsgHelper:makesend_buy_goods(data.id,1)
    Proxy:send(NetAPIList.buy_goods,cont)
  else
    mainScene:closeAllPanel()
    LuaItemManager:getItemObject("shopPanel"):showAll()
    LuaItemManager:getItemObject("shopPanel"):showBuyVitPanel()
  end
end

function mainScene:OnVitAlertClick()
  Refer.monos[10].gameObject:SetActive(true)
  local refer = LuaHelper.GetComponent(Refer.monos[10].gameObject,"ReferGameObjects")
  local shopPanel = LuaItemManager:getItemObject("shopPanel")
  local data = shopPanel:getShopDataOfShopNo(7)[1]
  print("OnBuyVitClick")
  printTable(data)
  refer.monos[0].text = "x" .. data.goods_price.price
  refer.monos[1].text = data.buy_limit
end

function mainScene:callback_BuyVitSucess()
  print("mainScene:callback_BuyVitSucess")
  Refer.monos[10].gameObject:SetActive(false)
  Refer.monos[11].gameObject:SetActive(true)
end
--=====================================globle=====================================
local prevBtn = "";
function mainUIProcess(obj,arg)
  local cmd =obj.name
  if cmd == "BtnVitAlert" then
    mainScene:OnVitAlertClick()
  elseif cmd == "cancel_vitPanel_btn" then
    Refer.monos[10].gameObject:SetActive(false)
  elseif cmd == "vitPanel_ret_ok_btn" then
    Refer.monos[11].gameObject:SetActive(false)
  elseif cmd == "buy_vitPanel_btn" then
    mainScene:OnBuyVitClick()
  elseif cmd =="BtnSetting" then --test 第一次战斗
    print(cmd.."sendGoFirstBattle")
    sendGoFirstBattle()
--======================================根据以上修改自己的地方=======================
  elseif string.find(cmd,"Btn") and mainScene.arrPanel[cmd] then
    local item = LuaItemManager:getItemObject(mainScene.arrPanel[cmd])
    if item.isShow == true then
         prevBtn = cmd   
         return
    elseif mainScene.arrPanel[cmd] == "teamPanel" then
        --- 队伍界面特殊处理
        if prevBtn ~= cmd then
            prevBtn = cmd
            mainScene:closeAllPanel()
        end
        item:showAll()
        return
    end

    mainScene:closeAllPanel()
    item:showAll()
  elseif cmd == "BtnTask" then
    local chat = LuaItemManager:getItemObject("chatPanel")
    if chat == nil then return end
    if chat.isShow then 
      chat:hideAll() 
    else 
      chat:showAll();
    end
  elseif cmd == "Treasurebox" then 
    if not mainScene.btnSwitch then return end
    local pack = LuaItemManager:getItemObject("packPanel")
    if pack == nil then return end
    if pack.isShow then 
      pack:hideAll() 
    else 
      pack:showAll() 
    end
  elseif string.find(cmd,"Clone_Modle") then
    local actor = LuaHelper.GetComponent(obj,"RoleActor") 
    actor.roleAnimator:Play("Show",0)
  elseif cmd == "BtnTeam" then 
    local team = LuaItemManager:getItemObject("teamPanel")
    if team == nil then return end
    if team.isShow > 0 then 
      team:hideAll();
    else
      team:showAll();
    end
  end
end

function callBackTeamDataMsg()
  mainScene:updateTeamModel()
end