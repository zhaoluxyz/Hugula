---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: shopPanel.lua
--data:2014.11.19
--author:yue an bang
--desc:商城
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local shopPanel = LuaItemManager:getItemObject("shopPanel")
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
local iTween=iTween
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
shopPanel.assets=
{
  Asset("shopPanel.u3d"),
  Asset("heroPanel.u3d", {"Refers"}),
  Asset("Strengthenmap.u3d")
}
--==================================================================================================
local Refer,sceneRefer,listTable,roleInfoPanel,showRoleScene
local rootPanel,showRolePanel,showItemPanel,showAlert_popPanel
local popItemInfoPanel
local titleButton = {}
local bPageList = true
local bFirst = true
local bPress = false
local bUpdateList = false
local curPageIndex = 1
local curChouNum = 1
local curShowIndex = 0
local curShowMaxNum = 0
local curLoadRoleNum = 0
local curShowState = 0 --1,抽卡模型展示阶段,2,加载模型
local curChouType = 0 -- 0:友情，1:勾玉
local curChongType = 0 --0:金币，1：勾玉
local LastCoolTime = 0
local LastUpdateTime = 0
local bIsCoolDownShowRoleAnim = false
local showRoleArray = {}
local showRoleItemArray = {}
local showRoleItemDataArray = {}
local showRoleDataArray = {}
--==================================================================================================
local cdl_component,cdl2_component
--==================================================================================================
function shopPanel:onAssetsLoad(items)
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  sceneRefer = LuaHelper.GetComponent(self.assets[3].root,"ReferGameObjects")
  roleInfoPanel = self.assets[2].items["Refers"]
  
  showRoleScene = self.assets[3].root
  rootPanel = Refer.monos[27]
  showRolePanel = Refer.monos[28]
  showItemPanel = Refer.monos[29]
  showAlert_popPanel = Refer.monos[30]
  popItemInfoPanel = Refer.monos[31]
  showRoleScene.gameObject:SetActive(false)
  roleInfoPanel:SetActive(false)
  rootPanel.gameObject:SetActive(true)

  --倒计时初始化
  cdl_component = require("components.cooldownLabel")({})
  cdl2_component = require("components.cooldownLabel")({})
  cdl_component.enable = false
  cdl2_component.enable = false
  cdl_component.label = Refer.monos[8]
  cdl_component.onCooldownFn=function() 
    Refer.monos[7].gameObject:SetActive(false)
    Refer.monos[9].gameObject:SetActive(true) 
  end
  cdl2_component.label = Refer.monos[11]
  cdl2_component.onCooldownFn=function() 
    Refer.monos[10].gameObject:SetActive(false)
    Refer.monos[12].gameObject:SetActive(true) 
  end
  
  local refer = LuaHelper.GetComponent(Refer.monos[26].gameObject,"ReferGameObjects")
  listTable = refer.monos[0]
  shopPanel:registerTableEvent(listTable)

  --init button
  for i=1,6 do
    titleButton[i] = Refer.monos[i]
  end

  bFirst = false
  shopPanel:updateMainPage()
  shopPanel:updateItemPage()
  waitingPanelEnd()
  print("....onAssetsLoad...")
end

function shopPanel:registerTableEvent(obj)
  if obj == listTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      if(itemdata) then
        referScipt.gameObject:SetActive(true)  
        local item_sprite = referScipt.monos[0]             -- icon
        local type_lable = referScipt.monos[1]              -- type
        local cost_lable = referScipt.monos[2]              -- cost
        local give_lable = referScipt.monos[3]              -- give
        local rmb_lable = referScipt.monos[4]               -- rmb
        if curChongType == 0 then
          item_sprite.spriteName = "common_img003"
          type_lable.text = getValue("main_mmonster_009")
        else
          item_sprite.spriteName = "common_img018"
          type_lable.text = getValue("main_shop_021")
        end
        cost_lable.text = "x" .. itemdata.goods_num
        give_lable.text = itemdata.goods_give
        rmb_lable.text = itemdata.goods_price.price
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

function shopPanel:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end

  if bFirst == false then
    shopPanel:initMainPanel()
    -- shopPanel:updateItemPage()
  end
end

function shopPanel:hideAll()
  self:removeFromState()
  self.isShow = false
