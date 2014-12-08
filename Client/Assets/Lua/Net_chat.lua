
local os=os
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local StateManager=StateManager
local Msg=Msg
local NetChat=NetChat
local delay = delay
-------------------------------------------------------------------------------
local Proxy=Proxy
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local ServerCommonNotify = {}

local login = LuaItemManager:getItemObject("login")
local bFirst = true
--------------------net----------------------

NetChat:set_onConnectionFn(function(net)
	-- print("NetChat onConnection  ")
	--showNetworkInfo("network ready")
	login.callbackChatConnected()
	processMessage:ChatBind()

	Proxy:binding(NetAPIList.chatserv_good,callback_ChatNotifygood)
	Proxy:binding(NetAPIList.chatserv_bad,callback_ChatNotifybad)
end)

NetChat:set_onIntervalFn(function(net)
	-- luaGC()
end)

NetChat:set_onAppPauseFn(function(bl)
	if bl==false then
		if NetChat.isConnected==false then NetChat:ReConnect() end
	end
end)

NetChat:set_onReConnectFn(function(net)
end)

NetChat:set_onMessageReceiveFn(function(m)
	local ty=m:get_Type()
	local dataStruct=NetAPIList:getDataStructFromMsgType("MSGTYPE"..tostring(ty))
	-- print("NetChat onMessageReceive  type="..tostring(ty).." Length="..tostring(m:ToArray().Length).." dataStruct ="..dataStruct)
	-- print(m:Debug())
	-- print(m)
	local model=NetProtocalPaser:parseMessage(m,ty)
	Proxy:distribute(ty,model)
end)

NetChat:set_onConnectionCloseFn(function(net)
	-- print("NetChat onConnectionClose")
	--showTips("你的网络已断开！点击确定重新连接。",onReConnect)
	--	geTips.show(geTips.GE_TIP,"Connection lose")
--	NetChat:ReConnect()
    local function rec( ... )
		    NetChat:ReConnect()
	    end 
	delay(rec,3,nil)
end)

NetChat:set_onConnectionTimeoutFn(function(net)

	-- print("NetChat Connection time out")
	--showTips("网络连接超时,点击确定重新连接。",onReConnect)
	--showNetworkInfo("connection time out")
	local function rec( ... )
		NetChat:ReConnect()
	end 
	delay(rec,3,nil)
end)

NetChat.onReConnectFn=function()
	-- body
	--print("onReConnect")
	--NetChat:ReConnect()
end

function callbackChatLoginOk( data )
  print("chat login.. ok..")

	-- if bFirst then
	-- 	print("-=-=-=-send chat...-=-=-=-=")
	-- 	local cont = NetMsgHelper:makesend_chat(1,0,"yab test message...")
	-- 	Proxy:sendChat(NetAPIList.send_chat,cont)
	-- 	bFirst = false
	-- end
	
  --begin Hert
  -- startChatHertbeat();
end

function callbackChatLoginError( data )
  print("command: " .. data["command"])
  print("errno: " .. data["errno"])
end

-- function callbackChatHert( data )
-- 	print("NetChat hertbeat..")
-- 	printTable(data)
-- 	local cont = NetMsgHelper:makept_int(1)
--   	Proxy:sendChat(NetAPIList.heartbeat,cont)
-- end

-- function startChatHertbeat()
-- 	print("NetChat start hertbeat..")
--   	local cont = NetMsgHelper:makept_int(1)
--   	Proxy:sendChat(NetAPIList.start_heartbeat,cont)
--   	Proxy:binding(NetAPIList.heartbeat,callbackChatHert)


-- end

function callback_ChatNotifygood(data)
	--报错
	if ServerCommonNotify[data["command"]] ~= nil then
		local fun = ServerCommonNotify[data["command"]].fun
  		if fun ~= nil then fun(data) end
	end
end

function callback_ChatNotifybad(data)
  -- login:onShowErrorInfo(data["errno"])
  if ServerCommonNotify[data["command"]] ~= nil then
	local funex = ServerCommonNotify[data["command"]].funex
	if funex ~= nil then funex(data) end
  end
end

function bindCommonChatNotify(api,fun,funex)
	local table = {}
	table.code = api.Code
	table.fun = fun
	table.funex = funex
	ServerCommonNotify[api.Code] = table
	printTable(ServerCommonNotify)
end
