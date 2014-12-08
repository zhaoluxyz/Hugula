---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: mailPanel.lua
--data:2014.10.22
--author:yue an bang
--desc:邮件功能
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local mailPanel = LuaItemManager:getItemObject("mailPanel")
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
local common_fun = common_fun
local Proxy=Proxy
local Model = Model
local MailData = MailData
local getValue = getValue
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local Color = UnityEngine.Color
local FileUtils=FileUtils
local fileUtils = FileUtils()
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
mailPanel.assets=
{
  Asset("mailPanel.u3d"),
}
mailPanel.mailFileName = ""
--==================================================================================================
local Refer,mailListTable,mailInfoTable,popInfoPanel,mailListPanel,mailInfoPanel
local curMailId
local bPageList = true
local bFirst = true
local bHasItem = false
local bPress = false
local mailData = {}
--==================================================================================================

--==================================================================================================
function mailPanel:onAssetsLoad(items)
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  mailListTable = Refer.monos[0]
  print("....onAssetsLoad...")
  print(mailListTable)
  mailListPanel = Refer.monos[1]
  mailInfoPanel = Refer.monos[2]
  popInfoPanel = Refer.monos[3]
  mailInfoTable = Refer.monos[4]
  mailListPanel.gameObject:SetActive(true)
  mailInfoPanel.gameObject:SetActive(false)

  mailPanel:registerTableEnvent(mailListTable)
  mailPanel:registerTableEnvent(mailInfoTable)

  bFirst = false

  mailPanel:sendRequestMailList()
  mailPanel:updateMailPanel()
  waitingPanelEnd()
end

function mailPanel:registerTableEnvent(obj)
  if obj == mailListTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      if(itemdata) then
        local item_sprite = referScipt.monos[0]  -- 道具icon
        local title_lable = referScipt.monos[1]  -- 标题信息
        local sender_lable = referScipt.monos[2] -- 发送者名字
        local date_lable = referScipt.monos[3]   -- 日期
        referScipt.gameObject:SetActive(true)
        referScipt.name = "mailID_" .. itemdata.mail_id
        local item = LuaHelper.GetComponent(referScipt.gameObject,"UIButton")
        if itemdata.mail_status == 1 then
          item.defaultColor = Color(0.6,0.6,0.6);
          item.hover = Color(0.6,0.6,0.6);
        else
          item.defaultColor = Color(1,1,1);
          item.hover = Color(1,1,1);
        end
          -- t["mail_id"]
          -- t["mail_group"]
          -- t["player_id"]
          -- t["player_name"]
          -- t["mail_title"]
          -- t["mail_body"]
          -- t["mail_goods"]
          -- t["mail_status"]
          -- t["mail_create_at"]
        -- item_sprite.spriteName = itemdata.spriteName
        title_lable.text = itemdata.mail_title
        sender_lable.text = itemdata.player_name
        date_lable.text = itemdata.mail_create_at
      end
    end
  elseif obj == mailInfoTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      if(itemdata) then
        local item_sprite = referScipt.monos[0]
        local item_num = referScipt.monos[1]
        --printTable(itemdata)
        referScipt.name = "itemID_" .. index .. "_" .. itemdata.goods_id
        if Model.getItemData(itemdata.goods_id) == nil then 
          print("error item id:" .. itemdata.goods_id)
        else
          item_sprite.spriteName = Model.getItemData(itemdata.goods_id).icon
        end
        
        item_num.gameObject:SetActive(false)
        if itemdata.goods_num > 1 then
          item_num.text = itemdata.goods_num
          item_num.gameObject:SetActive(true)
        end
        referScipt.gameObject:SetActive(true)
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

function mailPanel:onClick(obj,arg)
  local cmd = obj.name;
  if cmd == "ButtonClose" then
    if bPageList == true then 
      self:hideAll();
    elseif bPageList == false then
      mailPanel:openListPanel()
    end
  elseif string.find(cmd,"mailID_") then
    mailPanel:onClickMail(obj)
  elseif cmd == "DeleteBtn" then
    if bHasItem == true then
      mailPanel:sendGaveItemFormMail(curMailId)
    end
    mailPanel:deleteMail(curMailId)
    mailPanel:openListPanel()
  end
