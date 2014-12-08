--local ImplBrain = luanet.ImplBrain
local ConditionNode = luanet.ConditionNode
local ConditionWaitNode = luanet.ConditionWaitNode
local ConditionNotNode = luanet.ConditionNotNode
local DeltaConditionNode = luanet.DeltaConditionNode
local ActionNode=luanet.ActionNode
local DeltaActionNode = luanet.DeltaActionNode
local ActionEventNode = luanet.ActionEventNode
local WaitNode = luanet.WaitNode
local ActionNotNode = luanet.ActionNotNode
local DecoratorNode=luanet.DecoratorNode
local DecoratorNotNode = luanet.DecoratorNotNode
local SelectorNode = luanet.SelectorNode
local RandomNode = luanet.RandomNode
local SequenceNode = luanet.SequenceNode
local SequenceTrueNode = luanet.SequenceTrueNode
local ParallelNode = luanet.ParallelNode
local ParallelNodeAny = luanet.ParallelNodeAny
local ParallelSelectorNode = luanet.ParallelSelectorNode
local ParallelFallOnAllNode = luanet.ParallelFallOnAllNode
local IfNode = luanet.IfNode
local EventNode = luanet.EventNode
local LoopNode = luanet.LoopNode
local LoopUntilSuccessNode = luanet.LoopUntilSuccessNode
local SuppressFailure = luanet.SuppressFailure
local TriggerNode = luanet.TriggerNode
local ConditionNodes=toluacs.ConditionNodes
local ActionNodes=toluacs.ActionNodes


BrainEventManager = {}

-- 事件枚舉
BrainEventEnum =
{
    -- 休息
    IdleEnd = 1,
    -- 移动结束
    MoveEnd = 2,
    -- 释放技能结束
    SpellEnd = 3,
    -- 死亡结束
    DeathEnd = 4,
    -- 前摇结束
    WaitSpellEnd = 5,
    -- 点击到敌人
    HitEnemy =30,
    -- 移动到目标
    MoveTo = 31,
    -- 移动并攻击目标
    MoveAttack = 32,
    -- 技能攻击
    SkillAttack = 33,
}

--EventTypeEnum =
--{
--    TypeFindNearestSelfBuilding = 1,                -- 寻找己方最近的建筑
--    TypeFindNearestSelfUnderAttackBuilding = 2,     -- 寻找己方最近的正在遭受攻击的建筑
--    TypeFindNearestEnemyInRangeVisible = 3,         -- 寻找可视范围内最近的敌人
--    TypeFindNearestEnemyFromAll = 4,                -- 全图寻找敌方单位
--    TypeMoveTo = 5,                                 -- 寻路节点
--    TypeMoveAttack = 6,                             -- 移动并攻击目标
--    TypeDragMove = 7,                               -- 拖拽寻路
--    TypeSkillAttack = 8,                            -- 释放技能

--}




--function BrainEventManager:GenerateEventNode( eventType )
--    print("GenerateEventNode="..eventType)
--    if eventType == EventTypeEnum.TypeFindNearestSelfBuilding then
--        return self:EventFindNearestSelfBuilding()
--    elseif eventType == EventTypeEnum.TypeMoveTo then
--        return self:EventMoveTo()
--    elseif eventType == EventTypeEnum.TypeMoveAttack then
--        return self:EventMoveAttack()
--    elseif eventType == EventTypeEnum.TypeFindNearestEnemyInRangeVisible then
--        return self:EventFindNearestEnemyInRangeVisible()
--    elseif eventType == EventTypeEnum.TypeFindNearestEnemyFromAll then
--        return self:EventFindNearestEnemyFromAll()
--    elseif eventType == EventTypeEnum.TypeFindNearestSelfUnderAttackBuilding then
--        return self:EventFindNearestSelfUnderAttackBuilding()
--    elseif eventType == EventTypeEnum.TypeDragMove then
--        return self:EventDragMove()
--    elseif eventType == EventTypeEnum.TypeSkillAttack then
--        return self:EventSkillAttack()
--    end


--end


