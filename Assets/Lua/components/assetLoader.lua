--Gameobject 资源集合
GAMEOBJECT_ATLAS={}
local loadCount=0
local loadCurr=0
local LuaHelper=LuaHelper
local Loader=Loader
local CUtils=CUtils
local Asset = Asset

local GAMEOBJECT_ATLAS = GAMEOBJECT_ATLAS
local AssetLoader=class(function(self,luaObj)
	self.items={}
	self.luaObj=luaObj
	self.asserts = nil
end)

function AssetLoader:onAssetLoaded(key,asset)
	self.asserts[key]=asset.items
	self.asserts[key.."_root"]=asset.root
	loadCurr=loadCurr+1
	self.luaObj:sendMessage("onAssetLoad",key,asset)
	if loadCurr >= loadCount then
		self.luaObj:sendMessage("onAssetsLoad",self.asserts)
	end
end

function AssetLoader:loadAssets(asserts)
	local req = nil
	local reqs = {}
	local url = "" local key=""
	local asset = nil

	local onReqLoaded=function(req)
		local main=req.data.assetBundle.mainAsset
		local root=LuaHelper.Instantiate(main)
		root.name=main.name
		local ass = req.head

		local baseAsset=Asset(ass.url)
		baseAsset.root=root
		local eachFn =function(i,obj)
			baseAsset.items[obj.name]=obj
		end

		LuaHelper.ForeachChild(root,eachFn)
		local key = ass.key  --CUtils.GetKeyURLFileName(ass.url)
		GAMEOBJECT_ATLAS[key]=baseAsset
		baseAsset:copyTo(ass)
		Loader:clear(req.key)
		self:onAssetLoaded(key,ass)
	end

	local onErr=function(req) end

	for k,v in ipairs(asserts) do
		key = v.key
		local asst=GAMEOBJECT_ATLAS[key]
		if asst then
			asst:copyTo(v)
			self:onAssetLoaded(key,v)
		else
			req={v.fullUrl,onReqLoaded,onErr,v}
			table.insert(reqs,req)
		end
	end
	Loader:getResource(reqs)
end

function AssetLoader:clear()
	local at = GAMEOBJECT_ATLAS[self.name]
	GAMEOBJECT_ATLAS[self.name]=nil
	if at then LuaHelper.Destroy(at.root) end
	self.items=nil
	self.url=nil
	self.name=nil
end

-- function AssetLoader:onLoaded(root)
-- 	LuaHelper.Foreach(root,eachFn)
-- 	GAMEOBJECT_ATLAS[self.name]=self
-- 	luaObj:sendMessage("onAssetLoaded",root)
-- end

function AssetLoader:load(asts)
	loadCount = #asts
	loadCurr = 0
	self.asserts = {}
	self:loadAssets(asts)
end

function clearAssets()
	for k,v in pairs(GAMEOBJECT_ATLAS) do
		print(k.." is Destroy ")
		if v then LuaHelper.Destroy(v.root) end
	end
	GAMEOBJECT_ATLAS={}
end

return AssetLoader