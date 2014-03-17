TestLuaObject = Class(LuaObject, function(self, assetName, value)
    LuaObject._ctor(self, assetName)
    self.value = value
end)

function TestLuaObject:testFn()
	print("there is a testLuaObject")
end