end

function shopPanel:onClick(obj,arg)
  if self.isShow == false then return end
  local cmd = obj.name;
  if cmd == "ButtonClose" then
    shopPanel:hideAll()
  elseif cmd == "back_btn" then
    shopPanel:onShowRoleInfoPanelBack()
  elseif cmd == "button_chou_back" then
    Refer.monos[23].gameObject:SetActive(false)
  elseif cmd == "showRole_back_btn" then
    shopPanel:onChouPanelBack()
  elseif cmd == "showRole_chou_btn" then
    shopPanel:onClickReChou()
  elseif cmd == "showRole_info_btn" then
    shopPanel:onShowRoleInfo()
  elseif cmd == "showRole_pre_btn" then
    shopPanel:onShowRolePreClick()
  elseif cmd == "showRole_next_btn" then
    shopPanel:onShowRoleNextClick()
  elseif cmd == "showAlert_popPanel_ok" then
    shopPanel:onClickChongzhi(1)
    shopPanel:closeAlertBuyPanel()
  elseif cmd == "showAlert_popPanel_cancel" then   
    shopPanel:closeAlertBuyPanel()
  elseif cmd == "Pop_chongzhi_list_Btn_back" then
    Refer.monos[26].gameObject:SetActive(false)
  elseif cmd == "button_chou_left" then
    shopPanel:onClickChouType(0)
  elseif cmd == "button_chou_right" then  
    shopPanel:onClickChouType(1)
  elseif cmd == "button_chongzhi_right" then
    shopPanel:onClickChongzhi(1)
  elseif cmd == "button_chongzhi_left" then  
    shopPanel:onClickChongzhi(0)
  elseif cmd == "button_chou_sel_left" then
    shopPanel:onClickChouNum(1)
  elseif cmd == "button_chou_sel_right" then  
    shopPanel:onClickChouNum(10)
  elseif string.find(cmd,"Button_title_") then
    shopPanel:onClickTitle(obj)
  -- elseif string.find(cmd,"showItem_item_btn_") then
  --   shopPanel:onClickItem(obj)
  end
end

function shopPanel:onPress(obj,arg)
  local cmd = obj.name
  if string.find(cmd,"showItem_item_btn_")  then
    shopPanel:onClickItem(obj)
  elseif string.find(cmd,"skill_")  then
    shopPanel:onClickSkill(obj)
  end
end

function shopPanel:onClickSkill(obj)
  shopPanel:showPopSkillInfo(obj)
end

function shopPanel:onClickItem(obj)
  local index = tonumber(string.sub(obj.transform.parent.name,-1))
  if index == 0 then index = 10 end
  shopPanel:showPopItemInfo(obj,index)
end

function shopPanel:onClickReChou()
  shopPanel:onClickChouNum(curChouNum)
end

function shopPanel:onClickChouNum(num)
  curChouNum = num
  local offset = 0
  if curChouType == 0 then offset = 1 end
  local data = shopPanel:getShopDataOfShopNo(curPageIndex*2 - offset,num)[1]
  printTable(data)
  if data ~= nil and data.id ~= nil then
    --check gouyu
    if Model.getPlayerInfo().yu < shopPanel:getChooseChouNumPrice(num) then
      shopPanel:openAlertBuyPanel()
      return
    end
    --send message
    local cont = NetMsgHelper:makesend_buy_goods(data.id,num)
    Proxy:send(NetAPIList.buy_goods,cont)
    showWaitingPanel()
  end
end

function shopPanel:onClickChouType(type)
  curChouType = type
  shopPanel:showChouSelectPanel()
end

function shopPanel:onClickChongzhi(type)
  curChongType = type
  Refer.monos[26].gameObject:SetActive(true)
  shopPanel:updateBuyPage()
end 

function shopPanel:onClickTitle(obj)
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
  shopPanel:changePage()
end

function shopPanel:updateView()
  if self.isShow == true then
    shopPanel:updateChouPage()
  end
end

