-- luanet.load_assembly(assemblyname)
-- loadByUrl(url,onComp)
require("core.unity3d")
require("core.loader")
json=require("lib/json")

-- CUtils =LCUtils
local url= CUtils.GetAssetFullPath("Map01.u3d")

local req=Request(url)

req.key="daddad"
print(req.key)

local onCom = function(...)
	print("onCom  ")
end

---------------------------------for test------------------------------
local t = 10000
local b=os.clock()
local k1="sddd"..tostring(b)
for i=1,t do
	-- req:set_onCompleteFn(onCom)
	-- k=req:get_onCompleteFn()
end
local dt = os.clock()-b
print(string.format(" lua times = %s, dt=%s, re =%s",t,dt*1000,k))

-- onCom = function(...)

-- end
b=os.clock()
for i=1,t do
	req.onCompleteFn=onCom
	k=req.onCompleteFn
end
dt = os.clock()-b
print(string.format(" lua times = %s, dt=%s, re =%s",t,dt*1000,k))
req:DispatchComplete()