local russia = LuaItemManager:getItemObject("russia")

local LuaObject=LuaObject
local isover=false

local assets=
{
 	Asset(SINGLE,"BlockRoot.u3d")
}

local function ceraterussiaBlock( ... )
	 local bolck = LuaObject("bolck")
	bolck:addComponent("russianBlocks.block")
	bolck:addComponent("russianBlocks.blockManager")
	bolck:addComponent("assetLoader"):load(assets)
	bolck:addComponent("russianBlocks.uiBlock")
	russia.bolck=bolck
	print("ceraterussiaBlock ed")
	return bolck
end

function russia:onClick(obj,arg)
	--print("you are click "..obj.name )
	--print(obj)
	local cmd =obj.name 
	if isover and cmd=="NGUIEvent" then
		russia.bolck.components.blockManager:gameStart()	
		isover=false
	end
end

function russia:gameOver(blockManager)
	print("russia:gameOver")
	isover=true
end

function russia:onBlur()
 	if russia.bolck~=nil then russia.bolck:hide() end
 	russia.bolck = nil
end

function russia:onFocus( ... )
	print("onFocus")
	if russia.bolck==nil then
		local block=ceraterussiaBlock()
		block.parent=self
	else
		russia.bolck.components.blockManager:gameStart()
	end
	isover=false
end