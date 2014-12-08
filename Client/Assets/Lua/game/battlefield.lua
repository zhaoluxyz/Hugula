local battlefield = LuaItemManager:getItemObject("battlefield")
local BattleLoader = LuaItemManager:getItemObject("battleLoader")
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
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
local iTween=iTween
local LeanTween = LeanTween
local LTBezierPath = luanet.LTBezierPath
local LeanTweenType=luanet.LeanTweenType
local Mathf = UnityEngine.Mathf
-- local BattleCache = BattleCache
local GroupController = luanet.import_type("GroupController")
local AiHelper = luanet.import_type("AiHelper").instance
local RoleProperty = luanet.import_type("RoleProperty")
local PrefabPool = luanet.PrefabPool.instance
local BuffHelper = toluacs.BuffHelper
local UIButtonColor = luanet.UIButtonColor
local Pos,HpSlider,HerosIconWidth,UIStart,UIAwardLose
-----------------------net--------------------
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper
local showTips = showTips
local beginTime,hero_deaths_number
local HeroBrain = luanet.HeroBrain

---------------------------------------------
battlefield.assets=
{
  	Asset("BattleUI.u3d"),
    Asset("Map01.u3d"),
    Asset("MapAssistUI.u3d")
}

local ReferConfig,ReferWar,BattleUICamera,MiniMap
local cardList,roles
local ReferBattle,BattleCamera,BattleControlCamera,EnemyGlobalBrain,ReferSKill
local RTSInput,RTSCamera,CamackTable,InputController,ReferAward,MyFormation,CameraInitPosition
local myMainCity,enemyMainCity,allEnemy,allFriend
local camera1,camera1Path,target,camera1LookAt
-----------------------------private------------------
local function ShowWarStarUI( ... )
	UIStart:SetActive(true)
end 

local function HideWarStarUI( ... )
	UIStart:SetActive(false)
end

local function refreshHero(refer,unit)
	refer.monos[0].spriteName = unit.icon
end

