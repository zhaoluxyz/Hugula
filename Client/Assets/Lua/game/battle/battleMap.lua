local battleMap = LuaItemManager:getItemObject("battleMap")
local battleLoading = LuaItemManager:getItemObject("battleLoading")
local battleUI = LuaItemManager:getItemObject("battleUI")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Model = Model
local UnityEngine = UnityEngine
local Vector3 = UnityEngine.Vector3
local GameObject = GameObject
local PrimitiveType = UnityEngine.PrimitiveType
local Quaternion = UnityEngine.Quaternion
local Color = UnityEngine.Color
local RenderSettings=UnityEngine.RenderSettings
local Screen = UnityEngine.Screen
local Time = UnityEngine.Time
local Timer = luanet.Timer

local Vector3Helper = luanet.Vector3Helper
local iTween=iTween
local LeanTween = LeanTween
local LTBezierPath = luanet.LTBezierPath
local LeanTweenType=luanet.LeanTweenType
local Mathf = UnityEngine.Mathf

local RoleProperty = luanet.import_type("RoleProperty")
local PrefabPool = luanet.PrefabPool.instance
local BuffHelper = toluacs.BuffHelper
local UIButtonColor = luanet.UIButtonColor
local SceneManager = luanet.SceneManager.instance


local tipUI = {} --提示相关UI
-----------------------net--------------------
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper
local showTips = showTips
---------------------------------------------
battleMap.allEnemy = {} --场景存在的敌人
battleMap.allFriend ={} --场景纯在的友军
battleMap.stronghold ={} --据点刷兵配置
battleMap.levelArmy ={} --刷新的军队
---------------------------local-------------------------

local hero_table
local function addEnemy(enemy)
	table.insert(battleMap.allEnemy,enemy)
	battleUI.MiniMap:AddBattleRole(enemy.gameObject)
	if enemy.roleSlider~=nil  then 
		local hps = enemy.roleSlider.hpSlider
		local len = hps.Count-1
		for i=0,len  do
--			hps[i].foregroundWidget.color = Color(1,0,0)]
            hps[i].foregroundWidget.spriteName = "blood_red" 
		end
	end
end

local function addFriend(fri)
	table.insert(battleMap.allFriend,fri)
	battleUI.MiniMap:AddBattleRole(fri.gameObject)
--    if enemy.roleSlider~=nil  then 
--		local hps = enemy.roleSlider.hpSlider
--		local len = hps.Count-1
--		for i=0,len  do
----			hps[i].foregroundWidget.color = Color(1,0,0)]
--            hps[i].spriteName = "spriteName" 
--		end
--	end
end

--添加血条和头像
local function addHpSlider(actor,info)
	local HeroAssist = battleUI.HeroAssist
	local clone=LuaHelper.InstantiateLocal(HeroAssist.gameObject,MapAssistUIOtherRoot) 
   clone:SetActive(true)
   clone.name = "photo_"..actor.roleProperty.id
   table.insert(tipUI,clone)
   local cloneHAs=LuaHelper.GetComponent(clone,"ReferGameObjects")
   local monos = cloneHAs.monos
   local lookFllow = monos[2] --LuaHelper.GetComponent(clone,"LookForwardAndFllow")
   lookFllow.fllow = actor
   lookFllow.lookAt = battleUI.camera.transform

   local slider =  monos[0] --LuaHelper.GetComponent(clone,"UISlider")
   actor.roleSlider:AddHpSlider(slider)
    local photo = monos[1]

   if info.icon~=nil and info.type ==1  then
        cloneHAs.refers[0]:SetActive(true)
        photo.spriteName = info.icon
   else
        cloneHAs.refers[0]:SetActive(false)
   end
end

--添加指示
local function addForwardUI( actor,info)
	local heroPos = battleUI.heroPosPrefab --英雄指示位置UI
	local left  = battleUI.posLeft.gameObject 
	local clone=LuaHelper.InstantiateLocal(heroPos.gameObject,left)
	local cloneRefer=LuaHelper.GetComponent(clone,"ReferGameObjects")
	clone:SetActive(true)
	local monos = cloneRefer.monos
	local photo = monos[0]
	photo.spriteName = info.icon
	local roleFoward = monos[2]
	roleFoward.warCamera = battleUI.camera
	roleFoward.lookForward = actor.transform
	battleUI.posLeft.repositionNow = true
end

--添加从服务端获取的技能
local function addMsgSkill(actor,skills)
    local skill = GetSkillData(10)
    BuffHelper.DoSpellBuff(actor,skill,actor,actor.transform.position)
	SetRoleSkillsByMsg(actor.roleSkill,skills)
end


