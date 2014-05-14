require("core.luaObject")
require("core.asset")

local os=os
local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
-- local SINGLE=SINGLE local SHARE=SHARE


-- local LuaItemManager = LuaItemManager
-- LuaItemManager:registerItemObject("hello","state/hello")

-- local hello = LuaItemManager:getItemObject("hello")
-- hello:load()
--local assets=
--{
--	Asset(SINGLE,"BlockRoot.u3d")
--}

local bolck = LuaObject("bolck")
bolck:addComponent("russianBlocks.block")
bolck:addComponent("russianBlocks.blockManager")
bolck:addComponent("assetLoader"):load(assets)
bolck:addComponent("russianBlocks.uiBlock")


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

-- print(pLua.updateFn)