local StateManager = StateManager
local LuaItemManager = LuaItemManager
local StateBase = StateBase
StateManager:setStateTransform(LuaItemManager:getItemObject("transform"))

StateManager.main=StateBase({LuaItemManager:getItemObject("hello")})
StateManager.russia=StateBase({LuaItemManager:getItemObject("russia")})