--创建一个角色
local function buildOneActor(id,info,property,brain,team,skills,type)

	local v = info
	local key = v.model
	local pro =  RoleProperty()
	if property ==nil then 
		property = v.property 
	end

	SetRoleProperty(pro,property)
	SetCateProperty(pro, type, 1)
	-- print(id)
	-- print(key)
	-- print(brain)

 --[[	if pro == nil then
 		print("buildOneActor  	_____  pro为空")
 	else
 		print( "buildOneActor   _____  AddMemberFromCache之前檢測，打印pro表" )
 		printTable(pro)
 	end]]

	local actor = SceneManager:AddMemberFromCache(id,key,pro,team)--加入场景
    print(" ai "..(brain or ""))
	if brain then
        local braincls =  require("brain."..brain)
        if braincls then     actor.brain =braincls().brain
        else    print(brain.." does not exsit") end
	end

	addHpSlider(actor,info)
	if skills then
		addMsgSkill(actor,skills) 
	end

	if team == 1 then
		actor.tag="OwnRole"
		addFriend(actor)
		hero_table[id..""] = actor
--		print(" buildOneActor "..key)
		printTable(info)
		if info.type==1  then
			addForwardUI(actor,info)
		end
	else
		actor.tag = "Enemy"
		addEnemy(actor)
	end



	actor:Stop()

	if battleUI.isbattling then --战斗已经开始
		local function beginAi()
			-- print("beginAi"..actor.name)
			actor.roleSkill:DoAutoSkill() --释放自动技能
			actor:Begin() --开始AI计算
		end
		delay(beginAi,1,nil)
	end

	return actor
end 

--创建军队不分敌我
local function buildArmyfmsg(msg)
	local brain
	local v 
	local team = msg.team
	local army = msg.monster

--	if msg == nil then
-- 			print("buildArmyfmsg 中 _____   msg为空")
-- 	end

	local actor
	for k,v1 in ipairs(army) do
		-- v1.info = Model.getUnit(v1.hero_group_id)
		v = v1.info
 		if v == nil then
 			print("buildArmyfmsg 中 _____   v=v1.info为空")
 		end

  		if team==1 and v.type==1 then --
			brain = "HeroBrain"
		elseif	v.type == 1 then
			brain= v1.hero_brain
		else
			brain = nil
		end

		

		if brain == nil then
 			print("buildArmyfmsg服務端傳來的AI為空")
		end


		actor = buildOneActor(v1.id,v1.info,v.player_hero_attribute,brain,team,v1.player_hero_skill,v.type)
		actor.name="Team"..team.."_"..v1.id
		actor.userData=v1
		actor.transform.position=Vector3(v1.pos.x,v1.pos.y,v1.pos.z)
	end
end

--据点刷兵
local function buildStrongholdEnemy(enemy,owner)

	local brain
	local pos = battleUI.Formation.refers
	local team = owner.roleProperty.team
	local ownerP=owner.transform.position
	for k,v1 in ipairs(enemy) do
		local v = v1.info
		if v.type == 1  then --or v.type==2
			--brain= "SoldierBrain" --v.brain
			--brain= "ImplBrain" --v.brain
			brain = v1.hero_brain
		else
			brain = nil

		end
		-- printTable(v)
		-- if brain then 
		-- 	print("据点刷兵 brain = "..brain.." id= "..v.id)
		-- else		
		-- 	print("据点刷兵 brain = "..brain.." id= "..v.id)
		-- end 
		local actor = buildOneActor(k,v,v1.player_hero_attribute,brain,team,v1.player_hero_skill,v.type) --
	
		local p=pos[k].transform.position
		if team==2 then
			actor.name= "EnemySoldier"..k
			local x = ownerP.x+p.x
			local z = ownerP.z-p.z-2
			actor.transform.position=Vector3(x,0.0001,z)
			if v.type== 1 then actor.transform.rotation = Quaternion.Euler(0, 180, 0) end
		else
			actor.name= "MySoldier"..k
			local x = ownerP.x+p.x
			local z = ownerP.z-p.z+2
			actor.transform.position=Vector3(x,0.0001,z)
			-- actor.transform.rotation = Quaternion.Euler(0, 0, 0)
		end
	end
end

--运行自动释放的技能开始AI计算
local function autoSkill( ... )
	local allEnemy = battleMap.allEnemy
	local allFriend = battleMap.allFriend
	for k,v in ipairs(allEnemy) do
		v.roleSkill:DoAutoSkill()
		v:Begin()
	end

	for k,v in ipairs(allFriend) do
		v.roleSkill:DoAutoSkill()
		v:Begin()
	end
end 

--------------------------public-------------------------
function battleMap:destoryAll()

	for k,v in ipairs(self.allEnemy) do
		LuaHelper.Destroy(v.gameObject)
	end

	for k,v in ipairs(self.allFriend) do
		LuaHelper.Destroy(v.gameObject)
	end

	local function clearChild(i,obj)
		LuaHelper.Destroy(obj)
	end
	local mroot = MapAssistUIOtherRoot
	LuaHelper.ForeachChild(mroot,clearChild)

	self.allEnemy = {}
	self.allFriend = {}
	self.levelArmy= {}
	self.stronghold = {}
 	print("======================destoryAll battleMap")
    printTable(self.levelArmy)
	SceneManager:Clear()
	PrefabPool:Clear()
	PrefabPool:ClearCache()
end

--创建第一波怪
function battleMap:buildEnemy()
	print(" buildEnemy frist")
    local teams = self:getTopArmyByTeam(2)
    if teams then
	    buildArmyfmsg(teams)
    end
end

