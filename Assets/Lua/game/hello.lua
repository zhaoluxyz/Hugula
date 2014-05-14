local hello = LuaItemManager:getItemObject("hello")
local StateManager = StateManager
local delay = delay
hello.assets=
{
  Asset(SINGLE,"Hello.u3d"),
 -- Asset("BlockRoot.u3d",{"StartPanel","Blocks"})
}

function hello:onAssetsLoad(items)
  print(tojson(items))
  --self:hide()
  --delay(self.show,2,self)

  --print(self.assets[2].items["StartPanel"].name)
  print("....................... hello resource is loaded !")
end

function hello:onClick(obj,arg)
	local cmd =obj.name
	if cmd == "Button" then
		StateManager:setCurrentState(StateManager.russia)
	end
 -- print("hello onclick "..obj.name)
end
--return ItemObject