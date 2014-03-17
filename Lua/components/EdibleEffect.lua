EdibleEffect = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
end)
--------------------------------------------------
function EdibleEffect:onEatted(mouth)end -- for override

--------------------------------------------------
function EdibleEffect:Start()
	self.food = self.luaObject:GetComponent("Food")
	if self.food then
		self.food:AddEvent(Event.FOOD_EATED,EdibleEffect.onEatted)
	else
		error("! EdibleEffect Component must Under a Food Component")
	end
end

function EdibleEffect:OnDestroy()
	if self.food then
		self.food:RemoveEvent(Event.FOOD_EATED,EdibleEffect.onEatted)
	end
end