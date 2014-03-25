FoodGra = Class(LuaObject, function(self,id)
    LuaObject._ctor(self) 

    self.id = id

    local foodHolder = AssetMan:GetAssetSource("foods")
    foodHolder.active = true

    local foodBase = foodHolder.transform:FindChild("food").gameObject
    foodBase.active = false

    local food = Object.Instantiate(foodBase) 
    food.active = true
    food.transform.parent = foodHolder.transform

    local sprite = food.transform:FindChild("Sprite")
    local name = "food_"..string.fitNum(id)
    sprite:GetComponent("UISprite").spriteName = name

    local lookAtMono = sprite:GetComponent("LookAt")

    self:SetGameObject(food)
    self.gameObject.name = name
   
end)



