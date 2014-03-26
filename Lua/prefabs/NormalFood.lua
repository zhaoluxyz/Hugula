local function NormalFood()
	local id = Random.Range(1,9.9)
	local id = math.floor(id)

	local food = FoodGra(id)
	local foodCom = food:AddComponent("Food")
	local rigidbody = food:AddComponent("Rigidbody")
	
	local forceX = Random.Range(-20,20)
	local forceY = Random.Range(30,50)
	local forceZ = Random.Range(-20,20)

	local posX = Random.Range(-1,1)
	local posY = Random.Range(2.5,3.5)
	local posZ = Random.Range(-1,1)

	food.transform.position = Vector3(posX,posY,posZ)
	rigidbody:addForce(Vector3(forceX,forceY,forceZ))

	return food
end

Prefabs:Add("NormalFood",NormalFood)