local battleUI = LuaItemManager:getItemObject("battleUI")
local battleMap = LuaItemManager:getItemObject("battleMap")
local battleLoading = LuaItemManager:getItemObject("battleLoading")
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
local ActionNodes=toluacs.ActionNodes

-----------------------net--------------------
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper
local showTips = showTips

---------------------------------------------
battleUI.assets=
{
  	Asset("BattleUI.u3d"),
  	Asset("MapTips.u3d")
}

battleUI.isbattling=false
battleUI.HeroAssist = nil
battleUI.cardList = {} --英雄卡牌列表
battleUI.heroList ={} --卡牌英雄列表
-- battleUI.rolesPos ={} --英雄位置信息
battleUI.MiniMap = nil --小地图
battleUI.player_base = nil --基地属性
battleUI.myteam = nil --我的队伍
battleUI.onConfiged = false
battleUI.noConfig = false --不显示配置界面
-- player_base:{
-- 	pos:{y:0;x:0;z:0};
-- 	player_hero_skill:{
-- 		1:{lv:1;id:300002}
-- 		};
-- id:0;
-- hero_group_id:210011;
-- 	player_hero_attribute:{dodgeValue:27;magicDefend:54;rangeVisible:10;hp:440;turnSpeed:365;speed:2.5;defend:29;critValue:27;attackSpeed:1;maxMp:100;maxHp:440;magicDamage:76;mp:0;damage:38};
-- system_hero_id:210011;
-- hero_brain:HeroBrain
-- 	}
battleUI.chapterData = nil --关卡配置
battleUI.Formation = nil --阵型
battleUI.RTSCamera = nil --ControllCamera GameObject
battleUI.camera = nil --主camera
battleUI.heroPosPrefab = nil --指示英雄位置
battleUI.posLeft = nil --右边位置
-----------------------------private---------------------
local ReferConfig,ReferWar,ReferAward,ReferSKill,UIStart,UIAwardLose,ReferMapTips,ReferMapAssistUI
local camera1,camera1Path,camera1LookAt,RTSInput,RTSInput,InputController
local cardTable,expsTable,goodsTable
local myMainCity,enemyMainCity
----------------------------
local roles
local allEnemy,allFriend
--------------------------------------
local function ShowWarStarUI( ... )
	UIStart:SetActive(true)
end 

local function HideWarStarUI( ... )
	UIStart:SetActive(false)
end

local function listenSlider(card,slider)
	if roles[card.id.."slider"] ==nil then
		local leader = battleMap:getActorById(card.id)  --roles[card.id..""]
		if(leader and leader.roleSlider) then
			leader.roleSlider:AddHpSlider(slider)
			slider.value=leader.roleProperty.hp/leader.roleProperty.maxHp
			roles[card.id.."slider"] = true
		end
	end
end

local function listenSliderMp(card,slider)
	if roles[card.id.."mslider"] ==nil then
		local leader = battleMap:getActorById(card.id)  --roles[card.id..""]
		if(leader and leader.roleSlider) then
			leader.roleSlider:AddMpSlider(slider)
			slider.value=leader.roleProperty.mp/leader.roleProperty.maxMp
			roles[card.id.."mslider"] = true
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

