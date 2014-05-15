local Input=UnityEngine.Input
local Vector3=UnityEngine.Vector3
local KeyCode=UnityEngine.KeyCode
local Mathf=UnityEngine.Mathf
local Random=UnityEngine.Random
local Quaternion = UnityEngine.Quaternion
local Time=UnityEngine.Time
local LuaHelper=LuaHelper
local RuntimePlatform = UnityEngine.RuntimePlatform
local Application = UnityEngine.Application
local RunTime
local TouchPhase = UnityEngine.TouchPhase
local Screen = UnityEngine.Screen

local preBlocks = nil
local preRefs = nil
local blocks = nil
local refs = nil 
local startPoint = nil 
local pos=nil
local fallSpeed = 1
local map,nextB,currB=nil,nil,nil
local blockManager = nil
local blockBoxTrans = nil
local startPointY = 1 --开始Y坐标
local startPointX = 1
local blockBoxTrans = nil
local lastTime = 1 --上一帧时间
local lastInputTime = 1 --上次点击时间
local nextGridPosY=0 --下个格子坐标
local nowBlock = false
--for touch
local touchClickThreshold = 0.03
local startPos,directionChosen,direction
local beginTime,clickDt,stopf=0,0,10
local center={}
local inputCenter = nil 
local DebugRoot = nil
local DebugItem = nil

local scorelabel = nil --提示UI
local cutDownLabel = nil --倒计时
local scroteTipstr="难度: %s \n\n 层数:%s/%s \n\n 积分:%s"
local mode = "简单"

local Block = class(function(self,luaObj )
	self.luaObj=luaObj
	self.enable=false
	RunTime =Application.platform
	center.x = Screen.width/2
	center.y = Screen.height/2
end)
-----------------------------private-------------------------------------

local function ceateBlock( )
	local block7=blockManager:getBlocksData()
	local len=#block7+1
	local rend=math.floor(Random.Range(1,len))
	nextB = block7[rend]
	return nextB
end

local function getBlock()
	currB = nextB
	return currB
end

--刷新方块数据 和位置
local function refreshBlock(data,blockRefs,pos)
	local row=#data 
	local col=#data[1] 
	local indx=0
	local center=data.center
	local tile =blockManager.tile
	local offx,offy=center[1]*tile,center[2]*tile
	
	if pos==nil then 
		blockRefs.gameObject.transform.localRotation = Quaternion.identity;
		data.x =math.floor(blockManager.width/2)+data.top[1]
		data.y = data.top[2]
		local p2= (row % 2==0)
		local p=startPoint.localPosition
 		if p2==false then p.x=p.x-tile/2 end

 		p.y = p.y -row*tile/2 
		blockRefs.gameObject.transform.localPosition = p
		startPointY= p.y + blockManager.tile
		startPointX = p.x - (data.x*blockManager.tile)
		blockRefs.userObject=data
		--print(string.format("gridx = %s , gridy = %s,beginpos=%s",data.x,data.y,p))
	end

	local x,item
	for i = 1,row do
		for j=1,col do
			if(data[i][j]==1)then
				x=(j-1)*tile-offx
				item=blockRefs.refers[indx]
				item.transform.localPosition = Vector3(x,(1-i)*tile+offy,0)
				item.name= "block_"..tostring(i).."_"..tostring(j)--string.format("block_%s_%s",i,j)
				indx=indx+1
			end
		end
	end
end

local function refreshDebug()
	local map = blockManager:debugMap()
	local size = #map
	local mx,my,key = 1,1,""
	local row,datarow = nil,nil
	local len = nil
	for y,v in ipairs(map) do
		for x,v1 in ipairs(v) do
			local dug =v1
			if type(v1)~="userDate" then
				dug=LuaHelper.InstantiateGlobal(DebugItem,DebugRoot)
	 			map[y][x]=dug
	 			dug.name=""..y.."_"..x
	 			dug:SetActive(true)
	 			dug.transform.localPosition=Vector3(x*blockManager.tile,-y*blockManager.tile,100)
 			end
	 		if v1==true then
	 			dug.transform.localRotation=Quaternion.Euler(0,90,0)
	 		else
	 			dug.transform.localRotation=Quaternion.Euler(0,0,0)
	 		end
		end
	end
end

local function refreshPos(blockRefs)	
	local userObject=blockRefs.userObject
	local p = blocks.localPosition
	p.y = startPointY-userObject.y*blockManager.tile
	p.x = startPointX+userObject.x*blockManager.tile --+
	blocks.localPosition = p
end

