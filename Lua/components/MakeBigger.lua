local MakeBigger = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeBigger"
end)
LuaComponents:Add("MakeBigger",MakeBigger)
--------------------------------------------------
function MakeBigger:onEatted(mouth)
	print(mouth.luaObject.name .. " is bigger now")
end
--------------------------------------------------
