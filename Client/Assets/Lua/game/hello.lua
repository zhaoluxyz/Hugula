local hello = LuaItemManager:getItemObject("hello")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local ReferScript

hello.assets=
{
  Asset("Hello.u3d")
}

function hello:onAssetsLoad(items)
  local ReferScript = LuaHelper.GetComponent(self.assets[1].root,"ReferGameObjects") 

end

function hello.onErrClick( ... )
  StateManager:setCurrentState(StateManager.mainScene)
end

function hello:onBlur( ... )
    self:clear()
end

function hello:onClick(obj,arg)
	local cmd =obj.name
	if cmd == "Button" then
		print(" you are click "..cmd)
    -- StateManager:setCurrentState(StateManager.battle)
  elseif cmd =="BtnTest" then
     -- StateManager:setCurrentState(StateManager.battle)
	end
 -- print("hello onclick "..obj.name)
end
