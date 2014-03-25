local function Food(id)
	local food = FoodGra(id)
	local foodCom = food:AddComponent("Food")
	local rigidbody = food:AddComponent("Rigidbody")
	
	rigidbody:addForce(Vector3(100,500,0))	
	return food
end

Prefabs:Add("Food",Food)