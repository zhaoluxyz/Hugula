--Asset type
SINGLE = 1 
SHARE = 2
-----------------inport type-------------------------------------
LFunction=luanet.import_type("LFunction")

-----------------------global-----------------------------
GAMEOBJECT_ATLAS={} --resource cach table
UPDATECOMPONENTS={} --all update fun components
----------------------require-----------------------------
require("core.luaObject")
require("core.asset")

require("state.stateManager")
require("state.itemObject")
require("state.stateBase")

require("model.model")
require("model.mailData")
require("fun.common_fun")
require("fun.battleCache")
require("game.netProcess.processMessage")

require("brain.BrainEvent")
require("brain.ImplBrain")