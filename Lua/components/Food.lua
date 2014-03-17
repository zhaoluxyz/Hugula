local Food = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
	self.name = "Food"
	self.chewTime = TUNING.DEFAULT_CHEW_TIME 
end)
LuaComponents:Add("Food",Food)
--------------------------------------------------
Event.FOOD_EATED = "foodEated"
--------------------------------------------------
function Food:beEatted(mouth)
	self:DispatchEvent(Event.FOOD_EATED, mouth)
end
