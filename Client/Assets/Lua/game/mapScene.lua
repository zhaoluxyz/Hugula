---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: mapScene.lua
--data:2014.7.1
--author:yue an bang
--desc:大地图界面
--===============================================================================================--
---------------------------------------------------------------------------------------------------
local arenaUI = LuaItemManager:getItemObject("arenaUI")
local mapScene = LuaItemManager:getItemObject("mapScene")
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
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
mapScene.assets=
{
   Asset("Main.u3d"),
   Asset("mapScene.u3d"),
}
--==================================================================================================
local curMainChapterID = 1
local BtnBack
local Refer
local bFirst = false
--==================================================================================================
function mapScene:onAssetsLoad(items)
  -- self:show()
  Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  BtnBack = Refer.monos[0]
  local rask = Refer.monos[8]
  local back = Refer.monos[9]
  rask.gameObject:SetActive(false)
  back.gameObject:SetActive(true)

  bFirst = true
  mapScene:updateView()
  mapScene:msgCallbackBind()
end

function mapScene:updateView()
  if bFirst == false then return end
  local Refer = LuaHelper.GetComponent(self.assets[1].items["Refers"],"ReferGameObjects")
  local lableName = Refer.monos[0]
  local lableCoin = Refer.monos[1]
  local  progressExp = LuaHelper.GetComponent(Refer.monos[2].gameObject,"UISlider")
  local  progressVit = LuaHelper.GetComponent(Refer.monos[3].gameObject,"UISlider")
  local lableYu = Refer.monos[4]
  local lableLV = Refer.monos[5]
  local lableVit = Refer.monos[6]
  local lableExp = Refer.monos[7]

  local playerInfo = Model:getPlayerInfo()
  lableName.text = playerInfo.name
  lableCoin.text = playerInfo.coin
  progressExp.Value = playerInfo.exp / playerInfo.maxExp
  progressVit.Value = playerInfo.vit / playerInfo.vit_m
  lableLV.text = playerInfo.lv
  lableYu.text = playerInfo.yu
  lableVit.text = playerInfo.vit .. "/" .. playerInfo.vit_m
  lableExp.text = (string.format("%2.2f", progressExp.Value) * 100 ) .. "%"
end

function mapScene:onClick(obj,arg)
  local cmd = obj.name
  if cmd == "BtnBack" then
    mapScene:updateTeamPrefab()
    -- common_fun:debugTimeBegin()
    -- common_fun:debugTime()
    mapScene:hideAll()
    local mainScene = LuaItemManager:getItemObject("mainScene")
    mainScene:showMainPanel()
    --common_fun:debugTimeBegin()
  elseif string.find(cmd,"BtnTask0") then
    curMainChapterID = tonumber(string.sub(cmd,-2))
    mapScene:sendReqChapterData(curMainChapterID) 
  end

  mainUIProcess(obj,arg)
end

function mapScene:msgCallbackBind()
  Proxy:binding(NetAPIList.recv_player_chapter_list,recvChapterData)
end

function mapScene:sendReqChapterData(index)
  if index == 6 then 
    LuaItemManager:getItemObject("arenaUI"):showAll()
    return
  end
  if index < 6 then
    showWaitingPanel()
    local cont = NetMsgHelper:makesend_player_chapter(index)
    printTable(cont)
    Proxy:send(NetAPIList.player_chapter_list,cont)
  end
end

function mapScene:onHide(...)
  --mapScene:destoryAll()
  --self:clear()
  Refer.monos[8].gameObject:SetActive(true)
  Refer.monos[9].gameObject:SetActive(false)
end

function mapScene:onShowed(...)
  if bFirst == true then
    Refer.monos[8].gameObject:SetActive(false)
    Refer.monos[9].gameObject:SetActive(true)
  end
end

function mapScene:showAll()
  if not self.isShow then
    self.isShow = true;
    self:addToState();
  end
end

function mapScene:hideAll()
  self:removeFromState();
  self.isShow = false;
end

function mapScene:destoryAll()
end

function mapScene:updateTeamPrefab()
  -- PrefabPool:Clear()
  -- PrefabPool:ClearCache()

  -- updateTeamPrefabData()
end

function getCurMainChapterID()
  return curMainChapterID
end

function mapSceneActive(isActive)
  --BtnBack.gameObject:SetActive(isActive)
end

function recvChapterData( data )
  --print("command: " .. data["command"])
  mapSceneActive(false)
  showchapterPanel(data)
end

