LuaComponent = Class( function(self)
end)

function LuaComponent:SetObject(luaObject)
	self.luaObject = luaObject
	self.gameObject = self.luaObject.gameObject
end

function LuaComponent:AddEvent(eventName, callback)
	Event:AddEvent(eventName, callback, self)
end

function LuaComponent:RemoveEvent(eventName, callback)
	Event:RemoveEvent(eventName, callback, self)
end

function LuaComponent:DispatchEvent(eventName,value)
	Event:DispatchEvent(eventName, value, self)
end
-----------------------------------surport callbacks
--function LuaComponent:Start()end
--function LuaComponent:OnDestroy()end
--function LuaComponent:OnEnable()end (called by LuaObject:SetActive)
--function LuaComponent:OnDisable()end (called by LuaObject:SetActive)
-----------------------------------

