---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: processMessage.lua
--data:2014.7.1
--author:yue an bang
--desc:游戏服务器网络消息处理模块
--===============================================================================================--
---------------------------------------------------------------------------------------------------

processMessage = {}
local processMessage = processMessage
local Proxy = Proxy
local Model = Model
local MailData = MailData
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local common_fun = common_fun

function processMessage:bind()
  --player data
  Proxy:binding(NetAPIList.recv_player_attribute1,callback_message_recv_player_attribute1)
  --item data
  Proxy:binding(NetAPIList.recv_player_bag_change_goods, callback_message_recv_player_bag_change_goods);
  --mail data
  Proxy:binding(NetAPIList.recv_mail_count,callback_message_recv_mail_count)
  
  Proxy:binding(NetAPIList.recv_player_mail_list,callback_recv_player_mail_list)
  --签到
  Proxy:binding(NetAPIList.recv_reward_data,callback_message_recv_singIn)

  --handbook
  Proxy:binding(NetAPIList.recv_hero_atlas_list,callback_recv_hero_atlas_list)

  --任务列表
  Proxy:binding(NetAPIList.recv_player_quest_list,callback_recv_player_task_list)

  --请求好友列表
  Proxy:binding(NetAPIList.recv_friends_list, callback_recv_friend_list)

  --好友申请列表
  Proxy:binding(NetAPIList.recv_friends_apply_list, callback_recv_friend_apply_list)

  --好友邮件列表
  Proxy:binding(NetAPIList.recv_friends_mail_list, callback_recv_friend_mail)
  --友情点剩余次数
  Proxy:binding(NetAPIList.recv_friends_remain_count, callback_recv_friend_ship_times)
  --神兽数据
  Proxy:binding(NetAPIList.recv_player_beast_list, callback_recv_player_beast_list)

  --活动数据
  Proxy:binding(NetAPIList.recv_activity_list, callback_recv_activity_list);

  --活动剩余次数
  Proxy:binding(NetAPIList.recv_activity_residue_list, callback_recv_activity_times);
  --商城数据
  Proxy:binding(NetAPIList.recv_shop_goods_list,callback_recv_shop_goods);
  --购买商品返回
  Proxy:binding(NetAPIList.recv_buy_goods,callback_recv_buy_goods);
  
  --删除好友消息
  Proxy:binding(NetAPIList.recv_player_friends_delete,callback_recv_delete_friend);
  
  --系统配置
  Proxy:binding(NetAPIList.recv_system_conf_data,callback_recv_system_conf_data);

  ---- other 其他
  --- 注册背包回调
  local localPack = LuaItemManager:getItemObject("packPanel")
  if localPack then localPack.msgCallBackBind() end
  --- 注册队伍回调
  local localTeam = LuaItemManager:getItemObject("teamPanel")
  if localTeam then localTeam.msgCallBackBind() end

end

function processMessage:ChatBind()
  --player data
  Proxy:binding(NetAPIList.recv_broadcast_message,callback_message_recv_chat)
  --chat hertbeat
  Proxy:binding(NetAPIList.chat_heartbeat,callback_message_chat_heartbeat)
end

--=====================================globle=====================================--

function callback_message_chat_heartbeat(data)
  local cont = NetMsgHelper:makept_int(0)
  Proxy:sendChat(NetAPIList.chat_heartbeat,cont)
end

function callback_message_recv_player_attribute1( data )
  -- print("------0000-----------------")
  Model.InitPlayerDataEx(data)
  local arry = {"mainScene","mapScene","shopPanel"}
  for k,v in pairs(arry) do
    local ListenerItem = LuaItemManager:getItemObject(v)
    if ListenerItem ~= nil then
      ListenerItem:updateView()
    end
  end
  updateFriendship_Call_back();
end

function callback_message_recv_mail_count(data)
  local mailPanel = LuaItemManager:getItemObject("mailPanel")
  MailData.setNewMailCount(data.count)
  mailPanel:callback_message_recv_mail_count(data)
end

function callback_recv_player_mail_list(data)
  print("callback_recv_player_mail_list")
  printTable(data.list)
  local mailPanel = LuaItemManager:getItemObject("mailPanel")
  mailPanel:callback_recv_player_mail_list(data)
