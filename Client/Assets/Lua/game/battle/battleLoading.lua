local BattleLoader = LuaItemManager:getItemObject("battleLoading")
local battleUI = LuaItemManager:getItemObject("battleUI")
local battleMap = LuaItemManager:getItemObject("battleMap")
local chapterPanel = LuaItemManager:getItemObject("chapterPanel")

local PrefabPool = luanet.PrefabPool.instance
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue
local make_array = make_array
local Model = Model
local PrefabPool = PrefabPool
-----------------------------------------------------------------------------
local SpellTargetHelper=toluacs.SpellTargetHelper
local SkillData= toluacs.SkillData
local BuffData=toluacs.BuffData
local BuffHelper = toluacs.BuffHelper
local BuffEffect = toluacs.BuffEffect
--UI资源
BattleLoader.priority=1
BattleLoader.assets=
{
    Asset("BattleLoading.u3d")
}

local reqs={}
local itemShowed = 0
------------------private-----------------

local function allComplete( ... )
  	Loader:setOnAllCompelteFn(nil)
    StateManager:setLoading(false)
    StateManager:hideTransform()
    --加载战斗场景和战斗UI
    battleUI:addToState()  
    battleMap:addToState()
    print("進入了battleMap...........")
end

local function onModelComplete(req)
  local key = req.key
  if req.data then
    local mainAsset = req.data.assetBundle.mainAsset
    local clone
    if mainAsset:GetType().Name == "Texture2D" then
      clone=mainAsset
    else
      LuaHelper.RefreshShader(req.data)
      clone = LuaHelper.Instantiate(req.data.assetBundle.mainAsset)
      clone.name=key
      clone:SetActive(false)
    end
    PrefabPool:Add(key,clone)
    disposeWWW(req.data)
  end
end 


local function addToList(key,reqs)
  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      reqs[key]={CUtils.GetAssetFullPath(key..".u3d"),onModelComplete}
  end
end

local function addBuffResToList(buffIds,reqs)
    local bufD 
    for k,v in ipairs(buffIds) do
      bufD=Model.getBuff(v)
      if bufD.model then
        local pars = split(bufD.model,",")
        for k,v in ipairs(pars) do
          addToList(v,reqs)
        end
      end
  end
end 

local function loadRes( ... )
--  print(" begin loadRes ")
--  printTable(reqs)
  Loader:getResource(reqs,false)
  Loader:setOnAllCompelteFn(allComplete)
end

------------------public------------------

function BattleLoader:onItemShowed(item)
     itemShowed=itemShowed+1
    --battleUI.ass
    if itemShowed >=2 then
      self:hide()
      battleUI:checkToConfig()
      -- print("**************************************************************************==========")
      -- print(battleUI.chapterData["id"])
      -- showStoryDlg(battleUI.chapterData["id"])
      itemShowed = 0
    end
end

function BattleLoader:onShowed()
  self:show()
  battleUI.chapterData=Model.getChapterDataByid(Model.chapterCurrentIndex) --Model.getChapterData(chapterPanel.serverChapterData.command)
  print("battleLoading.onShowed chapterData")
  local leveltype=battleUI.chapterData.type
  if leveltype==5 or   leveltype==4 then
        battleUI.noConfig = true
  end
  --printTable(500001)
  loadRes()
end

function BattleLoader.onRourseRecMessage(msg)
  print("==========BattleLoading.onRourseRecMessage==============")
  --================生成据点配置=============
  battleMap.stronghold ={}
  local stronghold = msg.stronghold
  for k,v in ipairs(stronghold) do
    battleMap.stronghold[v.hero_group_id] =v
  end

  printTable(msg)
  print("==========battleMap.stronghold==============")
  printTable(battleMap.stronghold)

  --==============
  Model.chapterCurrentIndex = msg.chapter_id
        --msg.chapter_type
  reqs={}
  local data = msg.hero_group_ids
  local skils = msg.hero_skill_ids
  --  msg.player_base.player_hero_id = msg.player_base.id
  -- battleUI.player_base = msg.player_base
