local requires ={
	"const/assets",
	"const/constants",
	"const/tuning",
	"const/levelSetting",
	
	"Lib/Predefined",
	"Lib/MainFunction",
	
	"core/Class",
	"core/Event",
	"core/AssetMan",
	"core/LuaObjects",
	"core/LuaObject",
	"core/LuaComponent",
	"core/LuaComponents",
	"core/Prefabs",
	"core/Input",
	"core/DelayDo",

	"luaObjects/TestLuaObject",
	"luaObjects/HugulaGra",
	"luaObjects/FoodGra",

	"components/TestComponent",
	"components/Collider",
	"components/EdibleEffect",
	"components/Food",
	"components/MakeBigger",
	"components/MakeBlind",
	"components/MakeEscaper",
	"components/MakeFrozenTime",
	"components/MakeHiccup",
	"components/MakeLongTongue",
	"components/MakeUbtuse",
	"components/MakeUnStoppable",
	"components/Mouth",
	"components/Movement",
	"components/MoveStraight",
	"components/Rigidbody",

	"prefabs/TestPrefab",
	"prefabs/Hugula",
	"prefabs/NormalFood",

	"game/Level",
	"game/Foods",
}

for i,f in ipairs(requires) do
	print("require "..f)
	require(f)
end
