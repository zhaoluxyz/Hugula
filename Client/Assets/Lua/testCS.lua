luanet.load_assembly(assemblyname)
GameObject=luanet.UnityEngine.GameObject

local b=os.clock()

local t=1000
local re=0
for i=1,t do
	re=GameObject(" name"..i)
end

local dt = os.clock()-b
print(string.format("反射 lua times = %s, dt=%s, re =%s",t,dt*1000,re))

GameObject=toluacs.UnityEngine.GameObject

b=os.clock()
re =0
for i=1,t do
	re=GameObject("toluacs name"..i)
end
local dt = os.clock()-b
print(string.format("toluacs times = %s, dt=%s, re =%s",t,dt*1000,re.name))
