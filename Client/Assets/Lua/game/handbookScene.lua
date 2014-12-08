---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: handbookScene.lua
--data:2014.10.28
--author:yue an bang
--desc:图鉴功能
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local handbookScene = LuaItemManager:getItemObject("handbookScene")
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
local getValue = getValue
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local Color = UnityEngine.Color
local RenderSe ttingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
handbookScene.assets=
{
  Asset("handbookPanel.u3d"),
  Asset("heroPanel.u3d", {"Refers"}),
  Asset("Strengthenmap.u3d"),
}
handbookScene.serverData = {}
--==================================================================================================
local Refer,sceneRefer,rootPanel,roleInfoPanel
local curShowModel = nil
local bFirst = true
local curShowRoleID = 0
local bookTable = {}
local bookData = {}
local tablePanel
--配置表中得类型和存放在本地数据中得ID映射
handbookScene.category={
  [1]=2,
  [2]=3,
  [3]=4,
  [4]=5,
  [5]=6,
}
--==================================================================================================

--==================================================================================================
function handbookScene:onAssetsLoad(items)
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  sceneRefer = LuaHelper.GetComponent(self.assets[3].root,"ReferGameObjects")
  roleInfoPanel = self.assets[2].items["Refers"]
  rootPanel = Refer.monos[10]

  fun=function()Refer.monos[1].text = tonumber(#handbookScene.serverData)end
  delay(fun,1,nil)
  

  tablePanel = Refer.monos[9]
  --handbookScene:registerTableEnvent(tablePanel)
  for i=1,5 do
    bookTable[i] = Refer.monos[3 + i]
    handbookScene:registerTableEnvent(bookTable[i])
  end
  handbookScene:initBookData()
  handbookScene:updateBookPanel()
  print("....onAssetsLoad...")
  
  bFirst = false
  waitingPanelEnd()
end

function handbookScene:initBookData()
  bookData = {}
  local count = 0
  for k,v in pairs(Model.units) do
    local str = string.sub(v.id ,1,2)
    if str == "20" then
      if bookData[v.category1] == nil then
        bookData[v.category1] = {}
      end
      count = count + 1
      table.insert(bookData[v.category1],v)
    end
  end

  --按id升序排序
  sortLevel=function(a,b)return a.id<b.id end
  for k,v in pairs(bookData) do
    table.sort(v,sortLevel)
  end
  Refer.monos[1].text = 0
  Refer.monos[2].text = count
end

function handbookScene:loadModel(roleid)
  PrefabPool:Clear()
  PrefabPool:ClearCache()

  local reqs = {}
  local modleName = Model.getUnit(roleid).model
  print("modle name:" .. modleName)
  common_fun.addToList(modleName,reqs,handbookScene.callbackLoadModel)
  common_fun.beginLoad(reqs)
end

function handbookScene:callbackLoadModel(key)
  print("handbookScene... load callback ，name:" .. key)
  if curShowModel ~= nil then
    LuaHelper.Destroy(curShowModel.gameObject)
  end
  local role = PrefabPool:Get(key)
  if role ~= nil and sceneRefer.refers[0] ~= nil then
    curShowModel = LuaHelper.InstantiateLocal(role,
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
  end
end

function handbookScene:updateBookPanel()
  
  -- tablePanel.PageSize = #bookData
  -- tablePanel.data = bookData
  -- tablePanel:Refresh()

  for i=1,5 do
    local category = handbookScene.category[i]
    bookTable[i]:clear()
    bookTable[i].PageSize = #bookData[category]
    print("bookTable[i].PageSize:" .. bookTable[i].pageSize .. "i:" .. i)
    bookTable[i].data = bookData[category]
    printTable(bookData[category])
    bookTable[i]:Refresh()
  end
end

function handbookScene:clearShowRole()
  if curShowModel ~= nil then
    LuaHelper.Destroy(curShowModel.gameObject)
    curShowModel = nil
  end
end

function handbookScene:registerTableEnvent(obj)
  obj.onItemRender=function(referScipt,index,itemdata)
    if(itemdata) then
      -- print("onItemRender..")
      -- print(referScipt)
      referScipt.gameObject:SetActive(true)
      if obj == tablePanel then
        -- 嵌套table，未通过测试
        -- local item_sprite = referScipt.monos[0]  -- icon
        -- local itemTable = referScipt.monos[1]
        -- item_sprite.spriteName = "handbook_icon0" .. index
        -- print("index:" .. index)
        -- local category = handbookScene.category[index]
        -- bookTable[index].PageSize = #bookData[category]
        -- print("bookTable[index].PageSize:" .. bookTable[index].PageSize)
        -- bookTable[index].data = bookData[category]
        -- printTable(bookTable[index].data)
        -- bookTable[index]:Refresh()
      else
        local isOwn,lv = handbookScene:checkIsOwnHandbook(itemdata.id)        
        local item_sprite = referScipt.monos[0]  -- 道具icon  
        local bg_sprite = referScipt.monos[1]  -- bg 
        local full_sprite = referScipt.monos[2]  -- full icon 
        full_sprite.gameObject:SetActive(false)  
        if isOwn == true then
          item_sprite.color = Color(1,1,1);
          bg_sprite.color = Color(1,1,1); 
          if lv >= 30 then
            full_sprite.gameObject:SetActive(true)
          end   
        else
          item_sprite.color = Color(0,0,0);
          bg_sprite.color = Color(0,0,0); 
        end        
        item_sprite.spriteName = Model.getUnit(itemdata.id).icon
        updateShowStar(referScipt,itemdata.star,2,isOwn)
      end
    else
      print("onItemRender object nil")
      print(referScipt)
      if referScipt and referScipt.gameObject then
        referScipt.gameObject:SetActive(true)   
      end
    end
  end

  obj.onPreRender=function(referScipt,index,dataItem)
    referScipt.name="Pre_item"..tostring(dataItem.id)
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

function handbookScene:onClickSkill(obj) 
  handbookScene:showPopItemInfo(obj)
end

function handbookScene:onClickIcon(cmd)
  local id = string.sub(cmd,9)
  print("onClickIcon:" .. id)
  handbookScene:showRole(id)
end

function handbookScene:hideShowPanel()
  rootPanel.gameObject:SetActive(true)
  roleInfoPanel.gameObject:SetActive(false)
  self.assets[3].root:SetActive(false)
end

function handbookScene:onClick(obj,arg)
  local cmd = obj.name;
  print("click：" .. cmd)
  if cmd == "ButtonClose" then
    self:hideAll()
  elseif cmd == "back_btn" then
    handbookScene:hideShowPanel()
  elseif string.find(cmd,"Pre_item") then
    handbookScene:onClickIcon(cmd)
  elseif string.find(cmd,"Clone_Modle") then
    print("Clone_Modle:" .. cmd)
    local actor = LuaHelper.GetComponent(obj,"RoleActor") 
    actor.roleAnimator:Play("Show",0)   
  end
end

function handbookScene:onPress(obj,arg)
  local cmd = obj.name
  if string.find(cmd,"skill_")  then
    handbookScene:onClickSkill(obj) 
  end
end

function handbookScene:onHide( ... )
  handbookScene:clearShowRole()
  --self:clear()
end

function handbookScene:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end
end

function handbookScene:hideAll()
  handbookScene:clearShowRole()
  self:removeFromState();
  self.isShow = false;
end

function handbookScene:showRole(id)
  rootPanel.gameObject:SetActive(false)
  roleInfoPanel.gameObject:SetActive(true)
  self.assets[3].root:SetActive(true)
  curShowRoleID = id
  handbookScene:loadModel(id)

  local refer = LuaHelper.GetComponent(roleInfoPanel,"ReferGameObjects")
  local showRoleRefer = LuaHelper.GetComponent(refer.refers[0].gameObject,"ReferGameObjects")
  handbookSceneShowRole(showRoleRefer,id)
end

function handbookScene:showPopItemInfo(obj)
  showPopSkillInfo(roleInfoPanel,obj)
end

function handbookScene:checkIsOwnHandbook(id)
  if handbookScene.serverData == nil then
    handbookScene.serverData = {}
  end 

  if tonumber(#handbookScene.serverData) > 0 then
    for k,v in pairs(handbookScene.serverData) do
      if id == v.system_hero_id then
        return true,v.player_hero_lv
      end
    end
  end
  return nil,nil
end

function handbookScene:isOwnerCard(id,lv)
  if handbookScene.serverData == nil or 
    #handbookScene.serverData == 0 then
    return false
  end

  for k,v in pairs(handbookScene.serverData) do
    if id == v.system_hero_id then
      v.player_hero_lv = lv  
      return true
    end
  end
  return false
end

function handbookScene:updateHandbookData(data)
  for k,v in pairs(data) do
    local ret = handbookScene:isOwnerCard(v.system_hero_id,v.player_hero_lv)
    if ret == false then
      table.insert(handbookScene.serverData,v)
    end
  end
  printTable(handbookScene.serverData)
end

function handbookScene:recv_hero_atlas_list( data )
  print("---------")
  print("---------callback_message_recv_handbookScene---------")
  print("---------")
  printTable(data.list)
  handbookScene:updateHandbookData(data.list)
  print("serverdata count:" .. #handbookScene.serverData)
end
--=====================================message=====================================
function sendRequestHandbookMsg()
  local cont = NetMsgHelper:makesend_player_hero_stlas_list(0)
  Proxy:send(NetAPIList.select_player_hero_atlas_player_id,cont)
end

function showPopSkillInfo(roleInfoPanel,obj)
  local cmd = obj.name;
  local index = string.sub(cmd,7,7)
  local id = string.sub(cmd,9)
  print("onClickSkill:" .. cmd .. "id:" .. id .. ",index:" .. index)

  local Refer = LuaHelper.GetComponent(roleInfoPanel,"ReferGameObjects")
  local popPanel = Refer.refers[1]
  local refer = LuaHelper.GetComponent(popPanel.gameObject,"ReferGameObjects")
  local posY = popPanel.transform.position.y
  local posX = obj.transform.position.x
  local vector = Vector3(posX,posY,0)
  popPanel.transform.position = vector
  local BGSprite = refer.monos[0]
  local SpritePosY = BGSprite.transform.localPosition.y
  if tonumber(index) < 3 then
    local vector = Vector3(100,SpritePosY,0)
    BGSprite.transform.localPosition = vector
  else
    local vector = Vector3(-100,SpritePosY,0)
    BGSprite.transform.localPosition = vector
  end

  local id = string.sub(obj.transform.name,9) 
  local table = Model.getSkill(id)
  printTable(table)

  if table ~= nil then
    refer.monos[1].text = getValue(table.description) 
  end
end

function updateShowStar(obj,starNum,offsetIndex,isOwn)
  local star_sprite = {}
  for i=1,5 do
    star_sprite[i] = obj.monos[offsetIndex+i]  -- star icon  
    star_sprite[i].gameObject:SetActive(false)
  end
  for i=1,starNum do
    if isOwn == true then
      star_sprite[i].color = Color(1,1,1); 
    else
      star_sprite[i].color = Color(0,0,0); 
    end
    star_sprite[i].gameObject:SetActive(true)
  end
end

function handbookSceneShowRole(showRoleRefer,id)
  local skillSprite = {}
  skillSprite[1] = showRoleRefer.monos[3] --skill icon
  skillSprite[2] = showRoleRefer.monos[4] --skill icon
  skillSprite[3] = showRoleRefer.monos[5] --skill icon
  skillSprite[4] = showRoleRefer.monos[6] --skill icon

  local data = Model.getUnit(id)
  if data == nil then print("show id error:" .. id) return end
  showRoleRefer.monos[0].text = getValue(data.name)--name
  showRoleRefer.monos[1].text = getValue(data.desc)--info
  showRoleRefer.monos[2].spriteName = data.icon--icon
  for i=1,4 do
    local skillIndex = i+1--技能从第2位开始，第一位是普通技能
    print(data.skill[skillIndex])
    local skillData = Model.getSkill(data.skill[skillIndex])
    if skillData ~= nil then
      skillSprite[i].gameObject:SetActive(true)
      skillSprite[i].name = "skill_" .. i .. "_" .. skillData.id
      skillSprite[i].spriteName = skillData.icon
      --skill name 
      local skillrefer = LuaHelper.GetComponent(skillSprite[i].gameObject,"ReferGameObjects")
      skillrefer.monos[0].text = getValue(skillData.name)
    else
      skillSprite[i].gameObject:SetActive(false)
    end
  end

  --update Star
  updateShowStar(showRoleRefer,data.star,10,true)

  showRoleRefer.monos[7].text = data.property.hp --hp
  local dmage = data.property.magicDamage
  if dmage < data.property.damage then damage = data.property.damage end
  showRoleRefer.monos[8].text = dmage --att
  showRoleRefer.monos[9].text = data.property.defend --def
  showRoleRefer.monos[10].text = data.property.magicDefend --mdef
end
