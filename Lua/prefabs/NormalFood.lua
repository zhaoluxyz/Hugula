local function NormalFood()
	local id = Random.Range(1,9.9)
	local id = math.floor(id)

	local food = FoodGra(id)
	local foodCom = food:AddComponent("Food")
	local rigidbody = food:AddComponent("Rigidbody")
	
	local forceX = Random.Range(-100,100)
	local forceY = Random.Range(120,200)
	local forceZ = Random.Range(-100,100)
	
	rigidbody:addForce(Vector3(forceX,forceY,forceZ))

	return food
end

Prefabs:Add("NormalFood",NormalFood)