function shopPanel:updateMainPage()
  Refer.monos[24].gameObject:SetActive(true)
  Refer.monos[25].gameObject:SetActive(false)
  if curPageIndex == 1 then
    Refer.monos[19].gameObject:SetActive(true)
    Refer.monos[20].gameObject:SetActive(true)
    Refer.monos[21].gameObject:SetActive(false)
    Refer.monos[22].gameObject:SetActive(false)
    shopPanel:updateChouPage()
  elseif curPageIndex == 2 then
    Refer.monos[19].gameObject:SetActive(false)
    Refer.monos[20].gameObject:SetActive(false)
    Refer.monos[21].gameObject:SetActive(true)
    Refer.monos[22].gameObject:SetActive(true)
    shopPanel:updateChouPage()
  elseif curPageIndex == 3 then
    Refer.monos[24].gameObject:SetActive(false)
    Refer.monos[25].gameObject:SetActive(true)
  end
end

function shopPanel:updateBuyPage()
  local refer = LuaHelper.GetComponent(Refer.monos[26].gameObject,"ReferGameObjects")
  if curChongType == 0 then
    refer.monos[1].gameObject:SetActive(true)
    refer.monos[2].gameObject:SetActive(false)
  else
    refer.monos[1].gameObject:SetActive(false)
    refer.monos[2].gameObject:SetActive(true)
  end
  local data = {}
  if curChongType == 0 then
    data = shopPanel:getShopDataOfShopNo(curPageIndex*2 - 1)
  else
    data = shopPanel:getShopDataOfShopNo(curPageIndex*2)
  end
  print("show buy list")
  printTable(data)
  listTable.data = data
  listTable:Refresh()
  local fun=function() listTable:scrollTo(0) end 
  delay(fun,0.1,nil)
end

function shopPanel:updateChouPage()
  local index = curPageIndex
  if index <= 0 then return end
  local dataFriend = shopPanel:getShopDataOfShopNo(index*2 - 1,1)[1]
  local dataGouyu = shopPanel:getShopDataOfShopNo(index*2,1)[1]
  local leftCool = Refer.monos[7]
  local leftCoolFree = Refer.monos[9]
  local rightCool = Refer.monos[10]
  local rightCoolFree = Refer.monos[12]
  local friend_free_lb = Refer.monos[13]
  local friend_normal_lb = Refer.monos[14]
  local gouyu_free_lb = Refer.monos[15]
  local gouyu_normal_lb = Refer.monos[16]
  if dataFriend == nil or dataGouyu == nil then return end
  if dataFriend.goods_price == nil then return end
    --当前友情点
  if Model.getPlayerInfo().player_friendship ~= nil then
    Refer.monos[17].text = Model.getPlayerInfo().player_friendship
  end
  if Model.getPlayerInfo().yu ~= nil then
    Refer.monos[18].text = Model.getPlayerInfo().yu
  end
  --免费和倒计时显示
  if dataFriend.goods_free_time > 0 then
    leftCool.gameObject:SetActive(true)
    leftCoolFree.gameObject:SetActive(false)
    friend_free_lb.gameObject:SetActive(false)
    friend_normal_lb.gameObject:SetActive(true)
    friend_normal_lb.text = dataFriend.goods_price.price
    if os.time() - LastUpdateTime < dataFriend.goods_free_time then
      cdl_component:begin(dataFriend.goods_free_time - (os.time() - LastUpdateTime) ,0)
    else
      leftCool.gameObject:SetActive(false)
      leftCoolFree.gameObject:SetActive(true)
    end
  else
    friend_free_lb.gameObject:SetActive(true)
    friend_normal_lb.gameObject:SetActive(false)
    leftCool.gameObject:SetActive(false)
    leftCoolFree.gameObject:SetActive(true)
  end
  if dataGouyu.goods_free_time > 0 then
    rightCool.gameObject:SetActive(true)
    rightCoolFree.gameObject:SetActive(false)
    gouyu_free_lb.gameObject:SetActive(false)
    gouyu_normal_lb.gameObject:SetActive(true)
    gouyu_normal_lb.text = dataFriend.goods_price.price
    if os.time() - LastUpdateTime < dataGouyu.goods_free_time then
      cdl2_component:begin(dataGouyu.goods_free_time - (os.time() - LastUpdateTime) ,0)
    end
  else
    rightCool.gameObject:SetActive(false)
    rightCoolFree.gameObject:SetActive(true)
    gouyu_free_lb.gameObject:SetActive(true)
    gouyu_normal_lb.gameObject:SetActive(false)
  end
