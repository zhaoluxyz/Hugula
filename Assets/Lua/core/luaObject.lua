local components = {}
UPDATECOMPONENTS={}

local function loadComponent(name)
    if components[name] == nil then
        components[name] = require("components/"..name)
    end
    return components[name]
end

local function getComponentName(path)
   local _,_,name= string.find(path,"[%.,%/]*(%a+)$")
   return name
end

local function addGlobalUpdateComp(fn)
    table.insert(UPDATECOMPONENTS,fn)
end

local function removeGlobalUpdateComp(fn)
    local len=#UPDATECOMPONENTS
    local delIdx
    for i=1,len do
        if UPDATECOMPONENTS[i]==fn then
            delIdx =i
            break
        end
    end

    if delIdx~=nil then table.remove(UPDATECOMPONENTS,delIdx) end
end

LuaObject=class(function(self,name) 
    self.name=name or "LuaObject"
	self.components={}
	self.updatecomponents = {}
    self.active=true
end)

function LuaObject:addComponent(arg)
    local name = getComponentName(arg)
    local cmp = nil 
	if self.components[name] then
        print("component "..name.." already exists!")
        return self.components[name]
    end

    cmp = loadComponent(arg)
    assert(cmp, "component ".. name .. " does not exist!")

    local loadedcmp = cmp(self)
    self.components[name] = loadedcmp
    loadedcmp.name = name

    if loadedcmp.start then loadedcmp:start() end

    if loadedcmp.onUpdate then
    	if not self.updatecomponents then self.updatecomponents={} end
    	self.updatecomponents[name]=loadedcmp
        addGlobalUpdateComp(loadedcmp)
    end

    return loadedcmp
 end

 function LuaObject:removeComponent(name)
	local cmp=self.components[name]
	if cmp then removeGlobalUpdateComp(cmd)
    elseif cmp and cmp.remove then cmp:remove() 
    end 
    self.components[name]=nil
    self.updatecomponents[name]=nil
 end

 function LuaObject:setActive(bl)
    self.active=bl
    -- local assets = self.component.assets
    -- if assets then
    --     if bl==true then assets:show()
    --     else  assets:hide()
    --     end
    -- end
 end

 -- function LuaObject:sendMessage(compName,method,...)
 --    local cmp=self.components[compName]
 --    if cmp then
 --       if cmp[method]  then  cmp[method](v, table.unpack({...})) end
 --    end
 -- end

 function LuaObject:sendMessage(method,...)
    local cmps=self.components
    for k,v in pairs(cmps) do
       if v[method]  then  v[method](v,table.unpack({...})) end
    end
 end

function LuaObject:__tostring()
    return string.format("luaObject.name = %s ", self.name)
end