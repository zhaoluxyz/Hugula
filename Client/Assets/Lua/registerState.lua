local StateManager = StateManager
local LuaItemManager = LuaItemManager
local StateBase = StateBase
StateManager:setStateTransform(LuaItemManager:getItemObject("transform"))
-- StateManager:showTransform()
--StateManager.hello=StateBase({LuaItemManager:getItemObject("hello")},"hello") --frist 
	-- StateManager.battle=StateBase({LuaItemManager:getItemObject("battleLoader")},"battle") --battle
	StateManager.battle=StateBase({LuaItemManager:getItemObject("battleLoading")},"battle") --battle
StateManager.login=StateBase({LuaItemManager:getItemObject("login")},"login") --battle
--StateManager.testbattle = StateBase({LuaItemManager:getItemObject("testBattlefield")},"testbattle")
StateManager.mainScene=StateBase({LuaItemManager:getItemObject("mainScene")},"mainScene") --mainScene
StateManager.mapScene=StateBase({LuaItemManager:getItemObject("mapScene")},"mapScene") --mapScene
StateManager.handbookScene=StateBase({LuaItemManager:getItemObject("handbookScene")},"handbookScene") --handbook

StateManager.gameloading=StateBase({LuaItemManager:getItemObject("gameLoading")},"gameloading") --battle
