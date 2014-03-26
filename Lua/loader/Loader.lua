-- local GameObject=UnityEngine.GameObject
-- local Vector3=UnityEngine.Vector3
-- local Quaternion=UnityEngine.Quaternion
-- local Random=UnityEngine.Random
local ArrayList=luanet.import_type("System.Collections.ArrayList")
local LMultipleLoader=luanet.import_type("LMultipleLoader")
local ArrayList=luanet.import_type("System.Collections.ArrayList")

LMultipleLoader=LMultipleLoader.instance
local Request=Request

Loader={}
Loader.multipleLoader=LMultipleLoader
Loader.resdic={} --cache dic

local function dispatchComplete(req)
	print(req.key.."  form cache ")
	if req.onCompleteFn then req.onCompleteFn(req) end
end

local function loadByUrl(url,compFn,cache,endFn)
	--local url1 = CUtils.getAssetPath(url)
    -- local url1 = CUtils.getFileFullPath(url)
	local req=Request(url)	
	if compFn then req.onCompleteFn=compFn end
	if endFn then req.onEndFn=endFn end
	if cache==nil or cache then req.cache=Loader.resdic end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:loadReq(req)
	end
end

local function loadByReq( req,cache )
	if cache==nil or cache then req.cache=Loader.resdic end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:loadReq(req)
	end
end

local function loadByTable(tb,cache)
	local arrList=ArrayList()
	local len=#tb
	local key = ""
	for i=1,len do
		local item = tb[i]
		local l1=#item
		local req=Request(v[1])
		key=req.key
		if l1>1 then req.onCompleteFn=v[2] end
		if l1>2 then req.onEndFn=v[3] end
		if cache==nil or cache then req.cache=Loader.resdic end
		local cacheData=Loader.resdic[key]
		if cacheData~=nil then req.data=cacheData dispatchComplete(req)
		else arrList:Add(req)
		end
	end
	Loader.multipleLoader:loadReq(arrList)
end

local function loadByArray( arrList ,cache)
	local arrListRe=ArrayList()
	local len=arrList.Count-1
	local key = ""
	for i=1,len do
		local req = arrList[i]
		key=req.key
		if cache==nil or cache then req.cache=Loader.resdic end
		local cacheData=Loader.resdic[key]
		if cacheData~=nil then req.data=cacheData dispatchComplete(req)
		else arrListRe:Add(req)
		end
	end
	Loader.multipleLoader:loadReq(arrListRe)
end


function Loader:clearItem(key)
	local www =	self.resdic[key]
	if www then
		if www.assetBundle~=null then www.assetBundle:Unload(false) end
		www:Dispose()
		www = nil
	end
	self.resdic[key]=nil 
end

function Loader:clear(key)
	if key then 
		self:clearItem(key)
	else
		for k, v in pairs(self.resdic) do
			self:clearItem(k)
		end
	end 
end

function Loader:unload(url)
	if url then
		local key=CUtils.getURLFullFileName(url)
		self:clearItem(key)
	end
end

function Loader:getResource(...)
	local a,b,c,d=...
	--url,onComplete
	if type(a)=="string" then 
		loadByUrl(a,b,c,d)
	elseif type(a)=="userdata" then
		local t = CUtils.GetType(a).Name
		if t=="LRequest" then	loadByReq(a,b)
		elseif t=="ArrayList" then loadByArray(a)
		end
	elseif type(a) == "table" then
		loadByTable(a,b)
	end
end

local function onCache( req)
	local key=req.key
	req.cache[key]=req.data
	print(key.." cached")
end

local function onSharedComplete(req)
	-- body
end

Loader.multipleLoader.onCacheFn=onCache
Loader.multipleLoader.onSharedCompleteFn=onSharedComplete