--初始化己方阵型
local function initFormation()
	-- battleUI.myteam = battleMap:getTopArmyByTeam(1) --得到自己

	battleUI.cardList = {} 
	battleUI.heroList = {}
	--英雄 UI 生成
	local teams=battleUI.myteam.monster
	local itemClone = ReferConfig.monos[2].gameObject
	local parent = ReferConfig.refers[2]
	local per = 100 --Screen.width/#CardList
	local begin = (per*#teams)/2+per
    print(" initFormation========生成位置UI信息 生成 "..tostring(#teams))

	for k,v in ipairs(teams) do
		if v.info.category==3 then --表示主基地
			local ReferHeroMain = ReferConfig.monos[3].gameObject
            local clone = LuaHelper.InstantiateLocal(ReferHeroMain,parent)
			clone:SetActive(true)
			local cloneRefer = LuaHelper.GetComponent(clone,"ReferGameObjects")
			cloneRefer.userObject = v
			table.insert(battleUI.cardList,cloneRefer)
			cloneRefer.monos[0].spriteName = v.info.icon
--            print(" 主基地 。。。"..v.info.id)
		elseif v.info.type==1 then
			local clone = LuaHelper.InstantiateLocal(itemClone,parent,Vector3(k*per-begin,10,0.1))
			clone:SetActive(true)
			local cloneRefer = LuaHelper.GetComponent(clone,"ReferGameObjects")
			cloneRefer.userObject = v
			table.insert(battleUI.cardList,cloneRefer)
			table.insert(battleUI.heroList,cloneRefer)
			cloneRefer.monos[0].spriteName = v.info.icon
		end
	end

end

-- local testPosition={{-7.649683,0,15.5},{-3.329903,0,15.5},{-0.5,0,13.5},{5.879266,0,15.5},
-- {10.14407,0,15.5},{-0.02349794,0.87888,15.5}}

local function buildMePos()

	for i,v in ipairs(battleUI.cardList) do  --group  postion
		local screenpos = BattleUICamera:WorldToScreenPoint(v.transform.position)
		local ray = BattleCamera:ScreenPointToRay(screenpos)
		local hit = LuaHelper.Raycast(ray)
		if  hit then
			local pos = v.userObject.pos
			local nPos = hit.point
			pos.x,pos.y,pos.z = nPos.x,nPos.y,nPos.z
		end
	end

end

local function dlgCallBack()
    print("dlgCallBack")
    battleUI:startBattle()
end

--------------------------skill--------------------------
--技能镜头效果
local function skillCamera1(time,oncomplete)
	local paths = Vector3[4]
	if target then

		camera1Path.transform.rotation=target.transform.rotation
		for i=0,3 do
			paths[i]= Vector3Helper.Add(camera1Path.refers[i].transform.position,target.transform.position)
		end
		camera1LookAt.target=target.transform
	end

	camera1:SetActive(true)
	camera1.transform.position=battleUI.RTSCamera.targetCamera.transform.position
	camera1.transform.rotation=battleUI.RTSCamera.targetCamera.transform.rotation

	LeanTween.move(camera1,paths, time):setEase(LeanTweenType.easeInQuart):setUseEstimatedTime( true ) --:setDelay(1)//:setOrientToPath(false)
end

--隐藏立绘
local function hideSkillUI()
	ReferSKill.gameObject:SetActive(false)
	Time.timeScale=1
	camera1:SetActive(false)
	battleUI.RTSCamera:MoveToSoon(target.transform.position) 
end

--显示立绘
local function showSkillUI(actbuf)
	Time.timeScale=0.1
	ReferSKill.gameObject:SetActive(true)
    local monos = ReferSKill.monos
	-- print(string.format(" show ui skill=%s roleid =%s",actbuf.skill.id,actbuf.actor.roleProperty.data.info.id))
--	monos[0].spriteName="sn_"..actbuf.skill.id
    monos[0].text = getValue(actbuf.skill.name)
	local userData=actbuf.actor.userData
	local key=userData.info.photo
--    print("skill draw "..key.." skill name = "..actbuf.skill.name)
	local texture = PrefabPool:Get(key)
    local uitexture = monos[1]
	uitexture.mainTexture= texture
    uitexture:MakePixelPerfect()
--	skillCamera1(2)
--	Timer.AddFn(hideSkillUI,2.7)
    Timer.AddFn(hideSkillUI,2)
end
------------------------------msg-------------------

--结算面板
local function showAward(msg)
	RTSInput.controll=false

	ReferConfig.gameObject:SetActive(false)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(true)
	local monos=ReferAward.monos

	if msg.victory then
		ReferAward.refers[0]:SetActive(true)
		ReferAward.refers[1]:SetActive(false)
	else
		ReferAward.refers[0]:SetActive(false)
		ReferAward.refers[1]:SetActive(true)
	end

	if msg then

		printTable(msg)
		monos[2].text = "Lv"..tostring(1)
		monos[3].text = "+"..tostring(msg.drop.player_exp) --player
		monos[5].text = "+"..tostring(msg.drop.gold)
		for i=1,3 do
			if i<=msg.star then
				monos[5+i].gameObject:SetActive(true)
			else
				monos[5+i].gameObject:SetActive(false)
			end
		end 

			expsTable.data = msg.drop.hero_exp
			expsTable:Refresh()

			goodsTable.data = msg.drop.goods
			goodsTable:Refresh()
	end

end

local function clearChild(i,obj)
		LuaHelper.Destroy(obj)
end

local function clearFormation()
	local DragRangePanel = ReferConfig.refers[2]
	battleUI.cardList = nil
	LuaHelper.ForeachChild(DragRangePanel,clearChild)
end

local function destoryAll()
	print(" battleUI . destoryAll ")
	clearFormation()
    	
    LuaHelper.ForeachChild(battleUI.posLeft.gameObject,clearChild)
	-- local parent = ReferConfig.refers[2]
	-- local function clearChild(i,obj)
	-- 	LuaHelper.Destroy(obj)
	-- end
	-- LuaHelper.ForeachChild(parent,clearChild)

	battleUI.isbattling =false
	battleUI.onConfiged = false
   battleUI.noConfig = false
end

local function cooldownFn( ... )
	print("倒计时完成")
end 

--------------------------public-------------------------
--开始战斗
function battleUI:startBattle()
	ReferWar.gameObject:SetActive(true)
	RTSInput.controll = true

	beginTime=os.clock()
	hero_deaths_number=0
	self.RTSCamera.onMoveFinish=nil
	ShowWarStarUI()
	
	battleMap:beginWar()
    self.RTSCamera.targetCamera.fieldOfView = 40
    local y = self.RTSCamera.maxDistance
    print(string.format(" set maxDistance = %s",y))
    self.RTSCamera:SetY(y)
	delay(HideWarStarUI,2,nil)
	
   self.components.cooldownLabel:begin(self.chapterData.time) --开始计时
   self.onCooldownFn = function( ... )
   		print(" cool down !")
   end
   	self.isbattling = true

   self:sendBegin() --向服务端发送开始消息

--   showGuide(1)
end 

--转换到配置
function battleUI:toConfig( ... )
	self:hideAll()
	ReferConfig.gameObject:SetActive(true)
	self.isbattling = false
	self.onConfiged = false
--    showGuid(50)
end

--直接切换到战斗
function battleUI:toRealWar()
    self:hideAll()
    battleMap:buildEnemy()
	battleMap:buildMe()
    local f = function(i,v) 
		if v.info.type==1 then 
			return true 
		else 
			return false 
		end
	end

	local teams= Model.filter(battleUI.myteam.monster,f)

	cardTable.pageSize = #teams
	cardTable.data = teams
	cardTable:Refresh()

	self.RTSCamera:RotationTo(Vector3(60,0,0),1)
--    clearFormation() --清理配置位置图标
	-- startBattle()
--    showStoryDlg(self.chapterData["id"], dlgCallBack)
    self:startBattle()
--    showGuide(1)
end

function battleUI:toWar( ... )
    print("-------------------------------------------- battleUI:toWar  ---------------------------------")
	buildMePos()
    self:toRealWar()
end

function battleUI:toWar1()
print(string.format("------------------toWar1 %d ",self.chapterData.camera) )
    	local cameraInitPosition = battleMap.positions[self.chapterData.camera] --镜头位置
        	print(cameraInitPosition)
        self.RTSCamera:SetPosition(cameraInitPosition)
        self:toRealWar()
end

function battleUI:hideAll( ... )
	ReferConfig.gameObject:SetActive(false)
	ReferWar.gameObject:SetActive(false)
	ReferAward.gameObject:SetActive(false)
	ReferSKill.gameObject:SetActive(false)
	UIAwardLose:SetActive(false)
end

function battleUI:toAward(success)
	RTSInput.controll=false
	self:hideAll()
	if success then
		ReferAward.monos[9].color = Color.white
	else
		--ReferAward.monos[9].color = Color.black
		-- showAward()
		UIAwardLose:SetActive(true)
	end
	local chapter_id 
	-- if battlefield.serverChapterData then
		chapter_id=tonumber(Model.chapterCurrentIndex)
	-- end
	 if chapter_id==nil then chapter_id=500001 end
	 local chapter_time = os.clock()-beginTime
	 print(string.format("chapter_id =%d,chapter_time=%d,hero_deaths_number=%d ",chapter_id,chapter_time,hero_deaths_number))
	 -- print(chapter_id.." send to server"..tostring(chapter_time))
	 local msg = NetMsgHelper:makesend_challenge_chapter_result(success,chapter_id,hero_deaths_number,chapter_time) 
	Proxy:send(NetAPIList.player_challenge_chapter_result,msg)

	battleMap:endWar()
end

function battleUI:setMapSize()
	local sizet = battleMap.size
	if (battleUI.RTSCamera) and sizet then battleUI.RTSCamera:SetSize(sizet[1],sizet[4]) end
end
-------------------------lua object---------------------


-------------------------item object---------------------
function battleUI:onCustomer(sender,arg)
	if sender=="buffend" then
		showSkillUI(arg)
	end
end

function battleUI:onShowed( ... ) 
--初始化
    roles = {}
	local Ref_MoveLabelBuff=ReferMapAssistUI.refers[0]
	local clone  = LuaHelper.InstantiateLocal(Ref_MoveLabelBuff,Ref_MoveLabelBuff.transform.parent.gameObject) 
	PrefabPool:Add("Ref_MoveLabelBuff",clone)
	self:toConfig()
	self:setMapSize()
	battleLoading:onItemShowed(self) --通知loading加载完成
end

function battleUI:checkToConfig( ... )
	battleUI.myteam = battleMap:getTopArmyByTeam(1)
	if  battleUI.myteam~=nil and  self.onConfiged ~= true and self.assetsLoaded  and battleMap.assetsLoaded then
		self.onConfiged = true
        if self.noConfig   then --如果不显示配置界面
            self:toWar1()
        else
        		self:onInitConfig()
        end
	end
end

function battleUI:onInitConfig( )
	 print("onInitConfig")
	initFormation()

	self.RTSCamera:RotationTo(Vector3(90,0,0),0.1)
	local cameraInitPosition = battleMap.positions[self.chapterData.camera]
	self.RTSCamera:SetPosition(cameraInitPosition)
    self.RTSCamera.targetCamera.fieldOfView = 60
end

function battleUI:onAssetsLoad(items)
	local buiItems=self.assets[1].items
	ReferConfig = LuaHelper.GetComponent(buiItems["Config"],"ReferGameObjects")
	ReferWar = LuaHelper.GetComponent(buiItems["War"],"ReferGameObjects")
	ReferAward = LuaHelper.GetComponent(buiItems["Award"],"ReferGameObjects")
	ReferSKill = LuaHelper.GetComponent(buiItems["SKill"],"ReferGameObjects")
	UIStart=buiItems["Start"]
	UIAwardLose = buiItems["AwardLose"]

	ReferMapTips = LuaHelper.GetComponent(self.assets[2].root,"ReferGameObjects")
	--tips
	ReferMapAssistUI=ReferMapTips.monos[7]
	self.HeroAssist = ReferMapAssistUI.monos[0]
	MapAssistUIOtherRoot = ReferMapAssistUI.refers[1]

	camera1= ReferMapTips.refers[2]
	camera1Path=ReferMapTips.monos[4]
	camera1LookAt=ReferMapTips.monos[5]

	BattleUICamera = ReferConfig.refers[1].camera
	BattleCamera = ReferMapTips.refers[1].camera
	-- BattleControlCamera = ReferBattle.refers[0]

	RTSInput=ReferMapTips.monos[1]
	RTSInput.controll=false
	self.RTSCamera = ReferMapTips.monos[0]
	self.camera = BattleCamera --ReferMapTips.monos[1]
	InputController = ReferMapTips.monos[2]
	self.Formation = ReferMapTips.monos[6]

	battleUI.MiniMap=ReferWar.monos[0]
	cardTable = ReferWar.monos[1]
	expsTable=ReferAward.monos[0]
	goodsTable = ReferAward.monos[1]
	self.MiniMap:SetMapCamera(self.RTSCamera)
-------------------------------------
	self.heroPosPrefab = ReferWar.monos[5] --英雄指示位置UI
	self.posLeft  = ReferWar.monos[6] --左边的列表
---------------------------------------------------------------------------------------------
	local cdl = self:addComponent("cooldownLabel") --加入倒计时label 
	cdl.enable = false
	cdl.label = ReferWar.monos[3]
	cdl.onCooldownFn=cooldownFn
---------------------------------------------------------------------------------------------
	cardTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="Card"..tostring(itemdata.id)
				local mono = referScipt.monos
				mono[1].spriteName = itemdata.info.icon
				mono[0].text = itemdata.info.name

				listenSlider(itemdata,mono[2])
				listenSliderMp(itemdata,mono[3])
				referScipt.gameObject:SetActive(true)
				if (mono[4].luaFn==nil) then mono[4].luaFn=CheckSlider end
				if (mono[5].luaFn==nil) then mono[5].luaFn=CheckSlider end
		end
	end

	cardTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end

	cardTable.onDataRemove = function(data,index,script)
		local lenold=#data
			table.remove(data,index)
	end

	cardTable.onDataInsert = function(data,index,script)
			if script.data==nil then script.data={} end
			local lenold=#script.data
			table.insert(script.data,index,data)
	end

		expsTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="hero"..tostring(index)
				local mono = referScipt.monos
				mono[1].spriteName = Model.getUnit(itemdata.system_hero_id).icon
				mono[0].text = "+"..tostring(itemdata.exp) --itemdata.info.name
				referScipt.gameObject:SetActive(true)

		end
	end

	expsTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end

	goodsTable.onItemRender=function(referScipt,index,itemdata)
		if(itemdata) then
				referScipt.name="goods"..tostring(itemdata.goods_id)
				local mono = referScipt.monos
				mono[1].spriteName = Model.getItemData(itemdata.goods_id).icon
				referScipt.gameObject:SetActive(true)
		end
	end

	goodsTable.onPreRender=function(referScipt,index,dataItem)
		referScipt.name="Pre"..tostring(index)	
		referScipt.gameObject:SetActive(false)
	end

end

function battleUI:onClick(obj,arg)
	local cmd = obj.name
	print(" battleUI.onClick --------------------------"..cmd)

	if cmd == "NGUIEvent" then
		return
	elseif cmd =="BtnOk" then
         if self.callback then
            self.callback()
            self.callback = nil
--             delay(self.callback,0.1,nil) 
        else
		    StateManager:setCurrentState(StateManager.mapScene)
        end
	elseif cmd == "BtnAgain" then	
		 if self.callback then
            self.callback()
            self.callback = nil
--             delay(self.callback,0.1,nil) 
        else
		    StateManager:setCurrentState(StateManager.mapScene)
        end
	elseif cmd == "BtnStart" then
   	 	self:toWar()
--   	else
   	elseif cmd == "BtnCall" then
        self:sendMythical()
   	end
end

function battleUI:onPress(obj,arg)
local cmd = obj.name
	if arg ==false then
		local controllTarget = InputController.focusActor

   		if controllTarget== target and controllTarget~=nil then	
   			local tarPos = RTSInput:GetLastVector3()
   			 controllTarget:DispatchBrainEvent(31,tarPos) -- :MoveTo(tarPos) 
   		end
   		controllTarget=nil
    else
        	local id = string.match(cmd,"Card(%d+)")
   		    if id~=nil then
   			    target = battleMap:getActorById(id)  --roles[id..""]
   			    if target then
   				    if target.isDead==false then

   					    local function onMoveToActor( ... )
						    ActionNodes.ChooseSkill1(target.input,target.output) --选择技能1
   						    print(target.roleSkill.currSkill.id) 
   						    target.brain:DispatchEvent(33, nil) --BrainEventEnum.SkillAttack =33--技能攻击
   						    self.RTSCamera.onMoveFinish = nil
					    end 

   					    self.RTSCamera:MoveToSoon(target.transform.position) 
   					    InputController:SetFocus(target)
   					    onMoveToActor()	
   				    end
   			    end
   		    end --end if

	end
end

function battleUI:onBlur(...)
	destoryAll()
	self:hide() --self:clear()
	StateManager:setLoading(true)
	StateManager:getCurrentState():removeItem(self)
end

-------------------------net---------------------
--发送战斗开始时间
function battleUI:sendBegin()
        local msg = NetMsgHelper:makesend_player_challenge_chapter_start(Model.chapterCurrentIndex)
        Proxy:send( NetAPIList.player_challenge_chapter_start,msg)
end

--请求圣兽
function battleUI:sendMythical()
        local playerID =  Model.PlayerInfo.player_id
        local msg = NetMsgHelper:makept_int (playerID)
        Proxy:send( NetAPIList.call_mythical_animals,msg)
end

function battleUI.onAwardMessage(msg)
	-- print("msg battle "..tostring(type))
	-- printTable(msg)
	showAward(msg)
end

function battleUI.onErr(data)
	local tips = getValue("g_notify_"..data.errno)
	 showTips(tips,battleUI.onErrClick)
end

function battleUI.onErrClick( ... )
	StateManager:setCurrentState(StateManager.mainScene)
end

--初始化函数只会调用一次
function battleUI:initialize()
	Proxy:bindingOne(NetAPIList.recv_player_challenge_chapter_result,self.onAwardMessage)
	Proxy:bindingError(36,self.onErr)
end