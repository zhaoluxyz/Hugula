---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: arenaUI.lua
--data:2014.11.18
--author:liutangming
--desc:竞技场
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local teamEquipInfo = LuaItemManager:getItemObject("teamEquipInfo")
local login = LuaItemManager:getItemObject("login")
local teamPanel = LuaItemManager:getItemObject("teamPanel")
local arenaUI = LuaItemManager:getItemObject("arenaUI")
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
arenaUI.assets=
{
  Asset("ArenaUI.u3d"),
}

-- 四大面板
local arenaPanel, rankPanel, shopPanel, newsPanel
-- 八大面板切换按钮
local tabBtns ={}

-- 引用
local ReferRoot, ReferArenaBaseInfo, ReferRankBaseInfo, ReferShopBaseInfo, ReferSureRefreshShop, ReferSureBuyShop
-- CamakTable
local arenaCamakTable, rankCamakTable, newsCamakTable, shopCamakTable

local timeCountPoint = 1000



-- 竞技场附近10个排名玩家数据
arenaUI.arenaData = {}
arenaUI.arenaData.isValid = false

-- 竞技场前10名玩家数据
arenaUI.arenaDataTop = {} 
arenaUI.arenaDataTop.isValid =false

-- 竞技场战报
arenaUI.newsData = {}
arenaUI.newsData.isValid =false

-- 兑换商品
arenaUI.shopData = {}
arenaUI.shopData.isValid =false



--==================================================================================================
function arenaUI:onAssetsLoad(items)

  print("初始化竞技场UI开始， arenaUI:onAssetsLoad    ______   onAssetsLoad finished")


  ReferRoot = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  if ReferRoot == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取Refers失败")
  end

----------------------------------------------------------------------------
-----------------------------  GameObject获取   ----------------------------

  arenaPanel = ReferRoot.refers[0]
  if arenaPanel == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取arenaPanel失败")
  end
  rankPanel = ReferRoot.refers[1]
  if rankPanel == nil then
    print("arenaUI:onAssetsLoad  _____ ".."获取rankPanel失败")
  end 
  shopPanel = ReferRoot.refers[2]
  if shopPanel == nil then
    print("arenaUI:onAssetsLoad  _____ ".."获取shopPanel失败")
  end 
  newsPanel = ReferRoot.refers[3]
  if newsPanel == nil then
    print("arenaUI:onAssetsLoad  _____ ".."获取newsPanel失败")
  end 

  for i=4,11 do
    local objTemp = ReferRoot.refers[i]
    if objTemp == nil then
      print("arenaUI:onAssetsLoad  _____ ".."获取Btn失败，idx="..i)
    end 
    tabBtns[""..objTemp.name] = objTemp
  end

  ReferSureRefreshShop = ReferRoot.refers[12]
  if ReferSureRefreshShop == nil then
    print("arenaUI:onAssetsLoad  _____ ".."获取ReferSureRefreshShop失败")
  end 

  ReferSureBuyShop = ReferRoot.refers[13]
  if ReferSureBuyShop == nil then
    print("arenaUI:onAssetsLoad  _____ ".."获取ReferSureBuyShop失败")
  end 


-----------------------------  GameObject获取end   ----------------------------
-------------------------------------------------------------------------------


-------------------------------------------------------------------------------
-----------------------------  MonoBehaviour获取   ----------------------------
  arenaCamakTable = ReferRoot.monos[0]
  if arenaCamakTable == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取arenaCamakTable失败")
  end

  ReferArenaBaseInfo = ReferRoot.monos[1]
  if ReferArenaBaseInfo == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取ReferArenaBaseInfo失败")
  end
  
  rankCamakTable = ReferRoot.monos[2]
  if rankCamakTable == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取rankCamakTable失败")
  end

  ReferRankBaseInfo = ReferRoot.monos[3]
  if rankCamakTable == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取ReferRankBaseInfo失败")
  end

  newsCamakTable = ReferRoot.monos[4]
  if newsCamakTable == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取newsCamakTable失败")
  end

  shopCamakTable = ReferRoot.monos[5]
  if shopCamakTable == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取shopCamakTable失败")
  end

  ReferShopBaseInfo = ReferRoot.monos[6]
  if ReferShopBaseInfo == nil then
    print("arenaUI:onAssetsLoad   ____ ".."获取ReferShopBaseInfo失败")
  end