end

function mailPanel:onClickMail(obj)
  local id = string.sub(obj.name,8)
  --print("onClickMail:" .. id)
  local item = LuaHelper.GetComponent(obj.gameObject,"UIButton")
  item.defaultColor = Color(0.6,0.6,0.6);
  item.hover = Color(0.6,0.6,0.6);
  mailPanel:openInfoPanel(tonumber(id))
end

function mailPanel:openListPanel()
  print("openListPanel:")
  mailListPanel.gameObject:SetActive(true)
  mailInfoPanel.gameObject:SetActive(false)
  bPageList = true
end

function mailPanel:openInfoPanel(id)
  print("openInfoPanel:" .. id)
  local info = MailData.getMailFromID(id)
  if info ~= nil then
    printTable(info)
    mailListPanel.gameObject:SetActive(false)
    mailInfoPanel.gameObject:SetActive(true)
    mailPanel:sendReadMail(id)
    MailData.SetMailRead(id)
    mailPanel:writeMail2File()

    local itemRefer = LuaHelper.GetComponent(mailInfoPanel.gameObject,"ReferGameObjects")
    itemRefer.monos[0].text = info.mail_title
    itemRefer.monos[1].text = info.mail_body
    itemRefer.monos[2].text = "x" .. info.mail_goods.crystal
    printTable(info.mail_goods)
    printTable(info.mail_goods.goods)

    mailInfoTable.pageSize = #info.mail_goods.goods
    mailInfoTable.data = info.mail_goods.goods
    mailInfoTable:Refresh()

    if mailInfoTable.pageSize > 0 then
      bHasItem = true
      itemRefer.monos[3].text = getValue("main_mail_004")
    else
      bHasItem = false
      itemRefer.monos[3].text = getValue("main_mail_003")
    end
    curMailId = id
    bPageList = false
  else
    print("error:" .. id)
  end
end

function mailPanel:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end
end

function mailPanel:sendRequestMailList()
  local count = MailData.getNewMailCount()
  if count > 0 and self.isShow == true then
    print("sendRequestMailList, count:" .. count)
    local cont = NetMsgHelper:makesend_player_mail_list(tonumber(MailData.getMailCount()))
    Proxy:send(NetAPIList.player_mail_list,cont)
  end
end

function mailPanel:hideAll()
  self:removeFromState();
  self.isShow = false;
end

function mailPanel:onPress(obj,arg)
  if bPress == true then
    bPress = false
    return
  end
  bPress = true
  if string.find(obj.name,"itemID_") then
    local index = string.sub(obj.name,8,8)
    local id = string.sub(obj.name,10)
    mailPanel:showPopItemInfo(obj,tonumber(index),tonumber(id))
  end
end

function mailPanel:showPopItemInfo(obj,index,id)
  local refer = LuaHelper.GetComponent(popInfoPanel.gameObject,"ReferGameObjects")
  local posY = obj.transform.position.y
  local posX = obj.transform.position.x
  local vector = Vector3(posX,posY,0)
  popInfoPanel.transform.position = vector
  local BGSprite = refer.monos[5]
  if index % 4 < 2 then
    local vector = Vector3(100,-15,0)
    BGSprite.transform.localPosition = vector
  else
    local vector = Vector3(-100,-15,0)
    BGSprite.transform.localPosition = vector
  end

  -- local id = string.sub(obj.transform.name,7) 
  local table = Model.getItemData(id)
  if table ~= nil then
    obj.spriteName = table.icon
    refer.monos[0].spriteName = table.icon -- iconSprite
    refer.monos[1].text = table.usable_level
    refer.monos[2].text = getValue(table.name)
    refer.monos[4].text = getValue(table.Desc2)
  end
