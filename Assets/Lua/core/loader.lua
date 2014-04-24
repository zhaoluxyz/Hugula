Loader={}

local ArrayList=luanet.import_type("System.Collections.ArrayList")
local LMultipleLoader=luanet.import_type("LMultipleLoader")
LMultipleLoader=LMultipleLoader.instance
local Request=Request

local Loader=Loader 
Loader.multipleLoader=LMultipleLoader
Loader.resdic={} --cache dic
LMultipleLoader.cache=Loader.resdic

local function dispatchComplete(req)
	if req.onCompleteFn then req.onCompleteFn(req) end
end

local function loadByUrl(url,compFn,cache,endFn,head)
	local req=Request(url)	
	if compFn then req.onCompleteFn = compFn end
	if endFn then req.onEndFn = endFn end
	if head~=nil then req.head = head end
	if cache==nil or cache==true then req.cache=true end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:loadReq(req)
	end
end

local function loadByReq( req,cache )
	if cache==nil or cache==true then req.cache = true end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:loadReq(req)
	end
end

local function loadByTable(tb,cache)
	local arrList={} --ArrayList()
	local len=#tb
	local key = ""
	for i=1,len do
		local v = tb[i]
		local l1=#v
		local req=Request(v[1])
		key=req.key
		if l1>1 then req.onCompleteFn=v[2] end
		if l1>2 then req.onEndFn=v[3] end
		if l1>3 then req.head=v[4] end
		if cache==nil or cache==true then req.cache=true end
		local cacheData=Loader.resdic[key]
		if cacheData~=nil then req.data=cacheData dispatchComplete(req)
		else table.insert(arrList,req)--arrList:Add(req)
		end
	end
	--print("load by table")
	--printTable(tb)
	Loader.multipleLoader:loadReq(arrList)
end

local function loadByArray( arrList ,cache)
	local arrListRe={} --ArrayList()
	local len=arrList.Count-1
	local key = ""
	for i=1,len do
		local req = arrList[i]
		key=req.key
		if cache==nil or cache==true then req.cache=true end
		local cacheData=Loader.resdic[key]
		if cacheData~=nil then req.data=cacheData dispatchComplete(req)
		else table.insert(arrList,req)--arrListRe:Add(req)
		end
	end
	Loader.multipleLoader:loadReq(arrListRe)
end


function Loader:clearItem(key)
	local www =	self.resdic[key]
	-- if www then
	-- 	if www.assetBundle~=null then www.assetBundle:Unload(false) end
	-- 	www:Dispose()
	-- 	www = nil
	-- end
	self.resdic[key]=nil 
end

function Loader:clear(key)
	if key then 
		self:clearItem(key)
	elseif (key==true) then
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
	--print("Loader:getResource type=" ..type(a))
	--url,onComplete
	if type(a)=="string" then 
		loadByUrl(a,b,c,d)
	elseif type(a)=="userdata" then
		loadByReq(a,b)
		-- local t = a:GetType().name--CUtils.GetType(a).Name
		-- if t=="LRequest" then	loadByReq(a,b)
		-- elseif t=="ArrayList" then loadByArray(a)
		-- end
	elseif type(a) == "table" then
		loadByTable(a,b)
	end
	--print("getResource  ed...."..tostring(a))
end

local function disposeWWW( www )
	www.assetBundle:Unload(false) 
	www:Dispose()
	www = nil
end

local function onCache( req)
	local key=req.key
	local www=req.data
	Loader.resdic[key]=www
end

local function onSharedComplete(req)
	local key=req.key
	local www=req.data
	Loader.resdic[key]=www.assetBundle.mainAsset
	--disposeWWW(www)
end

function Loader:setOnAllCompelteFn(compFn)
	self.multipleLoader.onAllCompleteFn=compFn
end

function Loader:setOnProgressFn(progFn)
	self.multipleLoader.onProgressFn=progFn
end


Loader.multipleLoader.onCacheFn=onCache
Loader.multipleLoader.onSharedCompleteFn=onSharedComplete