-----------------------------  MonoBehaviour获取end   ----------------------------
----------------------------------------------------------------------------------
  
  arenaUI:registerTableEventArena(arenaCamakTable)
  arenaUI:registerTableEventRank(rankCamakTable)
  arenaUI:registerTableEventNews(newsCamakTable)
  arenaUI:registerTableEventShop(shopCamakTable)

  -- 網絡消息綁定
  arenaUI:msgCallbackBind()

--  waitingPanelEnd()



  print("arenaUI:onAssetsLoad    ______   onAssetsLoad finished")
end




function arenaUI:registerTableEventShop(obj)
  if obj == shopCamakTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      
      if(itemdata) then

        print("开始render index="..index)

        referScipt.gameObject:SetActive(true)

        local lbl_name = referScipt.monos[0]            -- 商品名
        local spr_goods = referScipt.monos[1]           -- 商品图标
        local lbl_price = referScipt.monos[2]           -- 商品价格

        referScipt.name = "shopItem_" .. index

        lbl_name.text = itemdata.itemCfg.name.." ×"..itemdata.goods_num
        spr_goods.spriteName = itemdata.itemCfg.icon
        lbl_price.text = itemdata.prestige

        if itemdata.exchange_num <= 0 then
          referScipt.refers[0]:SetActive(false)
          referScipt.refers[1]:SetActive(true)
        else
          referScipt.refers[0]:SetActive(true)
          referScipt.refers[1]:SetActive(false)
        end
        print("结束render index="..index)
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


function arenaUI:registerTableEventNews(obj)
  if obj == newsCamakTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      
      if(itemdata) then
        referScipt.gameObject:SetActive(true)

        local lbl = referScipt.monos[0]              -- 戰隊等級
        referScipt.name = "newsItem_" .. index

        local reportTemp = ""
        if itemdata.battle_type == 1 then
          local sTemp = ""
          if itemdata.is_victory == true then
--            sTemp = "[00FF00]获胜了！\n[000000]排名升至第".."[D535E1]"..itemdata.rank.."[000000]位"
            sTemp = ""..tostring(getValue("main_arena_016"))..itemdata.rank..tostring(getValue("main_arena_017"))
          else
--            sTemp = "[FF0000]战败了！\n[000000]排名不变！"
            sTemp = ""..tostring(getValue("main_arena_015"))
          end
          -- 主动
--          reportTemp = "[000000]你对".."[ECAB15]【"..itemdata.battle_player_name.."】".."[000000]发起挑战，你"..sTemp
            reportTemp = ""..tostring(getValue("main_arena_013"))..itemdata.battle_player_name..tostring(getValue("main_arena_014"))..sTemp        
        elseif itemdata.battle_type == 2 then
          -- 被动
          local sTemp = ""
          if itemdata.is_victory == true then
--            sTemp = "[00FF00]获胜了！\n[000000]排名升至第".."[D535E1]"..itemdata.rank.."[000000]位"
            sTemp = ""..tostring(getValue("main_arena_016"))..itemdata.rank..tostring(getValue("main_arena_017"))
          else
--            sTemp = "[FF0000]战败了！\n[000000]排名降至第".."[4A8E88]"..itemdata.rank.."[000000]位"
            sTemp = ""..tostring(getValue("main_arena_020"))..itemdata.rank..tostring(getValue("main_arena_017"))
          end
          -- 主动
--          reportTemp = "[ECAB15]【"..itemdata.battle_player_name.."】".."[000000]对你发起挑战，你"..sTemp
            reportTemp = ""..tostring(getValue("main_arena_018"))..itemdata.battle_player_name..tostring(getValue("main_arena_019"))..sTemp
        end

        lbl.text = reportTemp
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


