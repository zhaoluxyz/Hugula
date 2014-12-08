--local ImplBrain = luanet.ImplBrain
--local ConditionNode = luanet.ConditionNode
--local ConditionWaitNode = luanet.ConditionWaitNode
--local ConditionNotNode = luanet.ConditionNotNode
--local DeltaConditionNode = luanet.DeltaConditionNode
--local ActionNode=luanet.ActionNode
--local DeltaActionNode = luanet.DeltaActionNode
--local ActionEventNode = luanet.ActionEventNode
--local WaitNode = luanet.WaitNode
--local ActionNotNode = luanet.ActionNotNode
--local DecoratorNode=luanet.DecoratorNode
--local DecoratorNotNode = luanet.DecoratorNotNode
--local SelectorNode = luanet.SelectorNode
--local RandomNode = luanet.RandomNode
--local SequenceNode = luanet.SequenceNode
--local SequenceTrueNode = luanet.SequenceTrueNode
--local ParallelNode = luanet.ParallelNode
--local ParallelNodeAny = luanet.ParallelNodeAny
--local ParallelSelectorNode = luanet.ParallelSelectorNode
--local ParallelFallOnAllNode = luanet.ParallelFallOnAllNode
--local IfNode = luanet.IfNode
--local EventNode = luanet.EventNode
--local LoopNode = luanet.LoopNode
--local LoopUntilSuccessNode = luanet.LoopUntilSuccessNode
--local SuppressFailure = luanet.SuppressFailure
--local TriggerNode = luanet.TriggerNode


--local ConditionNodes=toluacs.ConditionNodes
--local ActionNodes=toluacs.ActionNodes

--local BrainEventManager=BrainEventManager

--[[cal LuaImplBrain=class(function(self)
	self.brain=ImplBrain()
end)]]


--BrainType = 
--{

--     HeroBrain =
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeDragMove,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--    },
--    -- 我方英雄防守
--    SelfHeroDef = 
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeDragMove,
--        EventTypeEnum.TypeFindNearestSelfUnderAttackBuilding,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--    },

--    -- 我方英雄进攻
--    SelfHeroAtk =
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeDragMove,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--    },

--    -- 敌方英雄进攻
--    EnemyHeroAtk =
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeMoveTo,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--        EventTypeEnum.TypeFindNearestEnemyFromAll,
--    },

--    -- 小兵进攻
--    SoldierBrain = 
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeMoveTo,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--        EventTypeEnum.TypeFindNearestEnemyFromAll,
--    },

--    -- 測試AI
--    TestAI =
--    {
--        EventTypeEnum.TypeSkillAttack,
--        EventTypeEnum.TypeMoveAttack,
--        EventTypeEnum.TypeMoveTo,
--        EventTypeEnum.TypeFindNearestEnemyInRangeVisible,
--        EventTypeEnum.TypeFindNearestEnemyFromAll,      
--    },

--}


--function InitAI( brain, brainKey )

-- 	if BrainType[brainKey] == nil then
--        print("InitAI失败，没有的Brain类型:"..brainKey)
--        return
--    end

-- 	local rootNode = SelectorNode("AIBrain")
-- 	brain.bTree = rootNode
--    print(brainKey)
--    for k,v in ipairs(BrainType[brainKey]) do
--        rootNode:AddNode(BrainEventManager:GenerateEventNode(v))
--    end

--end


--return LuaImplBrain