local Input=UnityEngine.Input
local Vector3=UnityEngine.Vector3
local KeyCode=UnityEngine.KeyCode
local LuaHelper=LuaHelper
local minRowNumber=1
local block7={ --center for rota offset
{{1,1},{1,1},center={0.5,0.5},top={0,1}}, --
{{1,1,0},{0,1,0},{0,1,0},center={1,1},top={-1,1}},
{{0,1,1},{0,1,0},{0,1,0},center={1,1},top={-1,1}},
{{1,0,0},{1,1,0},{0,1,0},center={1,1},top={-1,1}},
{{0,0,1},{0,1,1},{0,1,0},center={1,1},top={-1,1}},
{{0,1,0},{1,1,1},{0,0,0},center={1,1},top={-1,1}},
{{0,1,0,0},{0,1,0,0},{0,1,0,0},{0,1,0,0},center={1.5,1.5},top={-1,1}}
}

local map = {}
local BlockManager = class(function(self,luaObj )
	self.luaObj = luaObj
	self.enable = false
	self.width = 10
	self.height = 18
	self.score=0
end)
----------------------------private---------------------


----------------------------class--------------------------
function BlockManager:start()
	self.tile = 30
	self.blockDropSpeed = 1000
	self.speed= 50
	minRowNumber = self.height
	for y=1,self.height+2 do
		for x=1,self.width do
			if(map[y]==nil) then map[y] = {} end
			if y <= self.height then map[y][x]=false
			else map[y][x]=true end
		end
	end
	self.score = 0
end

function BlockManager:gameOver()
	self.luaObj.components.block.enable = false
	print("gameOver ")
	local uiBlock = self.luaObj.components.uiBlock
	uiBlock:setState(3)
	uiBlock:setScore(self.score)
	self:start()
end

function BlockManager:gameStart()
	-- body
end

function BlockManager:getBlocksData()
	return block7
end

--get width and height
function BlockManager:getRect()
	return self.width*self.tile,self.height*self.tile
end

function BlockManager:checkDelete(data)
	local size = #data
	local sizeY,sizeX= size+data.y,size+data.x
	local y,x,row,item,rowlen,delelen
	local dels
	local delrow,delRowCount={},0

	for y=data.y,sizeY do
		if y <= self.height then
			row = map[y]
			rowlen=#row
			dels = {}
			for i=1,rowlen do 
				item =row[i] 
				if type(item) == "userdata" then
					table.insert(dels,item)
				else 
					dels = {}
					break
				end
			end

			delelen=#dels

			if delelen>=rowlen then
				delRowCount=delRowCount+1 
				for j=1,rowlen do 
					delrow[tostring(y)]=y
					item =dels[j] LuaHelper.Destroy(item) 
					row[j]=false
				end
			end
		end
	end

	if minRowNumber >= data.y then minRowNumber = data.y end

	--move map data
	if delRowCount ==0 then return end
	self.score=self.score+delRowCount*10
	local moveDown,p,sourRow,mapy,findy,findcopy= 0,nil,nil,nil,1,false
	for y=sizeY,data.y,-1 do
		findcopy = false
		-- if(delrow[tostring(y)]) then print(delrow[tostring(y)]) end
		if y<=self.height then

			if y == delrow[tostring(y)] then  --if deleted
				for findy=y-1,data.y,-1 do
					if findy ~=delrow[tostring(findy)] then
						-- print("move "..tostring(findy).." to "..tostring(y))
						findcopy = true
						break
					end
				end

				if findcopy then
					row = map[y]
					rowlen=#row
					sourRow = map[findy]
					for i=1,rowlen do
						item =row[i]
						sourRow[i]=item
						if type(item) == "userdata" then
							p=item.transform.localPosition
							p.y=p.y-moveDown*self.tile
							item.transform.localPosition = p
						end
						row[i]=false
					end
				end
			end
		end
	end

	-- print("map1 = \n"..tojson(map))

	-- local maplen=self.height
	-- for y=data.y,minRowNumber,-1 do
	-- 	row = map[y]
	-- 	rowlen=#row
	-- 	mapy = y+delRowCount
	-- 	sourRow = map[mapy]
	-- 	print(string.format("all  row = %s ,sourRow = %s",y,y+delRowCount))
	-- 	for i=1,rowlen do
	-- 		item =row[i]
	-- 		sourRow[i]=item
	-- 		if type(item) == "userdata" then
	-- 			p=item.transform.localPosition
	-- 			p.y=p.y-delRowCount*self.tile
	-- 			item.transform.localPosition = p
	-- 		end
	-- 		row[i]=false
	-- 	end
	-- end

	-- 	print("map3 = \n"..tojson(map))
end

-- block can rota
function BlockManager:fill(data,blockDic)
	 local size = #data
	 local mx,my,key = 1,1,""
	 local row,datarow = nil,nil
	 for y=1,size do
	 	my=math.floor(data.y+y-1)
	 	row=map[my]
	 	datarow=data[y]
	 	for x=1,size do
	 		mx=math.floor(data.x+x-1)
	 		if row and datarow[x]==1 then-- 列超出界限
	 			key = "block_"..tostring(y).."_"..tostring(x) --string.format("block_%s_%s",y,x)
	 			local item  = blockDic[key]
	 			row[mx] = item
	 			if item ==nil then 
	 				print(tojson(blockDic))
	 				print(key.."is not exist !")
	 				print(tojson(data))
	 				print(tojson(row))
	 			end
	 			key = "map_"..tostring(my).."_"..tostring(mx)--string.format("map_%d_%d",my,mx)
	 			item.name = key
	 		end
	 	end
	 end
end

--check if move
function BlockManager:check(data,posx,posy)
	 local size = #data
	 local mx,my = 1,1
	 local row,datarow
	 for y=1,size do
	 	my=math.floor(posy+y-1)
	 	row=map[my]
	 	datarow=data[y]
	 	for x=1,size do
	 		mx=math.floor(posx+x-1)
	 		if row == nil then-- 列超出界限
	 			if  datarow[x]==1 then 	return false end
 			elseif row[mx] == nil and datarow[x]==1 then  --行超出界限不能有方块
 				return false
 			elseif datarow[x]==1 and row[mx]~=false  then  --界限内有方块的地方不能有其他东西
 				return false  
	 		end
	 	end
	 end
	 return true
end

-- function BlockManager:onAssetsLoad(items)
-- 	self.enable=true
-- 	-- self.gameObject=self.luaObj.components.assetLoader.asserts.BlockRoot.Block
-- 	-- self.gameObject:SetActive(true)
-- 	-- transform=self.gameObject.transform
-- end

-- function BlockManager:onUpdate( ... )
-- 	--transform.position 
-- end

function BlockManager:__tostring()
    return string.format("BlockManager.name = %s ", self.name)
end

return BlockManager