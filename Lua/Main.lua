print("----------------------lua main----------------------")

local function onAssetLoaded(event)
	local uCount = 10
	local vCount = 5

	for v = 0,vCount do
		for u=0,uCount do
			local p = Prefabs:New("TestPrefab")
			local pos = Vector3((u-0.5*uCount)*1.3,(v-0.5*vCount)*1.5,0)
			p.transform.localPosition = pos
		end
	end
end

Event:AddEvent(Event.ASSET_LOADED_EVENT,onAssetLoaded)
AssetMan:Load("Cube")
