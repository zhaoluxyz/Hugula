Movement = Class(LuaComponent, function(self)
	LuaComponent._ctor(self)
	self.isRunning = false
	self.movementFn = nil -- for override
	self.startPos = Vector3(0,0,0)
end)
--------------------------------------------------
Event.MOVEMENT_START = "movementStart"
Event.MOVEMENT_FINISH = "movementFinish"
--------------------------------------------------
function Movement:start()
	self.isRunning = true
	self:DispatchEvent(Event.MOVEMENT_START)
end

function Movement:Update()
	if sele.isRunning and self.movementFn then
		self:movementFn()
	end
end

function Movement:finish()
	self.isRunning = false
	self.Update = nil
	self:DispatchEvent(Event.MOVEMENT_FINISH)
end