local function fall(blockRefs)
	local userObject=blockRefs.userObject
	local y=userObject.y+1
	if blockManager:check(userObject,userObject.x,y)==true then --能下移动
		userObject.y= userObject.y+1--math.abs(i)+2 --userObject.y+1 --
		return true
	else
		return false
	end
end

local function rotate(blockRefs)
	local data=blockRefs.userObject
	-- print(" source = \n"..tojson(data))
	 local tempMatrix = {} --new bool[size, size];
	 local size=#data
	 local ty = 0

	local count = blockRefs.refers.Count-1
	local item,name by,bx=nil,"",0,0
	local blockDic,dic ={},{}
	for i=0,count do
		item=blockRefs.refers[i]
		name = item.name
		by,bx=string.match(name,"block_(%d+)_(%d+)")
		local key =tostring(by).."_"..tostring(bx)
		-- print(key)
		blockDic[key]=item --LuaHelper.InstantiateGlobal(item,blockBoxTrans)
	end

    for y = 1, size do
        for  x = 1, size do
        	tx=size-x+1
        	if tempMatrix[x] ==nil then tempMatrix[x]={} end
            tempMatrix[x][y] = data[y][tx]
            dic[tostring(y).."_"..tostring(tx)]="block_"..tostring(x).."_"..tostring(y)
        end
    end
    tempMatrix.x=data.x
    tempMatrix.y=data.y
    tempMatrix.center=data.center
    tempMatrix.top=data.top
    -- print("rotate = \n"..tojson(tempMatrix))
    if(blockManager:check(tempMatrix,tempMatrix.x,tempMatrix.y)) then
	    blockRefs.userObject= tempMatrix
	    for k,v in pairs(blockDic) do   	v.name=dic[k]	    end
	    --refreshBlock(tempMatrix,blockRefs,true)
		blockRefs.gameObject.transform:Rotate(Vector3(0,0,90.0)) 
	end
end

local function cloneBlock(blockRefs)
	local data=blockRefs.userObject
	local count = blockRefs.refers.Count-1
	local blockDic,item,name ={},nil,""
	for i=0,count do
		item=blockRefs.refers[i]
		name = item.name
		blockDic[name]=LuaHelper.InstantiateGlobal(item,blockBoxTrans)
	end

	blockManager:fill(data,blockDic)
	blockManager:checkDelete(data)
	--print(" map state is   = \n"..tojson(blockManager:map()))
end

local function creatNewBolck()
	if currB==nil then
		ceateBlock( )
	end		
	getBlock()
	refreshBlock(currB,refs)
	local nex = ceateBlock( )	
	refreshBlock(nex,preRefs,true)
	fallSpeed = blockManager.speed
	if blockManager:check(currB,currB.x,currB.y+1)==false then
		blockManager:gameOver()
	end
end

local function getDir(position)
	-- print(string.format("center %s,%s position%s,%s",center.x,center.y,position.x,position.y))
	direction = math.atan2(center.y-position.y,center.x-position.x)/ math.pi * 180 
	if direction>145 or direction<-145 then --right
		return 1
	elseif direction >-45 and direction <45  then --left
		return 3
	elseif direction >45 and direction <135 then --down
		return 2
	elseif direction > -135 and direction< -45 then --up
		return 0
	end
	return -1
end

-------------------------------public ------------------------------------
function Block:begin()
	self.enable = true
	creatNewBolck()
	local asserts = self.luaObj.components.assetLoader.asserts

	-- local w,h =blockManager:getRect()
	local left=asserts.BlockRoot.items.Left
	local right=asserts.BlockRoot.items.Right
	left:SetActive(true)
	right:SetActive(true)
	preBlocks:SetActive(true)
	inputCenter:SetActive(true)

	refreshDebug()
	self:setScore(0,10,0)
end

function Block:endGame()
	lastFrameT = 0
	beginDelay = false
	local asserts = self.luaObj.components.assetLoader.asserts
	local left=asserts.BlockRoot.items.Left
	local right=asserts.BlockRoot.items.Right
	left:SetActive(false)
	right:SetActive(false)
	preBlocks:SetActive(false)
	inputCenter:SetActive(false)
	local function onItem(i,obj)
		LuaHelper.Destroy(obj)
	end
	LuaHelper.ForeachChild(blockBoxTrans,onItem)
	LuaHelper.ForeachChild(DebugRoot,onItem)
	blocks.localPosition =Vector3(10000,10000,10000)
end

function Block:setScore(xiaochun,mubiao,jifen)
	scorelabel.text =  string.format(scroteTipstr,mode,xiaochun,mubiao,jifen)
