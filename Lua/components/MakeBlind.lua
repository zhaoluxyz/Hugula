local MakeBlind = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeBlind"
end)
LuaComponents:Add("MakeBlind",MakeBlind)
--------------------------------------------------
function MakeBlind:onEatted(mouth)
	
end
--------------------------------------------------