end

function shopPanel:getChooseChouNumPrice(num)
  Refer.monos[23].gameObject:SetActive(true)
  local data = {}
  local offset = 0
  if curChouType == 0 then
    offset = 1  
  else
    offset = 0
  end
  data = shopPanel:getShopDataOfShopNo(curPageIndex*2 - offset,1)  
  if data[1].goods_free_time ~= 0 then
    return data[1].goods_price.price
  else
    return 0
  end
end

function shopPanel:openAlertBuyPanel()
  showAlert_popPanel.gameObject:SetActive(true)
end

function shopPanel:closeAlertBuyPanel()
  showAlert_popPanel.gameObject:SetActive(false)
end

function shopPanel:showChouSelectPanel()
  Refer.monos[23].gameObject:SetActive(true)
  local ReferSel = LuaHelper.GetComponent(Refer.monos[23].gameObject,"ReferGameObjects")
  local data = {}
  if curChouType == 0 then
    data[1] = shopPanel:getShopDataOfShopNo(curPageIndex*2 - 1,1)
    data[2] = shopPanel:getShopDataOfShopNo(curPageIndex*2 - 1,10)
  else
    data[1] = shopPanel:getShopDataOfShopNo(curPageIndex*2,1)
    data[2] = shopPanel:getShopDataOfShopNo(curPageIndex*2,10)
  end
  printTable(data)
  shopPanel:setChouTypeTexture(data[1][1],ReferSel.monos[0])
  shopPanel:setChouTypeTexture(data[2][1],ReferSel.monos[3])
  if data[1][1].goods_free_time ~= 0 then
    ReferSel.monos[1].gameObject:SetActive(false)
    ReferSel.monos[2].gameObject:SetActive(true)
    ReferSel.monos[2].text = data[1][1].goods_price.price
  else
    ReferSel.monos[1].gameObject:SetActive(true)
    ReferSel.monos[2].gameObject:SetActive(false)
  end
  if data[2][1].goods_free_time ~= 0 then
    ReferSel.monos[4].gameObject:SetActive(false)
    ReferSel.monos[5].gameObject:SetActive(true)
    ReferSel.monos[5].text = data[2][1].goods_price.price
  else
    ReferSel.monos[4].gameObject:SetActive(true)
    ReferSel.monos[5].gameObject:SetActive(false)
  end
end

function shopPanel:onShowRoleInfo()
  local id = showRoleDataArray[curShowIndex].data
  if showRoleDataArray[curShowIndex].type == 1 then
    id = shopPanel:getShowItemRoleIDByMergeList(id)
  end

  if showRoleArray[curShowIndex].type == 1 then
    showRoleArray[curShowIndex].data.gameObject:SetActive(false)
  end

  roleInfoPanel:SetActive(true)
  showRoleScene:SetActive(true)
  rootPanel.gameObject:SetActive(false)
  showRolePanel.gameObject:SetActive(false)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)

  local refer = LuaHelper.GetComponent(roleInfoPanel,"ReferGameObjects")
  local showRoleRefer = LuaHelper.GetComponent(refer.refers[0].gameObject,"ReferGameObjects")

  handbookSceneShowRole(showRoleRefer,id)
end

function shopPanel:setChouTypeTexture(data,obj)
  if data.goods_price.type == "crystal" then
    obj.spriteName = "common_img018"
  elseif data.goods_price.type == "gold" then
    obj.spriteName = "common_img003"
  elseif data.goods_price.type == "player_friendship" then
    obj.spriteName = "common_img049"
  end
end

function shopPanel:changePage()
  shopPanel:updateMainPage()
end

function shopPanel:initMainPanel()
  shopPanel:clearShowRoleArray()
  roleInfoPanel:SetActive(false)
  showRoleScene:SetActive(false)
  rootPanel.gameObject:SetActive(true)
  showRolePanel.gameObject:SetActive(false)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)
end

function shopPanel:onHide()
  if bFirst == false then
    shopPanel:clearShowRoleArray()
    roleInfoPanel:SetActive(false)
    showRoleScene:SetActive(false)
    rootPanel.gameObject:SetActive(true)
    showRolePanel.gameObject:SetActive(false)
    showItemPanel.gameObject:SetActive(false)
    showAlert_popPanel.gameObject:SetActive(false)
    popItemInfoPanel.gameObject:SetActive(false)
  end
