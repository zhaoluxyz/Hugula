---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: guide.lua
--data:2014.11.19
--author:pu
--desc:新手引导
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local guide = LuaItemManager:getItemObject("guide")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue --多国语言
local showTips = showTips --显示提示
local Rect = luanet.UnityEngine.Rect
local Vector3 = luanet.UnityEngine.Vector3
local Screen = luanet.UnityEngine.Screen
-----------------------net--------------------
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper

--UI资源
guide.assets=
{
    Asset("Guide.u3d")
}
guide.priority=100 --事件处理优先级别
guide.data = nil --引导位置数据
guide.onGuide = true
local refsMono = nil --root ReferGameObjects 
local masksMono = nil --遮罩快
local arrow = nil --箭头
local arrowOffx = nil --箭头偏移
local camera = nil
local center = nil
local hand1 = nil --手型引导
local moveHand1 = nil --手sprite
------------------private-----------------


------------------public------------------

--function guide:dispatch(id)
--        self.data = Model.getGuid(id)
--        if self.data then

--        end
--end

--隐藏引导
function guide:hideAllTips()
        masksMono.gameObject:SetActive(false)
        arrow.gameObject:SetActive(false)
        hand1.gameObject:setActive(false)
end

--获取下个节点数据
function guide:getNextData()
    if self.data.next~=0 then
        return Model.getGuid(self.data.next)
    end
    return nil
end

--指示UI
function guide:fllowUI()
--        if path == nil then  path= "UI Root/Container/Button" end
--        print(path)
        local path = self.data.position[1]
        local ui = LuaHelper.Find(path)
        local collider =  LuaHelper.GetComponent(ui,"BoxCollider")

        if collider~=nil then
            masksMono.gameObject:SetActive(true)
            local b = collider.bounds
            print(string.format("max = %s ,min = %s",b.max,b.min))
            local pt,pl =  camera:WorldToScreenPoint(b.max), camera:WorldToScreenPoint(b.min)
    --        print(string.format("Screen %s  %s",p1,p2))
            center = b.center
            self:fllowScreenBlock(pl,pt,self.data.sign,self.data.offx,self.data.rotateZ)
        else
                  delay(self.fllowUI,0.1,self)
        end
end

--指示角色
function guide:fllowActor()
         local paths = self.data.position
        local bleft,tright
        local battleMap = LuaItemManager:getItemObject("battleMap")

        for k,v in ipairs(paths) do
            local ui = battleMap[v[1]]
            if ui and ui[v[2]] then
                local collider =  LuaHelper.GetComponent(ui[v[2]].gameObject ,"BoxCollider")
                if collider then
                    local b = collider.bounds
                    local _right,_left =  camera:WorldToScreenPoint(b.max), camera:WorldToScreenPoint(b.min)
                        tright,bleft=_right,_left 
                        center = b.center
                end
            end
        end

        if bleft and tright then
            hand1.gameObject:SetActive(true)
            self:fllowScreenBlock(bleft,tright,self.data.sign,self.data.offx,self.data.rotateZ)
        else
                  delay(self.fllowActor,0.1,self)
        end
end

--指示一个屏幕区域快
function guide:fllowScreenBlock(pbl,ptr,sign,offx,rotZ)
        local pMin = camera:ScreenToWorldPoint(pbl)
        local pMax = camera:ScreenToWorldPoint(ptr)
        local monos = masksMono.monos
--        print("fllowScreenBlock")
--        print(offx)
--        print(rotZ)
        offx = offx or -86
        rotZ = rotZ or 90
        monos[0].transform.position = Vector3(0,pMax.y,0)
        monos[1].transform.position = Vector3(pMin.x,0,0)
        monos[2].transform.position = Vector3(pMax.x,0,0)
        monos[3].transform.position = Vector3(0,pMin.y,0)
        --箭头指示
        if sign == "hand1" then --战斗引导
          
        elseif sign == "hand2" then --

        else --普通引导
            arrow.gameObject:SetActive(true)
            arrow.position = center
            local eulerAngles =Vector3(0,0,rotZ)
            arrow.eulerAngles = eulerAngles
            arrowOffx.localPosition = Vector3(offx,0,0)
        end
end

function guide:showNextStep()
    local nex =  self:getNextData()
    print("showNextStep")
    if nex then
        self.data = nex
        printTable(nex)
        --loadstring(
        self:hideAllTips()
        self:showData()
    else
        self:hide()
        if self.callBack then self.callBack() end
    end
end

--显示引导
function guide:showData()
        if  self.data.type ==2 then
            self:fllowUI()
        else
            self:fllowActor()
        end
end

--点击事件
function guide:showGuide(id,callBack)
	self.data = Model.getGuid(id)
    self.callBack = callBack
    self:onFocus()
end

--检测引导完成
function guide:checkCondition(method,obj,arg)
--print(string.format("checkCondition  %s  %s  %s ",method,obj,arg))
    if self.onGuide and self.data then
        local condition = self.data.condition
        local condData = condition[method]
        if condData then
            local name =   obj.name
--            print(name)
--            print("condData"..condData)
--            print(string.match(name,condData))
--            print(condition.arg== arg)
             if string.match(name,condData) and  (condition.arg==nil or  condition.arg == arg) then
                    self:showNextStep()
             end
        end
    end
end
-----------------override-------------------
-- 资源加载完成时候调用方法
function guide:onAssetsLoad(items)
	 refsMono = LuaHelper.GetComponent(self.assets[1].root,"ReferGameObjects") 
     masksMono = refsMono.monos[0]
     local refers = refsMono.refers
     arrow = refers[0].transform
     arrowOffx = refers[1].transform
     camera = self.assets[1].items["Camera"].camera --UiCamera
     hand1 = refers[2].transform
     moveHand1 = refers[3]
--     self:fllowScreenBlock()
--    self:fllowUI()
end

--显示时候调用
function guide:onShowed( ... )
    if  self.data then
        self:showData()
    end
end

--初始化函数只会调用一次
function guide:initialize()

end

---------------------------------------------public---------------------------------

function showGuide(id,callBack)
    guide:showGuide(id,callBack)
end