local MakeFrozenTime = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeFrozenTime"
end)
LuaComponents:Add("MakeFrozenTime",MakeFrozenTime)
--------------------------------------------------
function MakeFrozenTime:onEatted(mouth)
	
end
--------------------------------------------------
