---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: login.lua
--data:2014.7.1
--author:yue an bang
--desc:登陆流程
--===============================================================================================--
---------------------------------------------------------------------------------------------------
require("state.itemObject")
local login = LuaItemManager:getItemObject("login")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local common_fun = common_fun
local Encoding =toluacs.System.Text.Encoding
local BitConverter = luanet.import_type("System.BitConverter")
local Byte = luanet.import_type("System.Byte[]")
--==================================================================================================
local Net=Net
local NetChat=NetChat
local LFunction = LFunction.instance
local Proxy=Proxy
local Vector3 = UnityEngine.Vector3
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local SelServerName,SelServerID,SelServerLable
local CurListItemRefer,CurServerRefer,RootReferPanel
local ServerListTable,CurSelectServerInfo
local loginSID,curRandNameText
local ChooseServerURL = ""
local TCPServerIP = ""
local TCPServerPort = 0
local TCPChatServerIP = ""
local TCPChatServerPort = 0
local curCreateRoleIndex=0
local g_roleInfo
local first=true
local IsCreateRolePanel = false
local bLimitDrag = false
local platformLimit = true
isDebug=false

--==================================================================================================

local surename = {}
local malename = {}
local femalename = {}
function InitRandomNameData()
  local surenameNum = tonumber(getValue("g_surname_num"))
  local malenameNum = tonumber(getValue("g_malename_num"))
  local femalenameNum = tonumber(getValue("g_femalename_num"))
  for i=1,surenameNum do
    surename[#surename + 1] = getValue("g_surname_"..i)
  end
  for i=1,malenameNum do
    malename[#malename + 1] = getValue("g_malename_"..i)
  end
  for i=1,femalenameNum do
    femalename[#femalename + 1] = getValue("g_femalename_"..i)
  end
end

function login:GetRandName(isMale)
  curRandNameText = ""
  math.randomseed(os.time()) 
  local sureN = surename[math.random(1,#surename)]
  if isMale == true then
    local maleN = malename[math.random(1,#malename)]
    curRandNameText = sureN .. maleN
  else
    local femaleN = femalename[math.random(1,#femalename)]
    curRandNameText = sureN .. femaleN
  end
  return curRandNameText
end
--==================================================================================================

--外网平台
local LoginURL="http://114.215.181.123:8443/api"
--内网平台
--local LoginURL="http://192.168.18.152:8443/api"

login.msg = 
{
  chk_ver=410,--checkversion
  login=411,--login to server
  reqServer=412,--requestServerList
  chooseGame=413,--chooseGameserver
  loginHTTPGame=115,--loginHTTPGameserver
  newRole=116--createRole
}

login.roleInfo =
{
  [0]={name="g_login_text_001",info="g_login_text_004",hp=0.95,att=0.56,def=0.71},--通灵师
  [1]={name="g_login_text_002",info="g_login_text_005",hp=0.56,att=0.93,def=0.69},--阴阳师
  [2]={name="g_login_text_003",info="g_login_text_006",hp=0.51,att=0.72,def=0.82}--巫女
}

login.createRoleImg = 
{
  [0]="SelectRole_img10",
  [1]="SelectRole_img12",
  [2]="SelectRole_img11"
}

login.serverstate = 
{
  [0]="g_login_text_007",
  [1]="g_login_text_008",
  [2]="g_login_text_009"
}
--==================================================================================================
login.assets=
{
   Asset("Login.u3d")
}
--===============================================local function=====================================

local function allComplete( ... )
  --Loader:setOnAllCompelteFn(nil)

  --------------------------------
  RootReferPanel = LuaHelper.GetComponent(login.assets[1].items["Refers"],"ReferGameObjects")
  local BtnSelServer = RootReferPanel.monos[2]
  local SelServerListPanel = RootReferPanel.monos[0]
  -----------------------------------
  local LoginPanelRefer = LuaHelper.GetComponent(BtnSelServer.gameObject,"ReferGameObjects")
  SelServerID = LoginPanelRefer.monos[0]
  SelServerName = LoginPanelRefer.monos[1]
  SelServerLable = LoginPanelRefer.monos[2]
  SelServerLable.gameObject:SetActive( false)
  SelServerName.text = getValue("g_login_text_013")--"正在获取服务器列表"
  SelServerID.text = ""

  CurServerRefer = LuaHelper.GetComponent(SelServerListPanel.gameObject,"ReferGameObjects")
  local CurListItem = CurServerRefer.monos[0]
  CurListItemRefer = LuaHelper.GetComponent(CurListItem.gameObject,"ReferGameObjects")
  -----------------------------------
  login:onCheckVersion()
  --login:onReqServerList()
end

local function updateSelectRoleInfo(index)
  local SelectRolePanel = RootReferPanel.monos[5]
  local SelectRoleRefer = LuaHelper.GetComponent(SelectRolePanel.gameObject,"ReferGameObjects")
  local Name = SelectRoleRefer.monos[0]
  local hp = SelectRoleRefer.monos[1]
  local att = SelectRoleRefer.monos[2]
  local def = SelectRoleRefer.monos[3]
  local Info = SelectRoleRefer.monos[4]
  Name.text = getValue(login.roleInfo[index]["name"])
  Info.text = getValue(login.roleInfo[index]["info"])
  local progressHp = LuaHelper.GetComponent(hp.gameObject,"UISlider")
  local progressAtt = LuaHelper.GetComponent(att.gameObject,"UISlider")
  local progressDef = LuaHelper.GetComponent(def.gameObject,"UISlider")

  progressHp.Value = login.roleInfo[index]["hp"]
  progressAtt.Value = login.roleInfo[index]["att"]
  progressDef.Value = login.roleInfo[index]["def"]
  --switch picture
  local sprite1Img = LuaHelper.GetComponent(RootReferPanel.monos[7].gameObject,"UISprite")
  local sprite2Img = LuaHelper.GetComponent(RootReferPanel.monos[8].gameObject,"UISprite")
  local sprite3Img = LuaHelper.GetComponent(RootReferPanel.monos[9].gameObject,"UISprite")
  sprite1Img.spriteName = login.createRoleImg[index]
  sprite2Img.spriteName = login.createRoleImg[(index + 1) % 3]
  sprite3Img.spriteName = login.createRoleImg[(index + 2) % 3]
  sprite1Img:MakePixelPerfect()
  sprite2Img:MakePixelPerfect()
  sprite3Img:MakePixelPerfect()
end

local function randGenRoleName()
  local isMale = true
  if curCreateRoleIndex == 1 then 
    isMale = false
  end
  local CreateRoleNameLable = RootReferPanel.monos[6]
  local input = LuaHelper.GetComponent(RootReferPanel.monos[6].transform.parent.gameObject,"UIInput")
  input.Value = login:GetRandName(isMale)
  --CreateRoleNameLable.text = login:GetRandName(isMale)
end

local function onShowCreateRolePanel()
  IsCreateRolePanel = true
  RootReferPanel.monos[3].gameObject:SetActive(false)
  RootReferPanel.monos[4].gameObject:SetActive(true)

  updateSelectRoleInfo(curCreateRoleIndex)
end

local function onUpdateSelServerInfo()
  if CurSelectServerInfo ~= nil then
    --SelServerLable.text = CurSelectServerInfo.monos[2].text
    SelServerLable.gameObject:SetActive(true)
    SelServerName.text = CurSelectServerInfo.monos[1].text
    SelServerID.text = CurSelectServerInfo.monos[0].text
  end
end

local function onUpdateServerList()
  --================================
  if ServerListTable == nil or first == false then
    return
  end

  printTable(ServerListTable)
  CurListItemRefer.monos[0].text = ServerListTable[1]["id"] .. getValue("g_login_text_010")--"区"
  CurListItemRefer.monos[1].text = ServerListTable[1]["name"]
  CurListItemRefer.monos[2].text = getValue(login.serverstate[ServerListTable[1]["status"]])
  CurListItemRefer.monos[3].text = ServerListTable[1]["id"]
  CurSelectServerInfo = CurListItemRefer
  local Item = CurServerRefer.monos[1]
  if Item == nil then
    return
  end

  local i = 0
  for k,v in pairs(ServerListTable) do
    local clone = LuaHelper.InstantiateLocal(Item.gameObject,Item.transform.parent.gameObject)
    local CloneItemRefer = LuaHelper.GetComponent(clone.gameObject,"ReferGameObjects")
    CloneItemRefer.monos[0].text = v["id"] .. getValue("g_login_text_010")--"区"
    CloneItemRefer.monos[1].text = v["name"]
    CloneItemRefer.monos[2].text = getValue(login.serverstate[v["status"]])
    CloneItemRefer.monos[3].text = v["id"]
    local posX = clone.transform.localPosition.x
    local posY = clone.transform.localPosition.y
    local vector = Vector3(posX,posY - 60 * i,0)
    clone.transform.localPosition = vector
    clone.gameObject:SetActive(true)
    i = i + 1
  end 
  first = false 
end

local function onChangePage(state)
  if state == "SelserverListPanel" then
    onUpdateServerList()
  elseif state == "SelServer" then
    onUpdateSelServerInfo()
  elseif state == "CreateRole" then
    onShowCreateRolePanel()
  end
end

local function onCheckVersionComp(req)
  print("onCheckVersionComp")
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    local result = res["results"]
    if result["upgrade"] == 0 then
      delay(login.onReqServerList,0.5,nil)--必须延时执行
    end
  elseif res["success"] == 0 then
    login:onShowErrorInfo(res["errno"])
  end
end

local function onCheckVersionError( req )
  waitingPanelEnd()
  print("onCheckVersionError")
  if isDebug then
    delay(login.onReqServerList,0.5,nil)--必须延时执行
  else
    showTips(getValue("g_login_text_012"),login.onCheckVersion)
  end
end

local function onReqServerComp(req)
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    ServerListTable = res["results"]
    SelServerLable.gameObject:SetActive(true)
    print("state:" .. ServerListTable[1]["status"])
    SelServerLable.text = getValue(login.serverstate[ServerListTable[1]["status"]])
    SelServerName.text = ServerListTable[1]["name"]
    SelServerID.text = ServerListTable[1]["id"] .. getValue("g_login_text_010")--"区"

    onUpdateServerList()
  elseif res["success"] == 0 then
    login:onShowErrorInfo(res["errno"])  
  end 
  waitingPanelEnd()
end

local function onReqServerError( req )
  print("onReqServerError")
  fun=function()
    waitingPanelEnd()
    if isDebug then
      --onChangePage("CreateRole")
      showTips(getValue("g_login_text_011"))--服务器未开启，可以直接点击进入游戏")
    else
      showTips(getValue("g_login_text_012"),login.onReqServerList)
    end
  end
  delay(fun,0.5,nil)
end

local function onReqLoginComp(req)
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    local result = res["results"]
    loginSID = result["sid"]
    delay(login.onChooseGameserver,0.5,nil)--必须延时执行
  elseif res["success"] == 0 then
    login:onShowErrorInfo(res["errno"])
    waitingPanelEnd()
  end
end

local function onReqLoginError( req )
  if isDebug then
    delay(login.onChooseGameserver,0.5,nil)--必须延时执行
  else
    showTips(getValue("g_login_text_014"),login.onLogin)
  end
end

local function onChooseGameComp( req )
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    ChooseServerURL = res["results"]["url"]
    delay(login.onLoginHTTPGameServer,0.5,nil)--必须延时执行
  elseif res["success"] == 0 then
    waitingPanelEnd()
    if isDebug then
      onChangePage("CreateRole")
    else
      showTips(login:getErrorMessage(res["errno"]) .. "," .. getValue("g_login_text_015"),
        login.onChooseGameserver)
    end
  end
end

local function onChooseGameError( req )
  print("onChooseGameError")
  waitingPanelEnd()
  if isDebug then
    onChangePage("CreateRole")
  else
    showTips(getValue("g_login_text_014"),login.onChooseGameserver)
  end
end

local function onHTTPGameComp( req )
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    TCPServerIP = res["results"]["gs_ip"]
    TCPServerPort = res["results"]["gs_port"]
    TCPChatServerIP = res["results"]["chatserv_ip"]
    TCPChatServerPort = res["results"]["chatserv_port"]
    if res["results"]["role"] ~= 0 then
      login:connectGameServer( res["results"] )
    else
      onChangePage("CreateRole")
      waitingPanelEnd()
    end
  elseif res["success"] == 0 then
    if isDebug then
      onChangePage("CreateRole")
    else
      showTips(login:getErrorMessage(res["errno"]) .. "," .. getValue("g_login_text_015"),
        login.onLoginHTTPGameServer)
    end
    waitingPanelEnd()
  end  
end

local function onHTTPGameError( req )
  print("onHTTPGameError")
  waitingPanelEnd()
  if isDebug then
    onChangePage("CreateRole")
  else
    showTips(getValue("g_login_text_014"),login.onLoginHTTPGameServer)
  end
end

local function onCreateRoleComp( req )
  local www=req:get_data();
  local txt=www.text;
  print(txt)
  local res = json:decode(txt)
  if res["success"] == 1 then
    if res["results"]["role"] ~= 0 then
      login:connectGameServer( res["results"] )
      Model.flgFirstBattle = true
    end
  elseif res["success"] == 0 then
    --res["results"]["player"].length > 0
    if isDebug then
      login:connectGameServer()
    else
      showTips(login:getErrorMessage(res["errno"]))
    end
  end  
  waitingPanelEnd()
end

local function onCreateRoleError( req )
  print("onCreateRoleError")
  waitingPanelEnd()
  if isDebug then
    login:connectGameServer()
  else
    showTips(getValue("g_login_text_014"),login.onCreateRole)
  end
end

local function onReqError( req )
  -- body
  if isDebug then
    waitingPanelEnd()
  end
  print("onReqError............")
end

--==============================================public====================================================
function login:onAssetsLoad(items)
  --local lb=LuaHelper.GetComponent(self.assets[1].items["Label"],"UILabel")
  --lb.text=" begin load resource "
  print("....................... hello resource is loaded !")
  --init randomname config
  local Refer = LuaHelper.GetComponent(login.assets[1].items["Refers"],"ReferGameObjects")
  Refer.monos[12].text = "version "..ResVersion
  -- lb.text="version "..ResVersion
  InitRandomNameData()
  allComplete()
end

function login:onDrag(obj,arg)
  if IsCreateRolePanel == true and bLimitDrag == false then
    local fun= function() bLimitDrag = false end
    bLimitDrag = true
    delay(fun,0.2,nil)
    if arg.x > 1 then
      curCreateRoleIndex = (curCreateRoleIndex + 2) % 3
      updateSelectRoleInfo(curCreateRoleIndex)
    elseif arg.x < -1 then
      curCreateRoleIndex = (curCreateRoleIndex + 1) % 3
      updateSelectRoleInfo(curCreateRoleIndex)
    end
  end
end

function login:onClick(obj,arg)
	local cmd =obj.name
	if cmd == "BtnStart" then
    login:onLogin()
    --StateManager:setCurrentState(StateManager.mainScene)
  elseif cmd == "BtnSelServer" then
    onChangePage("SelserverListPanel")
  elseif cmd == "BtnBack" then
    onChangePage("SelServer")
  elseif cmd == "BtnNextToCreateName" then
    IsCreateRolePanel = false
  elseif cmd == "BtnCreateRoleBack" then
    IsCreateRolePanel = true
  elseif cmd == "BtnCreateRoleOK" then
    login:onCreateRole()
  elseif cmd =="BtnNextRole" then
    curCreateRoleIndex = (curCreateRoleIndex + 2) % 3
    updateSelectRoleInfo(curCreateRoleIndex)
  elseif cmd == "BtnPreRole" then
    curCreateRoleIndex = (curCreateRoleIndex + 1) % 3
    updateSelectRoleInfo(curCreateRoleIndex)
  elseif cmd == "BtnCreateRoleRandName" then
    randGenRoleName()
  elseif string.find(cmd,"ServerInfo") then
    CurSelectServerInfo = LuaHelper.GetComponent(obj.gameObject,"ReferGameObjects")
	end
end

function login:connectGameServer( req )
  if req ~= nil then
    g_roleInfo = req["player"]
    Model.InitPlayerDataEx(g_roleInfo)
    printTable(req)
  end
  
  if isDebug == false then
    showWaitingPanel()
    Net:Close()
    Net:Connect(TCPServerIP,TCPServerPort)

    NetChat:Close()
    NetChat:Connect(TCPChatServerIP,TCPChatServerPort)
    login.msgCallbackBind()
  else
    StateManager:setCurrentState(StateManager.mainScene)
  end
end

function login:callbackConnected()
  print("game send login")
  login:SendLoginMsg()
end

function login:callbackChatConnected()
  print("chat send login")
  local cont = NetMsgHelper:makept_gs_login(LFunction:getDeviceID(),loginSID,g_roleInfo["player_id"])
  printTable(cont)
  Proxy:sendChat(NetAPIList.chatserv_login,cont)
end

function login:msgCallbackBind()
  bindCommonChatNotify(NetAPIList.chatserv_login,callbackChatLoginOk,callbackChatLoginError)
  bindCommonNotify(NetAPIList.gs_login,callbackLoginOk,callbackLoginError)
  Proxy:binding(NetAPIList.player_team,callbackTeamData)
end

----checkversion->reqServerList->login-----------------------------------------------
function login:onCheckVersion( )
  showWaitingPanel()
  print("onCheckVersion....")
  local c = {}
  c["os"] = "android"
  c["software_version"] = 1
  c["resource_version"] = 1
  login:SendHttpMsg(LoginURL,"",login.msg["chk_ver"],c,onCheckVersionComp,onCheckVersionError)
end

function login:onReqServerList( )
  showWaitingPanel()
  print("onReqServerList....")
  local c = {}
  c["udid"] = LFunction:getDeviceID()
  login:SendHttpMsg(LoginURL,"",login.msg["reqServer"],c,onReqServerComp,onReqServerError)
end

function login:onLogin( )
  showWaitingPanel()
  print("onLogin....")
  local c = {}
  c["os"] = "android"
  c["udid"] = LFunction:getDeviceID()
  if platformLimit == true then
--    c["platform"] = "envee"
    c["platform"] = ""
  end

  local inputAcc = LuaHelper.GetComponent(RootReferPanel.monos[10].gameObject,"UIInput")
  local inputPWord = LuaHelper.GetComponent(RootReferPanel.monos[11].gameObject,"UIInput")
  c["username"] = inputAcc.Value
  c["password"] = inputPWord.Value
  print("username:" .. inputAcc.Value ..  " password:" .. inputPWord.Value)
  login:SendHttpMsg(LoginURL,"",login.msg["login"],c,onReqLoginComp,onReqLoginError)
end

function login:onChooseGameserver()
  showWaitingPanel()
  print("onChooseGameserver....")
  local sid = loginSID
  local c = {}
  if CurSelectServerInfo ~= nil then
    c["gameid"] = tonumber(CurSelectServerInfo.monos[3].text)
  end
  login:SendHttpMsg(LoginURL,sid,login.msg["chooseGame"],c,onChooseGameComp,onChooseGameError)
end

function login:onLoginHTTPGameServer( )
  local sid = loginSID
  local c = {}
  c["udid"] = LFunction:getDeviceID()
  print("onLoginHTTPGameServer....")
  print(ChooseServerURL)
  login:SendHttpMsg(ChooseServerURL,sid,login.msg["loginHTTPGame"],c,onHTTPGameComp,onHTTPGameError)
end

function login:onCreateRole()

  local sid = loginSID
  local c = {}
  
  local CreateRoleNameLable = RootReferPanel.monos[6]
  if CreateRoleNameLable.text ~= "点击输入名字" and CreateRoleNameLable.text ~= "" then 
    curRandNameText = CreateRoleNameLable.text
  else
    showTips("请输入有效名字")
    return
  end

  showWaitingPanel()

--  print(UTF8:GetBytes)
  print(curRandNameText)
  local stringBytes = LuaHelper.GetBytes(curRandNameText)
  c["nickname"] = LuaHelper.GetUTF8String(stringBytes)
  c["role_id"] = curCreateRoleIndex + 290001

  print( "onCreateRole")
  print( ChooseServerURL)
  login:SendHttpMsg(ChooseServerURL,sid,login.msg["newRole"],c,onCreateRoleComp,onCreateRoleError)
end

function login:SendHttpMsg( url,sid,msgID,content,compFn,errorFn )
  local t = {}
  t["sid"] = sid
  t["event"]=msgID
  t["time"] = LFunction:getSystemTime()
  t["results"] = content
  t["token"] = LFunction:GetMD5("Enveesoft2014" .. json:encode(content) .. t["time"])
  local raw_json_text = json:encode(t)

  print("raw_json_text encode:" .. raw_json_text)
  local req = Request(url)
  if compFn ~= nil then req:set_onCompleteFn (compFn) end
  if errorFn ~= nil then req:set_onEndFn(errorFn) end

--local BindingFlags = luanet.import_type(" System.Reflection.BindingFlags")
--print(Encoding.UTF8:GetType():GetMember("GetBytes",BindingFlags.Public).Length)
--local Encoding = luanet.import_type("System.Text.Encoding")
--printTable(getmetatable(Encoding.UTF8))
  req:set_head (LuaHelper.GetBytes(raw_json_text))
  -- print(req.onCompleteFn)
  -- print(req)
  Loader:getResource(req,false) 
  print(" ---------------------login-end --------------UTF8:GetBytes----")
  print(UTF8)
  -- print(req)
end

function login:getErrorMessage( errorID )
  if errorID > 0 then
    local error = getValue( "g_notify_" .. errorID )
    if string.len(error) > 0 then
      return error
    end 
  end
  return ""
end

function login:onShowErrorInfo( errorID )
  local error = login:getErrorMessage(errorID)
  if string.len(error) > 0 then
    showTips("" .. error)
  end 
end

function login:SendLoginMsg()
  local cont = NetMsgHelper:makept_gs_login(LFunction:getDeviceID(),loginSID,g_roleInfo["player_id"])
  printTable(cont)
  Proxy:send(NetAPIList.gs_login,cont)
end
-------============================globle==========================--------
function callbackLoginOk( data )
  print("login.. ok..")
  
  --- 获取背包信息
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.player_bag,cont)
  --- 申请队伍数据
  local localTeam = LuaItemManager:getItemObject("teamPanel")
  if localTeam then localTeam:requestHeroData() end

  waitingPanelEnd()

  --first battle
  if Model.flgFirstBattle == true then
    sendGoFirstBattle()
  else
    StateManager:setCurrentState(StateManager.mainScene)
  end

  --client data init
  local mailPanel = LuaItemManager:getItemObject("mailPanel")
  mailPanel:InitMailData()

  --begin Hert
  startHertbeat();

  --handbook
  delay(sendRequestHandbookMsg,1,nil)

  --shopdata
  delay(sendRequestShopDataMsg,1.5,nil)

end

function sendGoFirstBattle()
     local battleUI = LuaItemManager:getItemObject("battleUI")
     battleUI.callback = callbackFirstBattleEnd
     local cont = NetMsgHelper:makesend_challenge_chapter(Model.guideTaskid)
     printTable(cont)
    Proxy:send(NetAPIList.player_challenge_chapter,cont)
end

function callbackFirstBattleEnd()
  StateManager:setCurrentState(StateManager.mainScene)
end

function callbackLoginError( data )
  waitingPanelEnd()
  print("command: " .. data["command"])
  print("errno: " .. data["errno"])
  login:onShowErrorInfo(data["errno"])
end

function updateTeamPrefabData()
  local reqs = {}
  for k,v in pairs(Model.battleGroup["team"]) do
    local roleid = v["system_hero_id"]
    local modleName = Model.getUnit(roleid).model
    print("modle name:" .. modleName)
    
    common_fun.addToList(modleName,reqs,Model.getTeamModel().loadComFun)
  end
  common_fun.beginLoad(reqs)
end

function callbackTeamData( data )
  print("-------------------team--------------------")
  --printTable(data)
  printTable(data["team"])
  --printTable(data.team[1])
  Model.battleGroup = data
  Model.getTeamModel().bRefer = true
  Model.getTeamModel().iLoadNum = 0
  PrefabPool:Clear()
  PrefabPool:ClearCache()
  callBackTeamDataMsg()
  updateTeamPrefabData()
end
