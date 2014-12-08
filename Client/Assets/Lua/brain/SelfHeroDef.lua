local LuaBrain=luanet.LuaBrain
local SelectorNode = luanet.SelectorNode

local selfHeroDefBrain=class(function(self)
	self.brain=LuaBrain(self.onStart)
end)

function selfHeroDefBrain.onStart(actor)
        local root = SelectorNode("selfHeroDefBrain")
         root:AddNode(BrainEventManager:EventSkillAttack()) --
         root:AddNode(BrainEventManager:EventMoveAttack()) --
         root:AddNode(BrainEventManager:EventDragMove()) 
        root:AddNode(BrainEventManager:EventFindNearestSelfUnderAttackBuilding()) 
         root:AddNode(BrainEventManager:EventFindNearestEnemyInRangeVisible()) --
         return root

--	local root = SelectorNode("SoldierBrain")
--	--循环攻击
--	print("soldierBrain"..actor.name)

--	--移动并攻击
--	    local lockAttack = EventNode(32, "锁定目标")--(int)BrainEventEnum.MoveAttack
--            local fllowA = SequenceNode("移动并攻击")
--                fllowA:AddNode(ActionNode(ActionNodes.ChooseAttack, "选择普通攻击"))
--                fllowA:AddNode(ActionNode(ActionNodes.SetTargetFromEventData, "获取攻击目标"))
--                local loopAtt = LoopNode(50, "循环攻击50")
--                    loopAtt:AddNode(ConditionNode(ConditionNodes.CheckInputTargetDeath, "判断目标死亡"))
--                        local loopOnArrive = LoopUntilSuccessNode("直达目标")
--                            loopOnArrive:AddNode(ConditionNode(ConditionNodes.CheckSkillDistance, "在攻击范围内"))
--                            local goTarget = DecoratorNotNode()
--                            goTarget:AddNode(DeltaActionNode(0.15, ActionNodes.MoveToTarget, "矫正移动到目标"))
--                            loopOnArrive:AddNode(goTarget)
--                    loopAtt:AddNode(loopOnArrive)
--                    loopAtt:AddNode(ConditionWaitNode(ConditionNodes.CheckSkillCDandCost, "是否能释放技能"))
--                    loopAtt:AddNode(ActionEventNode(ActionNodes.Spell, "攻击目标"))
--            fllowA:AddNode(loopAtt)
--        lockAttack:AddNode(fllowA)
--        root:AddNode(lockAttack)

--	--寻路
--    local eventPath = EventNode(31, "移动") --BrainEventEnum.MoveTo
--    local untilArrive = LoopUntilSuccessNode("移动到目标")
--        untilArrive:AddNode(DeltaConditionNode(0.25, ConditionNodes.IfSeeEnmeyDispatchMoveAttack, "检测周围有没敌人"))
--            local movtoTargetAct = DecoratorNotNode()
--            movtoTargetAct:AddNode(DeltaActionNode(0.5, ActionNodes.MoveToByEventData, "移动到目标"))
--        untilArrive:AddNode(movtoTargetAct)
--        untilArrive:AddNode(ConditionNode(ConditionNodes.IfArrivePosition, "到达目标"))
--    eventPath:AddNode(untilArrive)
--    root:AddNode(eventPath)
--	--寻找目标
--	local findTarget = SequenceNode("全屏寻找攻击目标")
--	findTarget:AddNode(WaitNode(1,0,"等待1S后执行"))
--	findTarget:AddNode(ConditionNode(ConditionNodes.IfGetNeastEnmeyFromAll, "找到敌人"))
--	findTarget:AddNode(ActionNode(ActionNodes.SetTargetToEventData, "放入eventData"))
--	findTarget:AddNode(TriggerNode(31, "触发移动到敌人")) --BrainEventEnum.MoveTo 
--	root:AddNode(findTarget)

--	--空闲
--	local kongxian = ActionNode(ActionNodes.Idle)
--	root:AddNode(kongxian)
--	-- return root
--	return root
end

return selfHeroDefBrain