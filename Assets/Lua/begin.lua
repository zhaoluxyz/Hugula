require("core.luaObject")
require("core.asset")
local os=os
local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local LuaObject=LuaObject
local SINGLE=SINGLE local MULITPLE=MULITPLE
local assets=
{
	--Asset(SINGLE,"Hello.u3d"),
	Asset(MULITPLE,"BlockRoot.u3d")
}

local bolck = LuaObject("bolck")
-- bolck:addComponent("input")
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

print(pLua.updateFn)