local alertTips = LuaItemManager:getItemObject("alertTips")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
alertTips.priority=99
alertTips.assets=
{
    Asset("UIPublic.u3d",{"AlertPanel"})
}

------------------private-----------------
local alertRefer,tipsLabel
local callBackFn,text

------------------public------------------

function alertTips:onAssetsLoad(items)
  -- print("alertTips ................. is loaded")
  alertRefer = LuaHelper.GetComponent(self.assets[1].items["AlertPanel"],"ReferGameObjects") 
  tipsLabel=alertRefer.monos[0]
  self:show()
end

--初始化函数只会调用一次
function alertTips:initialize()
    -- print(self.name.." initialize")
end

--显示提示信息
function alertTips:showTips(msg,callBack)
    text=msg
    callBackFn = callBack
    -- print("showTips . . . . . . . "..text)
    self:addToState()
end

function alertTips:onShowed()
    tipsLabel.text = text
    -- print(" show alertTips lable"..text)
end

--点击事件
function alertTips:onClick(obj,arg)
    local cmd =obj.name
    if cmd == "BtnSure" then
      self:removeFromState()
      if callBackFn then callBackFn() end
    elseif cmd == "BtnClose" then
      self:removeFromState()
    end
    callBackFn = nil      
    return true
end

-----------------global function --------------------------
function showTips(msg,callBack)
  -- print("showTips . . . . . . . ")
  alertTips:showTips(msg,callBack)
end