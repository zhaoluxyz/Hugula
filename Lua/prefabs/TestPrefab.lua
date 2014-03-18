
local function TestPrefab()
	local luaObject = TestLuaObject("Cube",60)

	local com = luaObject:AddComponent("MoveStraight")
	com.speed = 1
	com:start()

	return luaObject
end

Prefabs:Add("TestPrefab",TestPrefab)
-------------------------------------------------------------