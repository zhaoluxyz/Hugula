---------------------------send to mono functions
local function Awake()
	for i,obj in ipairs(LuaObjects.objects) do
		if obj.Awake then
			obj:Awake()
		end
	end
end

local function Start()
	for i,obj in ipairs(LuaObjects.objects) do
		if obj.Start then
			obj:Start()
		end
	end
end

local function Update()
	for i,obj in ipairs(LuaObjects.objects) do
		if obj.Update then
			obj:Update()
		end
	end
end

local function LateUpdate()
	for i,obj in ipairs(LuaObjects.objects) do
		if obj.LateUpdate then
			obj:LateUpdate()
		end
	end
end

local function FixedUpdate()
	for i,obj in ipairs(LuaObjects.objects) do
		if obj.FixedUpdate then
			obj:FixedUpdate()
		end
	end
end
------------------------------------------------------
local luaObjectMan = Class( function(self)
	self.gameObject = GameObject()
	self.gameObject.name = "LuaObjects"
	self.objects = {}

	local objectManMono = self.gameObject:AddComponent("LuaObjectMan")
	objectManMono.AwakeFn = Awake
	objectManMono.StartFn = Start
	objectManMono.UpdateFn = Update
	objectManMono.LateUpdateFn = LateUpdate
	objectManMono.FixedUpdateFn = FixedUpdate
end)

-----------------------------------
function luaObjectMan:Add(luaObj)
	luaObj.transform.parent = self.gameObject.transform	 
	table.insert(self.objects,luaObj)
end

function luaObjectMan:Remove(luaObj)
	table.removeVal(self.objects,luaObj)
	luaObj = nil
end

LuaObjects = luaObjectMan()