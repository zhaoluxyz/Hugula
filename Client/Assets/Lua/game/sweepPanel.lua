---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: sweepPanel.lua
--data:2014.10.13
--author:yue an bang
--desc:扫荡功能
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local sweepPanel = LuaItemManager:getItemObject("sweepPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local Vector3 = UnityEngine.Vector3
local Encodeing = luanet.import_type("System.Text.Encoding")
local Quaternion = UnityEngine.Quaternion
local Net=Net.instance
local LFunction = LFunction.instance
local Proxy=Proxy
local Model = Model
local getValue = getValue
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
print("sweepPanel....")
print(onShowSweepPanel)
sweepPanel.assets=
{
   Asset("sweepPanel.u3d"),
}

sweepPanel.titleLableValue = 
{
  [0]="task_sweep_001",
  [1]="task_sweep_002"
}

sweepPanel.state = "waiting"--result,run


--==================================================================================================
local curChapterId
local rootPanel,popInfoPanel,heroPanel,itemPanel,curTurnNum_Lable,title_Lable
local scroll_L_btn,scroll_R_btn,roleItem_clone
local Lv_Lable,EXP_Lable,EXP_Progress,Gold_Lable
local role_clone = {}
local item_Sprite = {}
local curPage = 0
local curSweepLeft = 0
local bOnceSweep = true
local bFirst = true
local sweepData = {}
--==================================================================================================

--==================================================================================================
function sweepPanel:onAssetsLoad(items)
  local Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  rootPanel = Refer.monos[23]
  popInfoPanel = Refer.monos[0]
  title_Lable = Refer.monos[1]
  roleItem_clone = Refer.monos[2]
  curTurnNum_Lable = Refer.monos[3]
  Lv_Lable = Refer.monos[4]
  EXP_Lable = Refer.monos[5]
  EXP_Progress = Refer.monos[6]
  Gold_Lable = Refer.monos[7]
  for i=0,5 do
    item_Sprite[i] = Refer.monos[8+i]
  end
  
  sweepPanel:initProgress()

  scroll_L_btn = Refer.monos[14]
  scroll_R_btn = Refer.monos[15]
  heroPanel = Refer.monos[16]
  itemPanel = Refer.monos[17]
  
  sweepPanel:toState("waiting",true)
  sweepPanel:msgCallbackBind()
  self:show()
  bFirst = false
  waitingPanelEnd()
end

function sweepPanel:initProgress()
  local Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  for i=0,4 do
    role_clone[i] = Refer.monos[18+i]
    local Refer = LuaHelper.GetComponent(role_clone[i].gameObject,"ReferGameObjects")
    local Progress = LuaHelper.GetComponent(Refer.monos[2].gameObject,"UISlider")
    Progress.Value = 0
  end

  local ProgressLv = LuaHelper.GetComponent(EXP_Progress.gameObject,"UISlider")
  ProgressLv.Value = 0
end

function sweepPanel:isState(state)
  return (sweepPanel.state == state)
end

function sweepPanel:updateItemPageButton()
  if sweepPanel:isState("result") == false then
    scroll_L_btn.gameObject:SetActive(false)
    scroll_R_btn.gameObject:SetActive(false)
    return
  end

  if curPage <= 1 then
    scroll_L_btn.gameObject:SetActive(false)
    if bOnceSweep  == false then
      scroll_R_btn.gameObject:SetActive(true)
    end
  elseif curPage == 10 then
    scroll_L_btn.gameObject:SetActive(true)
    scroll_R_btn.gameObject:SetActive(false)
  else
    if bOnceSweep == false then
      scroll_L_btn.gameObject:SetActive(true)
      scroll_R_btn.gameObject:SetActive(true)
    end
  end
end

function sweepPanel:updateState(bInit)
  if sweepPanel:isState("result") then
    heroPanel.gameObject:SetActive(true)
    itemPanel.gameObject:SetActive(true)
    curTurnNum_Lable.gameObject:SetActive(true)
    title_Lable.text = getValue(sweepPanel.titleLableValue[1]) 
    sweepPanel:updateItemPageButton()
  end

  if sweepPanel:isState("run") then
    heroPanel.gameObject:SetActive(true)
    itemPanel.gameObject:SetActive(true)
    curTurnNum_Lable.gameObject:SetActive(true)
    scroll_L_btn.gameObject:SetActive(false)
    scroll_R_btn.gameObject:SetActive(false)
  end

  if sweepPanel:isState("waiting") then
    print("....waiting.....")
    sweepPanel:waitingSweep(bInit)
  end
end

function sweepPanel:waitingSweep(bInit)
  scroll_L_btn.gameObject:SetActive(false)
  scroll_R_btn.gameObject:SetActive(false)
  if bInit ~= nil and bInit == true then
    curTurnNum_Lable.gameObject:SetActive(false)
    heroPanel.gameObject:SetActive(false)
    itemPanel.gameObject:SetActive(false)
  end
  
  --sweepPanel:initProgress()

  title_Lable.text = getValue(sweepPanel.titleLableValue[0]) 
  sweepData = {}
  curPage = 0
  curSweepLeft = 0
end

function sweepPanel:updatePage()
  curTurnNum_Lable.text = tostring(curPage)
  sweepPanel:updateItemPageButton()
  sweepPanel:updateRolePage()
  sweepPanel:updateItemPage()
end

function sweepPanel:toState(state,bInit)
  sweepPanel.lastState = sweepPanel.state
  sweepPanel.state = state
  sweepPanel:updateState(bInit)
end

function sweepPanel:updateItemPage()
  local data = sweepData[curPage]
  local playerInfo = Model:getPlayerInfo()
  Lv_Lable.text = data["player_lv"]
  EXP_Lable.text = "+" .. data["player_exp"]
  
  Gold_Lable.text = "+" .. data["gold"] 
  local ProgressEffect = LuaHelper.GetComponent(EXP_Progress.gameObject,"progressEffect")
  local fexp = data["player_cur_exp"] / playerInfo.maxExp
  ProgressEffect:ChangeValueTo(fexp-fexp%0.01,data.player_is_up)
  
  for i=0,5 do
    item_Sprite[i].gameObject:SetActive(false)
  end
  local index = 0
  if data.goods  then
    for k,v in pairs(data["goods"]) do
      item_Sprite[index].gameObject:SetActive(true)
      item_Sprite[index].name = "itemID" .. v["goods_id"]
      item_Sprite[index].spriteName = Model.getItemData(v["goods_id"]).icon
      index = index + 1
    end
  end
end

function sweepPanel:updateRolePage()
  for i=0,4 do
    role_clone[i].gameObject:SetActive(false)
  end

  local data = sweepData[curPage]
  local roleNum = 0

  if data.hero_exp == nil then
    return
  end

  for k,v in pairs(data["hero_exp"]) do
    local role = role_clone[roleNum]
    roleNum = roleNum + 1
    role.gameObject:SetActive(true)
    local Refer = LuaHelper.GetComponent(role.gameObject,"ReferGameObjects")
    local roleIcon = Refer.monos[0]
    local lv = Refer.monos[1]
    local Progress = Refer.monos[2]
    local exp = Refer.monos[3]
    local ProgressEffect = LuaHelper.GetComponent(Progress.gameObject,"progressEffect")
    local fexp = v.cur_exp / v.max_exp
    ProgressEffect:ChangeValueTo(fexp - fexp%0.01,v.isup)
    roleIcon.spriteName = Model.getUnit(v.system_hero_id).icon
    lv.text = "Lv." .. v.hero_lv
    exp.text = "EXP +" .. v.exp
  end
end

function sweepPanel:msgCallbackBind()
  Proxy:binding(NetAPIList.recv_player_sweep_chapter,callback_sweepMessage)
end

function callback_sweepMessage(data)
  print("callback_sweepMessage")
  printTable(data)
  waitingPanelEnd()

  curSweepLeft = curSweepLeft - 1
  curPage = curPage + 1
  print("-=-=-=-=-=-curSweepLeft-=-=-=-=-" .. curSweepLeft)
  if curSweepLeft > 0 then
    delay(sweepPanel.onSendSweep,3,nil)
    sweepPanel:toState("run") 
  else
    sweepPanel:toState("result") 
  end
  sweepData[curPage] = data.drop
  sweepPanel:updatePage() 
end

function sweepPanel:onClick(obj,arg)
  local cmd = obj.name
  if cmd == "ButtonClose" then
    print("sweepPanel ButtonClose")
    showchapterPanelEX()
    rootPanel.gameObject:SetActive(false)
    self:removeFromState()
  elseif cmd == "Button_sweep_once" then
    bOnceSweep = true  
    sweepPanel:onSweep(1)
  elseif cmd == "Button_sweep_tenth" then
    bOnceSweep = false 
    sweepPanel:onSweep(10)
  elseif cmd == "scroll_notify_img_L" then
    sweepPanel:onChangePage(true)
  elseif cmd == "scroll_notify_img_R" then  
    sweepPanel:onChangePage(false)
  elseif string.find(cmd,"itemID") then
    --sweepPanel:onClickItem(obj)
  end
end

function sweepPanel:onClickItem(obj)
  local index = string.sub(obj.transform.parent.name,-1)
  sweepPanel:showPopItemInfo(obj,tonumber(index))
end

function sweepPanel:onPress(obj,arg)
  local cmd = obj.name
  if string.find(cmd,"itemID") then
    local index = string.sub(obj.transform.parent.name,-1)
    sweepPanel:showPopItemInfo(obj,tonumber(index))
  end
end

function sweepPanel:onChangePage(bPre)
  local bUpdate = false
  if sweepPanel:isState("result") == true then
    if bPre == true then
      if curPage > 1 then
        curPage = curPage - 1
        bUpdate = true
      end
    elseif curPage < 10 then
      bUpdate = true
      curPage = curPage + 1
    end
    if bUpdate == true then
      sweepPanel:updatePage()
    end
  end
end

function sweepPanel:onSweep(index)
  if sweepPanel:isState("run") then
    print("cur state is run,return error...")
    return
  end

  sweepPanel:toState("run")
  sweepPanel:waitingSweep(true)
  sweepPanel:onSendSweep(index)
end

function sweepPanel:onSendSweep(index)
  if index == nil then
    index = curSweepLeft
  end
  curSweepLeft = index
  print("curSweepLeft.." .. curSweepLeft)
  showWaitingPanel()
  local cont = NetMsgHelper:makesend_challenge_chapter(curChapterId)
  Proxy:send(NetAPIList.player_sweep_chapter,cont)
end

function sweepPanel:showPanel(index)
  curChapterId = index
  self:addToState()
  if bFirst == false then
    waitingPanelEnd()
  end
end

function sweepPanel:onClickInfo(obj)

end

function sweepPanel:onBlur()
  sweepPanel:toState("waiting",true) 
end

function sweepPanel:showPopItemInfo(obj,index)
  local refer = LuaHelper.GetComponent(popInfoPanel.gameObject,"ReferGameObjects")
  local posY = popInfoPanel.transform.position.y
  local posX = obj.transform.position.x
  local vector = Vector3(posX,posY,0)
  popInfoPanel.transform.position = vector
  local BGSprite = refer.monos[5]
  if index < 4 then
    local vector = Vector3(100,-15,0)
    BGSprite.transform.localPosition = vector
  else
    local vector = Vector3(-100,-15,0)
    BGSprite.transform.localPosition = vector
  end

  local id = string.sub(obj.transform.name,7) 
  local table = Model.getItemData(id)
  printTable(table) 

  if table ~= nil then
    obj.spriteName = table.icon
    print(obj)
    refer.monos[0].spriteName =  table.icon -- iconSprite
    refer.monos[1].text = table.usable_level
    refer.monos[2].text = getValue(table.name)
    refer.monos[4].text = getValue(table.Desc2)
  end
end

--=====================================globle=====================================

function onShowSweepPanel(index)
  print("----onShowSweepPanel-----")
  --printTable(data)
  sweepPanel:showPanel(index) 
end

