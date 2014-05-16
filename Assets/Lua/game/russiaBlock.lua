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
	return bolck
end

function russia:onClick(obj,arg)
	print("you are click "..obj.name )
	--print(obj)
	local cmd =obj.name 
	print(self.bolck)
	print(self.bolck.enable)
	if self.bolck~=nil and self.bolck.enable then
		if cmd == "Up" then
			self.bolck:move(0)
		elseif cmd == "Down" then
			self.bolck:move(2)
		elseif cmd == "Left" then
			self.bolck:move(3)
		elseif cmd == "Right" then
			self.bolck:move(1)
		end
	end

	if isover and cmd=="NGUIEvent" then
		self.bolckObj.components.blockManager:gameStart()	
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
	if self.bolckObj==nil then
		self.bolckObj=ceraterussiaBlock()
		self.bolckObj.parent=self
		self.bolck=self.bolckObj.components.block
	else
		russia.bolck.components.blockManager:gameStart()
	end
	isover=false
end