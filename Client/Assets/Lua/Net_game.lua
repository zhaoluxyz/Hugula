local os=os
-- local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local StateManager=StateManager
local Net=Net
local Msg=Msg

-------------------------------------------------------------------------------

local login = LuaItemManager:getItemObject("login")

local Proxy=Proxy
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList

local ServerCommonNotify = {}

Net:set_onConnectionFn(function(net)
	print("game onConnection  ")
	--showNetworkInfo("network ready")
	login.callbackConnected()

  	Proxy:binding(NetAPIList.gs_good,callback_notifygood)
	Proxy:binding(NetAPIList.gs_bad,callback_notifybad)

	processMessage:bind()

end)

Net:set_onIntervalFn(function(net)
	--Net:send(pingMsg)
	--Proxy:send(NetAPIList.heartbeat_req,pingContent)
	luaGC()
	--print("pingMsg  ")
end)

Net:set_onAppPauseFn(function(bl)
--	print("onApplicationPause ="..tostring(bl).." isConnected="..tostring(Net.isConnected))
	--Net:send(pingMsg)
--	print("pingMsg onAppPause  "..CUtils.getDateTime())
	if bl==false then
		if Net.isConnected==false then Net:ReConnect() end
	end
end)

Net:set_onReConnectFn(function(net)
	--print("onReConnectFn")
	--delay(showNetworkInfo,2,"waiting reconnection")
end)

Net:set_onMessageReceiveFn(function(m)
	local ty=m:get_Type()
	local dataStruct=NetAPIList:getDataStructFromMsgType("MSGTYPE"..tostring(ty))
	print(" onMessageReceive  type="..tostring(ty).." Length="..tostring(m:ToArray().Length).." dataStruct ="..dataStruct)
	-- print(m:Debug())
	-- print(m)
	local model=NetProtocalPaser:parseMessage(m,ty)
	Proxy:distribute(ty,model)
end)

Net:set_onConnectionCloseFn(function(net)
	print("onConnectionClose")
	--showTips("你的网络已断开！点击确定重新连接。",onReConnect)
	--	geTips.show(geTips.GE_TIP,"Connection lose")
	Net:ReConnect()
end)

Net:set_onConnectionTimeoutFn(function(net)

	print("Connection time out")
	--showTips("网络连接超时,点击确定重新连接。",onReConnect)
	--showNetworkInfo("connection time out")

	Net:ReConnect()
end)

Net.onReConnectFn=function()
	-- body
	--print("onReConnect")
	--Net:ReConnect()
end

function callbackHert( data )
	print("hertbeat..")
	printTable(data)
	local cont = NetMsgHelper:makept_int(1)
  	Proxy:send(NetAPIList.heartbeat,cont)
end

function startHertbeat()
	print("start hertbeat..")
  	local cont = NetMsgHelper:makept_int(1)
  	Proxy:send(NetAPIList.start_heartbeat,cont)
  	Proxy:binding(NetAPIList.heartbeat,callbackHert)
end

function callback_notifygood(data)
	print("-=-=-=-=---=-callback_notifygood:" .. data["command"])
	--报错
	if ServerCommonNotify[data["command"]] ~= nil then
		local fun = ServerCommonNotify[data["command"]].fun
  		if fun ~= nil then fun(data) end
	end
end

function callback_notifybad(data)
  -- login:onShowErrorInfo(data["errno"])
  if ServerCommonNotify[data["command"]] ~= nil then
	  local funex = ServerCommonNotify[data["command"]].funex
	  if funex ~= nil then funex(data) end
 end
end

function bindCommonNotify(api,fun,funex)
	local table = {}
	table.code = api.Code
	table.fun = fun
	table.funex = funex
	ServerCommonNotify[api.Code] = table
	print("-=-=-=-=---=-bindCommonNotify:" .. api.Code)
	printTable(ServerCommonNotify)
end
