local luaComponentMan = Class( function(self)
	self.components = {}
end)

LuaComponents = luaComponentMan()
--------------------------------------------------------
function luaComponentMan:Add(key,component)
	self.components[key] = component
end

function luaComponentMan:AddComponent(componentName,luaObject)
	local component = self.components[componentName]

	if component then
		local com = component()
		com:SetObject(luaObject)
		return com
	else
		error("! No luaComponent named by: "..componentName)
	end
end
--------------------------------------------------------