function arenaUI:registerTableEventRank(obj)
  if obj == rankCamakTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      
      print("進入OnItemRender ， 打印本次更新數據")
      printTable(itemdata)

      if(itemdata) then
        referScipt.gameObject:SetActive(true)

        local lbl_lv = referScipt.monos[0]              -- 戰隊等級
        local lbl_name = referScipt.monos[1]            -- 戰隊名字
        local lbl_rank = referScipt.monos[2]            -- 排名
        local lbl_combat = referScipt.monos[3]          -- 戰鬥力
        local spr_reward_1 = referScipt.monos[4]       -- 第一個獎勵圖標
        local lbl_reward_1 = referScipt.monos[5]        -- 第一個獎勵數值
        local spr_reward_2 = referScipt.monos[6]       -- 第二個獎勵圖標
        local lbl_reward_2 = referScipt.monos[7]        -- 第二個獎勵數值
        local spr_head_list = {referScipt.monos[8],referScipt.monos[9],referScipt.monos[10],referScipt.monos[11],referScipt.monos[12]}    -- 玩家頭像列表

        referScipt.name = "rankItem_" .. index

        lbl_lv.text = "Lv"..itemdata.player_lv
        lbl_name.text = itemdata.player_name
        lbl_rank.text = itemdata.rank

        -- lbl_combat.text   需自己計算
        lbl_combat.text = arenaUI:CalcCombat(itemdata.team)

        -- 獎勵，動態更新
        lbl_reward_1.text = 0
        if itemdata.rank_reward.gold > 0 then
          lbl_reward_1.text = itemdata.rank_reward.gold
        end
        lbl_reward_2.text = 0
        if itemdata.rank_reward.player_prestige > 0 then
          lbl_reward_2.text = itemdata.rank_reward.player_prestige
        end

        for i = 1, 5 do
          spr_head_list[i].spriteName = ""
        end
        
        local iCount = 1
        for k,v in pairs(itemdata.team) do
          if v ~= nil then
            spr_head_list[iCount].spriteName = v.unitCfg.icon
            iCount = iCount+1
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


function arenaUI:registerTableEventArena(obj)
  if obj == arenaCamakTable then
    obj.onItemRender=function(referScipt,index,itemdata)
      
      print("進入OnItemRender ， 打印本次更新數據")
      printTable(itemdata)

      if(itemdata) then
        referScipt.gameObject:SetActive(true)

        local lbl_lv = referScipt.monos[0]              -- 戰隊等級
        local lbl_name = referScipt.monos[1]            -- 戰隊名字
        local lbl_rank = referScipt.monos[2]            -- 排名
        local lbl_combat = referScipt.monos[3]          -- 戰鬥力
        local spr_reward_1 = referScipt.monos[4]       -- 第一個獎勵圖標
        local lbl_reward_1 = referScipt.monos[5]        -- 第一個獎勵數值
        local spr_reward_2 = referScipt.monos[6]       -- 第二個獎勵圖標
        local lbl_reward_2 = referScipt.monos[7]        -- 第二個獎勵數值
        local spr_head_list = {referScipt.monos[8],referScipt.monos[9],referScipt.monos[10],referScipt.monos[11],referScipt.monos[12]}    -- 玩家頭像列表
        local lbl_timeCount = referScipt.monos[13]

        referScipt.name = "arenaItem_" .. index

        lbl_lv.text = "Lv"..itemdata.player_lv
        lbl_name.text = itemdata.player_name
        lbl_rank.text = itemdata.rank

        -- lbl_combat.text   需自己計算
        lbl_combat.text = arenaUI:CalcCombat(itemdata.team)

        -- 獎勵，動態更新
        lbl_reward_1.text = 0
        if itemdata.rank_reward.gold > 0 then
          lbl_reward_1.text = itemdata.rank_reward.gold
        end
        lbl_reward_2.text = 0
        if itemdata.rank_reward.player_prestige > 0 then
          lbl_reward_2.text = itemdata.rank_reward.player_prestige
        end

        for i = 1, 5 do
          spr_head_list[i].spriteName = ""
        end

        local iCount = 1
        for k,v in pairs(itemdata.team) do
          if v ~= nil then
            print("進入了設置頭像"..v.unitCfg.icon)
            spr_head_list[iCount].spriteName = v.unitCfg.icon
            print("完成了設置頭像")
            iCount = iCount+1
          end
        end


        print("记录的player_id="..Model.PlayerInfo.player_id)
        if Model.PlayerInfo.player_id == itemdata.player_id then
          referScipt.refers[0]:SetActive(true)
          referScipt.refers[1]:SetActive(false)
          hour = timeCountPoint / 3600
          if hour < 1 then
            hour = 0
          else
            hour = math.floor(hour)
          end
          min = ( math.fmod(timeCountPoint,3600))/60
          if min < 1 then
            min = 0
          else
            min = math.floor(min)
          end
          sec = math.fmod(( math.fmod(timeCountPoint,3600)),60)
          if sec < 1 then
            sec = 0
          else
            sec = math.floor(sec)
          end
          lbl_timeCount.text = ""..hour..":"..min..":"..sec
        else
          referScipt.refers[0]:SetActive(false)
          referScipt.refers[1]:SetActive(true)
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



