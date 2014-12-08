local LuaBrain=luanet.LuaBrain
local SelectorNode = luanet.SelectorNode

local soldierBrain=class(function(self)
	self.brain=LuaBrain(self.onStart)
end)

function soldierBrain.onStart()
        local rootNode = SelectorNode("soldierBrain")
        rootNode:AddNode(BrainEventManager:EventSkillAttack()) --¼¼ÄÜ¹¥»÷
        rootNode:AddNode(BrainEventManager:EventMoveAttack()) --ÒÆ¶¯¹¥»÷
        rootNode:AddNode(BrainEventManager:EventMoveTo()) --ÒÆ¶¯¹¥»÷
        rootNode:AddNode(BrainEventManager:EventFindNearestEnemyInRangeVisible()) --ÒÆ¶¯¹¥»÷
        rootNode:AddNode(BrainEventManager:EventFindNearestEnemyFromAll()) --ÒÆ¶¯¹¥»÷        
        return rootNode
end

return soldierBrain