end

function shopPanel:onChouPanelBack()
  shopPanel:clearShowRoleArray()
  showRoleScene:SetActive(false)
  rootPanel.gameObject:SetActive(true)
  showRolePanel.gameObject:SetActive(false)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)
end

function shopPanel:onShowRoleInfoPanelBack()
  if showRoleArray[curShowIndex].type == 1 then
    showRoleArray[curShowIndex].data.gameObject:SetActive(true)
  end
  roleInfoPanel:SetActive(false)
  showRoleScene:SetActive(true)
  rootPanel.gameObject:SetActive(false)
  showRolePanel.gameObject:SetActive(true)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)
end

function shopPanel:chouGoodsShowPanel(data)
  showRoleScene:SetActive(true)
  rootPanel.gameObject:SetActive(false)
  showRolePanel.gameObject:SetActive(false)
  showItemPanel.gameObject:SetActive(true)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)
  shopPanel:clearShowRoleArray()
  local curRefer = LuaHelper.GetComponent(showItemPanel.gameObject,"ReferGameObjects")
  shopPanel:updateReChouButtonText(curRefer.monos[0],#data)
  local index = 1
  for i=1,10 do
    curRefer.monos[i].gameObject:SetActive(false)
  end
  for k,v in pairs(data) do
    if index <= 10 then
      curRefer.monos[index].gameObject:SetActive(true)
      curRefer.monos[index].spriteName = Model.getItemData(v.goods_id).icon
      curRefer.monos[index].name = "showItem_item_btn_" .. v.goods_id
      index = index + 1
    end
  end
end

function shopPanel:updateReChouButtonText(obj,num)
  if num > 1 then
    obj.text = getValue("main_shop_019")
  else
    obj.text = getValue("main_shop_020")
  end
end

function shopPanel:chouRoleShowPanel(data)
  showRoleScene:SetActive(true)
  rootPanel.gameObject:SetActive(false)
  showRolePanel.gameObject:SetActive(true)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)

  shopPanel:updateShowRoleInst(data)
  local curRefer = LuaHelper.GetComponent(showRolePanel.gameObject,"ReferGameObjects")
  shopPanel:updateReChouButtonText(curRefer.monos[0],curShowMaxNum)
end

function shopPanel:showPopSkillInfo(obj)
  showPopSkillInfo(roleInfoPanel,obj)
end

function shopPanel:showPopItemInfo(obj,index)
  local refer = LuaHelper.GetComponent(popItemInfoPanel.gameObject,"ReferGameObjects")
  local posY = obj.transform.position.y
  local posX = obj.transform.position.x
  local vector = Vector3(posX,posY,0)
  popItemInfoPanel.transform.position = vector
  local BGSprite = refer.monos[5]
  if index < 4 or index == 6 or index == 7 or index == 8 then
    local vector = Vector3(100,-15,0)
    BGSprite.transform.localPosition = vector
  else
    local vector = Vector3(-100,-15,0)
    BGSprite.transform.localPosition = vector
  end

  local id = string.sub(obj.transform.name,19)
  print(id)
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

function shopPanel:showBuyVitPanel()
  showRoleScene:SetActive(false)
  rootPanel.gameObject:SetActive(true)
  showRolePanel.gameObject:SetActive(false)
  showItemPanel.gameObject:SetActive(false)
  showAlert_popPanel.gameObject:SetActive(false)
  popItemInfoPanel.gameObject:SetActive(false)
  curChongType = 1
  curPageIndex = 3
  Refer.monos[26].gameObject:SetActive(true)
  shopPanel:updateBuyPage()