end

function Block:onAssetsLoad(items)
	
	blockManager = self.luaObj.components.blockManager

	local asserts = self.luaObj.components.assetLoader.asserts
	self.gameObject=asserts.BlockRoot.items.Blocks
	local root = asserts.root
	preBlocks=self.gameObject
	preBlocks:SetActive(true)
	preRefs = LuaHelper.GetComponent(preBlocks,"ReferGameObjects")
	blocks=LuaHelper.InstantiateLocal(preBlocks,root)
	refs = LuaHelper.GetComponent(blocks,"ReferGameObjects")
	blocks = blocks.transform
	startPoint=asserts.BlockRoot.items.StartPoint.transform
	local bottom=asserts.BlockRoot.items.Bottom --.transform.localPosition.y
	blockBoxTrans = asserts.BlockRoot.items.BlockBox --.transform
	preBlocks:SetActive(false)
	blocks.localPosition =Vector3(10000,10000,10000)

	scorelabel = LuaHelper.GetComponent(asserts.BlockRoot.items.ScoreLabel,"UILabel")
	cutDownLabel = LuaHelper.GetComponent(asserts.BlockRoot.items.TipsLabel,"UILabel")
	cutDownLabel.text = ""
	scorelabel.text = ""
	self:setScore(0,10,0)
	--for debug
	DebugRoot = asserts.BlockRoot.items.Debug
	DebugItem = asserts.BlockRoot.items.DebugBlock
	--
	inputCenter = asserts.BlockRoot.items.Input
	local Camera = asserts.BlockRoot.items.Camera
	local camera = LuaHelper.GetComponent(Camera,"Camera")
	local screenp=camera:WorldToScreenPoint(inputCenter.transform.position)
	-- print(string.format("screen pos = %s",screenp))
	center.x = screenp.x --Screen.width/2
	center.y = screenp.y --Screen.height/2

	--set wall
	local w,h =blockManager:getRect()
	local left=asserts.BlockRoot.items.Left
	local right=asserts.BlockRoot.items.Right
	left.transform.localPosition = Vector3(-w/2,0,20)
	right.transform.localPosition = Vector3(w/2,0,20)
	local s = bottom.transform.localScale
	bottom.transform.localPosition = Vector3(0,startPoint.localPosition.y-h-s.y/2,0)

end

local deltaSpeed = 0.8
local lastFrameT = 0
local beginDelay = false
function Block:onUpdate(time)
  	pos = blocks.localPosition

	local userObj=refs.userObject
	if (lastInputTime==0) then lastInputTime=time-0.16 end
	local dt = time-lastInputTime

	startPos = nil
	if Input.touchCount > 0  then
		local touch = Input.GetTouch(0)
		if touch and (touch.phase == TouchPhase.Began or touch.phase ==nil ) then
			startPos = touch.position
			-- print(startPos)
			-- print(dt)
		end
	elseif Input.GetMouseButtonDown(0) then
		startPos = Input.mousePosition
		-- print("mouse position")
		-- print(startPos)
	end

	if startPos~=nil and dt>=0.15 then
		local dir = getDir(startPos)
		-- print(dir)
		if dir==3 and  blockManager:check(userObj,userObj.x-1,userObj.y) then --left
			userObj.x=userObj.x-1
			lastInputTime = time
			refreshPos(refs)
			print("left ...."..userObj.x)
		elseif dir==1 and blockManager:check(userObj,userObj.x+1,userObj.y) then  --right
			userObj.x=userObj.x+1
			refreshPos(refs)
	    	lastInputTime = time
	    elseif dir == 2 then --down
	    	fallSpeed = blockManager.blockDropSpeed
	    	lastInputTime = time
	    elseif dir == 0 then --up
			rotate(refs)
			refreshPos(refs)
			lastInputTime = time
		end	
	end 
 

	if lastFrameT==0 then lastFrameT = time end
	local dtspeed = time- lastFrameT
    if dtspeed >= fallSpeed then
    	local canFall=fall(refs)
    	if canFall==false and beginDelay == true then beginDelay=false nowBlock=true 
    	elseif canFall==true and beginDelay == true then beginDelay=false
    	end
    	if canFall==false and beginDelay ==false then beginDelay = true 	end
    	lastFrameT = time
    	refreshPos(refs)
    end

    if nowBlock then
    	refreshPos(refs)
    	cloneBlock(refs)
		creatNewBolck()
		nowBlock =false
		beginDelay =false
    end
end

function Block:__tostring()
    return string.format("Block.name = %s ", self.name)
end

return Block