---------------------------------------Enmey--------------------------------
  -- table.insert(data,{id=210011})
  -- table.insert(data,{id=210012})
    
  -- table.insert(data,{id=210013})
  -- table.insert(data,{id=210014})
  -- table.insert(data,{id=210015})

  for k,v in ipairs(data) do
      v.info=Model.getUnit(v.id) --player_hero_attribute
      addToList(v.info.model,reqs) --加载3d美术资源
      addToList(v.info.photo,reqs)--加载半身相
  end

  -- printTable(reqs)
---------------------------------------my 
  data = Model.battleGroup.team
  printTable(data)
  for k,v in ipairs(data) do
    v.info=Model.getUnit(v.hero_group_id) --player_hero_attribute
    addToList(v.info.model,reqs) --加载3d美术资源
    addToList(v.info.photo,reqs) --加载半身相

    -- printTable(v.player_hero_skill)
      for i,v in ipairs(v.player_hero_skill) do
        table.insert(skils,v)
      end
  end
--
 table.insert(skils,{lv=1,id=10}) --特别技能
-----------------skill resource--
  local skillConfig
  for k,v in ipairs(skils) do
        print(string.format("加载技能ID = %s",v.id))
      skillConfig=Model.getSkill(v.id) --player_hero_attribute
      if skillConfig.model then
        addToList(skillConfig.model,reqs)
      end

      local buff = skillConfig.buff
      if buff then addBuffResToList(buff,reqs) end
      buff = skillConfig.waitBuff
      if buff then addBuffResToList(buff,reqs) end
      buff= skillConfig.beginBuff
      if buff then addBuffResToList(buff,reqs) end

  end

  if StateManager:getCurrentState() ~= StateManager.battle then
    StateManager:setCurrentState(StateManager.battle)
  end
end


function BattleLoader.onErr(data)
  local tips = getValue("g_notify_"..data.errno)
   showTips(tips,battlefield.onErrClick)
end

function BattleLoader.onErrClick( ... )
  StateManager:setCurrentState(StateManager.mainScene)
end

--初始化函数只会调用一次
function BattleLoader:initialize()
    Proxy:bindingOne(NetAPIList.recv_player_challenge_chapter,self.onRourseRecMessage)
    print("綁定接受消息函數recv_player_challenge_chapter")
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
    roleProperty:SetBaseProperty(hp,mp, maxHp,maxMp, damage, defend, magicDamage,magicDefend, critValue, dodgeValue, speed, attackSpeed, rangeVisible,turnSpeed)
end

function SetCateProperty( roleProperty,type,cate )
  -- body
  roleProperty:SetCateProperty(type,cate)
--  print("為roleProperty賦值cate， type="..type.."cate="..cate)

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
     print(skillData.name)
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

function SetRoleAttack(roleSkill,attackid,lv)
  if attackid then
    local attack=Model.getSkill(attackid)
    local Skill = GetSkill(attack)
    roleSkill:SetAttack(Skill)
    if lv then Skill.level=lv end
  end
end

function GetSkillData(skillId)
  local skilConf=Model.getSkill(skillId)
  local Skill = GetSkill(skilConf)
  return Skill
end

function SetRoleSkillsByMsg(roleSkill,skills)
    if skills then
    for k,v in ipairs(skills) do
      if v.id>0  then  
        local skilConf=Model.getSkill(v.id)
        local skill = GetSkill(skilConf)
        if k==1 then  
            -- print("attack"..skill.name)
            roleSkill:SetAttack(skill) 
        else
            roleSkill:AddSkill(skill)
        end
        if v.lv then skill.level=v.lv end
      end
    end
  end
end

function SetRoleSkills(roleSkill,skillids)

  if skillids then
    for k,v in ipairs(skillids) do
      local skilConf=Model.getSkill(v)
      local skill = GetSkill(skilConf)
      roleSkill:AddSkill(skill)
      -- if skill.auto then
      --   local actor = roleSkill.actor
      --   BuffHelper.DoSpellBuff(actor,skill,actor,actor.transform.position)
      -- end
    end
  end
end

