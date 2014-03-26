local Food = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
	self.name = "Food"
	self.chewTime = TUNING.DEFAULT_CHEW_TIME 
end)
LuaComponents:Add("Food",Food)
--------------------------------------------------
Event.FOOD_ATE = "foodAte"
--------------------------------------------------
function Food:OnAdd()
	Foods:add(self)
end

function Food:OnDestroy()
	Foods:remove(self)
end

function Food:beEatted(mouth)
	self:DispatchEvent(Event.FOOD_ATE, mouth)

	self.luaObject:Destroy()
end

function Food:FixedUpdate()
	if self.luaObject.gameObject.transform.position.y<-2 then
		self.luaObject:Destroy()
	end
end

