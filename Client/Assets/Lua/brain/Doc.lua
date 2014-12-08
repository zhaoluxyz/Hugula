--===================================决策节点====================================================

-------------------------------------条件节点-----------------------------
ConditionNode(luafunction) ConditionNode(Condition)
--条件等待节点
ConditionWaitNode(luafunction) ConditionWaitNode(Condition)
--按一定时间执行的条件节点
DeltaConditionNode(float delta, Condition condition) DeltaConditionNode(float delta, Condition condition)

-------------------------------------行动节点-------------------------------------
ActionNode((System.Action<BTInput, BTOutput> action) --返回true
ActionNotNode((System.Action<BTInput, BTOutput> action) --返回false
--间隔时间执行的行动节点
DeltaActionNode(float delta,System.Action<BTInput, BTOutput> action)
-- 事件行动节点
ActionEventNode(System.Action<BTInput,BTOutput> action)

-------------------------------------等待节点------------------------------------- 
WaitNode(float duration, float variation)--（等待指定时间后返回成功）

-------------------------------------装饰节点-------------------------------------
DecoratorNotNode() -- 反转结果

-------------------------------------选择节点------------------------------------- [从begin到end依次执行子节点]
SelectorNode() --(遇到true返回True)

-------------------------------------顺序节点------------------------------------- [从begin到end依次执行子节点]
SequenceNode() --(遇到false返回false)
SequenceTrueNode() --(遇到false返回true,否则循环完成后返回true)

-------------------------------------并行节点------------------------------------- [同时执行所有子节点]
ParallelNode() --平行执行它的所有Child Node,遇到False则返回False，全True才返回True。
ParallelNodeAny() --平行执行它的所有Child Node,遇到False则返回False，有True返回True
ParallelSelectorNode() --遇到True则返回True，全False才返回False
ParallelFallOnAllNode()	--所有False才返回False，否则返回True

-------------------------------------事件节点-------------------------------------
EventNode(int eventType) --事件触发的时候执行，只能有一个子节点
TriggerNode(int eventType) --触发事件节点，运行到当前节点时候会触发eventType事件 返回成功

-------------------------------------循环节点-------------------------------------
LoopNode(int count) --The Loop node allows to execute one child a multiple number of times n (if n is not specified then it's considered to be infinite) or until the child FAILS its execution
LoopUntilSuccessNode() --The LoopUntilSuccess node allows to execute one child until it SUCCEEDS. A maximum number of attempts can be specified. If no maximum number of attempts is specified or if it's set to <= 0, then this node will try to run its child over and over again until the child succeeds.

-------------------------------------压制失败-------------------------------------
SuppressFailure() --只能有一个子节点，总是返回true


--===================================具体行动===================================--
ActionNodes.MoveToForActionEventNodeByEventData --移动到EventData指定的目标，ActionEventNode专属 移动
ActionNodes.MoveToByEventData --移动到EventData指定的目标可以是角色或者位置
ActionNodes.MoveTo 			--移动到目标位置 从input.postion接受数据
ActionNodes.MoveToTarget	--移动到角色位置 从input.target接受数据
ActionNodes.Spell			--释放技能
ActionNodes.Idle --什么都不做

ActionNodes.ChooseAttack	--选择普通攻击技能
ActionNodes.ChooseSkill1 	--选择技能1
ActionNodes.ChooseSkill2	--选择技能2
ActionNodes.ChooseSkill3	--选择技能3
ActionNodes.ChooseSkill4	--选择技能4

ActionNodes.InitStopDistance --设置默认寻路停止距离
ActionNodes.SetTargetFromEventData --设置 inp.target = (RoleActor)oup.eventData 如果获取失败节点状态为Failed
ActionNodes.SetTargetToEventData --设置 output.eventData = input.target 
ActionNodes.SetPositionFromEventData --设置 inp.position = (Vector3)oup.eventData 如果获取失败节点状态为Failed
ActionNodes.SetPositionToEventData --设置 output.eventData = input.position
ActionNodes.DoAction	--直接给一个actor执行一个行动(ActionNodes.action,actor)
--===================================具体条件===================================--
ConditionNodes.CheckSkillCanSpell	--判断input.skill能否释放
ConditionNodes.CheckSkillCD  --判断input.skill的cd
ConditionNodes.CheckSkillCost --判断input.skill的Cost
ConditionNodes.CheckSkillCDandCost --判断input.skill的cd时间和Cost
ConditionNodes.CheckSkillDistance --判断释放距离
ConditionNodes.CheckInputTargetDeath	--判断目标是否死亡

ConditionNodes.IfMeetNearestUnitInVisible --如果 找到可视范围内最近的目标就放入input.target
ConditionNodes.IfSeeEnmeyAndNotDraggingDispatchMoveAttack	--不是拖动状态 如果看见敌人 目标就放入input.target 触发[BrainEventEnum.MoveAttack]移动攻击事件
ConditionNodes.IfSeeEnmeyDispatchMoveAttack 	--如果看见敌人 触发[BrainEventEnum.MoveAttack]移动攻击事件
ConditionNodes.IfGetNeastEnmeyFromAll	--搜寻所有敌人 如果找到放入input.target
ConditionNodes.IfGetNeastEnmeyInRangeVisible	--搜寻看见的敌人 如果找到放入input.target
ConditionNodes.IfArrivePosition --如果到达目标(input.position)
ConditionNodes.IfArriveTarget --如果到达角色位置（input.target）
ConditionNodes.IfGetSpellTargetBySkill --	如果获取技能释放目标
--===================================输入域输出===================================--
input.target RoleActor --输入目标角色
input.position Vector3 --输入目标位置
input.skill int 	--输入技能
input.stopDistance	--移动停止距离
input.isDragging --是否拖动状态

output.leafNode --当前叶节点
output.eventData --传输数据

--====================================事件说明========================================--
BrainEventEnum.IdleEnd = 1, -- 休息
BrainEventEnum.MoveEnd --移动结束
BrainEventEnum.SpellEnd --释放技能结束
BrainEventEnum.DeathEnd --死亡动作结束
BrainEventEnum.WaitSpellEnd = 5 --前摇动作结束
BrainEventEnum.HitEnemy =30 --点击到敌人
BrainEventEnum.MoveTo =31--移动到目标
BrainEventEnum.MoveAttack =32-- 移动并攻击目标
BrainEventEnum.SkillAttack =33--技能攻击