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
local blockBoxTrans = nil
local lastTime = 1 --上一帧时间
local lastInputTime = 1 --上次点击时间
local nextGridPosY=0 --下个格子坐标
local nowBlock = false
--for touch
local touchClickThreshold = 0.02
local startPos,directionChosen,direction
local beginTime,clickDt=0,0

local Block = class(function(self,luaObj )
	self.luaObj=luaObj
	self.enable=false
	RunTime =Application.platform
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
	blockRefs.userObject=data
	if pos==nil then 
		blockRefs.gameObject.transform.localRotation = Quaternion.identity;
		blockRefs.userObject.x =math.floor(blockManager.width/2)+data.top[1]
		blockRefs.userObject.y = data.top[2]
		local p2= (row % 2==0)
		local p=startPoint.localPosition
 		if p2==false then p.x=p.x-tile/2 end

 		p.y = p.y -row*tile/2 
		blockRefs.gameObject.transform.localPosition = p
		startPointY= p.y
		nextGridPosY = startPointY - blockManager.tile
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
--下落时候调用
local function fall(blockRefs,dtframe)
	
	local userObject=blockRefs.userObject

		local moves = fallSpeed*Time.deltaTime
		local p = blocks.localPosition

		--print("fall y = "..tostring(p.y) )
		p.y = p.y-moves
		--print("move y = "..tostring(pos.y) )

		if p.y<=nextGridPosY then --到达临界点
			p.y = nextGridPosY
			userObject.y=userObject.y+1
			local y=userObject.y+1
			print(string.format(" firstx=%s ,y=%s next y = %s",userObject.x,userObject.y,y))
			if blockManager:check(userObject,userObject.x,y)==true then --能下移动
				nextGridPosY = startPointY-userObject.y*blockManager.tile
				-- blocks.localPosition = p
				-- return true
			else
				blocks.localPosition = p
				print(tojson(userObject))
				print(tojson(blockManager:map()))
				 print(string.format(" Y =%s x=%scould not done!",userObject.y,userObject.x))
				return false
			end
		end
		blocks.localPosition = p
		return true
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
	local len=#data
	-- print(tojson(data))
	local normalY=data.y*blockManager.tile
	local pos=blockRefs.gameObject.transform.localPosition
	-- print(string.format("y=%s ,normalY=%s",pos.y,normalY))
	blockRefs.gameObject.transform.localPosition=pos
	local count = blockRefs.refers.Count-1
	local blockDic,item,name ={},nil,""
	for i=0,count do
		item=blockRefs.refers[i]
		name = item.name
		blockDic[name]=LuaHelper.InstantiateGlobal(item,blockBoxTrans)
	end

	blockManager:fill(data,blockDic)
	blockManager:checkDelete(data)
end

local function creatNewBolck()
	if currB==nil then
		ceateBlock( )
	end		
	getBlock()
	refreshBlock(currB,refs)
	local nex = ceateBlock( )	
	refreshBlock(nex,preRefs,true)
	fallSpeed =blockManager.speed
	if blockManager:check(currB,currB.x,currB.y)==false then
		blockManager:gameOver()
	end
end

-------------------------------public ------------------------------------
function Block:begin()
	self.enable = true
	creatNewBolck()
	local asserts = self.luaObj.components.assetLoader.asserts

	-- local w,h =blockManager:getRect()
	local left=asserts.BlockRoot.Left
	local right=asserts.BlockRoot.Right
	left:SetActive(true)
	right:SetActive(true)
	preBlocks:SetActive(true)
	-- left.transform.localPosition = Vector3(-w/2,0,20)
	-- right.transform.localPosition = Vector3(w/2,0,20)
	-- local s = bottom.transform.localScale
	-- bottom.transform.localPosition = Vector3(0,startPoint.localPosition.y-h-s.y/2,0)
end

function Block:endGame()

	local asserts = self.luaObj.components.assetLoader.asserts
	-- local w,h =blockManager:getRect()
	local left=asserts.BlockRoot.Left
	local right=asserts.BlockRoot.Right
	left:SetActive(false)
	right:SetActive(false)
	preBlocks:SetActive(false)
	
	local function onItem(i,obj)
		LuaHelper.Destroy(obj)
	end
	LuaHelper.ForeachChild(blockBoxTrans,onItem)
	blocks.localPosition =Vector3(10000,10000,10000)
end

function Block:onAssetsLoad(items)
	
	blockManager = self.luaObj.components.blockManager

	local asserts = self.luaObj.components.assetLoader.asserts
	self.gameObject=asserts.BlockRoot.Blocks
	local root = asserts.BlockRoot_root
	preBlocks=self.gameObject
	preBlocks:SetActive(true)
	preRefs = LuaHelper.GetComponent(preBlocks,"ReferGameObjects")
	blocks=LuaHelper.InstantiateLocal(preBlocks,root)
	refs = LuaHelper.GetComponent(blocks,"ReferGameObjects")
	blocks = blocks.transform
	startPoint=asserts.BlockRoot.StartPoint.transform
	local bottom=asserts.BlockRoot.Bottom --.transform.localPosition.y
	blockBoxTrans = asserts.BlockRoot.BlockBox --.transform
	preBlocks:SetActive(false)
	blocks.localPosition =Vector3(10000,10000,10000)
	--print(blocks)
	--blocks:SetActive(false)
	--creatNewBolck()
	--set wall
	local w,h =blockManager:getRect()
	local left=asserts.BlockRoot.Left
	local right=asserts.BlockRoot.Right
	left.transform.localPosition = Vector3(-w/2,0,20)
	right.transform.localPosition = Vector3(w/2,0,20)
	local s = bottom.transform.localScale
	bottom.transform.localPosition = Vector3(0,startPoint.localPosition.y-h-s.y/2,0)
	--s.x=w
	--startPoint.localScale=s
end

function Block:onUpdate(time)
	  	pos = blocks.localPosition

		local userObj=refs.userObject
		local dt = time-lastInputTime
		if (lastInputTime==0) then lastInputTime=time-0.03 end
		local dtframe = time-lastTime
	if RunTime==RuntimePlatform.WindowsEditor or RunTime==RuntimePlatform.OSXEditor or 
		RunTime == RuntimePlatform.WindowsPlayer or RunTime == RuntimePlatform.OSXPlayer then

	  	if dt>0.15 and Input.GetKey(KeyCode.LeftArrow)==true and blockManager:check(userObj,userObj.x-1,userObj.y+1) then --left
			pos.x = pos.x-blockManager.tile
			userObj.x=userObj.x-1
			lastInputTime=time
			blocks.localPosition = pos
			--print("l..........l...left y = "..tostring(pos.y) )
			-- print(tojson(userObj))
			-- print(tojson(blockManager:map()))
	    elseif  dt>0.15 and Input.GetKey(KeyCode.RightArrow)==true and  blockManager:check(userObj,userObj.x+1,userObj.y+1) then
	    	--local size = blockManager.width --#userObj-1
			pos.x = pos.x+blockManager.tile
			userObj.x=userObj.x+1
	    	lastInputTime=time
	    	blocks.localPosition = pos
	    end

	    if  Input.GetKeyDown(KeyCode.UpArrow) then
	    	rotate(refs)
		end

		if Input.GetKey(KeyCode.DownArrow) then
	        fallSpeed = blockManager.blockDropSpeed
	    end
	else

		if Input.touchCount > 0  then
		local touch = Input.GetTouch(0)
		if touch then
				if touch.phase ==TouchPhase.Began then
						startPos = touch.position;
						beginTime=time
				elseif touch.phase == TouchPhase.Moved then
					
				elseif	touch.phase == TouchPhase.Ended then
						clickDt=time - beginTime
						if clickDt>touchClickThreshold then --and startPos==touch.position then
							direction = math.atan2(startPos.y-touch.position.y,startPos.x-touch.position.x)/ math.pi * 180 
							print("direction"..tostring(direction))
							if direction>160 or direction<-160 and blockManager:check(userObj,userObj.x+1,userObj.y+1) then  --right
								userObj.x=userObj.x+1
								pos.x = pos.x+blockManager.tile
						    	blocks.localPosition = pos
						    	print(string.format("right userObj.x =%s pos =%s",userObj.x,pos))
							elseif direction >-20 and direction <20 and  blockManager:check(userObj,userObj.x-1,userObj.y+1) then --left
								userObj.x=userObj.x-1
								pos.x = pos.x-blockManager.tile
								blocks.localPosition = pos
								print(string.format("left userObj.x =%s pos =%s",userObj.x,pos))
							elseif direction >70 and direction <110 then --down
								fallSpeed = blockManager.blockDropSpeed
							elseif direction > -110 and direction< -70 then --up
								rotate(refs)
							end
							--self.luaObj:sendMessage("onTouch",direction,touch.position)
						end
				end
			end
		end --end touch
	end	 

    if nowBlock then
    	cloneBlock(refs)
		creatNewBolck()
		nowBlock =false
    end

   	 if fall(refs,dtframe)==false then
		nowBlock=true
    end

end

function Block:__tostring()
    return string.format("Block.name = %s ", self.name)
end

return Block