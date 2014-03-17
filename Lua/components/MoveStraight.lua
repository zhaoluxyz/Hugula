local MoveStraight = Class(Movement, function(self)
	Movement._ctor(self)
	self.name = "MoveStraight"

	self.speed = 1
	self.dir = Vector(0,0,1)
end)
LuaComponents:Add("MoveStraight",MoveStraight)
--------------------------------------------------
function MoveStraight:movementFn()
	local pos = self.luaObject.transform.localPosition
	local vec = self.speed*self.dir
	pos = pos + vec

	self.luaObject.transform.localPosition = pos
end


