---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: taskPanel.lua
--data:2014.11.10
--author:yue an bang
--desc:任务功能
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local taskPanel = LuaItemManager:getItemObject("taskPanel")
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
local FileUtils=FileUtils
local fileUtils = FileUtils()
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
taskPanel.assets=
{
  Asset("taskPanel.u3d"),
}
taskPanel.atrArray =
{
  ["crystal"] = "common_img018",
  ["gold"] = "common_img003",
  ["vit"] = "common_icon010"
}
taskPanel.taskList = {}
--==================================================================================================
local Refer,taskListTable,popInfoPanel,taskListPanel
local curTaskId = 0
local curTaskIndex = 0
local bPageList = true
local bFirst = true
local bPress = false
local bUpdateList = false
local curPageIndex = 1
--==================================================================================================

--==================================================================================================
function taskPanel:onAssetsLoad(items)
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  taskListTable = Refer.monos[0]
  popInfoPanel = Refer.monos[2]
  taskPanel:registerTableEvent(taskListTable)

  bFirst = false
  taskPanel:updateTaskPanel()
  waitingPanelEnd()
  print("....onAssetsLoad...")
end

function taskPanel:registerTableEvent(obj)
  if obj == taskListTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      if(itemdata) then
        referScipt.gameObject:SetActive(true)
        local item_sprite = referScipt.monos[0]         -- 任务类型icon
        local title_lable = referScipt.monos[1]         -- 任务标题
        local sender_lable = referScipt.monos[2]        -- 任务内容
        local ret_item_lable_10 = referScipt.monos[3]   -- 任务奖励1——经验
        local ret_item_lable_11 = referScipt.monos[4]   -- 任务奖励1——普通
        local ret_item_lable_2 = referScipt.monos[5]    -- 任务奖励2——普通
        local ret_item10 = referScipt.monos[6]          -- 任务奖励1——经验
        local ret_item11 = referScipt.monos[7]          -- 任务奖励1——普通
        local ret_item2 = referScipt.monos[8]           -- 任务奖励2——普通
        local finish_sprite = referScipt.monos[9]       -- 完成标志
        ret_item2.gameObject:SetActive(false)
        -- 1:{id:18;
        --   quest_progress:{total:3;current:1};quest_status:0;quest_id:600001
        --   };
        referScipt.name = "taskItem_" .. index
        if itemdata.quest_status == 0 then
          referScipt.monos[10].color = Color(0.7,0.7,0.7);  
          finish_sprite.gameObject:SetActive(false)
        else
          finish_sprite.gameObject:SetActive(true)
          referScipt.monos[10].color = Color(1,1,1);
        end   

        local data = Model.getTaskData(itemdata.quest_id)
        item_sprite.spriteName = data.quest_icon
        title_lable.text = getValue(data.quest_title) 
        local str = "(" .. itemdata.quest_progress.current .. "/" .. 
          itemdata.quest_progress.total .. ")"
        sender_lable.text = getValue(data.desc) .. str

        local bHasExp = true
        if data.rewards.team_exp ~= nil then
          ret_item_lable_10.text = "x" .. data.rewards.team_exp
          ret_item10.gameObject:SetActive(true)
          ret_item11.gameObject:SetActive(false)
          bHasExp = false
        else
          ret_item10.gameObject:SetActive(false)
          ret_item11.gameObject:SetActive(true)
        end
        for k,v in pairs(data.rewards) do
          if k ~= "team_exp" then
            if bHasExp == true then
              ret_item_lable_11.text = "x" .. data.rewards[k]
              ret_item11.spriteName = taskPanel.atrArray[k]
              bHasExp = false
            else
              ret_item_lable_2.text = "x" .. data.rewards[k]
              ret_item2.spriteName = taskPanel.atrArray[k]
              ret_item2.gameObject:SetActive(true)  
            end
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

function taskPanel:onClick(obj,arg)
  local cmd = obj.name;
  if cmd == "ButtonClose" then
    taskPanel:hideAll()
  elseif cmd == "ButtonOk" then
    taskPanel:onClickFinish()
  elseif string.find(cmd,"Button_title_") then
    taskPanel:onClickTitle(obj)
  elseif string.find(cmd,"taskItem_") then
    taskPanel:onClickTaskItem(obj)
  end
end

function taskPanel:onClickFinish()
  local cont = NetMsgHelper:makesend_receive_quest_goods(tonumber(curTaskId))
  Proxy:send(NetAPIList.receive_quest_goods,cont)
  
  taskPanel:removeTaskFromList(curTaskId)
  taskListTable:removeDataAt(curTaskIndex)
  taskListTable:Refresh()
  popInfoPanel.gameObject:SetActive(false)
end

