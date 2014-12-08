local LuaBrain=luanet.LuaBrain
local SelectorNode = luanet.SelectorNode

local soldierBrain=class(function(self)
	self.brain=LuaBrain(self.onStart)
end)

function soldierBrain.onStart()
        local rootNode = SelectorNode("soldierBrain")
        rootNode:AddNode(BrainEventManager:EventSkillAttack()) --���ܹ���
        rootNode:AddNode(BrainEventManager:EventMoveAttack()) --�ƶ�����
        rootNode:AddNode(BrainEventManager:EventMoveTo()) --�ƶ�����
        rootNode:AddNode(BrainEventManager:EventFindNearestEnemyInRangeVisible()) --�ƶ�����
        rootNode:AddNode(BrainEventManager:EventFindNearestEnemyFromAll()) --�ƶ�����        
        return rootNode
end

return soldierBrain