end
--============model load=======-------------
function shopPanel:callbackLoadModel(key)
  print("... load callback ，name:" .. key)

  local role = PrefabPool:Get(key)
  if role ~= nil and sceneRefer.refers[0] ~= nil then
    local curShowModel = LuaHelper.InstantiateLocal(role,
    sceneRefer.refers[0].transform.parent.gameObject)
    curShowModel.gameObject:SetActive(true)
    local nav = LuaHelper.GetComponent(curShowModel,"NavMeshAgent")
    if(nav) then nav.enabled = false end
    curShowModel.name = "Clone_Modle_"-- .. id
    LuaHelper.GetComponent(curShowModel.gameObject,"BoxCollider").size = Vector3(0.4, 1,1)
    LuaHelper.GetComponent(curShowModel.gameObject,"BoxCollider").center = Vector3(0, 0.5,0)
    curShowModel.transform.position = sceneRefer.refers[0].transform.position
    curShowModel.transform.localRotation = Quaternion.Euler(0, 180, 0)
    curShowModel.transform.localScale = sceneRefer.refers[0].transform.localScale
    --insert array
    curLoadRoleNum = curLoadRoleNum + 1
    showRoleArray[curLoadRoleNum] = {}
    showRoleArray[curLoadRoleNum].data = curShowModel
    showRoleArray[curLoadRoleNum].type = 0
    shopPanel:ScaleTo(curShowModel.gameObject,Vector3(0,0,0),Vector3(1,1,1),0.8)
    delay(shopPanel.autoShowRole,1,nil)
  else
    print("shopPanel:callbackLoadModel error .. " .. key)
    shopPanel:setCurShowState(2)
  end
end

function shopPanel:updateShowRoleInst(data)
  shopPanel:clearShowRoleArray()
  shopPanel:setCurShowIndex(1)
  shopPanel:setCurShowState(1)
  print("updateShowRoleInst")
  printTable(data)
  --碎片图标
  PrefabPool:Clear()
  PrefabPool:ClearCache()
  showRoleDataArray = {}
  curShowMaxNum = 0
  --模型
  local index = 1
  for k,v in pairs(data.hero) do
    showRoleDataArray[index] = {}
    showRoleDataArray[index].data = v.hero_id
    showRoleDataArray[index].type = 0
    index = index + 1
  end
  for k,v in pairs(data.goods) do
    showRoleDataArray[index] = {}
    showRoleDataArray[index].data = v.goods_id
    showRoleDataArray[index].type = 1
    index = index + 1
  end
  if index > 1 then 
    curShowMaxNum = index - 1
    shopPanel:setCurShowIndex(1)
    curLoadRoleNum = 0
    print("begin load model")
    print("curShowMaxNum:" .. curShowMaxNum)
    shopPanel:autoShowRole()
  end
end

function shopPanel:loadRoleItem(id)
  local refer = LuaHelper.GetComponent(showRolePanel.gameObject,"ReferGameObjects")
  local sprite = refer.monos[3]
  local curShowItem = LuaHelper.InstantiateLocal(sprite.gameObject,sprite.transform.parent.parent.gameObject)
  local refer1 = LuaHelper.GetComponent(curShowItem.gameObject,"ReferGameObjects")
  local sprite_icon = refer1.monos[0]
  sprite_icon.spriteName = Model.getItemData(id).icon
  curShowItem.gameObject:SetActive(true)
  shopPanel:ScaleTo(curShowItem.gameObject,Vector3(0,0,0),Vector3(1,1,1),0.8)
  --insert array
  curLoadRoleNum = curLoadRoleNum + 1
  showRoleArray[curLoadRoleNum] = {}
  showRoleArray[curLoadRoleNum].data = curShowItem
  showRoleArray[curLoadRoleNum].type = 1
  delay(shopPanel.autoShowRole,1,nil)
end

function shopPanel:autoShowRole()
  print("autoShowRole...")
  --error state
  if curShowState ~= 1 then
    print("curShowState error:" .. curShowState)
    return
  end
  --reset autoshow index
  if curLoadRoleNum > 0 then
    shopPanel:setCurShowIndex(curLoadRoleNum + 1)
  end
  --auto sucess
  if curShowIndex > curShowMaxNum then
    curShowIndex = curShowMaxNum
    print("load model finish")
    if #showRoleItemDataArray > 0 then
      shopPanel:setCurShowState(3)  
      shopPanel:autoShowRoleItem()
      return
    else
      shopPanel:setCurShowState(2)
      return
    end
  end
    --hide front role
  if curLoadRoleNum > 0 then
    --showRoleArray[curLoadRoleNum].data.gameObject:SetActive(false)
  end
  --load back role
  local reqs = {}
  print("curShowIndex: " .. curShowIndex)
  local showID = showRoleDataArray[curShowIndex].data
  print("id:" .. showID)
  print("type:" .. showRoleDataArray[curShowIndex].type)
  shopPanel:updateShowRolePos(nil)
  if showRoleDataArray[curShowIndex].type == 0 then
    local modleName = Model.getUnit(showID).model
    print("modle name:" .. modleName)
    common_fun.addToList(modleName,reqs,shopPanel.callbackLoadModel)
    common_fun.beginLoad(reqs)
  else
    shopPanel:loadRoleItem(showID)
  end