function arenaUI:CalcCombat(team)

  local combatTotal = 0
  for k,v in pairs(team) do
    local da = teamPanel:getFinalHeroData(v)
    combatTotal = combatTotal + teamPanel:getFightPower(da)
  end  
  
  return combatTotal
end


function arenaUI:onClick(obj,arg)
  local cmd = obj.name;
  if cmd == "closeBtn" then
    arenaUI:hideAll()
  elseif cmd == "arenaBtn" then
    arenaUI:BtnStatusChange(obj)
    arenaUI:openArena()
  elseif cmd == "rankBtn" then
    arenaUI:BtnStatusChange(obj)
    arenaUI:openRank()
  elseif cmd == "newsBtn" then
    arenaUI:BtnStatusChange(obj)
    arenaUI:openNews()
  elseif cmd == "shopBtn" then
    arenaUI:BtnStatusChange(obj)
    arenaUI:openShop()
  elseif cmd == "chanllenge" then
    arenaUI:onChanllenge(obj)
  elseif cmd == "btnTeam" then
    arenaUI:onTeamInfo(obj)
  elseif cmd == "btnShopBuy" then
    arenaUI:onShopBuy(obj)
  elseif cmd == "btnRefreshShop" then
    arenaUI:onShopRefresh(obj)
  elseif cmd == "btnSureRefreshShop" then
    arenaUI:onShopSureRefresh()
  elseif cmd == "btnCancelRefreshShop" then
    arenaUI:onShopCancelRefresh()
  elseif cmd == "btnSureBuyShop" then
    arenaUI:onShopSureBuy()
  elseif cmd == "btnSureBuyClose" then
    arenaUI:onShopCancelBuy()
  end


end



-- 點擊挑戰按鈕后的處理
-- obj  :挑戰按鈕
function arenaUI:onChanllenge(obj)
  local tempString = obj.transform.parent.parent.name
  local idx = tonumber(string.sub(tempString,11))

  arenaUI:send_player_challenge_arena(self.arenaData.data.list[idx+1].player_id)
  print("挑戰按鈕對應的index ="..idx)

end

-- 点击阵容按钮后的处理
-- obj  :阵容按钮
function arenaUI:onTeamInfo(obj)
  local tempString = obj.transform.parent.parent.name
  local idx = tonumber(string.sub(tempString,10))

  if self.arenaDataTop.data.list[idx+1] and self.arenaDataTop.data.list[idx+1].team and table.getn(self.arenaDataTop.data.list[idx+1].team) >= 1 then
    teamEquipInfo:showAll(self.arenaDataTop.data.list[idx+1])
  end
end


-- 点击兑换后的处理
-- obj  :点击的按钮
function arenaUI:onShopBuy(obj)
  local tempString = obj.transform.parent.name
  local idx = tonumber(string.sub(tempString,10))

