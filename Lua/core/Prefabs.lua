local prefabMan = Class( function(self)
	self.prefabs = {}
end)
Prefabs = prefabMan()
-------------------------------------------
function prefabMan:Add(key,prefab)
	self.prefabs[key] = prefab
end

function prefabMan:New(key,value)
	return self.prefabs[key](value)
end
-------------------------------------------
