
Level = Class( function(self, id)
    self.id = id 
	self.setting = LevelSetting[id]
	self.presentNormalFood = self.setting.normalFoods
end)

-----------------------------------------------
local function onAssetLoaded(self,event)
	if event.data.name == "foods" then
		
		Foods = FoodMan()
		AssetMan:Load("hugula")

	elseif event.data.name == "hugula" then
		Event:RevomeEvent(Event.ASSET_LOADED_EVENT,onAssetLoaded,self)

		local hugula = Prefabs:New("Hugula")

		self:start()
	end
end

function Level:init()
	Event:AddEvent(Event.ASSET_LOADED_EVENT,onAssetLoaded,self)

	if not Foods then
		AssetMan:Load("foods")
	else
		AssetMan:Load("hugula")
	end
end

function Level:start()
	local function newNormalFood()
		local food = Prefabs:New("NormalFood")
		self.presentNormalFood = self.presentNormalFood-1

		local timeSpace = self.setting.time/self.setting.normalFoods
		if self.presentNormalFood>0 then
			DelayDo:Add(self.start,timeSpace+Random.Range(-0.5,0.5),self)
		else
			self:finish()
		end
	end

	newNormalFood()
end

function Level:pause()
	print("PauseLevel "..self.id)
end

function Level:resume()
	print("ResumeLevel "..self.id)
end

function Level:finish()
	print("FinishLevel "..self.id)
end