--  arenaUI:send_exchange_goods(self.shopData.data.goods[idx+1].goods_id)

  -- 打开确定界面
  ReferSureBuyShop:SetActive(true)
  local referTemp = LuaHelper.GetComponent(ReferSureBuyShop, "ReferGameObjects")

  local sprIcon = referTemp.monos[0]
  local lblName = referTemp.monos[1]
  local lblNum = referTemp.monos[2]
  local lblInfo = referTemp.monos[3]
  local lblBuyNum = referTemp.monos[4]
  local lblPrice = referTemp.monos[5]

  local lblGoodsID = referTemp.monos[6]


  local itemInfo = self.shopData.data.goods[idx+1]
  sprIcon.spriteName = itemInfo.itemCfg.icon
  lblName.text = itemInfo.itemCfg.name
  lblNum.text = ""..tostring(getValue("main_arena_021")).."4"..tostring(getValue("main_arena_022"))
  lblInfo.text = itemInfo.itemCfg.Desc2
  lblBuyNum.text = ""..tostring(getValue("main_arena_023"))..itemInfo.goods_num..tostring(getValue("main_arena_022"))
  lblPrice.text = itemInfo.prestige
  lblGoodsID.text = itemInfo.goods_id
  print("兑换按鈕對應的index ="..idx+1)

end

function arenaUI:onShopSureBuy()
  local referTemp = LuaHelper.GetComponent(ReferSureBuyShop, "ReferGameObjects")
  local goodsid = referTemp.monos[6].text
  ReferSureBuyShop:SetActive(false)

  arenaUI:send_exchange_goods(goodsid)
end
function arenaUI:onShopCancelBuy()
  ReferSureBuyShop:SetActive(false)
end

-- 点击商店刷新后的处理
-- obj  :点击的按钮
function arenaUI:onShopRefresh(obj)
  ReferSureRefreshShop:SetActive(true)

  local referTemp = LuaHelper.GetComponent(ReferSureRefreshShop,"ReferGameObjects")
  local lbl = referTemp.monos[0]
  lbl.text = ""..tostring(getValue("main_arena_024"))..self.shopData.data.refresh_price.price..tostring(getValue(main_arena_025))..self.shopData.data.refresh_current_num.."/"..self.shopData.data.refresh_limit_num..tostring(getValue("main_arena_026"))
--  arenaUI:send_refresh_exchange_goods()

--  print("处理了刷新商品")
end

-- 点击商店刷新后的处理
-- obj  :点击的按钮
function arenaUI:onShopSureRefresh(obj)
  ReferSureRefreshShop:SetActive(false)
  arenaUI:send_refresh_exchange_goods()

  print("处理了刷新商品")
end
-- 点击商店刷新后的处理
-- obj  :点击的按钮
function arenaUI:onShopCancelRefresh(obj)
  ReferSureRefreshShop:SetActive(false)
end

-- 按钮变换
-- obj  :当前点中的按钮
function arenaUI:BtnStatusChange( obj )
  if obj ~= nil then
    if string.find(obj.name, "Checked") then
      return
    end

    for k,v in pairs(tabBtns) do
      if string.find(k, "Checked") then
        v:SetActive(false)
      else
        v:SetActive(true)
      end
    end

    tabBtns[obj.name]:SetActive(false)
    tabBtns[obj.name.."Checked"]:SetActive(true)

  end
end
function arenaUI:BtnStatusChangeByName(name)
  if name ~= nil then
    if string.find(name, "Checked") then
      return
    end

    for k,v in pairs(tabBtns) do
      if string.find(k, "Checked") then
        v:SetActive(false)
      else
        v:SetActive(true)
      end
    end

    tabBtns[name]:SetActive(false)
    tabBtns[name.."Checked"]:SetActive(true)

  end
end

function arenaUI:hideAll()
  self:removeFromState();
  self.isShow = false;
end


function arenaUI:openArena()
  if self.arenaData.isValid == false then
 --   showWaitingPanel()
    arenaUI:send_player_arena_rank_near()
  else
    arenaUI:showArena()
  end
end

function arenaUI:showArena()

  arenaUI:hideRank()
  arenaUI:hideNews()
  arenaUI:hideShop()

  arenaPanel:SetActive(true)
  
  -- 更新基本信息
  arenaUI:refreshArenaBaseInfo()

  -- grid信息
  arenaCamakTable:Refresh()

  -- 按钮显示
  

--  waitingPanelEnd()

end

