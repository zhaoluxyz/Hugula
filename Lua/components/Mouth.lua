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
function Mouth:Start()
	self.hugula = self.luaObject
end

function Mouth:eat(food)
	self.isEatting = true
	self:DispatchEvent(Event.MOUTH_OPEN)

	self.hugula:play(HUGULA_ANIMATIONS.EAT)

	local function ateSuprise()
		if food.makeMad then
			self:mad()
		else
			self:foodAte()
		end
	end
	
	local function onAte()
		food:beEatted(self)

		if food.isSuprise then
			self.hugula:play(HUGULA_ANIMATIONS.SUPRISE)

			DelayDo:Add(ateSuprise,1.5)
		else
			self:foodAte()
		end
	end

	DelayDo:Add(onAte,food.chewTime)
end

function Mouth:mad()
	self.hugula:play(HUGULA_ANIMATIONS.MAD)

end

function Mouth:foodAte()
	self.hugula:play(HUGULA_ANIMATIONS.IDLE)
	self.isEatting = false
end

function Mouth:hiccup()
	self.hugula:play(HUGULA_ANIMATIONS.HICCUP)
	self.isEatting = true

	self:DispatchEvent(Event.MOUTH_OPEN)

	DelayDo:Add(self.foodAte,1,self)
end

