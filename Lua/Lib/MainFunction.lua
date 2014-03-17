--------------------------------------------------table
function table.len(tab)
	local len = 0
	for v in pairs(tab) do
		len = len+1
	end
	return len
end

function table.indexof(tab,obj)
	local ra={}
	for i,v in ipairs(tab) do
		ra[v]=i
	end

	local id = ra[obj]
	return id
end

function table.removeVal(tab,val)
	if table.indexof(tab,val) then
		table.remove(tab,table.indexof(tab,val))
	end
end

function table.clone(object)
	local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end  
       
        local new_table = {}
        lookup_table[object] = new_table

        for index, value in pairs(object) do
            new_table[_copy(index)] = _copy(value)
        end 
         
        return setmetatable(new_table, getmetatable(object))
    end  
    return _copy(object)
end

--------------------------------------------------string
function string.split(szFullString, szSeparator)
	local nFindStartIndex = 1
	local nSplitIndex = 1
	
	local nSplitArray = {}
	
	while true do
	   local nFindLastIndex = string.find(szFullString, szSeparator, nFindStartIndex)
	
	   if not nFindLastIndex then
		nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, string.len(szFullString))
		break
	   end
	
	   nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, nFindLastIndex - 1)
	   nFindStartIndex = nFindLastIndex + string.len(szSeparator)
	   nSplitIndex = nSplitIndex + 1
	end
	
	return nSplitArray
end

function string.setNumberPrefix(numString,prefix)
	local s = ""
	for i=1,#(numString) do
		s = s..prefix..string.sub(numString,i,i)
	end

	return s
end

function string.fitNum(num)
	local str = "00"
	if 0+num>9 then str = "0" end 
	if 0+num>99 then str="" end
	return (str..num)
end

--------------------------------------------------mainFunctions
function GetAngle(posFrom,posTo)  
    local tmpx=posTo.x - posFrom.x
    local tmpy=posTo.y - posFrom.y
    local angle= math.atan2(tmpy,tmpx)*(180/math.pi)
    return angle
end

function ResetTM(gameObject)
    gameObject.transform.localPosition = Vector3(0,0,0)
    gameObject.transform.localEulerAngles = Vector3(0,0,0)
    gameObject.transform.localScale = Vector3(1,1,1)
    return gameObject.transform
end

function LuaGC()
  	local c=collectgarbage("count")
  	print("begin gc ="..tostring(c).." ")
  	collectgarbage("collect")
  	c=collectgarbage("count")
  	print(" gc end ="..tostring(c).." ")
end