function arenaUI:hideArena()
  arenaPanel:SetActive(false)
end


function arenaUI:openRank()
  if self.arenaDataTop.isValid == false then
--    showWaitingPanel()
    arenaUI:send_player_arena_rank_top()
  else
    arenaUI:showRank()
  end
end
function arenaUI:showRank()

  arenaUI:hideArena()
  arenaUI:hideNews()
  arenaUI:hideShop()

  rankPanel:SetActive(true)
  
  -- 更新基本信息
  arenaUI:refreshRankBaseInfo()

  -- grid信息
  rankCamakTable:Refresh()

 -- waitingPanelEnd()

end
function arenaUI:hideRank()
  rankPanel:SetActive(false)
end



function arenaUI:openNews()
  if self.newsData.isValid == false then
--    showWaitingPanel()
    arenaUI:send_player_arena_battle_report()
  else
    arenaUI:showNews()
  end
end
function arenaUI:showNews()

  arenaUI:hideArena()
  arenaUI:hideRank()
  arenaUI:hideShop()

  newsPanel:SetActive(true)


  -- grid信息
  newsCamakTable:Refresh()

 -- waitingPanelEnd()

end
function arenaUI:hideNews()
  newsPanel:SetActive(false)
end



function arenaUI:openShop()
  if self.shopData.isValid == false then
--    showWaitingPanel()
    arenaUI:send_player_exchanges()
  else
    arenaUI:showShop()
  end
end
function arenaUI:showShop()

  arenaUI:hideArena()
  arenaUI:hideRank()
  arenaUI:hideNews()

  shopPanel:SetActive(true)

    -- 更新基本信息
  arenaUI:refreshShopBaseInfo()

  -- grid信息
  shopCamakTable:Refresh()

 -- waitingPanelEnd()

end
function arenaUI:hideShop()
  shopPanel:SetActive(false)
end



function arenaUI:refreshArenaBaseInfo()
  
  if self.arenaData ~= nil then
    ReferArenaBaseInfo.monos[0].text = self.arenaData.data.current_rank
    ReferArenaBaseInfo.monos[1].text = self.arenaData.data.remaining_number.."/"..self.arenaData.data.max_limit
    ReferArenaBaseInfo.monos[2].text = self.arenaData.data.player_prestige

    -- 戰鬥力需要計算
    ReferArenaBaseInfo.monos[3].text = arenaUI:CalcCombat(Model.battleGroup.team)

  end

end

function arenaUI:refreshRankBaseInfo()
  
  if self.arenaDataTop ~= nil then
    ReferRankBaseInfo.monos[0].text = self.arenaDataTop.data.current_rank
    ReferRankBaseInfo.monos[1].text = self.arenaDataTop.data.remaining_number.."/"..self.arenaDataTop.data.max_limit

  end

end


function arenaUI:refreshShopBaseInfo()
  
  if self.shopData ~= nil then
    ReferShopBaseInfo.monos[0].text = self.shopData.data.player_prestige
    ReferRankBaseInfo.monos[1].text = self.shopData.data.refresh_time

  end

end


function arenaUI:showAll()

  print("arenaUI:showAll     -------  進入顯示處理函數")

  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end

  print("arenaUI:showAll     -------  开始打开竞技场")
--  arenaUI:showArena()
--  arenaUI:send_player_arena_rank_near()
  arenaUI:BtnStatusChangeByName("arenaBtn")
  arenaUI:openArena()
--arenaUI:openRank()

end




local countDown = function()
  timeCountPoint = timeCountPoint - 1
end
delay(countDown, 1)

function arenaUI:ReplaceArenaDataNear( data )
  self.arenaData.data = data

  print("开始打印竞技场接受的玩家数据 ----------- ")
  if self.arenaData.data.list ~= nil then
    for k,v in pairs(self.arenaData.data.list) do
      for kk,vv in pairs(v.team) do
        vv.unitCfg = Model.getUnit(vv.system_hero_id)
      end

      if v.player_id == Model.PlayerInfo.player_id then
          timeCountPoint = v.recv_reward_time
      end

    end
    
  end
  print("结束打印竞技场接受的玩家数据 ----------- ")



  -- 新數據放入
  arenaCamakTable.data = self.arenaData.data.list

  self.arenaData.isValid = true