--初始化阵型
local function initFormation()
	--
	local CardList=Model.battleGroup.team

	cardList ={} 
	local itemClone = ReferConfig.monos[2].gameObject
	local parent = ReferConfig.refers[2]
	local per = 100 --Screen.width/#CardList
	local begin = (per*#CardList)/2+(per/2)

	for k,v in ipairs(CardList) do
		local clone = LuaHelper.InstantiateLocal(itemClone,parent,Vector3(k*per-begin,10,0.1))
		clone:SetActive(true)
		local cloneRefer = LuaHelper.GetComponent(clone,"ReferGameObjects")
		cloneRefer.userObject = v
		table.insert(cardList,cloneRefer)
		refreshHero(cloneRefer,v.info)
	end

end

local function clearFormation()
	for k,v in ipairs(cardList) do
		LuaHelper.Destroy(v.gameObject)
	end

end

local function destoryAll()

	AiHelper:Clear()
	EnemyGlobalBrain:Clear()
	EnemyGlobalBrain:End()

	RenderSettingsHelper.Fog(false)
	PrefabPool:Clear()
	PrefabPool:ClearCache()
	clearFormation()

	for k,v in ipairs(allEnemy) do
		LuaHelper.Destroy(v.gameObject)
	end

	for k,v in ipairs(allFriend) do
		LuaHelper.Destroy(v.gameObject)
	end

	allEnemy=nil
	allFriend = nil
end

local function addEnemy(enemy)
	if allEnemy==nil then allEnemy ={} end
	table.insert(allEnemy,enemy)
	MiniMap:AddBattleRole(enemy.gameObject)
	if enemy.roleSlider~=nil  then 
		local hps = enemy.roleSlider.hpSlider
		local len = hps.Count-1
		for i=0,len  do
			hps[i].foregroundWidget.color = Color(1,0,0)
		end
	end
end

local function addFriend(fri)
	if allFriend==nil then  allFriend={} end
	table.insert(allFriend,fri)
	MiniMap:AddBattleRole(fri.gameObject)
end

local function addHpSlider(actor)
	local clone=LuaHelper.InstantiateLocal(HpSlider,MapAssistUI) 
   clone:SetActive(true)
   local lookFllow=LuaHelper.GetComponent(clone,"LookForwardAndFllow")
   lookFllow.tarTrans = actor.transform
   local slider = LuaHelper.GetComponent(clone,"UISlider")
   actor.roleSlider:AddHpSlider(slider)
end

local function addSkill(actor,attackid,skills)
    local skill = GetSkillData(10)
    BuffHelper.DoSpellBuff(actor,skill,actor,actor.transform.position)
	SetRoleAttack(actor.roleSkill,attackid)
	SetRoleSkills(actor.roleSkill,skills)
	--
	addHpSlider(actor)
end

local function buildEnemy()
	--enemy city
	local v = Model.getUnit(210012)
	local key = v.model
	local building = PrefabPool:Get(key)--BattleCache.modelCache[key]
	local posMian = ReferBattle.refers[3].transform.position
	-- print(posMian)
	local arr=make_array(Vector3,{posMian})
	print(building)
	local Maingroup = GroupController.Create(tonumber(v.id),building,nil,arr,nil,2)
	enemyMainCity=Maingroup.leader
	enemyMainCity.tag = "Enemy"
	SetRoleProperty(enemyMainCity.roleProperty,v.property)
	
	enemyMainCity.name = "EnemyCity"
	-- addHpSlider(Maingroup.leader)
	addSkill(enemyMainCity,nil,nil)
	EnemyGlobalBrain:SetHome(enemyMainCity)
	AiHelper:AddTeamMeber(enemyMainCity,2)
	addEnemy(enemyMainCity)

	local itemPos = ReferBattle.refers[4].transform.position
	local enemy = Model.enemyGroup
	local pos = MyFormation.refers
	local lenPos = pos.Count-1
	for k,v1 in ipairs(enemy) do
		local id = v1.id
		local v = v1.info
		local key = v.model
		local key1 = v.model1
		local role =PrefabPool:Get(key)-- BattleCache.modelCache[key]		
		local role1 =PrefabPool:Get(key1)-- BattleCache.modelCache[key1]
		-- local grouppos=itemPos
		-- grouppos.x=grouppos.x+k*3
		print(string.format("enemy %s,%s,key=%s",role,role1,key))
		local grouppos = Pos[k+4].transform.position

		local tbpos={}
		
		for i=0,lenPos do
			local p=pos[i].transform.position
			local x = grouppos.x+p.x
			local z = grouppos.z-p.z
			table.insert(tbpos,Vector3(x,0.0001,z))
		end
		local arr=make_array(Vector3,tbpos)
		local leaderPro =  RoleProperty()
		 SetRoleProperty(leaderPro,v.property)

		local proper=make_array(RoleProperty,{leaderPro})

		local ag=GroupController.Create(tonumber(id),role,role1,arr,proper,2)
		ag.leader.tag = "Enemy"
		ag.leader.name= "Enemy ai"..k
		ag.isMe = false
		addSkill(ag.leader,v.attack,v.skill)
		local actors = ag:GetActors()
		local len =actors.Count-1
		for i=0,len do
			actors[i].tag = "Enemy"
			addEnemy(actors[i])
		end
		EnemyGlobalBrain:AddActor(ag.leader)
		AiHelper:AddTeamMeber(ag.leader,2)
		if k<=2 then
			ag.leader.brain=HeroBrain()
		end
	end
end

-- 主基地
local function setMain()
	local main = Model.getUnit(200010)
	local ReferHeroMain = ReferConfig.monos[3]
	ReferHeroMain.monos[0].spriteName = main.icon
end

--监测英雄放置位置。
local function chechkPos()
	--BattleCamera.
	-- 主城位置
	local ReferHeroMain = ReferConfig.monos[3]
	local posMian 
	local screenpos = BattleUICamera:WorldToScreenPoint(ReferHeroMain.gameObject.transform.position)
	local ray = BattleCamera:ScreenPointToRay(screenpos)
	local hit = LuaHelper.Raycast(ray)
	if  hit then	posMian=hit.point end

	local v = Model.getUnit(210011)
	local key = v.model
	local building =PrefabPool:Get(key)-- BattleCache.modelCache[key]
	local arr=make_array(Vector3,{posMian})
	local Maingroup = GroupController.Create(tonumber(v.id),building,nil,arr,nil,1)

	myMainCity = Maingroup.leader
	myMainCity.tag = "OwnRole"
	myMainCity.name = "MyCity"
	SetRoleProperty(myMainCity.roleProperty,v.property)
	-- addHpSlider(myMainCity)
	addSkill(myMainCity,nil,nil)

	AiHelper:AddTeamMeber(myMainCity,1)
	addFriend(myMainCity)

	roles = {}
	for i,v in ipairs(cardList) do  --group  postion
		local screenpos = BattleUICamera:WorldToScreenPoint(v.gameObject.transform.position)
		local ray = BattleCamera:ScreenPointToRay(screenpos)
		local hit = LuaHelper.Raycast(ray)
		if  hit then
			local id = v.userObject.player_hero_id
			roles[id.."pos"]=hit.point
		end
	end

	local pos = MyFormation.refers
	local lenPos = pos.Count-1
	for i,v in ipairs(cardList) do  --create group
		local db = v.userObject
		local id = db.player_hero_id
		local v = v.userObject.info		
		local key = v.model
		local key1 = v.model1
		local role =PrefabPool:Get(key)-- BattleCache.modelCache[key]		
		local role1 =PrefabPool:Get(key1)-- BattleCache.modelCache[key1]
		local grouppos=roles[id.."pos"]

		print(string.format("my %s,%s,key=%s id=%s",role,role1,key,id))

		local tbpos={}
		for i=0,lenPos do
			local p=pos[i].transform.position
			local x = grouppos.x+p.x
			local z = grouppos.z+p.z
			table.insert(tbpos,Vector3(x,0.0001,z)) 
		end
		local arr=make_array(Vector3,tbpos)
		local leaderPro =  RoleProperty()
		db.player_hero_attribute[1].rangeVisible=v.property.rangeVisible	
		 SetRoleProperty(leaderPro,db.player_hero_attribute[1]) --设置基础属性
		 leaderPro:AddMp(100)
		 -- leaderPro.data=userObject
		 leaderPro.id=tonumber(id)
		 leaderPro.level=db.player_hero_lv 
		 leaderPro.data=db

		local proper=make_array(RoleProperty,{leaderPro})
		local ag=GroupController.Create(tonumber(id),role,role1,arr,proper,1)
		roles[id..""]=ag.leader
		ag.leader.tag = "OwnRole"
		ag.isMe=true
		ag.leader.name= "My ai"..i
		--添加技能
		addSkill(ag.leader,v.attack,v.skill) --db.player_hero_attribute.player_hero_skill

		local actors = ag:GetActors()
		local len =actors.Count-1
		for i=0,len do
			actors[i].tag = "OwnRole"
			addFriend(actors[i])
		end
		AiHelper:AddTeamMeber(ag.leader,1)
	end

end

local function cameraPos(pos) 
	local y = RTSCamera.transform.position.y
    local q = RTSCamera.transform.rotation.eulerAngles.x
    local dtZ = Mathf.Abs(Mathf.Tan(q * Mathf.Deg2Rad) * y * 0.5)
    pos.z = pos.z - dtZ
    pos.y=y
    return pos
end

local function CameraMoveTo(paths,time,oncomplete)
	-- local l = paths.Length-1
	-- for i=0,l  do
	-- 	paths[i]=cameraPos(paths[i])
	-- end
	-- local t={}
	-- t["path"] = paths
 --    t["movetopath"] = true
 --    t["orienttopath"] = false
 --    t["time"] = time
 --    t["easetype"] = iTween.EaseType.linear
 --    if oncomplete then   t["oncomplete"]=oncomplete end

	-- local has = iTween.HashLua(t)
 --    iTween.MoveTo(RTSCamera.gameObject,has)
 		LeanTween.moveSpline(RTSCamera.gameObject,paths, time):setEase(LeanTweenType.easeInQuart):setUseEstimatedTime( true ):setOnComplete(oncomplete) --:setDelay(1)//:setOrientToPath(false)

end

local function changeToWar()
	buildEnemy()
	chechkPos()
	ReferConfig.gameObject:SetActive(false)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(false)
	local CardList=Model.battleGroup.team

	CamackTable.PageSize = #CardList
	CamackTable.data = CardList
	CamackTable:Refresh()

	RTSCamera:RotationTo(Vector3(60,0,0),1)
	-- BattleControlCamera.transform.localPosition = Vector3(0,0,0)

	local function onBeginWar( ... )
		ReferWar.gameObject:SetActive(true)
		RTSInput.Controll = true
		EnemyGlobalBrain:Begin()
		RenderSettingsHelper.Fog(true) --打开迷雾

		beginTime=os.clock()
		hero_deaths_number=0
		RTSCamera.onMoveFinish=nil
		ShowWarStarUI()
		delay(HideWarStarUI,2)
	end
				----------------itween move--------------------------------------
	local p0=enemyMainCity.transform.position
	local p1 = myMainCity.transform.position
	local paths = Vector3[2]
	paths[0] = p0
	paths[1] = p1
	-- CameraMoveTo(paths,3,onBeginWar)
	onBeginWar()
end 

local function listenSlider(card,slider)
	if roles[card.player_hero_id.."slider"] ==nil then
		local leader =roles[card.player_hero_id..""]
		if(leader and leader.roleSlider) then
			leader.roleSlider:AddHpSlider(slider)
			slider.value=leader.roleProperty.hp/leader.roleProperty.maxHp
			roles[card.player_hero_id.."slider"] = true
		end
	end
end

local function listenSliderMp(card,slider)
	if roles[card.player_hero_id.."mslider"] ==nil then
		local leader =roles[card.player_hero_id..""]
		if(leader and leader.roleSlider) then
			leader.roleSlider:AddMpSlider(slider)
			slider.value=leader.roleProperty.mp/leader.roleProperty.maxMp
			roles[card.player_hero_id.."mslider"] = true
		end
	end
end

local function CheckSlider(gameObject, trigger, target)
	if trigger.name == "SliderHp" then
		if trigger.value<=0 then  end --target[0]:SetState(UIButtonColor.State.Disabled,true)
	elseif trigger.name == "SliderMp" then
		if trigger.value>=1 then  target[1].gameObject:SetActive(true) end
	end
end

local function chageToLose() 
	ReferConfig.gameObject:SetActive(false)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(true)
	-- ReferAward.monos[0].text = awradTxt
	AiHelper:Clear()
	EnemyGlobalBrain:Clear()
	EnemyGlobalBrain:End()

	AwardLose:SetActive(true)
end

local function chageToAward(msg)
	ReferConfig.gameObject:SetActive(false)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(true)
	-- ReferAward.monos[0].text = awradTxt
	AiHelper:Clear()
	EnemyGlobalBrain:Clear()
	EnemyGlobalBrain:End()

	-- if msg ==nil then
	-- 	msg = {}
	-- 	local recv_challenge_chapter_result_hero={NetMsgHelper:makerecv_challenge_chapter_result_hero(1,20)}
	-- 	local recv_goods = {NetMsgHelper:makerecv_goods(100118,2)}
	-- 	msg = NetMsgHelper:makerecv_challenge_chapter_result(10,250,recv_challenge_chapter_result_hero,math.random(1,3),recv_goods)
	-- end
	local monos=ReferAward.monos

	if msg then
		monos[2].text = "Lv"..tostring(1)
		monos[3].text = "+"..tostring(msg.goods[1].player_exp) --player
		monos[5].text = "+"..tostring(msg.goods[1].gold)
		for i=1,3 do
			if i<=msg.star then
				monos[5+i].gameObject:SetActive(true)
			else
				monos[5+i].gameObject:SetActive(false)
			end
		end 

			monos[0].data = msg.heros
			monos[1].data = msg.goods[1].goods

			monos[0]:Refresh()
			monos[1]:Refresh()

		local tilesize=CamackTable.tileSize
		tilesize.x = (HerosIconWidth-20)/6
		CamackTable.tileSize =tilesize 
	else
		monos[2].text = "Lv"..tostring(1)
		monos[3].text = "+"..tostring(0) --player
		monos[5].text = "+"..tostring(0)
		for i=1,3 do
			-- if i<=msg.star then
			-- 	monos[5+i].gameObject:SetActive(true)
			-- else
				monos[5+i].gameObject:SetActive(false)
			-- end
		end 

			monos[0].data = {}
			monos[1].data = {}

			monos[0]:Refresh()
			monos[1]:Refresh()

		-- local tilesize=CamackTable.tileSize
		-- tilesize.x = (HerosIconWidth-20)/6
		-- CamackTable.tileSize =tilesize 
	end
end

local function changeToConfig( ... )
	ReferConfig.gameObject:SetActive(true)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(false)
	ReferSKill.gameObject:SetActive(false)
end

local function skillCamera1(time,oncomplete)
	local paths = Vector3[4]
	-- paths[0] = p0
	-- paths[1] = p1

	if target then

		camera1Path.transform.rotation=target.transform.rotation
		for i=0,3 do
			paths[i]= Vector3Helper.Add(camera1Path.refers[i].transform.position,target.transform.position)
		end
		camera1LookAt.target=target.transform
	end

	camera1:SetActive(true)
	camera1.transform.position=RTSCamera.targetCamera.transform.position
	camera1.transform.rotation=RTSCamera.targetCamera.transform.rotation
	-- local t={}
	-- t["path"] = paths
 --    t["movetopath"] = true
 --    -- t["orienttopath"] = false
 --    t["time"] = time
 --    t["looktarget"]=target.transform
 --    -- t["looktime"] =1
 --    t["easetype"] = iTween.EaseType.linear
 --    t["ignoretimescale"]=true
 --    if oncomplete then   t["oncomplete"]=oncomplete end

	-- local has = iTween.HashLua(t)
 --    iTween.MoveTo(camera1,has)

	-- local ltPath = LTBezierPath(paths)
	-- ltPath:place(camera1.transform,0.6) //ltPath.pts
	LeanTween.move(camera1,paths, time):setEase(LeanTweenType.easeInQuart):setUseEstimatedTime( true ) --:setDelay(1)//:setOrientToPath(false)
end

local function hideSkillUI()
	ReferSKill.gameObject:SetActive(false)
	Time.timeScale=1
	camera1:SetActive(false)
	RTSCamera:MoveToSoon(target.aiPerception.targetPos) 
end

local function showSkillUI(actbuf)
	Time.timeScale=0.2
	ReferSKill.gameObject:SetActive(true)
	-- print(string.format(" show ui skill=%s roleid =%s",actbuf.skill.id,actbuf.actor.roleProperty.data.info.id))
	ReferSKill.monos[0].spriteName="sn_"..actbuf.skill.id
	ReferSKill.monos[1].spriteName="r_"..actbuf.actor.roleProperty.data.info.id
	skillCamera1(2)
	Timer.AddFn(hideSkillUI,2.7)
end
local function CheckFinish( ... )
	if hero_deaths_number>=5 then
		sendResultToServer(false)
	end
end
------------------------------send-------------------
local function sendResultToServer(success)
	-- printTable(battlefield.serverChapterData)
	if success then
		ReferAward.monos[9].color = Color.white
	else
		--ReferAward.monos[9].color = Color.black
		chageToAward()
	end
	local chapter_id 
	if battlefield.serverChapterData then
	chapter_id=tonumber(Model.chapterCurrentIndex)
	end
	 if chapter_id==nil then chapter_id=500001 end
	 local chapter_time = os.clock()-beginTime
	 print(string.format("chapter_id =%d,chapter_time=%d,hero_deaths_number=%d ",chapter_id,chapter_time,hero_deaths_number))
	 -- print(chapter_id.." send to server"..tostring(chapter_time))
	 local msg = NetMsgHelper:makesend_challenge_chapter_result(success,chapter_id,hero_deaths_number,chapter_time) 
	Proxy:send(NetAPIList.player_challenge_chapter_result,msg)
	-- chageToAward()
end
-----------------------------public------------------
function battlefield:onShowed( ... )
	local Ref_MoveLabelBuff=self.assets[3].items["Ref_MoveLabelBuff"]
	PrefabPool:Add("Ref_MoveLabelBuff",Ref_MoveLabelBuff)

	setMain()
	initFormation()
	RTSCamera:RotationTo(Vector3(90,0,0),0.1)

	RTSCamera:SetPosition(CameraInitPosition)
	--BattleControlCamera.transform.localPosition = CameraInitPosition --Vector3(0,195.8,-17.26)

	RenderSettingsHelper.Fog(false)
	BattleLoader:hide()

end

function battlefield:onBlur(...)
	-- print(self.name.." onBlur ")
	destoryAll()
	ReferConfig.gameObject:SetActive(true)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(false)
	ReferSKill.gameObject:SetActive(false)
	self:clear()
	StateManager:setLoading(true)
	StateManager:getCurrentState():removeItem(self)
end

function battlefield:onAssetsLoad(items)
  	print(".......................  newBattlefield is loaded ! /n root.activeSelf="..tostring(self.assets[1].root.activeSelf))
  	ReferConfig = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects")
	ReferWar = LuaHelper.GetComponent(self.assets[1].items["War"],"ReferGameObjects")
	ReferAward = LuaHelper.GetComponent(self.assets[1].items["Award"],"ReferGameObjects")
	ReferBattle = LuaHelper.GetComponent(self.assets[2].root,"ReferGameObjects")
	UIStart=self.assets[1].items["Start"]
	UIAwardLose = self.assets[1].items["AwardLose"]
	MapAssistUI=self.assets[3].root
	local Ref_MoveLabelBuff=self.assets[3].items["Ref_MoveLabelBuff"]
	HpSlider = self.assets[3].items["SliderHp"]
	ReferSKill = LuaHelper.GetComponent(self.assets[1].items["SKill"],"ReferGameObjects")
	camera1= ReferBattle.refers[6]
	camera1Path=ReferBattle.monos[6]
	camera1LookAt=ReferBattle.monos[7]
	-- print("ReferBattle ="..ReferBattle.name)
	BattleUICamera = ReferConfig.refers[1].camera
	BattleCamera = ReferBattle.refers[1].camera
	BattleControlCamera = ReferBattle.refers[0]
	RTSInput=ReferBattle.monos[1]
	RTSInput.Controll=false
	RTSCamera = ReferBattle.monos[0]
	-- print(RTSCamera)
	MiniMap=ReferWar.monos[0]
	CamackTable = ReferWar.monos[1]
	InputController = ReferBattle.monos[2]
	EnemyGlobalBrain = ReferBattle.monos[3]
	MyFormation = ReferBattle.monos[4]
	CameraInitPosition = ReferBattle.refers[5].transform.position
	Pos=ReferBattle.monos[5].refers
	-- BattleControlCamera.transform.localRotation = Quaternion.Euler(Vector3(90,0,0))
	HerosIconWidth=ReferWar.monos[4].width
	MiniMap:SetMapCamera(RTSCamera)

	CamackTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="Card"..tostring(itemdata.player_hero_id)
				local mono = referScipt.monos
				mono[1].spriteName = itemdata.info.icon
				mono[0].text = itemdata.info.name
				--mono[2].value=1
				--mono[3].value=0.5
				listenSlider(itemdata,mono[2])
				listenSliderMp(itemdata,mono[3])
				referScipt.gameObject:SetActive(true)
				if (mono[4].luaFn==nil) then mono[4].luaFn=CheckSlider end
				if (mono[5].luaFn==nil) then mono[5].luaFn=CheckSlider end
		end
	end

	CamackTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end

	CamackTable.onDataRemove = function(data,index,camackTable)
		local lenold=#data
			table.remove(data,index)
	end

	CamackTable.onDataInsert = function(data,index,script)
			if script.data==nil then script.data={} end
			local lenold=#script.data
			table.insert(script.data,index,data)
	end

------------------------------------------awardlist-----------------------------------
		local expsTable=ReferAward.monos[0]
		expsTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="hero"..tostring(index)
				local mono = referScipt.monos

				-- if Model.battleGroup.item[index+1] then
				-- mono[1].spriteName =  Model.battleGroup.item[index+1].info.icon
				-- end
				mono[1].spriteName = Model.getUnit(itemdata.system_hero_id).icon
				mono[0].text = "+"..tostring(itemdata.exp) --itemdata.info.name
				
				-- listenSlider(itemdata,mono[2])
				-- listenSliderMp(itemdata,mono[3])
				referScipt.gameObject:SetActive(true)
				-- if (mono[4].luaFn==nil) then mono[4].luaFn=CheckSlider end
				-- if (mono[5].luaFn==nil) then mono[5].luaFn=CheckSlider end
		end
	end

	expsTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end

	local goodsTable = ReferAward.monos[1]
	goodsTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="goods"..tostring(itemdata.goods_id)
				local mono = referScipt.monos
				mono[1].spriteName = Model.getItemData(itemdata.goods_id).icon
				 -- "item_"..tostring(itemdata.goods_id) --itemdata.info.icon
				-- mono[0].text = "+"..tostring(itemdata.exp) --itemdata.info.name
				
				-- listenSlider(itemdata,mono[2])
				-- listenSliderMp(itemdata,mono[3])
				referScipt.gameObject:SetActive(true)
				-- if (mono[4].luaFn==nil) then mono[4].luaFn=CheckSlider end
				-- if (mono[5].luaFn==nil) then mono[5].luaFn=CheckSlider end
		end
	end

	goodsTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end


	changeToConfig()
end

function battlefield:onCustomer(sender,arg)
	if sender=="buffend" then
		showSkillUI(arg)
	end
end

function battlefield:onClick(obj,arg)
	local cmd = obj.name
	--print(" battlefield  click "..cmd)
	-- print(arg)
	if cmd == "NGUIEvent" then
		return
	elseif cmd=="BtnSetting" then
		-- sendResultToServer(true)
		-- StateManager:setCurrentState(StateManager.mainScene)
		-- battlefield.onErr({errno=36}) --data.errno
	elseif cmd =="BtnOk" then
		-- destoryAll()
		StateManager:setCurrentState(StateManager.mapScene)
	elseif cmd == "BtnAgain" then	
		-- destoryAll()
		-- StateManager:setCurrentState(StateManager.main)
	elseif cmd == "BtnStart" then
   	 	changeToWar()
   	elseif type(arg)=="string" and string.match(arg,"Death")   then --== "Death"
   		if cmd== "EnemyCity" then     		
   			RTSInput.Controll=false
   			sendResultToServer(true)
   		elseif cmd =="MyCity" then 
   			sendResultToServer(false)
   			RTSInput.Controll=false
   		end
		if 	string.match(cmd,"My ai")	then
   			hero_deaths_number=hero_deaths_number+1
   			CheckFinish()
   		end
   	else
   		local id = string.match(cmd,"Card(%d+)")
   		--print(id)
   		if id~=nil then
   			target = roles[id..""]
   			--print(RTSCamera)
   			if target then
   				if target.gameObject.activeSelf then
   					roleid=id
   					local function onMoveToActor( ... )
						target.roleSkill:ChooseSkillByIndex(1)
   						target:Spell()
   						RTSCamera.onMoveFinish = nil
					end 

					-- RTSCamera.onMoveFinish=onMoveToActor
   					RTSCamera:MoveToSoon(target.transform.position) 
   					InputController:SetFocus(target)
   					onMoveToActor()	
   		-- 			local p0=target.transform.position
					-- local paths = Vector3[1]
					-- paths[0] = p0
					
   		-- 			CameraMoveTo(paths,0,onMoveToActor)	
   					-- if(target:AutoTarget()) then target:Spell() end
   				end	
   			end
   		end
	end
end

local controllTarget
function battlefield:onPress(obj,arg)
	if arg ==false then
   		if controllTarget then	
   			local tarPos = RTSInput:GetLastVector3()
   			InputController:MoveTo(tarPos) 
   		end
   		controllTarget=nil
	end
end

function battlefield.onMessage(msg)
	-- print("msg battle "..tostring(type))
	-- printTable(msg)
	chageToAward(msg)
end

function battlefield.onErr(data)
	local tips = getValue("g_notify_"..data.errno)
	 showTips(tips,battlefield.onErrClick)
end

function battlefield.onErrClick( ... )
	-- print("battlefield.onErrClick ")
	-- print(StateManager:getCurrentState())
	StateManager:setCurrentState(StateManager.mainScene)
end

--初始化函数只会调用一次
function battlefield:initialize()
	Proxy:bindingOne(NetAPIList.recv_player_challenge_chapter_result,battlefield.onMessage)
	Proxy:bindingError(36,battlefield.onErr)
end