--创建自己
function battleMap:buildMe()
	print(" buildMe ")
    local teams = self:getTopArmyByTeam(1)
    printTable(teams)
    if teams then
	    buildArmyfmsg(teams)	
    end
end

--技能刷兵
function battleMap:buildSolider(buffAction,args)
	print("build  Solider         ________   进入buildSolider")

	local owner,target,skill,buff=buffAction.actor,buffAction.target,buffAction.skill,buffAction.buff
	local id =  owner.userData.info.id
	local stronghold = self.stronghold[id]
	if stronghold then
		local allm=stronghold.army      --Model.getChapterDataByid(Model.chapterCurrentIndex).stronghold
		local enmey = {}
		for k,v in ipairs(allm) do



			v.info=Model.getUnit(v.hero_group_id)

			if v.info == nil then 
 				print("buildSolider     ____  v.info为空 ____"..v.hero_group_id)
			else
				print("buildSolider    _____ 打印配置数据 __"..v.hero_group_id)
	 			printTable(v.info)
	 		end


			table.insert(enmey,v)
		end
		buildStrongholdEnemy(enmey,owner)
	end
end

function battleMap:beginWar()
	-- buildOneEnemy
	-- local function aiStart( ... )
	-- 	for k,v in ipairs(self.allEnemy) do
	-- 		v:Begin()
	-- 	end

	-- 	for k,v in ipairs(self.allFriend) do
	-- 		v:Begin()
	-- 	end
	-- end 

	delay(autoSkill,3,nil)
	-- delay(aiStart,3,nil)
end

function battleMap:endWar( ... )
	for k,v in ipairs(self.allEnemy) do
		v:Stop()
	end

	for k,v in ipairs(self.allFriend) do
		v:Stop()
	end
end

--------------------------public------------------------
--得到玩家
function battleMap:getActorById(id)
	return hero_table[id..""]
end

--得到最新的数据
function battleMap:getTopArmyByTeam(teamid)
	local teams=self.levelArmy[teamid]
	if teams==nil then 
		return nil
	else 
        return teams[#teams]
--        if #teams >=1 then
--		    local top = teams[1]
--            table.remove(teams,1)
--		    return top
--        else
--            return nil
--        end
	end
end

function battleMap:onCustomer(sender,arg)
	if sender=="OnDeath" then --死亡
		local chapter_id =  Model.chapterCurrentIndex
		local monster_id = arg.roleProperty.id
		local msg =NetMsgHelper:makesend_kill_monster(chapter_id,monster_id) 
		 print(" death "..arg.name)
--		printTable(msg)
		Proxy:send(NetAPIList.kill_monster,msg)
	end
end

function battleMap:onFocus()
	local mapUrl="Battlebacks_01.u3d"
    print(Model.chapterCurrentIndex)
	mapUrl = Model.getChapterDataByid(Model.chapterCurrentIndex).mapid..".u3d"
	self.assets={Asset(mapUrl)}
	-- StateManager:checkShowTransform()
    self.assetLoader:load(self.assets)
end

function battleMap:onAssetsLoad(items)
	battleMap.positions = {}
	local initPos = self.assets[1].items["InitPosition"] --绑定camera初始位置
	local eachFn =function(i,obj)
		table.insert(battleMap.positions,obj.transform.position)
	end
	LuaHelper.ForeachChild(initPos,eachFn)

	local sizet = {}
	local size = self.assets[1].items["Size"] --绑定camera初始位置
	local eachFn1 =function(i,obj)
		table.insert(sizet,obj.transform)
	end
	LuaHelper.ForeachChild(size,eachFn1)
	self.size = sizet

	battleUI:setMapSize()
end

function battleMap:onShowed()
    	hero_table ={} --我方英雄缓存

	-- battleMap.position=self.assets[1].items["InitPosition"].transform.position
	battleLoading:onItemShowed(self) --通知loading加载完成
end

function battleMap:onBlur()
	self:destoryAll()
	self:clear()
	self.size = nil
	StateManager:getCurrentState():removeItem(self)
end

-------------------------net---------------------

function battleMap.onMonster(msg) 
	print("-=====================battleMap.onMonster=====================")
	printTable(msg)

	local level = battleMap.levelArmy
	local team = nil
	local teamID = msg.team
	if level[teamID] == nil then level[teamID]={} end
	team = level[teamID]
	for k,v in ipairs(msg.monster) do
		v.info = Model.getUnit(v.hero_group_id)
--		print("onMonster   ______    服務端返回的hero_group_id="..v.hero_group_id)

--		if v.info == nil then 
-- 			print("onMonster     ____  v.info为空 ____"..v.hero_group_id)
--		else
--			print("onMonster    _____ 打印配置数据 __"..v.hero_group_id)
--	 		printTable(v.info)
--	 	end
	end
	table.insert(team,msg)

	if battleUI.isbattling then --如果战斗已经开始需要刷兵
		buildArmyfmsg(msg)
	end
	
	if battleUI.onConfiged ~= true then
		 battleUI:checkToConfig()
	end
end

--初始化函数只会调用一次
function battleMap:initialize()
	Proxy:bindingOne(NetAPIList.recv_monster_list,self.onMonster)
end