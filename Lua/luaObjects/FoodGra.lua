FoodGra = Class(LuaObject, function(self,id)
    LuaObject._ctor(self) 

    self.name = "food_"..string.fitNum(id)

    local gameObject = AssetMan:GetAsset(self.name)
    gameObject.transform.parent = Foods.gameObject.transform
    self:SetGameObject(gameObject)
end)

function FoodGra:gotoMouth(mouth,delay,time)
	local function hideFood()
		self:RemoveComponent("Rigidbody")
	end

	local function startMove()
		Tweener.addTweener(self.gameObject,"MoveTo",{position=mouth.gameObject.transform.position,time=time,easetype="linear",OnComplete=hideFood})
	end

	DelayDo:Add(startMove,delay)
end

function FoodGra:Destroy()
	for key,comList in pairs(self.components) do
		for i,com in ipairs(comList) do
			self:RemoveComponent(com.name)
			com = nil
		end
	end
	self.components = {}

	if self.gameObject then
		self.gameObject.active = false
		ResetTM(self.gameObject)
		self.gameObject = nil
	end

	LuaObjects:Remove(self)
end



