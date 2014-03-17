local MakeEscaper = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeEscaper"
	self.life = 1
end)
LuaComponents:Add("MakeEscaper",MakeEscaper)
--------------------------------------------------
function MakeEscaper:onEatted(mouth)
	
end
--------------------------------------------------