end

function arenaUI:ReplaceArenaDataTop( data )
  self.arenaDataTop.data = data

  print("开始打印竞技场接受的顶级玩家数据 ----------- ")
  if self.arenaDataTop.data.list ~= nil then
    for k,v in pairs(self.arenaDataTop.data.list) do
      for kk,vv in pairs(v.team) do
        vv.unitCfg = Model.getUnit(vv.system_hero_id)
      end
    end
    
  end
  print("结束打印竞技场接受的顶级玩家数据 ----------- ")

  -- 新數據放入
  rankCamakTable.data = self.arenaDataTop.data.list
  
  self.arenaDataTop.isValid =true

end




function arenaUI:ReplaceArenaShop( data )
  self.shopData.data = data


  if self.shopData.data.goods ~= nil then
    for k,v in pairs(self.shopData.data.goods) do
      print("搜集itemCfg数据开始")
      v.itemCfg = Model.getItemData(v.goods_id)
      if v.itemCfg then
        print("成功搜集")
      end
    end
  end

  -- 新數據放入
  shopCamakTable.data = self.shopData.data.goods
  
  self.shopData.isValid =true

end




function arenaUI:ReplaceArenaReport( data )
  self.newsData.data = data

  -- 新數據放入
  newsCamakTable.data = self.newsData.data.list
  print("战报新数据放入")
  printTable(newsCamakTable.data)
  
  self.newsData.isValid =true

end


function arenaUI:send_player_arena_rank_near()
  -- body
  print("开始发送竞技场最近排名玩家请求   ______ ")
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.player_arena_rank_near,cont)
  print("結束发送竞技场最近排名玩家请求   ______ ")
end

function arenaUI:send_player_challenge_arena(player_id)
  print("开始发送竞技场挑战")
  local msg = NetMsgHelper:makesend_player_challenge_arena(player_id)
  Proxy:send(NetAPIList.player_challenge_arena,msg)
end

function arenaUI:send_player_arena_rank_top()
  -- body
  print("开始发送竞技场顶级排名玩家请求   ______ ")
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.player_arena_rank_top,cont)
  print("結束发送竞技场顶级排名玩家请求   ______ ")
end

function arenaUI:recv_player_arena_rank_near( data )

  print("recv arena player rank naer list ....")
  printTable(data["list"])

  -- 收到數據，更新信息
  arenaUI:ReplaceArenaDataNear(data)
  
  arenaUI:showArena()
end


function arenaUI:recv_player_arena_rank_top( data )

  print("recv arena player rank top list ....")
  printTable(data["list"])

  -- 收到數據，更新信息
  arenaUI:ReplaceArenaDataTop(data)

  arenaUI:showRank()
end


function arenaUI:send_player_arena_battle_report()
  -- body
  print("开始发送战报请求   ______ ")
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.player_arena_battle_report,cont)
  print("結束发送战报请求   ______ ")
end

function arenaUI:recv_player_arena_battle_report( data )

  print("recv arena player arena report list ....")
  printTable(data["list"])

  -- 收到數據，更新信息
  arenaUI:ReplaceArenaReport(data)

  arenaUI:showNews()
end


function arenaUI:send_player_exchanges()

  print("开始发送竞技场商品请求   ______ ")
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.player_exchanges,cont)
  print("結束发送竞技场商品请求   ______ ")
end

function arenaUI:recv_player_exchanges( data )

  print("recv arena player arena shop list ....")
  printTable(data["goods"])

  -- 收到數據，更新信息
  arenaUI:ReplaceArenaShop(data)

  arenaUI:showShop()
end

function arenaUI:send_refresh_exchange_goods(  )
  print("开始发送刷新商品的请求")
  local cont = NetMsgHelper:makept_int(0)
  Proxy:send(NetAPIList.refresh_exchange_goods,cont)

  print("结束发送刷新商品的请求")
end

