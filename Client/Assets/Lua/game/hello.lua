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

  print(ReferScript.monos[0])
    print(ReferScript.refers[0].transform)
    print(ReferScript.refers[0].transform.parent.name)

  Model.chapterCurrentIndex=500001
  Model.battleGroup={}
  Model.battleGroup.team={}

  local m1 = {player_hero_lv=1,
            player_hero_exp=0,
            player_hero_color=1,
            player_hero_attribute={
                 {dodgeValue=10.199999809265,magicDefend=9,hp=173,turnSpeed=365,speed=2.5,defend=50.5,critValue=10.199999809265,attackSpeed=1.5,maxMp=100,maxHp=173,magicDamage=25.200000762939,mp=0,damage=24.039999961853}
                 },
            player_hero_skill={{id=30023,lv=1}},
            player_hero_id=494,
            system_hero_id=200006,
            player_hero_equip={}
            }

  local m2 = {player_hero_lv=1,
            player_hero_exp=0,
            player_hero_color=1,
            player_hero_attribute={
                 {dodgeValue=10.199999809265,magicDefend=9,hp=173,turnSpeed=365,speed=2.5,defend=50.5,critValue=10.199999809265,attackSpeed=1.5,maxMp=100,maxHp=173,magicDamage=25.200000762939,mp=0,damage=24.039999961853}
                 },
            player_hero_skill={},
            player_hero_id=495,
            system_hero_id=210017,--200002,210017
            player_hero_equip={}
            }          
   table.insert(Model.battleGroup.team,m2)
   table.insert(Model.battleGroup.team,m1)
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
    StateManager:setCurrentState(StateManager.battle)
  elseif cmd =="BtnTest" then
     StateManager:setCurrentState(StateManager.battle)
	end
 -- print("hello onclick "..obj.name)
end
