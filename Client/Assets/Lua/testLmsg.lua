require("core.unity3d")
require("core.loader")
json=require("lib/json")


local t = 10000
local b=os.clock()
local dt = os.clock()-b


local SkillData = luanet.SkillData
-- Transform = luanet.UnityEngine.Transform

local Cube=GameObject.Find("Cube")
sk1 = SkillData()
local v1=Vector3.up
local transform = Cube.transform
for i=1,t do
	transform.position=v1
end
dt = os.clock()-b
print(string.format(" lua times = %s, dt=%s, re =%s",t,dt*1000,1))


function loop(trans)
	local v = luanet.UnityEngine.Vector3.one
	for i=1,10000 do
		trans.position=v
	end
end