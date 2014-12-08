luanet.load_assembly(assemblyname)



-- loadByUrl(url,onComp)
-- require("core.unity3d")
-- require("core.loader")
-- json=require("lib/json")

CUtils = toLuaCS.CUtils --LCUtils
local url= CUtils.GetAssetFullPath("Map01.u3d")
Request=luanet.LRequest
local req=Request(url)

local t = 1000

CUtils=toLuaCS.CUtils
-- print(getmetatable(CUtils))
-- printTable(toLuaCS)
local b=os.clock()
local k1="sddd"..tostring(b)
for i=1,t do
	req.key=k1
	k=req.key
	-- CUtils.ADD(1,i)
	-- CUtils.GetAssetFullPath("Map01.u3d")
end
local dt = os.clock()-b
print(string.format(" lua times = %s, dt=%s, re =%s",t,dt*1000,1))
Localization = toLuaCS.Localization--luanet.import_type("Localization") --toLuaCS.Localization --

local Localization = Localization
-- Localization.set_language("Chinese")
Localization.language="Chinese"
-- print(Localization.__index(Localization,"language"))

-- print(Localization.language)
-- LMultipleLoader = luanet.LMultipleLoader
-- print(luanet.ctype(LMultipleLoader))
-- print(getmetatable(LMultipleLoader))
-- local loader=LMultipleLoader.get_instance
-- print(loader)
-- print(luanet.ctype(loader))
-- print(getmetatable(loader))

local testfn = function()
	local b=os.clock()
	for i=1,t do
		Localization.Get("quest_title_600001")
	end
	local dt = os.clock()-b
	print(string.format(" language lua times = %s, dt=%s, re =%s",t,dt*1000,1))
end

delay(testfn,2)
