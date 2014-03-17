local MakeUnStoppable = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeUnStoppable"
end)
LuaComponents:Add("MakeUnStoppable",MakeUnStoppable)
--------------------------------------------------
function MakeUnStoppable:onEatted(mouth)
	
end
--------------------------------------------------
