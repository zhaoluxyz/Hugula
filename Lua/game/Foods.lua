FoodMan = Class(LuaObject, function(self)
    LuaObject._ctor(self,"foods") 

    self.objects = {}

    self.foodBase = self.gameObject.transform:FindChild("food").gameObject
    self.foodBase.active = false

    local sp = self.foodBase.transform:FindChild("Sprite")
    local sprite = sp:GetComponent("UISprite")
    local atlas = sprite.atlas

    local len = atlas.spriteList.Count
    for i=0,len-1 do
    	local spData = atlas.spriteList[i]
    	local spriteName = spData.name

    	local asset = Object.Instantiate(self.foodBase)
    	asset.name = spriteName
    	asset.transform.parent = self.gameObject.transform

    	local newSp = asset.transform:FindChild("Sprite"):GetComponent("UISprite")
    	newSp.spriteName = spriteName

    	asset.active = false

    	AssetMan:AddAsset(spriteName,asset)
    end

end)

-----------------------------------

function FoodMan:add(food)
	table.insert(self.objects,food)
end

function FoodMan:remove(food)
	table.removeVal(self.objects,food)
end