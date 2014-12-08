---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: model.lua
--data:2014.7.1
--author:yue an bang
--desc:玩家数据中心
--===============================================================================================--
---------------------------------------------------------------------------------------------------

Model={}
local Model = Model
local common_fun = common_fun
--config data
Model.hasConnection = false --是否已经连接过
Model.guideTaskid = 200
Model.units=nil --Unit Config
function Model.getUnit(id)
    print(id)
	return Model.units[id..""]
end

--新手引导第一次战斗标志
Model.flgFirstBattle = false

--my battle group
Model.battleGroup={}
-----------------Item Data----------------------------
-- {player_hero_lv:1,
-- player_hero_exp:0,
-- player_hero_color:1,
-- player_hero_attribute:{
-- 			1:{dodgeValue:10.199999809265,magicDefend:9,hp:173,turnSpeed:365,speed:1.5,defend:10.5,critValue:10.199999809265,attackSpeed:1.5,maxMp:100,maxHp:173,magicDamage:25.200000762939,mp:0,damage:14.039999961853}
-- 			},
-- player_hero_skill:[],
-- player_hero_id:494,
-- system_hero_id:200006,
-- player_hero_equip:[]
-- }
------------------end---------------------------------

Model.enemyGroup={}

--story
Model.storys={}
function Model.getStory( id )
  -- body
  return Model.storyDlg[id..""]
end

--skill
Model.skills={}
function Model.getSkill(id)
	return Model.skills[id..""]
end

Model.buff = {}
function Model.getBuff(id)
	return Model.buff[id..""]
end

--chapterData
Model.chapterData = {}
function Model.getChapterDataByid(id)
	return Model.chapterData[id..""]
end

function Model.getChapterData()
	return Model.chapterData
end

--current chapter index in fight
Model.chapterCurrentIndex = 0
function Model.getcurrentChapterIndex() 
	return Model.chapterCurrentIndex 
end

--item data
Model.itemData = {}
function Model.getItemData(id)
	return Model.itemData[id..""]
end

Model.worldChatMsgs = {}

--插入世界聊天消息. 返回过滤后的聊天内容
function Model.insertWorldChatMsgs(chatName, content)
  local chat = {};
  chat.playerName = chatName;
  chat.msg = content;
  table.insert(Model.worldChatMsgs, chat);
end

function Model.getWorldChatMsgs()
  return Model.worldChatMsgs;
end

Model.signInData = {}
function Model.setSignInData(data)
Model.signInData = data
end

Model.discreteData = {}
function Model.getDiscreteData(id)
  local data = Model.discreteData[tostring(id)]
  if not data then
    print("Model.getDiscreteData is nil, ID :" .. id);
  end
  return data;
end


--活动配置
Model.activityConfig = {}
function Model.getActivityData(id)
  local data = Model.activityConfig[tostring(id)];
  if not data then
    print("Model.getActivityData is nil ID :" .. id);
  end
  return data;
end

Model.activityTimes = {}
function Model.getActivityTimes(category)
  for i, v in pairs(Model.activityTimes) do
    if v.category == category then 
      return v.num;
    end
  end

  print("don't find the category in Model.activityTimes :" .. category);
end
--活动数据(服务器发送)
Model.activityData = {}
--活动剩余次数

Model.friendList = {}
Model.friendApplyList = {}
Model.friendMails = {}
Model.friendShipTimes = 0;

Model.systemConfig = {};
-------------------------------------------------------------------------------------------

--team modle
Model.teamModle = {
	loadComFun = nil,
	iLoadNum = 0,
	bRefer = false
}
function Model.getTeamModel()
	return Model.teamModle
end

--player data
Model.PlayerInfo = {
  name = "",
  coin = 0,
  vit = 0,
  vit_m = 0,
  exp = 0.1,
  maxExp = 0,
  lv = 0,
  yu = 0,
  player_friendship = 0,
  player_id = 0,
  drama_id = 0,
  attribute = {}
}

function Model.InitPlayerDataEx(info)
	--[[
   * 返回数据:
 * player List [
 *  player_id int 玩家角色ID
 *  player_role_id int 玩家角色系统ID
 *  player_name string 玩家昵称
 *  lv short 玩家等级
 *  max_lv short 玩家最大等级
 *  exp int 玩家经验
 *  max_exp int 升级经验
 *  gold uint 金币
 *  crystal uint 水晶
 *  vit uint 体力
 *  vit_limit uint 体力上限
 *  drama_id 剧情ID
 *] 如果玩家有角色将返回当前角色信息
  {player_skill_points:10;player_arena_number:5;player_friendship:0;
  gold:13600;player_exp:0;crystal:10020;player_prestige:0;player_vit:994}

   --{"player_id":18,"player_role_id":18,"player_name":"许水云",
  ---"lv":1,"exp":0,"gold":0,"crystal":0,"vit":61,"vit_limit":61}}}
 */--]]

  if info ~= nil then
    if info["player_name"] ~= nil then 
      Model.PlayerInfo.name = info["player_name"] 
    end
    if info["player_role_id"] ~= nil then
      Model.PlayerInfo.player_hero_id = info["player_role_id"]
    end
    if info["attribute"] ~= nil then
      Model.PlayerInfo.attribute = info["attribute"]
    end
    Model.PlayerInfo.coin = info["gold"]
    Model.PlayerInfo.vit = info["vit"]
    Model.PlayerInfo.vit_m = info["vit_limit"]
    Model.PlayerInfo.lv = info["lv"]
    Model.PlayerInfo.exp = info["exp"]
    Model.PlayerInfo.maxExp = info["max_exp"]
    Model.PlayerInfo.yu = info["crystal"]
    if info["drama_id"] ~= nil then
      Model.PlayerInfo.drama_id = info["drama_id"]
    end
    if info["player_friendship"] ~= nil then
      Model.PlayerInfo.player_friendship = info["player_friendship"]
    end
    if info["player_id"] ~= nil then
      Model.PlayerInfo.player_id = info["player_id"]
    end
  end
end

function Model.getPlayerInfo()
	return Model.PlayerInfo
end

--任务数据
Model.taskData = {}
function Model.getTaskData(id)
  return Model.taskData[id..""]
end

--用于筛选
function Model.filter(data,filterFun)
  local re={} 
  for i,v in pairs(data) do
    if filterFun(i,v) then table.insert(re,v) end
  end
  return re
end

--神兽数据
Model.mMonsterData = {}
--当前上战ID
Model.mCurFightMonsterID = 0
function Model.getMMonsterData()
  return Model.mMonsterData
end
function Model.getMMonsterFromID(id)
  if #Model.mMonsterData == 0 then return nil end
  for k,v in pairs(Model.mMonsterData) do
    if v.beast_id == id then
      return v
    end
  end
  return nil
end


--新手引导数据

function Model.getGuid(id)
    return Model.guid[id..""]
end

--商城数据
Model.shopData = {}
function Model.getShopData()
  return Model.shopData
end

