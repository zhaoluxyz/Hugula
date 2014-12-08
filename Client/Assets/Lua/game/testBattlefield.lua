local battlefield = LuaItemManager:getItemObject("testBattlefield")
local BattleLoader = LuaItemManager:getItemObject("battleLoader")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Model = Model
local Vector3 = UnityEngine.Vector3
local GameObject = GameObject
local PrimitiveType = UnityEngine.PrimitiveType
local Quaternion = UnityEngine.Quaternion
local Color = UnityEngine.Color
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
local GroupController = luanet.import_type("GroupController")
local BattleCache = BattleCache
local Random = UnityEngine.Random
battlefield.assets=
{
	Asset("TestBattleUI.u3d"),
    Asset("TerrainMap.u3d")
}

local ReferBattle,ReferConfig,UIPopupList,BattleUICamera,BattleCamera,LabelCount,groupController
local Roles ={}
-----------------------------private------------------
--监测英雄放置位置。
local function cloneRole()
	--BattleCamera.
	-- 主城位置
	local pos=ReferConfig.refers[3].transform.position
	local posMian 
	local screenpos = BattleUICamera:WorldToScreenPoint(pos)
	local ray = BattleCamera:ScreenPointToRay(screenpos)
	local hit = LuaHelper.Raycast(ray)
	if  hit then	posMian=hit.point end
	--posMian.x= Random.Range(0.1,2.2)
	posMian.x=Random.Range(-9.0,9.0)
	posMian.z=Random.Range(5,30.11)
	--local v = Model.getUnit(7)
	local key = UIPopupList.value
	local building = BattleCache.modelCache[key]
	local clone = LuaHelper.Instantiate(building)
	clone.transform.position=posMian
	clone:SetActive(true)
	clone.tag = "OwnRole"
	local rolea=LuaHelper.GetComponent(clone,"RoleActor")
	if rolea then
		rolea.controller=groupController
		groupController:SetLeader(rolea)
	end
	-- local ani= LuaHelper.GetComponent(clone,"UnityEngine.Animator")
	-- if(ani) then ani.enabled =false end
	-- local nav= LuaHelper.GetComponent(clone,"UnityEngine.NavMeshAgent")
	-- if(nav) then ani.enabled =false end
	-- local comp= clone:GetComponents(t)
 --     local len = comp.Length-1
 --     for i=0,len do
 --     	comp[i].enabled=false
 --        --GameObject.Destroy(comp[i])
 --     end


	if(Roles==nil) then Roles={} end
	table.insert(Roles,clone)

	LabelCount.text = "Count:"..#Roles
end

local function clearRoles()
	for k,v in ipairs(Roles) do
		LuaHelper.Destroy(v.gameObject)
	end
	Roles={}
end

-----------------------------public------------------
function battlefield:onShowed( ... )
	UIPopupList.items:Clear()

	local units = Model.units

	for k,v in pairs(units) do

		if UIPopupList.items:Contains(v.model)==false then
			UIPopupList.items:Add(v.model)
		end
		if UIPopupList.items:Contains(v.model1)==false then
			UIPopupList.items:Add(v.model1)
		end

		UIPopupList.value=v.model
	end
	groupController =GroupController()

	BattleLoader:hide()
	-- UIPopupList.items:Add("Character1")
	-- UIPopupList.items:Add("Hetong2")
end

function battlefield:onBlur()
	clearRoles() --退
	self:clear()
	StateManager:setLoading(true)
	StateManager:getCurrentState():removeItem(self)
end

function battlefield:onAssetsLoad(items)

  	ReferConfig = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects")
	ReferBattle = LuaHelper.GetComponent(self.assets[2].root,"ReferGameObjects")
	BattleUICamera = ReferConfig.refers[1].camera 
	UIPopupList = ReferConfig.monos[0]
	BattleCamera = ReferBattle.refers[1].camera
	LabelCount = ReferConfig.monos[1]
end

function battlefield:onClick(obj,arg)
	local cmd = obj.name
	print(" battlefield  click "..cmd)
	if cmd == "NGUIEvent" then
	elseif cmd == "BtnStart" then
		cloneRole()
	elseif cmd =="BtnCancel" then
		StateManager:setCurrentState(StateManager.main)
	end
end
