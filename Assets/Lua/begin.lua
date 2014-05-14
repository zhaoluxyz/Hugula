require("registerItemObjects")
require("registerState")
require("uiInput")
local os=os
local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local StateManager=StateManager


StateManager:setCurrentState(StateManager.main)

local function update()
	local len = #UPDATECOMPONENTS
	local cmp
	local ostime=os.clock()
	for i=1,len do
		cmp=UPDATECOMPONENTS[i]
		if cmp.enable then	cmp:onUpdate(ostime) end
	end
end

pLua.updateFn=update