local HeroBrain=luanet.HeroBrain

local heroBrain=class(function(self)
	self.brain=HeroBrain()
       print("heroBrain.brain")
end)

return heroBrain