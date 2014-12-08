local LuaHelper=LuaHelper
BattleCache = {}

local BattleCache=BattleCache

--缓存战斗要使用的模型资源
BattleCache.modelCache={}

function BattleCache:clearModel()
	for k,v in pairs(BattleCache.modelCache) do
		print(k)
		print(v)
		print(LuaHelper)
		LuaHelper.Destroy(v)
	end
	BattleCache.modelCache={}
end

function BattleCache:addModel(key,gameobject)
	local tb = BattleCache.modelCache
	tb[key]=gameobject
end

function BattleCache:getModel(key)
	local tb = BattleCache.modelCache
	return tb[key]
end
