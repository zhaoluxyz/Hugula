
local assetMan = Class( function(self)
	self.assetRoot = GameObject()
	self.assetRoot.name = "AssetRoot"
	self.loader = self.assetRoot:AddComponent("AssetLoader")
	self.assetsBase = {}
	self.assets = {}
end)
-----------------------------------
AssetMan = assetMan()

Event.ASSET_LOADED_EVENT = "assetLoadedEvent"
-----------------------------------
local function getAssetURL(asset)
	local path = asset.defPath
	if asset.lowPath and TUNING.ASSET_QUALITY == ASSET_QUALITY.LOW then
		path = asset.lowPath
	end
	asset.url = CUtils.getFileFullPath(CUtils.getAssetPath(path))
end

local function onAssetLoaded(www,key)
	if not AssetMan.assetsBase[key] then
		AssetMan.assets[key] = {}
		AssetMan.assetsBase[key] = Object.Instantiate(www.assetBundle.mainAsset)
		AssetMan.assetsBase[key].name = key
		AssetMan.assetsBase[key].transform.parent = AssetMan.assetRoot.transform
		AssetMan.assetsBase[key].active = false
		AssetMan.loader:clear(www)
	end

	local val = {asset = AssetMan.assetsBase[key],name = key}
	Event:DispatchEvent(Event.ASSET_LOADED_EVENT,val)
end
-----------------------------------public function
function assetMan:Load(assetName)
	local asset = AssetList[assetName]
	if asset then
		getAssetURL(asset)
		self.loader:load(asset.url,onAssetLoaded,assetName)
	else
		error("! AssetList has no keyValue: "..assetName)
	end
end

function assetMan:GetAsset(assetName)
	local assetBase = self.assetsBase[assetName]
	if assetBase then
		local newAsset = nil
		for i,asset in ipairs(self.assets[assetName]) do
			if not asset.active then
				asset.active = true
				asset.transform.parent = self.assetRoot.transform
				ResetTM(asset)
				newAsset = asset
				break
			end
		end

		if not newAsset then
			newAsset = Object.Instantiate(assetBase)
			newAsset.active = true
			newAsset.name = assetName
			newAsset.transform.parent = self.assetRoot.transform
			ResetTM(newAsset)

			table.insert(self.assets[assetName],newAsset)
		end

		return newAsset
	else
		error("! asset:"..assetName.." has not loaded yet")
	end
end

function assetMan:GetAssetSource(assetName)
	return self.assetsBase[assetName]
end

function assetMan:ResetAsset(asset)
	asset.active = false
	asset.transform.parent = self.assetRoot.transform
	ResetTM(asset)
end

