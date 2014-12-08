local StoryDlg = LuaItemManager:getItemObject("StoryDlg")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue --多国语言
local showTips = showTips --显示提示

local GameObject= luanet.UnityEngine.GameObject
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs

-----------------------net--------------------
PrefabPool = luanet.PrefabPool.instance
local Proxy = Proxy
local NetAPIList = NetAPIList
local NetMsgHelper = NetMsgHelper

local Vector3 = UnityEngine.Vector3
local dlgAPoint = Vector3.zero
local dlgBPoint = Vector3.zero
local RootReferPanel
local fabDlgA, fabDlgB
local isSwitch = 1
local PrefabPool = PrefabPool

local callBackFn, text, head
local waitTime = 2
local fabHeadA, fabHeadB
local fabTextA, fabTextB

local a_labName, a_tipButtom
local b_labName, b_tipButtom
local v,tx, cnext, name, mlan

local currentID, nextID, currentTask

local nodeIndex = 0
local nodeLock = true
local headLock = true
local palyerfabName = "StoryIDD"

--config data
local  Model = Model

local function allComplete( ... )
	-- body
	local x = 1
end

local function showTop(dialog)
	 
end 

local function showBottom( dialog)
	-- body
end 
StoryDlg.priority = 99
StoryDlg.assets=
{
	Asset("fabDlgSwitch.u3d")
}

------------------public------------------
-- 资源加载完成时候调用方法
function StoryDlg:onAssetsLoad(items)
	print("my OnAssetsLoad")
	RootReferPanel = LuaHelper.GetComponent(StoryDlg.assets[1].items["Refers"], "ReferGameObjects")
	fabDlgA = RootReferPanel.monos[0]
	fabDlgB = RootReferPanel.monos[1]
	fabTextA = RootReferPanel.monos[2]
	fabHeadA = RootReferPanel.monos[3]
	fabTextB = RootReferPanel.monos[4]
	fabHeadB = RootReferPanel.monos[5]
	a_labName = RootReferPanel.monos[6]
	b_labName = RootReferPanel.monos[7]


	local posX = fabDlgA.transform.position.x
	local posY = fabDlgA.transform.position.y
	dlgAPoint = Vector3(posX, posY, 0)

	posX = fabDlgB.transform.position.x
	posY = fabDlgB.transform.position.y
	dlgBPoint = Vector3(posX, posY, 0)
	--scv
end

function StoryDlg:showStoryDlg( taskID,callBack )
	--isSwitch = 1
	nodeIndex = 0
	fabLock = true
	headLock = true
	currentTask = taskID
	print("taskID:"..taskID)
	callBackFn = callBack
    	self:addToState()

	--StoryDlg:SetTaskEx(taskID)	
end

function showStoryDlg( config,callBack )
	StoryDlg:showStoryDlg(config,callBack)

end

function StoryDlg:itMove( gobj,targetPoint,time )
	-- body
	local t = {}
	t["easetype"] = iTween.EaseType.linear
	t["time"] = time
	t["x"] = targetPoint.x
	t["y"] = targetPoint.y
	t["z"] = targetPoint.z
	local has = iTween.HashLua(t)

	iTween.MoveTo(gobj, has)
end

function StoryDlg:itShake( gobj,amount,delay )
	-- body
	iTween.ShakePosition(gobj, amount, delay)
end

local function onModelComplete(req)
  	if req.data then
 		local  mainAsset = req.data.assetBundle.mainAsset
 		if headLock then
 			fabHeadA.mainTexture = mainAsset
 			print("fabA is loaded")
 			headLock = false
 		else
 			fabHeadB.mainTexture = mainAsset
 			print("fabB is loaded")
 			headLock = true
 		end
 		disposeWWW(req.data)
 	end
end 

function StoryDlg:addToList( key,reqs )
	-- body
	if key and key ~="" and string.match(string.lower(key),"ref_%w*")==nil then
		reqs[key]={CUtils.GetAssetFullPath(key..".u3d"),onModelComplete}
	end
end

function StoryDlg:addHeadResToList( role )

	Loader:getResource(CUtils.GetAssetFullPath(role..".u3d"), onModelComplete, false)	
end

