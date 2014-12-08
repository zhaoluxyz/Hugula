local BattleLoader = LuaItemManager:getItemObject("battleLoader")
PrefabPool = luanet.PrefabPool.instance
Rigidbody = UnityEngine.Rigidbody
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue
local make_array = make_array
-- local BattleCache = BattleCache
local Model = Model
local PrefabPool = PrefabPool
-----------------------------------------------------------------------------
local SpellTargetHelper=luanet.SpellTargetHelper
local SkillData= luanet.SkillData
local BuffData=luanet.BuffData
local BuffHelper = luanet.BuffHelper
local BuffEffect = luanet.BuffEffect
--UI资源
BattleLoader.priority=1
BattleLoader.assets=
{
    Asset("BattleUI.u3d",{"Loading"})
}

BattleLoader.toTest =false
local battlefield = LuaItemManager:getItemObject("battlefield")
local testBattlefield = LuaItemManager:getItemObject("testBattlefield")
local chapterPanel = LuaItemManager:getItemObject("chapterPanel")
------------------private-----------------

local function allComplete( ... )
  	Loader:setOnAllCompelteFn(nil)
    StateManager:setLoading(false)
    if(BattleLoader.toTest) then
      testBattlefield:addToState()
    else
      battlefield:addToState()      
      print(string.format("BattleLoader.allComplete %s ",StateManager:getCurrentState()))
    end
end

local function onModelComplete(req)
  local key = req:get_key()
  if req:get_data() then
    LuaHelper.RefreshShader(req.data)
    local clone = LuaHelper.Instantiate(req.data.assetBundle.mainAsset)
    clone.name=key
    clone.active=false
    PrefabPool:Add(key,clone)
    disposeWWW(req.data)
  end
end 


local function addToList(key,reqs)

  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      reqs[key]={CUtils.GetAssetFullPath(key..".u3d"),onModelComplete}
  end
end

local function loadRes( ... )
  local reqs={}
  ------------------------------------------resource--------------------------------
  -- local data = {{id=1,uid=300003},{id=2,uid=300004},{id=3,uid=300009},{id=4,uid=300006},{id=5,uid=300009}}--{{id=3,uid=1}}--{{id=1,uid=3}} --{{id=1,uid=3}}--
  
  
  printTable( Model.battleGroup)
  local data = Model.battleGroup.team
  -- Model.battleGroup[1] = {}
  -- local CardList=Model.battleGroup[1]
  for k,v in ipairs(data) do
    v.info=Model.getUnit(v.system_hero_id) --player_hero_attribute
    addToList(v.info.model,reqs)
    addToList(v.info.model1,reqs)
  end

  Model.enemyGroup=Model.getChapterDataByid(Model.chapterCurrentIndex).monster
  data = Model.enemyGroup
  -- local enemy = Model.enemyGroup[1]
  for k,v in ipairs(data) do
    v.info=Model.getUnit(v[1])
    addToList(v.info.model,reqs)
    addToList(v.info.model1,reqs)
  end

  local  skills = Model.skills
  local buffs=Model.buff

  for k,v in pairs(skills) do
    if v.model then
      addToList(v.model,reqs)
    end
  end

  for k,v in pairs(buffs) do
      if v.model then
        local pars = split(v.model,",")
        for k,v in ipairs(pars) do
          addToList(v,reqs)
        end
      end
  end

  reqs["TaiwanWill01"] = {CUtils.GetAssetFullPath("TaiwanWill01.u3d"),onModelComplete}
  reqs["TaiwanWill02"] = {CUtils.GetAssetFullPath("TaiwanWill02.u3d"),onModelComplete}
  Loader:getResource(reqs,false)
  Loader:setOnAllCompelteFn(allComplete)
end

------------------public------------------
-- -- 资源加载完成时候调用方法
-- function BattleLoader:onAssetsLoad(items)
-- end

function BattleLoader:onShowed()
  self:show()
  if chapterPanel.serverChapterData then
    battlefield.serverChapterData=Model.getChapterData(chapterPanel.serverChapterData.command)
  end
  -- print("----------------battlefield.serverChapterData")
  -- printTable(chapterPanel.serverChapterData)
  -- printTable(battlefield.serverChapterData)
  -- print(battlefield.serverChapterData.id)
  loadRes()
end

function BattleLoader:onBlur( ... )
  print("......."..self.name.." onBluronBluronBlur ")
    self:clear()
    -- BattleCache:clearModel()
end

-------------------------global function---------------------------
local SkillData = luanet.SkillData
local BuffData=luanet.BuffData
local String =luanet.import_type("System.String")
local SpellTargetHelper = luanet.SpellTargetHelper