--寻找最近建筑
--返回值：寻找节点
function BrainEventManager:EventFindNearestSelfBuilding()

    local findTarget = SequenceNode("全屏寻找最近建筑")
    findTarget:AddNode( WaitNode(1, 0, "等待1S后执行"))
    findTarget:AddNode( ConditionNode(ConditionNodes.IfGetNeastSelfBuildingFromAll, "找到最近的己方建筑"))
--    findTarget:AddNode( ConditionNotNode(ConditionNodes.IfArriveTarget, "如果到达目标则不再处理"));
    findTarget:AddNode( ActionNode(ActionNodes.SetTargetToEventData, "放入eventData"))
    findTarget:AddNode( TriggerNode(BrainEventEnum.MoveTo, "触发移动到建筑"))
        
    return findTarget
end


--尋找正在攻擊己方建築的敵人
--返回值：尋找節點
function BrainEventManager:EventFindNearestSelfUnderAttackBuilding()
    -- body
    local findTarget = SequenceNode("全屏寻找正在攻擊己方建筑的敵人")
    findTarget:AddNode( WaitNode(1, 0, "等待1S后执行"))
    findTarget:AddNode( ConditionNode(ConditionNodes.IfGetNearEnimyFromAttackBuilding, "找到最近正在攻擊己方建築的敵人"))
--    findTarget:AddNode( ConditionNotNode(ConditionNodes.IfArriveTarget, "如果到达目标则不再处理"));
    findTarget:AddNode( ActionNode(ActionNodes.SetTargetToEventData, "放入eventData"))
    findTarget:AddNode( TriggerNode(BrainEventEnum.MoveTo, "触发移动到敌人"))

    return findTarget
end

-- 寻找可视范围内最近的敌人
function BrainEventManager:EventFindNearestEnemyInRangeVisible()
    local findTarget = SequenceNode("寻找可视范围内最近的敌人")
    findTarget:AddNode( WaitNode(0.4, 0.2, "等待0.2S后执行"))
    findTarget:AddNode( ConditionNode(ConditionNodes.IfGetNeastEnmeyInRangeVisible, "找到可视范围内最近的敌人"))
--    findTarget:AddNode( ConditionNotNode(ConditionNodes.IfArriveTarget, "如果到达目标则不再处理"));
    findTarget:AddNode( ActionNode(ActionNodes.SetTargetToEventData, "放入eventData"))
    findTarget:AddNode( TriggerNode(BrainEventEnum.MoveTo, "触发移动到敌人"))

    return findTarget
end


-- 寻找全图内最近的敌方单位
function BrainEventManager:EventFindNearestEnemyFromAll()
    local findTarget = SequenceNode("寻找全图内最近的敌方单位")
    findTarget:AddNode( WaitNode(1, 0.2, "等待0.2S后执行"))
    findTarget:AddNode( ConditionNode(ConditionNodes.IfGetNeastEnmeyFromAll, "寻找全图内最近的敌方单位"))
--    findTarget:AddNode( ConditionNotNode(ConditionNodes.IfArriveTarget, "如果到达目标则不再处理"));
    findTarget:AddNode( ActionNode(ActionNodes.SetTargetToEventData, "放入eventData"))
    findTarget:AddNode( TriggerNode(BrainEventEnum.MoveTo, "触发移动到敌人"))

    return findTarget
end


--寻路
--返回值：寻路事件节点
function BrainEventManager:EventMoveTo()

    local eventPath = EventNode(BrainEventEnum.MoveTo, "移动")
        local untilArrive = LoopUntilSuccessNode("移动到目标")
        untilArrive:AddNode(ActionNotNode(ActionNodes.InitStopDistance, "初始化停止距离"))
        untilArrive:AddNode(DeltaConditionNode(0.10, ConditionNodes.IfSeeEnmeyDispatchMoveAttack, "检测周围有没敌人"))
            local movtoTargetAct = DecoratorNotNode()
            movtoTargetAct:AddNode(DeltaActionNode(0.25, ActionNodes.MoveToByEventData, "移动到目标"))
        untilArrive:AddNode(movtoTargetAct)
        untilArrive:AddNode(ConditionNode(ConditionNodes.IfArrivePosition, "到达目标"))
    eventPath:AddNode(untilArrive)

    return eventPath
