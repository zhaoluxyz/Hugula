---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: chapterPanel.lua
--data:2014.7.1
--author:yue an bang
--desc:游戏关卡章节界面
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local chapterPanel = LuaItemManager:getItemObject("chapterPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local common_fun = common_fun
local Vector3 = UnityEngine.Vector3
local Encodeing = luanet.import_type("System.Text.Encoding")
local Quaternion = UnityEngine.Quaternion
local Net=Net.instance
local LFunction = LFunction.instance
local Proxy=Proxy
local Model = Model
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local Color = UnityEngine.Color
local UIButtonColor = luanet.UIButtonColor
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
print("chapterPanel....")
--==================================================================================================
chapterPanel.assets=
{
   Asset("chapterPanel.u3d"),
}
--==================================================================================================
local rootPanel,popInfoPanel,chapterItemClone,typeTxt,serverData
local curChapterType = 1
local bFirst = true
local bPress = false

--==================================================================================================
local curChapterData = {}
local curChapterItemList = {}
local curChapterIndex = 0
chapterPanel.chapterType = {
  "main_button_011",
  "main_button_012"
}
--==================================================================================================
function chapterPanel:onAssetsLoad(items)
  local Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  popInfoPanel = Refer.monos[0]
  rootPanel = Refer.monos[2]
  typeTxt = Refer.monos[1]
  chapterItemClone = Refer.refers[0]
  --progressExp = LuaHelper.GetComponent(Refer.monos[2].gameObject,"UISlider")
  --lableYu = Refer.monos[4]
  chapterPanel:InitData(getCurMainChapterID())
  chapterPanel:updateChapterPanel()
  chapterPanel:msgCallbackBind()
  self:show()
  bFirst = false
  waitingPanelEnd()
end

function chapterPanel:msgCallbackBind()
  bindCommonNotify(NetAPIList.player_challenge_chapter,callbackFightReq,callbackFightReqError)
  Proxy:binding(NetAPIList.recv_player_attribute1,onUpdateAttribute)
  
end

function chapterPanel:onClick(obj,arg)
  if rootPanel.gameObject.activeSelf == false then
    return
  end

  local cmd = obj.name
  if cmd == "ButtonClose" then
    print("chapterPanel ButtonClose")
    mapSceneActive(true)
    chapterPanel:removeFromState()
  elseif cmd == "BtnNext" or cmd == "BtnPre" then  
    chapterPanel:updateChapterType()
  elseif cmd == "ButtonInfo" then
    popInfoPanel.gameObject:SetActive(false)
    chapterPanel:onClickInfo(obj)
  elseif cmd == "ButtonFight" then
    chapterPanel:onFight(obj,tonumber(obj.transform.parent.gameObject.name))
  elseif cmd == "ButtonSaodang" then
    chapterPanel:onSweep(tonumber(obj.transform.parent.gameObject.name))
  -- elseif string.find(cmd,"roleBg") then
  --   chapterPanel:showPopRoleInfo(obj,tonumber(obj.transform.parent.parent.parent.name))
  --   print("rolebg:" .. cmd .. obj.transform.parent.parent.parent.name)
  elseif string.find(cmd,"ItemBg") then
    print("itembg:" .. cmd.. obj.transform.parent.parent.name)
  else
    --popInfoPanel.gameObject:SetActive(false)
  end
end

function chapterPanel:onPress(obj,arg)
  local cmd = obj.name
  if bPress == true then
    bPress = false
    return
  end
  bPress = true
  if string.find(cmd,"roleBg") then
    chapterPanel:showPopRoleInfo(obj,tonumber(obj.transform.parent.parent.parent.name))
    print("rolebg:" .. cmd .. obj.transform.parent.parent.parent.name)
  end
end

function chapterPanel:showPanel(data)
  --printTable(data.list[1])
  serverData = data
  self:addToState()
  if bFirst == false then
    chapterPanel:InitData(getCurMainChapterID())
    chapterPanel:updateChapterPanel()
    waitingPanelEnd()
  end
end

function chapterPanel:getPreChapter(id)
  for k,v in pairs(Model.getChapterData()) do
    if v.id == id then
      -- print("getPreChapter:" .. id)
      return v
    end
  end
  print("getPreChapter error,not data" .. id)
  return nil
end

function chapterPanel:getHasStarFormID(id)
  local data = chapterPanel:findServerData(id)
  if data ~= nil then
    -- print("getHasStarFormID:" .. data.chapter_star)
    if data.chapter_star > 0 then
      return true
    end 
  end
  print("getHasStarFormID error")
  return false
end

function chapterPanel:checkIsLimit(id)
  -- print("checkIsLimit:" .. id)
  for k,v in ipairs(curChapterData) do
    if v.id == id then
      --lv limit
      if Model.getPlayerInfo().lv < v.lvlimit then 
        -- print("lv limit:" .. v.lvlimit)
        return true
      end
      --pre chapter limit
      local preChapter = chapterPanel:getPreChapter(v.preid)
      if preChapter == nil then return false end 
      local bPass = chapterPanel:getHasStarFormID(preChapter.id)
      if bPass == false then
        -- print("pre limit:" .. preChapter.id)
        return true
      end 
    end
  end
  return false
end

function chapterPanel:onClickInfo(obj)
  --选中底纹
  for k,v in pairs(curChapterItemList) do
    local CloneItemRefer = LuaHelper.GetComponent(v.gameObject,"ReferGameObjects")
    --CloneItemRefer.monos[0].gameObject:SetActive(false)
    local sprite = LuaHelper.GetComponent(CloneItemRefer.monos[23].gameObject,"UISprite")
    sprite.spriteName = "chapterPanel_img17"
  end
  local curItemRefer = LuaHelper.GetComponent(obj.transform.parent.gameObject,"ReferGameObjects")
  --curItemRefer.monos[0].gameObject:SetActive(true)
  local sprite1 = LuaHelper.GetComponent(curItemRefer.monos[23].gameObject,"UISprite")
  sprite1.spriteName = "chapterPanel_img16"

end

--传入章节ID，初始化章节下小关卡数据
function chapterPanel:InitData(mainID)
  curChapterData = {}
  printTable(Model.getChapterData())
  print("InitData mainID:" .. mainID)
  for k,v in pairs(Model.getChapterData()) do
    if v.mainid == mainID then
      table.insert(curChapterData,v) 
      print(v.id)
    end
  end
  printTable(curChapterData)
  --按key排序
  --printTable(curChapterData)
  sortLevel=function(a,b)return a.id<b.id end
  table.sort(curChapterData,sortLevel)
  if curChapterData ~= nil then
    --printTable(curChapterData)
  end
end

function chapterPanel:updateChapterType()
  curChapterType = curChapterType % 2 + 1
  typeTxt.text = getValue(chapterPanel.chapterType[curChapterType])
end

function chapterPanel:clearPanel()
  for k,v in ipairs(curChapterItemList) do
      LuaHelper.Destroy(v.gameObject)
      --print("Destroy.." .. v.gameObject.name)
  end
  curChapterItemList = {}
end

function chapterPanel:updateChapterPanel()
  chapterPanel:clearPanel()
  local i = 0
  for k,v in ipairs(curChapterData) do
    local clone = LuaHelper.InstantiateLocal(chapterItemClone,chapterItemClone.transform.parent.gameObject)
    clone.name = v.id
    table.insert(curChapterItemList,clone)
    local CloneItemRefer = LuaHelper.GetComponent(clone.gameObject,"ReferGameObjects")

    --start
    chapterPanel:updateStar(CloneItemRefer,0)

    --name
    CloneItemRefer.monos[4].text = getValue("main_button_0".. tostring(i + 21))
    CloneItemRefer.monos[5].text = getValue(v.name)
    CloneItemRefer.monos[6].text = v.use.vit
    CloneItemRefer.monos[7].text = v.timeslimit

    --time
    CloneItemRefer.monos[21].text = "0'0''"
    CloneItemRefer.monos[22].text = "0'0''"

    --enemy
    local index = 1  
    for ka,va in pairs(v.monster) do
      if index <= 6 then
        local obj = CloneItemRefer.monos[8 + index]
        if Model.getUnit(va) then
          obj.spriteName = Model.getUnit(va).icon
          obj.gameObject:SetActive(true)
        end
      end
      index = index+ 1
    end
    
    --item
    index = 0
    for ka,va in pairs(v.drop) do
      if index < 6 then
        local obj = CloneItemRefer.monos[15 + index]
        --print(va)
        obj.spriteName = Model.getItemData(va).icon
        obj.gameObject:SetActive(true)
      end
      index = index+ 1
    end

    i = i + 1
    clone.gameObject:SetActive(true)
    chapterPanel:updateServerData(CloneItemRefer,v.id)

    --limit
    local bLimitOpen = chapterPanel:checkIsLimit(v.id)
    if bLimitOpen == true then 
      CloneItemRefer.monos[23].color = Color(0,0,0)
      CloneItemRefer.monos[24].isEnabled = false
      -- CloneItemRefer.monos[24]:SetState(UIButtonColor.State.Disabled,true)
    else
      CloneItemRefer.monos[23].color = Color(1,1,1)
      CloneItemRefer.monos[24].isEnabled = true
      -- CloneItemRefer.monos[24]:SetState(UIButtonColor.State.Normal,true)
    end
  end 
  local tb=  LuaHelper.GetComponent(chapterItemClone.transform.parent.gameObject,"UITable")
  local panel=  LuaHelper.GetComponent(chapterItemClone.transform.parent.parent.gameObject,"UIScrollView")
  --panel:ResetPosition()
  --panel:UpdatePosition()
  local fun=function()tb:Reposition() end
  delay(fun,0.1,nil)
  tb.repositionNow = true
end

function chapterPanel:updateStar( clone,number )
  --print("server chapter:")
  --print(number)
  for i=0,2 do
    local sprite = LuaHelper.GetComponent(clone.monos[i + 1].gameObject,"UISprite")
    sprite.spriteName = "chapterPanel_img12"
    if i >= number then
      sprite.spriteName = "chapterPanel_img14"
    end
  end

  clone.monos[8].gameObject:SetActive(false)
  if number == 3 then
    clone.monos[8].gameObject:SetActive(true)
  end
end

function chapterPanel:findServerData( id )
  for k,v in pairs(serverData.list) do
    if v.chapter_id == id then 
      return v  
    end
  end
  return nil
end

function chapterPanel:updateServerData(clone,id)
  local data = chapterPanel:findServerData(id)
  if data ~= nil then
    --star
    chapterPanel:updateStar(clone,data.chapter_star)
    clone.monos[7].text = data.chapter_residue_number

    --time
    clone.monos[21].text = common_fun.getTimeString(data.chapter_fastest_record)
    clone.monos[22].text = common_fun.getTimeString(data.chapter_my_record)
  end
end

function chapterPanel:onFight(obj,index)
  if obj.isEnabled == false then
    return
  end
  showWaitingPanel()
  curChapterIndex = index
  Model.chapterCurrentIndex = curChapterIndex
  local cont = NetMsgHelper:makesend_challenge_chapter(index)
  printTable(cont)
  Proxy:send(NetAPIList.player_challenge_chapter,cont)

  local battleUI = LuaItemManager:getItemObject("battleUI")
  battleUI.callback = chapterPanel.callbackBattleEnd

  self:removeFromState()
end

function chapterPanel:callbackBattleEnd( ... )
  local cont = NetMsgHelper:makesend_player_chapter(getCurMainChapterID())
  Proxy:send(NetAPIList.player_chapter_list,cont)

  StateManager:setCurrentState(StateManager.mapScene)
end

function chapterPanel:onSweep(index)
  print("onSweep")
  --self:removeFromState()
  rootPanel.gameObject:SetActive(false)
  onShowSweepPanel(index)
end

function chapterPanel:onShowed( ... )
  self.isShow = true;
  waitingPanelEnd()
end

function chapterPanel:onHide( ... )
  self.isShow = false;
end

function chapterPanel:showPopRoleInfo(obj,id)
  local refer = LuaHelper.GetComponent(popInfoPanel.gameObject,"ReferGameObjects")
  local posY = obj.transform.position.y
  local posX = obj.transform.position.x
  local vector = Vector3(posX,posY,0)
  popInfoPanel.transform.position = vector
  local BGSprite = refer.monos[6]
  local refer = LuaHelper.GetComponent(popInfoPanel.gameObject,"ReferGameObjects")
  local index = string.sub(obj.transform.name,-1)
  local table = Model.getChapterDataByid(id).monster[tonumber(index)]

  if index % 7 < 4 then
    local vector = Vector3(100,6,0)
    BGSprite.transform.localPosition = vector
  else
    local vector = Vector3(-100,6,0)
    BGSprite.transform.localPosition = vector
  end

  if table ~= nil then
    refer.monos[0].spriteName = Model.getUnit(table).icon -- iconSprite
  end
  refer.monos[1].text = Model.getUnit(table).star
  refer.monos[2].spriteName = "icon_property_" .. Model.getUnit(table).category2
  refer.monos[3].spriteName = "icon_profession_" .. Model.getUnit(table).category3
  refer.monos[4].text = getValue(Model.getUnit(table).desc)
  refer.monos[5].text = getValue(Model.getUnit(table).name)
end

--=====================================globle=====================================
function showchapterPanel(data)
  print("----showchapterPanel-----")
  printTable(data.list)
  chapterPanel:showPanel(data) 
end

function showchapterPanelEX()
  print("----showchapterPanelEX-----")
  --if rootPanel.gameObject then
    rootPanel.gameObject:SetActive(true)
  --end
end

function callbackFightReq(data)
  -- print("callbackFightReq...")
  -- waitingPanelEnd()
  -- self:removeFromState()
  -- StateManager:setCurrentState(StateManager.battle)
end

function callbackFightReqError(data)
  waitingPanelEnd()
  print("callbackFightReqError...")
end

function onUpdateAttribute( data )
  print("onUpdateAttribute...")
end