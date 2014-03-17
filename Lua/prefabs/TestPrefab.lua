
local function TestPrefab()
	local luaObject = TestLuaObject("Cube",60)

	local com = luaObject:AddComponent("TestComponent")
	com.value = 1

	return luaObject
end

Prefabs:Add("TestPrefab",TestPrefab)
-------------------------------------------------------------