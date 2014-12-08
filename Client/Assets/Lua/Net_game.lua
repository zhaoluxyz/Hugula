local os=os
-- local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local StateManager=StateManager
local Net=Net
local Msg=Msg

-------------------------------------------------------------------------------

local Proxy=Proxy
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList


Net:set_onConnectionFn(function(net)
	print("game onConnection  ")
	--showNetworkInfo("network ready")
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