end

function shopPanel:setCurShowIndex(index)
  if index ~= curShowIndex then
    curShowIndex = index
    shopPanel:updateShowArrow()
  end
end

function shopPanel:onShowRolePreClick()
  print(bIsCoolDownShowRoleAnim)
  if bIsCoolDownShowRoleAnim == false then
    if curShowState == 2 and curShowMaxNum > 1 then
      if curShowIndex > 1 then
        shopPanel:setCurShowIndex(curShowIndex - 1)
        shopPanel:changeCurShowRole(true)
      end
    end
  end
end

function shopPanel:onShowRoleNextClick()
  if bIsCoolDownShowRoleAnim == false then
    if curShowState == 2 and curShowMaxNum > 1 then
      if curShowIndex < curShowMaxNum then
        shopPanel:setCurShowIndex(curShowIndex + 1)
        shopPanel:changeCurShowRole(false)
      end
    end
  end
end

function shopPanel:changeCurShowRole(bPre)
  if bPre == true then
    if curShowIndex ~= curShowMaxNum then
      --showRoleArray[curShowIndex + 1].data.gameObject:SetActive(false)
      shopPanel:updateShowRolePos(bPre)
    end
  else
    if curShowIndex ~= 1 then
      --showRoleArray[curShowIndex - 1].data.gameObject:SetActive(false)
      shopPanel:updateShowRolePos(bPre)
    end
  end
  --showRoleArray[curShowIndex].data.gameObject:SetActive(true)
end

function shopPanel:updateShowArrow()
  --Arrow update
  local maxNum = #showRoleItemDataArray + curShowMaxNum
  local refer = LuaHelper.GetComponent(showRolePanel.gameObject,"ReferGameObjects")
  local preBtn = refer.monos[1]
  local nextBtn = refer.monos[2]
  if curShowState == 2 and curShowMaxNum > 1 then --手动浏览
    if curShowIndex == 1 then
      preBtn.gameObject:SetActive(false)
      nextBtn.gameObject:SetActive(true)
    elseif curShowIndex < maxNum then
      preBtn.gameObject:SetActive(true)
      nextBtn.gameObject:SetActive(true)
    else
      preBtn.gameObject:SetActive(true)
      nextBtn.gameObject:SetActive(false)
    end
  else
    preBtn.gameObject:SetActive(false)
    nextBtn.gameObject:SetActive(false)
  end
end

function shopPanel:setCurShowState(state)
  if state ~= curShowState then 
    print("setCurShowState:" .. curShowState .. "..to:" .. state)
    curShowState = state
    shopPanel:updateShowState()
  end
end

function shopPanel:updateShowState()
  if curShowState == 0 then -- 初始状态
    showRoleScene:SetActive(true)
    showRolePanel.gameObject:SetActive(true)
    roleInfoPanel.gameObject:SetActive(false)
    showItemPanel.gameObject:SetActive(false)
    popItemInfoPanel.gameObject:SetActive(false)
  elseif curShowState == 1 then --自动加载role状态
    bIsCoolDownShowRoleAnim = false
    showRolePanel.gameObject:SetActive(false)
    roleInfoPanel.gameObject:SetActive(false)
  elseif curShowState == 2 then --手动浏览
    showRolePanel.gameObject:SetActive(true)
    roleInfoPanel.gameObject:SetActive(false)
  elseif curShowState == 3 then --自动加载item状态

  end
  shopPanel:updateShowArrow()
end

function shopPanel:clearShowRoleArray()
  if showRoleArray ~= nil then 
    for k,v in pairs(showRoleArray) do
      LuaHelper.Destroy(v.data.gameObject)
    end
    showRoleArray = {}
  end
end