function SetRoleProperty(roleProperty,config)
    local hp = config.hp
    local mp = config.mp
    local maxHp = config.maxHp
    local maxMp = config.maxMp
    local damage = config.damage
    local defend = config.defend
    local magicDamage = config.magicDamage
    local magicDefend = config.magicDefend
    local critValue = config.critValue
    local dodgeValue = config.dodgeValue
    local speed = config.speed
    local attackSpeed = config.attackSpeed
    local turnSpeed = config.turnSpeed
    local rangeVisible = config.rangeVisible
    -- roleProperty.data=config
    -- print(rangeVisible)
    roleProperty:SetBaseProperty(hp,mp, maxHp,maxMp, damage, defend, magicDamage,magicDefend, critValue, dodgeValue, speed, attackSpeed, rangeVisible,turnSpeed)
end

function SetCateProperty( roleProperty,type,cate )
  -- body
  roleProperty:SetCateProperty(type,cate)
  print("為roleProperty賦值cate， type="..type.."cate="..cate)

end

local function GetBuff(buffData)
    local id = buffData.id
    local name = buffData.name
	local buffEffType = buffData.buffEffType
    local buffCategory = buffData.buffCategory
    local model = buffData.model 
    if model~="" and model then model =make_array(String,split(tostring(model),",")) end
    local probability = buffData.probability
    local continueTime = buffData.continueTime
    local effectInterval = buffData.effectInterval
    local expression = buffData.expression
    local endExpression = buffData.endExpression
    local pars = buffData.pars
    -- printTable(buffData)
    if pars ~= "" and pars then   pars=make_array(String,split(tostring(pars),","))   end
    local buff=BuffData(id,name,buffEffType,buffCategory,model,probability,continueTime,effectInterval,expression,endExpression,pars)
    return buff
end

local function GetSkill(skillData)
    local id = skillData.id
    local name = skillData.name
    local model = skillData.model
    local release = skillData.release
    local effectTime=skillData.effectTime
    local action = skillData.action
    local waitAction=skillData.waitAction
    local icon = skillData.icon
    local passive = skillData.passive~=0
    local auto = skillData.auto~=0
    local injury = skillData.injury
    local flySpeed = skillData.flySpeed
    local cost  = skillData.cost
    local waitTime = skillData.waitTime
    local spellTarget = SpellTargetHelper.StringToEnum(skillData.spellTarget)
    local effectTarget = SpellTargetHelper.StringToEnum(skillData.effectTarget)
    local amount = skillData.amount
    local effectRange = skillData.effectRange
    local cooldown = skillData.cooldown
    local minDistance = skillData.minDistance
    local maxDistance = skillData.maxDistance
    local pars = skillData.pars
    if pars ~= "" and pars then   pars=make_array(String,split(tostring(pars),","))   end
    -- print(skillData.name)
    local skill =SkillData(id, name, model, release,effectTime,action,waitAction,icon, passive, auto, injury,flySpeed,cost, waitTime, spellTarget, effectTarget,amount, effectRange, cooldown, minDistance, maxDistance,pars)
   skill.data=skillData
   -----add buff
    local buff = skillData.buff

    local arr = BuffData[#buff]
    for k,v in ipairs(buff) do
      local buffConf=Model.getBuff(v)
      local buffC = GetBuff(buffConf)
      buffC.data=buffConf
      arr:SetValue(buffC,k-1)
      -- skill:AddBuff(buffC)
    end

    skill.buffs=arr

      local waitbuff=skillData.waitBuff
      if waitbuff then
          arr = BuffData[#waitbuff]
          for k,v in ipairs(waitbuff) do
          local buffConf=Model.getBuff(v)
          local buffC = GetBuff(buffConf)
          buffC.data=buffConf
          arr:SetValue(buffC,k-1)
          end
        skill.waitBuffs=arr
      end

      local beginBuff=skillData.beginBuff
      if beginBuff then
          arr = BuffData[#beginBuff]
          for k,v in ipairs(beginBuff) do
            local buffConf=Model.getBuff(v)
            local buffC = GetBuff(buffConf)
            buffC.data=buffConf
            arr:SetValue(buffC,k-1)
          end
        skill.beginBuffs=arr
      end

    return skill
end

function SetRoleAttack(roleSkill,attackid)
  if attackid then
    local attack=Model.getSkill(attackid)
    local Skill = GetSkill(attack)
    roleSkill:SetAttack(Skill)
  end
end

function GetSkillData(skillId)
  local skilConf=Model.getSkill(skillId)
  local Skill = GetSkill(skilConf)
  return Skill
end

-- function SetRoleSkills(roleSkill,skillids)
--   if skillids then
--     for k,v in ipairs(skillids) do
--       local skilConf=Model.getSkill(v)
--       local Skill = GetSkill(skilConf)
--       roleSkill:AddSkill(Skill)
--     end
--   end
-- end