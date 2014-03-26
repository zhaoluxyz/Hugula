local Rigidbody = Class(LuaComponent, function(self)
	LuaComponent._ctor(self) 
	self.name = "Rigidbody"
end)
LuaComponents:Add("Rigidbody",Rigidbody)
-------------------------------------------------------------
function Rigidbody:OnAdd()
	self.rigidMono = self.luaObject.gameObject:AddComponent("Rigidbody")
	self.rigidMono.drag = 0.5
 	self.rigidMono:Sleep()
end

function Rigidbody:sleep()
	self.rigidMono:Sleep()
end

function Rigidbody:wakeUp()
	self.rigidMono:WakeUp()
end

function Rigidbody:addForce(vector3)
	self:wakeUp()
	self.rigidMono:AddForce(vector3)
end

function Rigidbody:OnDestroy()
	if self.rigidMono then
		Component.Destroy(self.rigidMono)
	end
end