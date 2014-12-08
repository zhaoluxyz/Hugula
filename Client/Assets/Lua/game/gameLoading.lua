---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: gameLoading.lua
--data:2014.11.18
--author:pu
--desc:游戏预加载
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local LuaItemManager = LuaItemManager
local gameLoading = LuaItemManager:getItemObject("gameLoading")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue --多国语言
local showTips = showTips --显示提示
local Loader = Loader

-----------------------net--------------------
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper

--UI资源
gameLoading.assets=
{
     Asset("GameLoading.u3d")
}
-------------------local memeber--------------
local reqs=nil
local textF = nil
------------------private-----------------
local function  destoryFirstView()
        local logo = LuaHelper.Find("Frist")
		if logo then  LuaHelper.Destroy(logo) end 
end

local function onProgress(loader,arg)
        if textF then
            local p = arg.current/arg.total
            textF.text = string.format(" 加载资源中 %d %%",p*100)
        end
end

local function loadAllAssets()
    reqs = {}
    local items = LuaItemManager.items
    local itemObj = nil
--   local transform = StateManager.m_transform
   local allAssets ={}
    for k,v in pairs(items) do
        print(k)
        itemObj = LuaItemManager:getItemObject(k)
        if itemObj~=gameLoading  and itemObj.assets then
                for k,v in ipairs(itemObj.assets) do
                        table.insert(allAssets,v)
                end
        end
    end

    print(" begin load all assets ")
--    printTable(allAssets)
    Loader:setOnProgressFn(onProgress)
    gameLoading.assetLoader:load(allAssets)

end
------------------public------------------


-----------------parent----------------------
function gameLoading:onAssetLoad(key,asset)
        if key== "GameLoading" then
            destoryFirstView()   
            require("fun.loadCSV")
            self.loadAll=true
            textF =   LuaHelper.GetComponentInChildren(asset.root,"UILabel")

            loadAllAssets()
        else
            asset:hide()
        end
end

-- 资源加载完成时候调用方法
function gameLoading:onAssetsLoad(items)
     if self.loadAll then
        print("all resource loaded ")
        self.loadAll = false
       Loader:setOnProgressFn(nil)
       StateManager:setCurrentState(StateManager.login)--StateManager.login
     end

	-- local ReferScript = LuaHelper.GetComponent(self.assets[1].root,"ReferGameObjects") 
	-- local ReferScript1 = LuaHelper.GetComponent(self.assets[2].items["yourItemName"],"ReferGameObjects")
end

function gameLoading:onBlur()
    self:clear()        
end