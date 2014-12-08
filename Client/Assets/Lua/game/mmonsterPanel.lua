---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: mmonsterPanel.lua
--data:2014.11.13
--author:yue an bang
--desc:神兽合成界面
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local mmonsterPanel = LuaItemManager:getItemObject("mmonsterPanel")
local teamPanel = LuaItemManager:getItemObject("teamPanel")
local packPanel = LuaItemManager:getItemObject("packPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local Vector3 = UnityEngine.Vector3
local Encodeing = luanet.import_type("System.Text.Encoding")
local UIButtonColor = luanet.UIButtonColor
local Quaternion = UnityEngine.Quaternion
local Net=Net.instance
local LFunction = LFunction.instance
local common_fun = common_fun
local Proxy=Proxy
local Model = Model
local getValue = getValue
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local Color = UnityEngine.Color
local FileUtils=FileUtils
local fileUtils = FileUtils()
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
mmonsterPanel.assets=
{
  Asset("mmonsterPanel.u3d"),
}
mmonsterPanel.mmItemList = {}

--==================================================================================================
local Refer,listTable,popInfoPanel_sale,popInfoPanel_merge,listPanel
local titleButton = {}
local bPageList = true
local bFirst = true
local bPress = false
local bUpdateList = false
local curPageIndex = 1
local curMergeItemID = 0
local curShowMMonsterID = 0
local LastCoolTime = 0
local LastUpdateTime = 0
local mmonsterIDList = {260001,260002,260003,260004}
--==================================================================================================
--==================================================================================================
function mmonsterPanel:onAssetsLoad(items)
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  listTable = Refer.monos[0]
  popInfoPanel_sale = Refer.monos[20]
  popInfoPanel_merge = Refer.monos[19]
  mmonsterPanel:registerTableEvent(listTable)

  --init button
  for i=1,8 do
    titleButton[i] = Refer.monos[i]
  end

  bFirst = false
  mmonsterPanel:updateItemPage()
  waitingPanelEnd()
  print("....onAssetsLoad...")
end

function mmonsterPanel:registerTableEvent(obj)
  if obj == listTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      if(itemdata) then
        referScipt.gameObject:SetActive(true)  
        local item_sprite = referScipt.monos[0]         -- icon
        local item_star_sprite = referScipt.monos[1]         -- star
        local item_num_lable = referScipt.monos[2]         -- number
        item_sprite.gameObject:SetActive(false)
        item_star_sprite.gameObject:SetActive(false)
        item_num_lable.gameObject:SetActive(false)
        if itemdata.itemId ~= nil and itemdata.itemId > 0 then
          referScipt.name =  "item_Button" .. itemdata.itemId
          item_sprite.spriteName = itemdata.spriteName
          local goodModel = packPanel:getGoodDataById(itemdata.itemId)
          if goodModel.netData.goods_num > 1 then
            item_num_lable.gameObject:SetActive(true)
            item_num_lable.text = goodModel.netData.goods_num
          end
          item_sprite.gameObject:SetActive(true)
          if itemdata.isStar == true then
            item_star_sprite.gameObject:SetActive(true)
          end
        end
      end
    end   
  end
  
  obj.onPreRender=function(referScipt,index,dataItem)
    referScipt.name="Pre"..tostring(index)
    referScipt.gameObject:SetActive(false)
  end

  obj.onDataRemove = function(data,index,camackTable)
    local lenold=#data
    table.remove(data,index)
  end

  obj.onDataInsert = function(data,index,script)
    if script.data==nil then script.data={} end
    local lenold=#script.data
    table.insert(script.data,index,data)
  end
end

function mmonsterPanel:onClick(obj,arg)
  local cmd = obj.name;
  if cmd == "ButtonClose" then
    mmonsterPanel:hideAll()
  elseif cmd == "ButtonGo" then
    mmonsterPanel:onClickGo(obj)
  elseif cmd == "ButtonMerge" then
    mmonsterPanel:onMerge()
  elseif cmd == "ButtonSale" then
    mmonsterPanel:onSale()
  elseif cmd == "ButtonCancel" then  
    mmonsterPanel:onCancel()
  elseif string.find(cmd,"Button_title_") then
    mmonsterPanel:onClickTitle(obj)
  elseif string.find(cmd,"item_Button") then
    mmonsterPanel:onClickItem(obj)
  end
end

function mmonsterPanel:onMerge()
  local curID = 0
  for k,v in pairs(mmonsterIDList) do
    local localCData = Model.goodComp[tostring(v)].goods;
    for i=1,#localCData do
      if curMergeItemID == localCData[i] then
         curID = v
      end
    end
  end
  local cont = NetMsgHelper:makesend_player_compound_goods_beast(tonumber(curID))
  Proxy:send(NetAPIList.player_compound_goods_beast,cont)
  popInfoPanel_sale.gameObject:SetActive(false)
  popInfoPanel_merge.gameObject:SetActive(false)
end

function mmonsterPanel:onSale()
  local cont = NetMsgHelper:makesend_player_goods_sell(curMergeItemID,1)
  Proxy:send(NetAPIList.goods_sell,cont)
  popInfoPanel_sale.gameObject:SetActive(false)
  popInfoPanel_merge.gameObject:SetActive(false)
end

function mmonsterPanel:onCancel()
  popInfoPanel_sale.gameObject:SetActive(false)
  popInfoPanel_merge.gameObject:SetActive(false)
end

function mmonsterPanel:onClickGo(obj)
  if obj.enabled == false then
    return
  end
  for k,v in pairs(Model.mMonsterData) do
    if v.beast_id == curShowMMonsterID then
      if v.played ~= 0 then
        return
      end
    end
  end
  print("send go:" .. curShowMMonsterID)
  local cont = NetMsgHelper:makesend_player_besat_played(tonumber(curShowMMonsterID))
  Proxy:send(NetAPIList.player_besat_played,cont)
end

function mmonsterPanel:onClickItem(obj)
  local id = tonumber(string.sub(obj.name,12))
  local tab = mmonsterPanel.mmItemList
  curMergeItemID = id
  local isMerge = false
  local coin = 0
  for k,v in pairs(tab) do
    if v.itemId == id then
      isMerge = v.isStar
      coin = v.coin
    end
  end
  if isMerge == true then
    local refer = LuaHelper.GetComponent(popInfoPanel_merge.gameObject,"ReferGameObjects")
    popInfoPanel_merge.gameObject:SetActive(true)
    refer.monos[0].text = coin
  else
    local refer = LuaHelper.GetComponent(popInfoPanel_sale.gameObject,"ReferGameObjects")
    popInfoPanel_sale.gameObject:SetActive(true)
    refer.monos[0].text = coin
  end
end

function mmonsterPanel:onClickTitle(obj)
  local index = tonumber(string.sub(obj.name,15,15))
  local isSel = string.find(obj.name,"sel")
  if index == curPageIndex then
    return
  end

  --update view
  titleButton[curPageIndex*2].gameObject:SetActive(false)
  titleButton[curPageIndex*2 - 1].gameObject:SetActive(true)
  titleButton[index*2].gameObject:SetActive(true)
  titleButton[index*2 - 1].gameObject:SetActive(false)
  curPageIndex = index

  --update data
  mmonsterPanel:changePage()
end

function mmonsterPanel:changePage()
  mmonsterPanel:updateItemPage()
end

function mmonsterPanel:onHide()
  popInfoPanel_sale.gameObject:SetActive(false)
  popInfoPanel_merge.gameObject:SetActive(false)
end

function mmonsterPanel:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end

  if bFirst == false and bUpdateList == true then
    mmonsterPanel:updateItemPage()
  end
end

function mmonsterPanel:hideAll()
  self:removeFromState()
  self.isShow = false
  if not teamPanel.isShow then
    teamPanel:setPanelState("normal")
    teamPanel:showAll()
  end
end

--- 每次显示都会调用
function mmonsterPanel:onShowed( ... )
  Refer.monos[21].text = getValue("main_mmonster_010")
  mmonsterPanel:updateMMonsterItemList()
  if teamPanel and teamPanel.isShow then
    teamPanel:hideAll()
  end
end
--=====================================message=====================================

function mmonsterPanel:sendmessage(id)
  -- local cont = NetMsgHelper:makesend_player_mail_read(id)
  -- Proxy:send(NetAPIList.player_mail_read,cont)
end

function mmonsterPanel:updateItemPage()
  curShowMMonsterID = 260000 + curPageIndex
  --道具镶嵌
  for i=0,5 do
    Refer.monos[9 + i].gameObject:SetActive(false)
  end

  --神兽技能
  local unitData = Model.getUnit(curShowMMonsterID)
  local skillData = Model.getSkill(unitData.skill[2])
  if skillData ~= nil then
    Refer.monos[15].spriteName = skillData.icon
    Refer.monos[16].text = getValue(skillData.name)
    Refer.monos[17].text = getValue(skillData.description)
  end

  local data = Model.getMMonsterFromID(curShowMMonsterID)
  if data == nil then
    return
  end

  local index = 0
  for k,v in pairs(data.synthesis_goods) do
    Refer.monos[9 + index].gameObject:SetActive(true)
    Refer.monos[9 + index].spriteName = Model.getItemData(v.goods_id).icon
    index = index + 1
  end

  --出阵按钮状态
  mmonsterPanel:updateGoButton()
end

function mmonsterPanel:updateGoButton()
  local played = 0
  local cool_down = 0
  local activate_status = 0
  for k,v in pairs(Model.mMonsterData) do
    if v.beast_id == curShowMMonsterID then
      played = v.played
      cool_down = v.cool_down
      activate_status = v.activate_status
      break
    end
  end
  if played == 0 then
    Refer.monos[21].text = getValue("main_mmonster_010")
  else
    Refer.monos[21].text = getValue("main_mmonster_011")
  end
  LastCoolTime = cool_down
  print("LastCoolTime:" .. LastCoolTime)
  mmonsterPanel:updateCoolDownTime()

  if activate_status ~= 0 then
    Refer.monos[18].isEnabled = false
    -- Refer.monos[18]:SetState(UIButtonColor.State.Normal,true)
  else
    Refer.monos[18].isEnabled = false
    -- Refer.monos[18]:SetState(UIButtonColor.State.Disabled,true)
  end
end

function mmonsterPanel:updateCoolDownTime()
  if LastCoolTime <= 0 then
    return
  end

  local leftTime = os.time() - LastUpdateTime
  -- mmonsterPanel.components.cooldownLabel:begin(LastCoolTime - leftTime) --开始计时
  if leftTime < LastCoolTime then
    Refer.monos[21].text = common_fun.getTimeString(LastCoolTime - leftTime,1)
  end
  delay(mmonsterPanel.updateCoolDownTime,1,nil)
end

function mmonsterPanel:updateListPanel()
  print("updateListPanel..")
  local curItemlist = mmonsterPanel.mmItemList
  --道具碎片列表
  bUpdateList = true
  if listTable ~= nil and self.isShow == true then
    curItemlist = mmonsterPanel:changeListSize(curItemlist)
    listTable:clear()
    listTable.pageSize = 15
    listTable.data = curItemlist
    listTable:Refresh()
    bUpdateList = false
  end
end

function mmonsterPanel:changeListSize(tab)
  print("changeListSize..")
  local retTable = tab
  if #tab < 12 then
    for i=#tab,11 do
      table.insert(retTable,{})
    end
  end
  return retTable
end

function mmonsterPanel:checkHasOwnerID(tab,value)
  if tab == nil then return false end
  for k,v in pairs(tab) do
    if v == value then return true end
  end
  return false
end

function mmonsterPanel:checkHasOwnerTab(tab)
  if tab == nil then return false end
  printTable(tab)
  for k,v in pairs(tab) do
    local goodModel = packPanel:getGoodDataById(v)
    if goodModel == nil then
      return false
    end
  end
  return true
end

function mmonsterPanel:updateMMonsterItemList()
  mmonsterPanel.mmItemList = {}
  local needItemList = {}
  local starItemList = {}
  for k,v in pairs(mmonsterIDList) do
    -- 获得合成表
    local localCData = Model.goodComp[tostring(v)].goods;
    local isStar = mmonsterPanel:checkHasOwnerTab(localCData)
    for i=1,#localCData do
      local goodModel = packPanel:getGoodDataById(localCData[i])
      if goodModel ~= nil then
        if mmonsterPanel:checkHasOwnerID(needItemList,localCData[i]) == false then
          table.insert(needItemList,localCData[i])
        end
        if isStar == true then
          table.insert(starItemList,localCData[i])
        end
      end
    end
  end

  for i=1,#needItemList do
    mmonsterPanel.mmItemList[i] = {}
    mmonsterPanel.mmItemList[i].itemId = needItemList[i]
    mmonsterPanel.mmItemList[i].coin = 
    Model.getItemData(needItemList[i]).sell_price
    mmonsterPanel.mmItemList[i].spriteName = 
    Model.getItemData(needItemList[i]).icon
    mmonsterPanel.mmItemList[i].isStar = 
    mmonsterPanel:checkHasOwnerID(starItemList,needItemList[i])
    -- printTable(mmonsterPanel.mmItemList[i])
  end

  print("getMMonsterItemList:")
  printTable(mmonsterPanel.mmItemList)

  mmonsterPanel:updateListPanel()
end

function mmonsterPanel:updateMonsterData(data)
  if data == nil or #data == 0 then
    return
  end
  for k1,v1 in pairs(data) do
    local bHas = false
    for k,v in pairs(Model.mMonsterData) do
      if v.beast_id == v1.beast_id then
        v.synthesis_goods = v1.synthesis_goods
        v.activate_status = v1.activate_status
        v.cool_down = v1.cool_down
        v.played = v1.played
        if v.played ~= 0 then
          --上战记录
          Model.mCurFightMonsterID = v.beast_id 
        end
        bHas = true
        break
      end
    end
    if bHas == false then
      table.insert(Model.mMonsterData,v1)  
    end
  end
  LastUpdateTime = os.time()
  print("udateMonsterData.." .. LastUpdateTime)
  printTable(Model.mMonsterData)
end

function mmonsterPanel:recv_player_mmonster_list(data)
  print("recv mmonster list..")
  printTable(data["list"])
  mmonsterPanel:updateMonsterData(data["list"])
  -- played:0;cool_down:0;activate_status:0;beast_id:260004
  -- synthesis_goods:{
  --   1:{goods_num:1;goods_id:100527};
  --   2:{goods_num:1;goods_id:100526};
  --   3:{goods_num:1;goods_id:100524};
  --   4:{goods_num:1;goods_id:100522}
  --   };
  if bFirst == false then
    mmonsterPanel:updateItemPage()
  else 
    bUpdateList = true    
  end
end

function mmonsterPanel:recv_player_bag_change_goods()
  mmonsterPanel:updateMMonsterItemList()
end
--=====================================globle=====================================