--点击事件
function StoryDlg:onClick(obj,arg)

	if fabDlgA ~= nil then
		local cmd =obj.name
		print("my OnClick")

		--移动方法
		local function sakA( ... )
			StoryDlg:itShake(fabDlgA.gameObject, Vector3(0.3, 0, 0), 0.3)
		end
		local function redressA( ... )
			-- body
			fabDlgA.transform.position = Vector3(-0.075, dlgAPoint.y, 0)
		end

		local function sakB( ... )
			StoryDlg:itShake(fabDlgB.gameObject, Vector3(0.3, 0, 0), 0.3)
		end
		local function redressB( ... )
			-- body
			fabDlgB.transform.position = Vector3(0.075, dlgBPoint.y, 0)
		end

		if nextID ~= 0 then
			StoryDlg:GetCurrentNode()
			StoryDlg:addHeadResToList(v.role)
			nodeIndex = nodeIndex + 1
			print("finish"..nodeIndex)
			if nodeLock then
				fabTextA.text = getValue(tx)
				a_labName.text = getValue(name)
				nodeLock = false

				if nodeIndex < 4 then
					StoryDlg:itMove(fabDlgA.gameObject, Vector3(-0.075, dlgAPoint.y, 0), 0.2)
					delay(sakA, 0.2, nil)
					delay(redressA, 0.2, nil)
				end
			else
				b_labName.text = getValue(name)
				fabTextB.text = getValue(tx)
				nodeLock = true

				if nodeIndex < 4 then
					StoryDlg:itMove(fabDlgB.gameObject, Vector3(0.075, dlgBPoint.y, 0), 0.2)	
					delay(sakB, 0.2, nil)
					delay(redressB, 0.2, nil)
				end
			end
		else
			fabDlgA.transform.position = dlgAPoint
			fabDlgB.transform.position = dlgBPoint
			if callBackFn then callBackFn() end
			self:removeFromState()
		end
	end	
end

--显示时候调用
function StoryDlg:onShowed( ... )
	print("my OnShowed")

	--移动方法
	local function sakA( ... )
		StoryDlg:itShake(fabDlgA.gameObject, Vector3(0.3, 0, 0), 0.3)
	end
	local function redressA( ... )
		-- body
		fabDlgA.transform.position = Vector3(-0.075, dlgAPoint.y, 0)
	end

	local function sakB( ... )
		StoryDlg:itShake(fabDlgB.gameObject, Vector3(0.3, 0, 0), 0.3)
	end
	local function redressB( ... )
		-- body
		fabDlgB.transform.position = Vector3(0.075, dlgBPoint.y, 0)
	end

	StoryDlg:SetTaskEx(currentTask)

	if nodeIndex > 0 then
		StoryDlg:GetCurrentNode()
		fabTextA.text = getValue(tx)
		a_labName.text = getValue(name)
		StoryDlg:addHeadResToList(v.role)
		nodeIndex = nodeIndex + 1
		nodeLock = false

		StoryDlg:itMove(fabDlgA.gameObject, Vector3(-0.075, dlgAPoint.y, 0), 0.2)
		delay(sakA, 0.2, nil)
		delay(redressA, 0.2, nil)
		print("finish"..nodeIndex)
	end
end

function StoryDlg:GetCurrentNode( )
	-- body
	for key,value in pairs(Model.storyDlg) do
		local curId = value.id
		if curId == nextID then
			v = Model.getStory(curId)
			tx = v.text
			name = v.name
			currentID = curId
			nextID = v.next
			if nextID == 0 then
				PlayerPrefs.SetInt(palyerfabName, currentID)
			end
			break
		end
	end
end

function StoryDlg:SetTaskEx( taskID )
	-- body
	print("-----------------------------------SETTASK--------------------------------------")
	local key_table = {}
	for key,_ in pairs(Model.storyDlg) do
		table.insert(key_table,key)
	end
	table.sort(key_table)

	local dlgtable = {}
	for _,key in pairs(key_table)do
		local v = Model.getStory(key) 
		local trigId = v.trigger.taskId
		local text = v.text
		if tonumber(trigId) == tonumber(taskID) then
			table.insert(dlgtable, v)
		end
	end

	for key,value in pairs(dlgtable) do
		--local mtaskID = value.trigger.taskId
		local curid = value.id
		v = Model.getStory(curid)
		local mtaskID = v.trigger.taskId
		if mtaskID == taskID then
			currentID = curid
			nextID = currentID --value.next
			print(currentID)
			break
		end
	end
	mlan = PlayerPrefs.GetInt(palyerfabName,0)		--获取当前的ID
	if mlan >= tonumber(currentID) then
		print("i am here.")
		if callBackFn then callBackFn() end
		self:removeFromState()
	else
		PlayerPrefs.SetInt(palyerfabName,currentID)
		nodeIndex = nodeIndex + 1
		print("finish"..nodeIndex)
	end
	print("lan:"..mlan)
	print("id:"..currentID)
end

--初始化函数只会调用一次
function StoryDlg:initialize()
	print("my Initialize") 
end