function taskPanel:onClickTaskItem(obj)
  local index = tonumber(string.sub(obj.name,10))
  local itemdata = taskListTable:getDataFromIndex(index)
  local isFinish = itemdata.quest_status
  if isFinish == 1 then
    curTaskId = itemdata.id
    curTaskIndex = index
    popInfoPanel.gameObject:SetActive(true)
    local refer = LuaHelper.GetComponent(popInfoPanel.gameObject,"ReferGameObjects")  
    local data = Model.getTaskData(itemdata.quest_id)
    refer.monos[0].text = getValue(data.quest_title) 
    local bHasExp = true
    if data.rewards.team_exp ~= nil then
      refer.monos[4].text = "x" .. data.rewards.team_exp
      refer.monos[1].gameObject:SetActive(true)
      refer.monos[2].gameObject:SetActive(false)
      bHasExp = false
    else
      refer.monos[1].gameObject:SetActive(false)
      refer.monos[2].gameObject:SetActive(true)
    end
    refer.monos[3].gameObject:SetActive(false)  
    for k,v in pairs(data.rewards) do
      if k ~= "team_exp" then
        if bHasExp == true then
          refer.monos[5].text = "x" .. data.rewards[k]
          refer.monos[2].spriteName = taskPanel.atrArray[k]
          bHasExp = false
        else
          refer.monos[6].text = "x" .. data.rewards[k]
          refer.monos[3].spriteName = taskPanel.atrArray[k]
          refer.monos[3].gameObject:SetActive(true)  
        end
      end
    end
  end
end

function taskPanel:onClickTitle(obj)
  local index = tonumber(string.sub(obj.name,15,15))
  local isSel = string.find(obj.name,"sel")
  if index == curPageIndex then
    return
  end
  --update view
  local Button_01 = Refer.monos[4]
  local Button_01_sel = Refer.monos[5]
  local Button_02 = Refer.monos[6]
  local Button_02_sel = Refer.monos[7]

  Button_01.gameObject:SetActive(false)
  Button_01_sel.gameObject:SetActive(false)
  Button_02.gameObject:SetActive(false)
  Button_02_sel.gameObject:SetActive(false)
  if index == 1 then
    Button_01_sel.gameObject:SetActive(true)
    Button_02.gameObject:SetActive(true)
  else
    Button_01.gameObject:SetActive(true)
    Button_02_sel.gameObject:SetActive(true)
  end
  curPageIndex = index
  --update data
  taskPanel:changePage()
end

function taskPanel:changePage()
  taskPanel:updateTaskPanel()
end

function taskPanel:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end

  if bFirst == false and bUpdateList == true then
    taskPanel:updateTaskPanel()
  end
end

function taskPanel:onHide()
  if popInfoPanel ~= nil then
    popInfoPanel.gameObject:SetActive(false)
  end
end

function taskPanel:sendRequestTaskList()
  if self.isShow == true then
    -- local cont = NetMsgHelper:makesend_player_mail_list(tonumber(MailData.getMailCount()))
    -- Proxy:send(NetAPIList.player_mail_list,cont)
  end
end

function taskPanel:hideAll()
  self:removeFromState();
  self.isShow = false;
end

--=====================================message=====================================

function taskPanel:sendReadTask(id)
  -- local cont = NetMsgHelper:makesend_player_mail_read(id)
  -- Proxy:send(NetAPIList.player_mail_read,cont)
end

function taskPanel:updateTaskPanel()
    print("updateTaskPanel..")
    local curTasklist = {}
    for k,v in pairs(taskPanel.taskList) do
      local data = Model.getTaskData(v.quest_id)   
      if data ~= nil then
        if data.category == curPageIndex then
          table.insert(curTasklist,v)
        end
      end
    end

    --sort
    sortFinish=function(a,b)return a.quest_status>b.quest_status end
    table.sort(curTasklist,sortFinish)

    printTable(taskPanel.taskList)
    printTable(curTasklist)
    taskListTable:clear()
    taskListTable.pageSize = 5--#curTasklist
    taskListTable.data = curTasklist
    taskListTable:Refresh()  
    bUpdateList = false
    local fun=function() taskListTable:scrollTo(0) end 
    delay(fun,0.1,nil)
end

function taskPanel:removeTaskFromList(id)
  for k,v in pairs(taskPanel.taskList) do
    if v.id == id then
      print("removeTaskFromList:   " .. id)
      printTable(v)
      table.remove(taskPanel.taskList,k)
      printTable(taskPanel.taskList)
      return
    end
  end
end

function taskPanel:updateTaskList(data)
  --id:18;quest_progress:{total:3;current:1};quest_status:0;quest_id:600001
  if taskPanel.taskList == nil then
    return print("update task list nil..")
  end
  if data == nil or #data == 0 then
    return print("update task data nil..")
  end
  for k,v in pairs(data) do
    taskPanel:checkAndUpdateTask(v)
  end
end

function taskPanel:checkAndUpdateTask(data)
  for k,v in pairs(taskPanel.taskList) do
    if v.id == data.id then
      v.quest_status = data.quest_status
      v.quest_progress.current = data.quest_progress.current
      return true
    end
  end
  table.insert(taskPanel.taskList,data)
  return false
end

function taskPanel:recv_player_task_list(data)
  print("recv task list..")
  printTable(data["list"])
  if #data["list"] > 0 then
    taskPanel:updateTaskList(data["list"])
  end
  if bFirst == false then
    taskPanel:updateTaskPanel()
  else 
    bUpdateList = true    
  end
end
--=====================================globle=====================================