function shopPanel:getShowItemRoleIDByMergeList(id)
  --从合成表中遍历关联的show role
  -- 获得合成表
  for k,v in pairs(Model.goodComp) do
    for i=1,#v.goods do
      if v.goods[i] == id then
        print("find merge role:" .. id .. ",role id:" .. v.index )
        return v.index
      end
    end
  end
  print("find merge role error:" .. id)
  return nil
end
--=====================================show effect=====================================
function shopPanel:CalcShowRolePos(obj,offset1,offset2)
  local paths = Vector3[2]
  if obj.type == 0 then
    local position = obj.data.transform.position
    paths[0] = position
    paths[1] = Vector3(position.x + offset1,position.y,position.y)
  else
    paths[1] = Vector3(offset2,0,0)
  end
  shopPanel:MoveTo(obj.data,paths,0.5)
end

function shopPanel:updateShowRolePos(bPre)
  local paths = Vector3[2]
  local paths1 = Vector3[2]
  local offset = 0
  if curShowState == 2 then --手动浏览模式
    if bPre == true then
      --cur center
      shopPanel:CalcShowRolePos(showRoleArray[curShowIndex],-3,0)
      --last center
      shopPanel:CalcShowRolePos(showRoleArray[curShowIndex + 1],-3,-2)
    else
      --cur center
      shopPanel:CalcShowRolePos(showRoleArray[curShowIndex],3,0)
      --last center
      shopPanel:CalcShowRolePos(showRoleArray[curShowIndex - 1],3,2)
    end
    bIsCoolDownShowRoleAnim = true
    local fun=function()bIsCoolDownShowRoleAnim = false end
    delay(fun,0.6,nil)
  else --自动浏览模式
    if curShowIndex > 1 then
      shopPanel:CalcShowRolePos(showRoleArray[curShowIndex - 1],3,2)
    end
  end
end

function shopPanel:MoveTo(obj,paths,time,oncomplete)
  local t={}
  t["path"] = paths
  t["movetopath"] = true
  t["orienttopath"] = false
  t["time"] = time
  t["easetype"] = iTween.EaseType.linear
  if oncomplete then   t["oncomplete"]=oncomplete end
  local has = iTween.HashLua(t)
  iTween.MoveTo(obj.gameObject,has)
end

function shopPanel:ScaleTo(taget,v3_frome,v3_scale,time)
  iTween.ScaleFrom(taget,v3_frome,0)
  iTween.ScaleTo(taget,v3_scale,time)
end
--=====================================message=====================================

function shopPanel:sendmessage(id)
  -- local cont = NetMsgHelper:makesend_player_mail_read(id)
  -- Proxy:send(NetAPIList.player_mail_read,cont)
end

function shopPanel:updateItemPage()
end

function shopPanel:getShopDataOfShopNo(index , number)
  local data = Model.getShopData()
  local ret = {}
  if data == nil then return nil end
  for k,v in pairs(data) do
    if v.shop_no == index then
      if number == nil or number == v.goods_num then
        table.insert(ret,v)
      end
    end
  end
  printTable(ret)
  return ret
end

function shopPanel:callback_recv_shop_goods()
  LastUpdateTime = os.time()
end

function shopPanel:callback_recv_buy_goods(data)
  waitingPanelEnd()
  print("callback_recv_buy_goods")
  printTable(data)
  if data.shop_no < 3 then
    shopPanel:chouRoleShowPanel(data.items)
  elseif data.shop_no == 3 or data.shop_no == 4 then
    shopPanel:chouGoodsShowPanel(data.items.goods)
  else
    if data.items.other[1].type == "vit" then
      if self.isShow == nil or self.isShow == false then
        local mainScene = LuaItemManager:getItemObject("mainScene")
        mainScene:callback_BuyVitSucess()
      end
    end
  end
end

--=====================================globle=====================================
function sendRequestShopDataMsg()
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.shop_goods,cont)
end
-- {
  -- 1、商城分组 shop_no
  --  由于商城内有单次抽卡与多抽卡所以需要给每个不同商城类型进行分组:
  --  1-召唤中友情抽卡
  --  2-召唤中水晶抽卡
  --  3-探索中友情探宝
  --  4-探索中水晶探宝
  --  5-金币购买
  --  6-水晶充值
  --  7-体力值购买


