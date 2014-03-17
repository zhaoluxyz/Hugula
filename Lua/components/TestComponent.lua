
local TestComponent = Class(LuaComponent, function(self)
    LuaComponent._ctor(self)
    self.name = "TestComponent"
    self.value = 1
end)

LuaComponents:Add("TestComponent",TestComponent)
-------------------------------------------------------------

function TestComponent:Start()
	self.luaObject:testFn()
	self.ang = self.luaObject.transform.localEulerAngles
	self.ang.y = 0
end

function TestComponent:Update()
	self.ang.y = self.ang.y+self.value
	self.luaObject.transform.localEulerAngles = self.ang
end

function TestComponent:OnDestroy()
	print(self.name .. "has been destroied")
end


