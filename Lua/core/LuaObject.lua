
LuaObject = Class( function(self, assetName)
    self.name = assetName or EMPTY_LUAOBJECT

    if assetName then
    	self.gameObject = AssetMan:GetAsset(assetName)
    else
    	self.gameObject = GameObject()
    end

    self.gameObject.name = self.name
    
    self.transform = self.gameObject.transform
    self.components = {}

    LuaObjects:Add(self)
end)

---------------------------------public
function LuaObject:SetActive(bool)
	self.gameObject.active = bool

	for key,comList in pairs(self.components) do
		for i,com in ipairs(comList) do
			local fn = bool and com.OnEnable or com.OnDisable
			if fn then fn(com) end
		end
	end
end

function LuaObject:Clone()
	local obj = LuaObject(self.name)
	local components = table.clone(self.components)
	for name,coms in pairs(components) do
		for i,com in ipairs(coms) do
			com.luaObject = obj
			com:Start()
		end
	end

	obj.components = components
	return obj
end

function LuaObject:AddComponent(componentName)
	local com = LuaComponents:AddComponent(componentName,self)

	if TUNING.IS_DEBUG then
		local monoCom = self.gameObject:AddComponent("LuaComponent")
		monoCom.comName = componentName
	end

	if not self.components[componentName] then
		self.components[componentName] = {}
	end

	table.insert(self.components[componentName],com)
	if com.Start then com:Start() end
	return com
end

function LuaObject:GetComponent(componentName)
	if self.components[componentName] then
		local com = self.components[componentName][1]
		return com
	end
end

function LuaObject:GetComponents(componentName)
	return self.components[componentName]
end

function LuaObject:RemoveComponent(componentName)
	if self.components[componentName] then
		local com = self.components[componentName][1]
		
		if TUNING.IS_DEBUG then
			local monoComs = CViewHelper.getComponents(self.gameObject, "LuaComponent")
			local len =  monoComs.Length
			for i=0,len-1 do
				local com = monoComs:GetValue(i)
				if com.comName == componentName then
					Component.Destroy(com)
					break
				end
			end
		end

		if com and com.OnDestroy then
			com:OnDestroy()
		end
		table.remove(self.components[componentName],1)
	end
end

function LuaObject:Destroy()
	for key,comList in pairs(self.components) do
		for i,com in ipairs(comList) do
			if com.OnDestroy then com:OnDestroy() end
		end
	end

	if self.name == EMPTY_LUAOBJECT then
		GameObject.Destroy(self.gameObject)
	else
		AssetMan:ResetAsset(self.gameObject)
	end

	LuaObjects:Remove(self)
end

---------------------------------
function LuaObject:Update()
	if self.gameObject.active then
		for key,comList in pairs(self.components) do
			for i,com in ipairs(comList) do
				if com.Update then com:Update() end
			end
		end
	end
end

function LuaObject:LateUpdate()
	if self.gameObject.active then
		for key,comList in pairs(self.components) do
			for i,com in ipairs(comList) do
				if com.LateUpdate then com:LateUpdate() end
			end
		end
	end
end

function LuaObject:FixedUpdate()
	if self.gameObject.active then
		for key,comList in pairs(self.components) do
			for i,com in ipairs(comList) do
				if com.FixedUpdate then com:FixedUpdate() end
			end
		end
	end
end



