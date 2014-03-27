local Mouth = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
	self.name = "Mouth"

	self.isBusy = false
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

function Mouth:FixedUpdate()
	if not self.isBusy then
		for i,food in ipairs(Foods.objects) do 
			local posA = self.gameObject.transform.position
			local posB = food.gameObject.transform.position

			local distance = Vector3.Distance(posA,posB)

			if distance<self.tongueLen then
				self:eat(food)
				break
			end
		end	
	end
end

function Mouth:eat(food)
	self.luaObject:lookToTarget(food.gameObject.transform,0.5)
	food.luaObject:gotoMouth(self,0.3,0.1)

	self.isBusy = true
	self:DispatchEvent(Event.MOUTH_OPEN)

	self.luaObject:play(HUGULA_ANIMATIONS.EAT)

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
			self.luaObject:play(HUGULA_ANIMATIONS.SUPRISE)

			DelayDo:Add(ateSuprise,1.5)
		else
			self:foodAte()
		end
	end

	DelayDo:Add(onAte,food.chewTime)
end

function Mouth:mad()
	self.luaObject:play(HUGULA_ANIMATIONS.MAD)
end

function Mouth:foodAte()
	self.luaObject:play(HUGULA_ANIMATIONS.IDLE)
	self.isBusy = false
end

function Mouth:hiccup()
	self.luaObject:play(HUGULA_ANIMATIONS.HICCUP)
	self.isBusy = true

	self:DispatchEvent(Event.MOUTH_OPEN)

	DelayDo:Add(self.foodAte,1,self)
end

