local LuaItemManager = LuaItemManager
local StateManager = StateManager
--global
LuaItemManager:registerItemObject("transform","state/stateTransform",true)
LuaItemManager:registerItemObject("alertTips","game/alertTips",true)
LuaItemManager:registerItemObject("networkInfo","game/networkInfo",true)
LuaItemManager:registerItemObject("waitingPanel","game/waitingPanel",true)
LuaItemManager:registerItemObject("guide","game/guide",true)

--itemobject
--LuaItemManager:registerItemObject("hello","game/hello")
LuaItemManager:registerItemObject("login","game/login")

	-- LuaItemManager:registerItemObject("battlefield","game/battlefield")
	-- LuaItemManager:registerItemObject("testBattlefield","game/testBattlefield")
	-- LuaItemManager:registerItemObject("battleLoader","game/battleLoader")
LuaItemManager:registerItemObject("mainScene","game/mainPanel",true)
LuaItemManager:registerItemObject("sweepPanel","game/sweepPanel",true)

LuaItemManager:registerItemObject("chapterPanel","game/chapterPanel",true)
LuaItemManager:registerItemObject("mapScene","game/mapScene",true)
LuaItemManager:registerItemObject("packPanel","game/packPanel",true)
LuaItemManager:registerItemObject("teamPanel","game/teamPanel",true)
LuaItemManager:registerItemObject("teamWeapon","game/teamWeapon",true)
LuaItemManager:registerItemObject("teamStrenth","game/teamStrenth",true)
LuaItemManager:registerItemObject("chatPanel","game/chatPanel",true)
LuaItemManager:registerItemObject("friendPanel","game/friendPanel",true)
LuaItemManager:registerItemObject("signInPanel","game/signInPanel",true)
LuaItemManager:registerItemObject("mailPanel","game/mailPanel",true)
LuaItemManager:registerItemObject("handbookScene","game/handbookScene",true)
LuaItemManager:registerItemObject("taskPanel","game/taskPanel",true)
LuaItemManager:registerItemObject("mmonsterPanel","game/mmonsterPanel",true)
LuaItemManager:registerItemObject("teamCompose","game/teamCompose",true)
LuaItemManager:registerItemObject("teamSkill","game/teamSkill",true)
LuaItemManager:registerItemObject("teamMake","game/teamMake",true)
LuaItemManager:registerItemObject("gameLoading","game/gameLoading")
LuaItemManager:registerItemObject("shopPanel","game/shopPanel",true)
LuaItemManager:registerItemObject("activityPanel","game/activityPanel",true)
LuaItemManager:registerItemObject("teamEquipInfo", "game/teamEquipInfo", true)
LuaItemManager:registerItemObject("arenaUI","game/arenaUI",true)

---------------------------战斗--------------------------------
LuaItemManager:registerItemObject("battleUI","game/battle/battleUI")
LuaItemManager:registerItemObject("battleMap","game/battle/battleMap")
LuaItemManager:registerItemObject("battleLoading","game/battle/battleLoading",true)
LuaItemManager:registerItemObject("StoryDlg","game/StoryDlg", true)