end
--=====================================message=====================================
function mailPanel:callback_message_recv_mail_count( data )
  print("callback_message_recv_mail_count..")
  print(MailData.getNewMailCount())
  --update panel
  
  mailPanel:sendRequestMailList()
  mailPanel:writeNewMailCount()
end

function mailPanel:sendReadMail(id)
  local cont = NetMsgHelper:makesend_player_mail_read(id)
  Proxy:send(NetAPIList.player_mail_read,cont)
end

function mailPanel:sendDeleteMail(id)
  local cont = NetMsgHelper:makesend_player_mail_delete(id)
  Proxy:send(NetAPIList.player_mail_delete,cont)
end

function mailPanel:sendGaveItemFormMail(id)
  local cont = NetMsgHelper:makesend_player_mail_goods(id)
  Proxy:send(NetAPIList.player_mail_goods,cont)
end

function mailPanel:deleteMail(id)
  print("deletemail .. id :" .. id)
  MailData.deleteMail(id)
  printTable(MailData.getMailData())
  mailPanel:sendDeleteMail(id)
  mailPanel:writeMail2File()
  -- mailListTable:removeDataAt()
  mailPanel:updateMailPanel()
end

function mailPanel:setMailFileName()
  playerID = Model.getPlayerInfo().player_hero_id
  print("player id :" .. playerID)
  mailPanel.mailFileName = "maildata" .. playerID.. ".text"
  print(mailPanel.mailFileName)
end

function mailPanel:writeNewMailCount()
  PlayerPrefs.SetString("newMailCount",tonumber(MailData.getNewMailCount()))
  local newCount = PlayerPrefs.GetString("newMailCount",0)
  print("writeNewMailCount newCount:" .. newCount)
end

function mailPanel:readNewMailCount()
  local newCount = PlayerPrefs.GetString("newMailCount",0)
  print("readNewMailCount newCount:" .. newCount)
  MailData.setNewMailCount(tonumber(newCount))
end

function mailPanel:writeMail2File()
  print("writeMail2File")
  print(common_fun.serialize(MailData.getMailData()))
  fileUtils:CreateFile(mailPanel.mailFileName,common_fun.serialize(MailData.getMailData()),true)
end

function mailPanel:readMailFromFile()
  --local table = "{{1,\"123\",\"23424\",21},{2,\"123\",\"sdfa\",22},{3,\"asdf\",\"23424\",2}}"
  local ret = fileUtils:ReadFile(mailPanel.mailFileName)
  print("ReadFile")
  print(ret)
  local table1 = common_fun.unserialize(ret)
  print(table1)
  if table1 ~= nil then
    printTable(table1)
  end
  return table1
end

function mailPanel:InitMailData()
  print("InitMailData..")
  mailPanel:setMailFileName()
  mailPanel:readNewMailCount()
  local table = mailPanel:readMailFromFile()
  print("readMailFromFile")
  print(table)
  if table == nil or #table == 0 then
    print("readMailFromFile_11111")
  else
    print("readMailFromFile_22222")
    MailData.insertMail(table)
  end

  mailPanel:sendRequestMailList()
end

function mailPanel:updateMailPanel()
    print("updateMailPanel..")
    local mailData = MailData.getMailData()
    printTable(mailData)
    mailListTable:clear()
    mailListTable.pageSize = #mailData
    mailListTable.data = mailData
    mailListTable:Refresh()  
end

function mailPanel:callback_recv_player_mail_list(data)
  local maxCount = MailData.getNewMailCount()
  local recvCount = #data.list
  print("recv mail count:" .. recvCount .. "max:" .. maxCount)
  if maxCount > recvCount then
    MailData.setNewMailCount(maxCount - recvCount)
  else
    MailData.setNewMailCount(0)
  end
  
  if recvCount > 0 then
    MailData.insertMail(data.list)
    mailPanel:writeMail2File()
    mailPanel:writeNewMailCount()
    mailPanel:updateMailPanel()
  end
end
--=====================================globle=====================================




