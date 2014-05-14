require("core.unity3d")
require("core.loader")
json=require("lib/json")
print(" ---------------lua main ---------------------")

local resourceURL ="http://121.199.51.39:8080/client_update?v_id=%s&platform=%s&code=%s";

local progressBarTxt;
local update_id="";
local FRIST_VIEW = "Frist.u3d";
local VIDEO_NAME = "Loading.mp4";
local VERSION_FILE_NAME = "Ver.t";
local ResVersion = 0
local CUtils=CUtils
local RuntimePlatform=UnityEngine.RuntimePlatform
local Application=UnityEngine.Application
local GameObject=GameObject
local LuaHelper=LuaHelper
local Loader =Loader
local FileHelper=luanet.import_type("FileHelper")
local fristView


local function enterGame()
	print("enterGame")
	require("begin")
	if fristView then LuaHelper.Destroy(fristView) end
	fristView = nil 
end

local function onProgress(loader,arg)
	-- body
end

local function onUpdateItemComp(req)
	local bytes=req.data.bytes
	if(bytes~=nil) then
		FileHelper.UnZipFile(bytes,Application.persistentDataPath);
	end
end

local function onAllUpdateResComp(loader)
	--SetProgressTxt("wait start...");
    loader:setOnAllCompelteFn(nil)
	loader:setOnProgressFn(nil)
	seveVersion()
	enterGame()
end

local function seveVersion()
	FileHelper.PersistentUTF8File(update_id,VERSION_FILE_NAME)	
end

local function  onUpdateResComp(req)
    local www=req.data;
	if(www) then
		local txt=www.text;
        local res = json:decode(txt)
		if res["error"] then
			enterGame()
		elseif res["update_url"] then
			local upURL=res["update_url"]
			local reqs={}
			local len=#upURL
			for i=1,len do
				table.insert(reqs,{upURL[i],onUpdateItemComp})
			end
			Loader:getResource(reqs)
			Loader:setOnAllCompelteFn(onAllUpdateResComp)
			Loader:setOnProgressFn(onProgress)
		else
			enterGame()
		end
	end
end

local function checkRes()

	if(Application.platform==RuntimePlatform.OSXEditor) then
		enterGame()
	elseif(Application.platform==RuntimePlatform.WindowsEditor) then
		enterGame()
	else
		enterGame()
		-- local url=string.format(resourceURL,tostring(ResVersion),Application.platform,"0.2.0");
		-- local req=Request(url)
		-- req.onCompleteFn=onUpdateResComp

		-- local function onErr( req )
		-- 	print("checkRes on erro")
		-- 	enterGame()
		-- end
		-- print("begin checkRes "..url)
		-- req.onEndFn=onErr
	 --    Loader:getResource(req,false)
	end
end

local function checkVerion()
	local function onURLComp(req ) print(req.url.."  oncompleta")	ResVersion=req.data.text checkRes() end
	local function onURLErComp(req )  print(req.url.."  onErr") checkRes() end
	
	local verPath=CUtils.getFileFullPath(VERSION_FILE_NAME);
	print("checkVerion . verPath"..verPath)
	local req=Request(verPath)
	req.onCompleteFn=onURLComp
	req.onEndFn=onURLErComp
  	--print("request create "..tostring(req))
  	--print(Loader)
    Loader:getResource(req,false)
    --print("checkVerion . Loader:getResource called  "..verPath)
end

local function loadFrist()

	local function onLoadComp(r)
		Application.targetFrameRate=30;
		local www=r.data
		print(r.url.." loaded ")
		--print(www)
        fristView = LuaHelper.Instantiate(www.assetBundle.mainAsset)
        progressBarTxt = LuaHelper.GetComponentInChildren(fristView,"UILabel")
        progressBarTxt.text="loading new ..."
        www.assetBundle:Unload(false)
        www:Dispose()
        checkVerion()
    end

	local url = CUtils.getFileFullPath(CUtils.getAssetPath(FRIST_VIEW))
	print(url)
	Loader:getResource(url,onLoadComp,true)
end

loadFrist()
--require("begin")
print(" ---------------lua main end---------------------")
