------------------------------------------------
--  Copyright © 2013-2014   Hugula: Arpg game Engine
--   
--  author pu
------------------------------------------------
require("const.importClass")
require("net.netMsgHelper")
require("net.netAPIList")
require("net.netProtocalPaser")
require("net.proxy")
require("const.requires")
require("registerItemObjects")
require("registerState")
require("uiInput")

local os=os
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local StateManager=StateManager
local Net=Net
local Msg=Msg

-------------------------------------------------------------------------------

local Proxy=Proxy
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList

-- StateManager:setCurrentState(StateManager.gameloading)--StateManager.login

require("Net_game")
