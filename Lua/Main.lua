print("----------------------lua main----------------------")

local function onAssetLoaded(event)
	local food = Prefabs:New("Food",3)
	
end

Event:AddEvent(Event.ASSET_LOADED_EVENT,onAssetLoaded)
AssetMan:Load("foods")
