local transform = LuaItemManager:getItemObject("transform")
transform.priority=100
transform.assets=
{
  Asset("UIPublic.u3d",{"Loading"})
}

function transform:onFocus( ... )
    if self.assetsLoaded then 
        self:show()  
        self:onShowed()     
    else
        self.assetLoader:load(self.assets)  
    end
end

function transform:onClick( ... )
	return true
end

function transform:onAssetsLoad(items)
  self:show()
end
