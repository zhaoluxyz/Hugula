---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: waitingPanel.lua
--data:2014.7.1
--author:yue an bang
--desc:等待页面
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local waitingPanel = LuaItemManager:getItemObject("waitingPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils

waitingPanel.assets=
{
    Asset("UIPublic.u3d",{"waiting"})
}

------------------private-----------------

------------------public------------------

function waitingPanel:onAssetsLoad(items)
  self:show()
end

--初始化函数只会调用一次
function waitingPanel:initialize()
   -- print(self.name.." initialize")
end

function waitingPanel:showWaitingPanel()
  self:addToState()
end

function waitingPanel:onShowed()
end

function waitingPanelEnd()
  waitingPanel.isShow = false;
  waitingPanel:removeFromState()
end
-----------------global function --------------------------
function showWaitingPanel()
  if waitingPanel.isShow == true then return end
  waitingPanel.isShow = true;
  local fun=function() 
  	if waitingPanel.isShow == true then
  	  waitingPanelEnd()
  	end
  end
  delay(fun,8,nil)
  waitingPanel:showWaitingPanel()
end

