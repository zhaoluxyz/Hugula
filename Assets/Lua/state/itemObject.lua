LuaItemManager={}
local LuaObject =LuaObject
local LuaItemManager = LuaItemManager
LuaItemManager.ItemObject=class(LuaObject,function(self,name) --implement luaobject
    LuaObject._ctor(self, name)
    self.assetLoader = self:addComponent("assetLoader")
    self.isLoad=false
end)

local ItemObject = LuaItemManager.ItemObject

function LuaItemManager:getItemObject(objectName)
    local obj=LuaItemManager[objectName]
    if(obj == nil) then
         print(objectName .. " is not registered ")
        return nil
    end

    if obj.m_require==nil then obj.m_require=true require(obj.m_luaPath)  end
    return LuaItemManager[objectName]
end

function LuaItemManager:registerItemObject(objectName, luaPath, instanceNow)
    assert(LuaItemManager[objectName] == nil)
    local newClass   = ItemObject(objectName)
    newClass.m_objectName  = objectName
    newClass.m_luaPath = luaPath
    LuaItemManager[objectName] = newClass
    if instanceNow then 
        newClass.m_require=true  
        require(luaPath) 
    end
end

function ItemObject:show( ... )
   local assets = self.assets
   assert(assets~=nil)
   for k,v in ipairs(assets) do
        v:show()
    end
end

function ItemObject:hide( ... )
   local assets = self.assets
   assert(assets~=nil)
   for k,v in ipairs(assets) do
        v:hide()
    end
end

function ItemObject:onFocus( ... )
    if self.asserts == nil then    
        self.assetLoader:load(self.assets)    
    else
        self:show()
    end
end

function ItemObject:onBlur( ... )
    self:hide()
end

function ItemObject:__tostring()
    return string.format("ItemObject.name = %s ", self.name)
end
