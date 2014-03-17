local Mouth = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
	self.name = "Mouth"

	self.isEatting = false
	self.tongueLen = TUNING.HUGULA_TONGUE_DEFAULT
	self.longTongueTime = TUNING.HUGULA_TONGUE_LONG_TIME
end)
LuaComponents:Add("Mouth",Mouth)
------------------------------------------------------

Event.MOUTH_OPEN = "mouthOpen"
------------------------------------------------------

function Mouth:eat(food)
	self.isEatting = true
	self:DispatchEvent(Event.MOUTH_OPEN,food)
	
	local function foodEatted()
		food:beEatted(self)
		self.isEatting = false
	end

	DelayDo:Add(foodEatted,food.chewTime)
end


