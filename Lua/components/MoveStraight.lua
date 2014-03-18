local MoveStraight = Class(Movement, function(self)
	Movement._ctor(self)
	self.name = "MoveStraight"

	self.speed = 1
	self.dir = Vector3(0,-1,0)
end)
LuaComponents:Add("MoveStraight",MoveStraight)
--------------------------------------------------
function MoveStraight:movementFn()
	local pos = self.luaObject.transform.localPosition
	
	local x = Time.deltaTime*self.speed*self.dir.x + pos.x
	local y = Time.deltaTime*self.speed*self.dir.y + pos.y
	local z = Time.deltaTime*self.speed*self.dir.z + pos.z
	pos = Vector3(x,y,z)

	self.luaObject.transform.localPosition = pos
end


