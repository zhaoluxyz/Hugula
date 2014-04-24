-------------------------unity----------------------
GameObject=UnityEngine.GameObject
local Debug=UnityEngine.Debug
-----------------------init---------------------------
Request=luanet.import_type("LRequest")
CUtils=luanet.import_type("CUtils")
LuaHelper=luanet.import_type("LuaHelper")

if unpack==nil then unpack=table.unpack end

--json like [{a,1,2},{b,c,d,dw}]
function jsonTolua(json)
	local b=string.gsub(json,"%[","{")
	local e=string.gsub(b,"%]","}")
	e=string.gsub(e,"([%a]+)",'"%1"')
	e="local e="..e.." return e"

  -- print("JJ: "..json)
	local t=doString(e)[0]
	return t
end

function tojson(tbl,indent)
  assert(tal==nil)
	if not indent then indent = 0 end

	local tab=string.rep("	",indent)
	local havetable=false
	local str="{"
	local sp=""

	 for k, v in pairs(tbl) do
	    if type(v) == "table" then
	    	havetable=true
	    	if(indenct==0) then
	    		str=str..sp.."\r\n	"..tostring(k)..":"..tojson(v,indent+1)
	    	else
	    		str=str..sp.."\r\n"..tab..tostring(k)..":"..tojson(v,indent+1)
	   		end
	    else
	    	str=str..sp..tostring(k)..":"..tostring(v)
	    end
		sp=","
	 end

	if(havetable) then	   	str=str.."\r\n"..tab.."}"	else	   	str=str.."}"	end

   return str
end


function getAngle(posFrom,posTo)  
    local tmpx=posTo.x - posFrom.x
    local tmpy=posTo.y - posFrom.y
    local angle= math.atan2(tmpy,tmpx)*(180/math.pi)
    return angle
end

function printTable(tbl)	print(tojson(tbl)) end

function split(inputstr,sep)
   if sep == nil then   sep = "%s"      end
   local t={} 
   local i=1
      for str in string.gmatch(inputstr, "([^"..sep.."]+)") do
              t[i] = str
              i = i + 1
      end
    return t
end

function class(base, _ctor)
    local c = {}    -- a new class instance
    if not _ctor and type(base) == 'function' then
        _ctor = base
        base = nil
    elseif type(base) == 'table' then
    -- our new class is a shallow copy of the base class!
        for i,v in pairs(base) do
            c[i] = v
        end
        c._base = base
    end
    
    -- the class will be the metatable for all its objects,
    -- and they will look up their methods in it.
    c.__index = c

    -- expose a constructor which can be called by <classname>(<args>)
    local mt = {}
    
    mt.__call = function(class_tbl, ...)
        local obj = {}
        setmetatable(obj,c)
  
        if _ctor then
            _ctor(obj,...)
        end
        return obj
    end    
        
    c._ctor = _ctor
    c.is_a = function(self, klass)
        local m = getmetatable(self)
        while m do 
            if m == klass then return true end
            m = m._base
        end
        return false
    end
    setmetatable(c, mt)
    return c
end

function lugGC()
  local c=collectgarbage("count")
  print("begin gc ="..tostring(c).." ")
  collectgarbage("collect")
  c=collectgarbage("count")
  print(" gc end ="..tostring(c).." ")
end

-- function print(msg)
--   Debug.Log(" NLua : "..tostring(msg))
-- end