function arenaUI:send_exchange_goods(goods_id)
  print("开始发送兑换商品请求")
  local msg = NetMsgHelper:makesend_exchange_goods(goods_id)
  Proxy:send(NetAPIList.exchange_goods, msg)
  print("结束发送兑换商品请求")
end


-- 消息綁定
function arenaUI:msgCallbackBind()

  print("开始绑定网络消息")
  bindCommonNotify(NetAPIList.player_arena_rank_near,callbackArenaRankNearReq,callbackArenaRankNearReqError)
  Proxy:binding(NetAPIList.recv_player_arena_rank_near,onRecvPlayerArenaRankNear)
  bindCommonNotify(NetAPIList.player_challenge_arena,callbackArenaRankNearReq,callbackArenaRankNearReqError)
  
  
  bindCommonNotify(NetAPIList.player_arena_rank_top,callbackArenaRankTopReq,callbackArenaRankTopReqError)
  Proxy:binding(NetAPIList.recv_player_arena_rank_top,onRecvPlayerArenaRankTop)

  bindCommonNotify(NetAPIList.player_arena_battle_report,callbackArenaNewsReq,callbackArenaNewsReqError)
  Proxy:binding(NetAPIList.recv_player_arena_battle_report,onRecvPlayerArenaNews)

  bindCommonNotify(NetAPIList.player_exchanges,callbackArenaShopReq,callbackArenaShopReqError)
  Proxy:binding(NetAPIList.recv_player_exchanges,onRecvPlayerArenaShop)

  bindCommonNotify(NetAPIList.refresh_exchange_goods,callbackArenaShopReq,callbackArenaShopReqError)
  bindCommonNotify(NetAPIList.exchange_goods,callbackArenaShopBuyReq,callbackArenaShopBuyReqError)

  print("结束绑定网络消息")
end


function callbackArenaRankNearReq(data)
  -- print("callbackFightReq...")
  -- waitingPanelEnd()
  -- self:removeFromState()
  -- StateManager:setCurrentState(StateManager.battle)

  print("arenaUI     callbackArenaRankNearReq")

end

function callbackArenaRankNearReqError(data)
 -- waitingPanelEnd()
  print("callbackArenaRankNearReqError...")
end

function onRecvPlayerArenaRankNear( data )
  print("onRecvPlayerArenaRankNear...")
  arenaUI:recv_player_arena_rank_near(data)
end


function callbackArenaRankTopReq(data)
  -- print("callbackFightReq...")
  -- waitingPanelEnd()
  -- self:removeFromState()
  -- StateManager:setCurrentState(StateManager.battle)

  print("arenaUI     callbackArenaRankTopReq")

end

function callbackArenaRankTopReqError(data)
 -- waitingPanelEnd()
  print("callbackArenaRankTopReqError...")
end

function onRecvPlayerArenaRankTop( data )
  print("onRecvPlayerArenaRankTop...")
  arenaUI:recv_player_arena_rank_top(data)
end


function callbackArenaNewsReq(data)
  -- print("callbackFightReq...")
  -- waitingPanelEnd()
  -- self:removeFromState()
  -- StateManager:setCurrentState(StateManager.battle)

  print("arenaUI     callbackArenaNewsReq")

end

function callbackArenaNewsReqError(data)
 -- waitingPanelEnd()
  print("callbackArenaNewsReqError...")
end

function onRecvPlayerArenaNews( data )
  print("onRecvPlayerArenaNews...")
  arenaUI:recv_player_arena_battle_report(data)
end

function callbackArenaShopReq(data)
  -- print("callbackFightReq...")
  -- waitingPanelEnd()
  -- self:removeFromState()
  -- StateManager:setCurrentState(StateManager.battle)

  print("arenaUI     callbackArenaShopReq")

end

function callbackArenaShopReqError(data)
 -- waitingPanelEnd()
  print("callbackArenaShopReqError...")
  printTable(data)
end

function onRecvPlayerArenaShop( data )
  print("onRecvPlayerArenaShop...")
  arenaUI:recv_player_exchanges(data)
end

function callbackArenaShopBuyReq(data)

  print("arenaUI     兑换成功")

end

function callbackArenaShopBuyReqError(data)

  print("arenaUI      兑换失败")
end