end


--移动并攻击目标
--返回值：移动并攻击的节点
function BrainEventManager:EventMoveAttack()
    -- body
    local lockAttack = EventNode(BrainEventEnum.MoveAttack, "锁定目标")
        local fllowA = SequenceNode("移动并攻击")
        fllowA:AddNode(ConditionNode(ConditionNodes.CheckControlBuffForbidAct,"判断是否被控制"))
        fllowA:AddNode(ActionNode(ActionNodes.ChooseAttack, "选择普通攻击"))
        fllowA:AddNode(ActionNode(ActionNodes.SetTargetFromEventData, "获取攻击目标"))
            local loopAtt = LoopNode(50, "循环攻击50")
            loopAtt:AddNode(ConditionNode(ConditionNodes.CheckInputTargetDeath, "判断目标死亡"))
                local loopOnArrive = LoopUntilSuccessNode("直达目标")
                    loopOnArrive:AddNode(ConditionNode(ConditionNodes.CheckSkillDistance, "在攻击范围内"))
                    local goTarget = DecoratorNotNode()
                        goTarget:AddNode(DeltaActionNode(0.15, ActionNodes.MoveToTarget, "矫正移动到目标"))
                loopOnArrive:AddNode(goTarget)
            loopAtt:AddNode(loopOnArrive)
            loopAtt:AddNode(ConditionWaitNode(ConditionNodes.CheckSkillCDandCost, "是否能释放技能"))
            loopAtt:AddNode(ActionEventNode(ActionNodes.Spell, "攻击目标"))
        fllowA:AddNode(loopAtt)
    lockAttack:AddNode(fllowA)

    return lockAttack
end


-- 释放技能
function BrainEventManager:EventSkillAttack()
    -- body
    local skillNode = EventNode(BrainEventEnum.SkillAttack, "技能攻击事件")
        local skillA = SequenceNode("技能")  print(ConditionNodes.CheckControlBuffForbidAct)
            skillA:AddNode(ConditionNode(ConditionNodes.CheckControlBuffForbidAct,"判断是否被控制"))
            skillA:AddNode(ConditionNode(ConditionNodes.CheckControlBuffSilence,"判断是否被沉默"))
            skillA:AddNode(ConditionNode(ConditionNodes.IfGetSpellTargetBySkill,"获取技能释放目标"))
            skillA:AddNode(ConditionWaitNode(ConditionNodes.CheckSkillCDandCost, "判断释放"))
            local loopOnArrive1 = LoopUntilSuccessNode("直达目标")
                loopOnArrive1:AddNode(ConditionNode(ConditionNodes.CheckSkillDistance, "在攻击范围内"))
                local goTarget1 = DecoratorNotNode() 
                    local an =DeltaActionNode(0.5,ActionNodes.MoveToTarget,"矫正移动到目标")
                    goTarget1:AddNode(an) 
                loopOnArrive1:AddNode(goTarget1)
            skillA:AddNode(loopOnArrive1) 
            skillA:AddNode(ConditionWaitNode(ConditionNodes.CheckSkillCDandCost, "判断释放"))
            skillA:AddNode(ActionEventNode(ActionNodes.Spell, "攻击"))
        skillNode:AddNode(skillA)
    return skillNode
end



-- 拖拽寻路
function BrainEventManager:EventDragMove()
    local eventPath = EventNode(BrainEventEnum.MoveTo, "移动事件")
    local seq = ParallelSelectorNode("移动同时搜索敌人")
        seq:AddNode(ActionNotNode(ActionNodes.InitStopDistance,"初始化停止距离"))
        seq:AddNode(DeltaConditionNode(1,ConditionNodes.IfSeeEnmeyAndNotDraggingDispatchMoveAttack,"检测周围有没敌人"))
        seq:AddNode(ActionEventNode(ActionNodes.MoveToForActionEventNodeByEventData,"寻路到某地"))
    eventPath:AddNode(seq)

    return eventPath

end