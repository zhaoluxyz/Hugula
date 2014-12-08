require("core.unity3d")
require("core.loader")
json=require("lib/json")
require("const.importClass")
require("net.netMsgHelper")
require("net.netAPIList")
require("net.netProtocalPaser")
require("net.proxy")
require("const.requires")
require("registerItemObjects")
require("registerState")
require("uiInput")

print("hello lan")
require("netGame")

local Proxy=Proxy
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local proxy = Proxy

local function gmReceive(msg)
	printTable(msg)
end

proxy:binding(NetAPIList.gm_cmd_req,gmReceive)