end

 --[[t["channel_id"]=channel_id
  t["type"]=type
  t["body"]=body
  t["sender_player_id"]=sender_player_id
  t["sender_player_role"]=sender_player_role
  t["sender_player_name"]=sender_player_name
  t["create_at"]=create_at]]

function callback_message_recv_chat( data )
  local isQualified, content = common_fun.checkString(data.body);

  Model.insertWorldChatMsgs(data.sender_player_name, content);
  receive_Chat_Msg(data.sender_player_name, content);
  printTable(data)
end

function callback_message_recv_singIn(data)
  print("收到签到消息..!!");
  Model.setSignInData(data);
end

function callback_recv_hero_atlas_list(data)
  local handbookScene = LuaItemManager:getItemObject("handbookScene")
  handbookScene:recv_hero_atlas_list(data)
end

function callback_recv_player_task_list(data)
  local taskPanel = LuaItemManager:getItemObject("taskPanel")
  taskPanel:recv_player_task_list(data)
end

function callback_recv_friend_list(data)
  print("receive friend list msg");
  for i,v in pairs(data.list) do
    local t = {};
    t["friends_player_id"] = v.friends_player_id
    t["friends_player_lv"] = v.friends_player_lv
    t["friends_player_role_id"] = v.friends_player_role_id
    t["friends_player_name"] = v.friends_player_name
    t["give_away_friendship"] = v.give_away_friendship
    t["cool_down"] = v.cool_down
    t["unread_mail_count"] = v.unread_mail_count
    print(t.friends_player_name);

    local isInsert = true;
    
    for j,k in pairs(Model.friendList) do
      if k.friends_player_id == t.friends_player_id then 
        Model.friendList[j] = t;
        isInsert = false;
      end
    end
    if isInsert then table.insert(Model.friendList, t);end
  end

  updateFriendList();
end

function callback_recv_friend_apply_list(data)
  print("receive friend apply list msg");
  for i,v in pairs(data.list) do
    local t = {};
    t["player_name"] = v.player_name
    t["player_lv"] = v.player_lv
    t["player_role_id"] = v.player_role_id
    t["player_id"] = v.player_id
    table.insert(Model.friendApplyList, t);
  end

  updateFriendApplyList();
end

function callback_recv_friend_mail(data)
  for i,v in pairs(data.list) do
    if not Model.friendMails[tostring(v.player_id)] then
      local t = {};
      table.insert(t, v);
      Model.friendMails[tostring(v.player_id)] = t;
    else
      table.insert(Model.friendMails[tostring(v.player_id)], v);
    end
  end

  updateFriendMsgHint();
end

function callback_recv_friend_ship_times(data)
    Model.friendShipTimes = data.count;
end

function callback_recv_player_beast_list(data)
  local mmonsterPanel = LuaItemManager:getItemObject("mmonsterPanel")
  mmonsterPanel:recv_player_mmonster_list(data)
end

function callback_message_recv_player_bag_change_goods(data)
  print("callback_message_recv_player_bag_change_goods")
  local packPanel = LuaItemManager:getItemObject("packPanel")
  packPanel.getGoodsChange(data)
  local mmonsterPanel = LuaItemManager:getItemObject("mmonsterPanel")
  mmonsterPanel:recv_player_bag_change_goods()
end

function callback_recv_activity_list(data)  
  Model.activityData = data.list;
  for i ,v in pairs(data.list) do
    print("Activity ID :  " .. v.category);
  end
end

--活动剩余次数
function callback_recv_activity_times(data)
  Model.activityTimes = data.list;
end

function callback_recv_shop_goods(data)
  -- print("callback_recv_shop_goods..")
  -- print("callback_recv_shop_goods..")
  -- print("callback_recv_shop_goods..")
  -- printTable(data["list"])
  local shopPanel = LuaItemManager:getItemObject("shopPanel")
  Model.shopData = data["list"]
  shopPanel:callback_recv_shop_goods()
end

function callback_recv_buy_goods(data)
  local shopPanel = LuaItemManager:getItemObject("shopPanel")
  shopPanel:callback_recv_buy_goods(data)
end

function callback_recv_delete_friend(data)
  for i, v in pairs(Model.friendList) do
    if v.friends_player_id == data.friends_player_id then
      table.remove(Model.friendList, i);
    end
  end

  updateFriendList();
end

function callback_recv_system_conf_data(data)
  Model.systemConfig = data.list;
end

