---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: networkInfo.lua
--data:2014.7.1
--author:yue an bang
--desc:测试用，网络方面信息
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local networkInfo = LuaItemManager:getItemObject("networkInfo")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils

networkInfo.assets=
{
    Asset("UIPublic.u3d",{"networkInfo"})
}

------------------private-----------------
local InfoRefer,InfoLabel,text

------------------public------------------

function networkInfo:onAssetsLoad(items)
  InfoRefer = LuaHelper.GetComponent(self.assets[1].items["networkInfo"],"ReferGameObjects") 
  InfoLabel = InfoRefer.monos[0]
  self:show()
end

--初始化函数只会调用一次
function networkInfo:initialize()
   -- print(self.name.." initialize")
end

--显示提示信息
function networkInfo:showNetworkInfo(msg)
    text=msg
    self:addToState()
end

function networkInfo:onShowed()
	InfoLabel.text = text
end

function showNetworkInfoEnd()
	--networkInfo:removeFromState()
	InfoLabel.text = ""
end
-----------------global function --------------------------
function showNetworkInfo(msg)
  	delay(showNetworkInfoEnd,5,nil)
  	networkInfo:showNetworkInfo(msg)
end

