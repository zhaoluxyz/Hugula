local Collider = Class(LuaComponent, function(self)
	LuaComponent._ctor(self) 
	self.name = "Collider"
end)
LuaComponents:Add("Collider",Collider)
-------------------------------------------------------------
Event.COLLISION_ENTER = "collisionEnter"
Event.COLLISION_EXIT = "collisionExit"
Event.COLLISION_STAY = "collisionStay"

Event.TRIGGER_ENTER = "triggerEnter"
Event.TRIGGER_EXIT = "triggerExit"
Event.TRIGGER_STAY = "triggerStay"
-------------------------------------------------------------privates
local listenCollisionEnter = true
local listenCollisionExit = false
local listenCollisionStay = false

local listenTriggerEnter = false
local listenTriggerExit = false
local listenTriggerStay = false

local function updateListener(self)
	self.monoCollider.collisionEnterFn = listenCollisionEnter and self.OnCollisionEnter or nil
	self.monoCollider.collisionExitFn = listenCollisionExit and self.OnCollisionExit or nil
	self.monoCollider.collisionStayFn = listenCollisionStay and self.OnCollisionStay or nil
	self.monoCollider.triggerEnterFn = listenTriggerEnter and self.OnTriggerEnter or nil
	self.monoCollider.triggerExitFn = listenTriggerExit and self.OnTriggerExit or nil
	self.monoCollider.triggerStayFn = listenTriggerStay and self.OnTriggerStay or nil
end
-------------------------------------------------------------public
function Collider:listenCollisionEnter(bool)
	listenCollisionEnter = bool
	updateListener(self)
end

function Collider:listenCollisionExit(bool)
	listenCollisionExit = bool
	updateListener(self)
end

function Collider:listenCollisionStay(bool)
	listenCollisionStay = bool
	updateListener(self)
end

function Collider:listenTriggerEnter(bool)
	listenTriggerEnter = bool
	updateListener(self)
end

function Collider:listenTriggerExit(bool)
	listenTriggerExit = bool
	updateListener(self)
end

function Collider:listenTriggerStay(bool)
	listenTriggerStay = bool
	updateListener(self)
end

-------------------------------------------------------------
function Collider:Start()
	self.monoCollider = self.gameObject:AddComponent("LuaCollider")
	updateListener(self)
end

function Collider:OnCollisionEnter(collision)
	self:DispatchEvent(Event.COLLISION_ENTER,collision)
end

function Collider:OnCollisionExit(collision)
	self:DispatchEvent(Event.COLLISION_EXIT,collision)
end

function Collider:OnCollisionStay(collision)
	self:DispatchEvent(Event.COLLISION_STAY,collision)
end

function Collider:OnTriggerEnter(collider)
	self:DispatchEvent(Event.TRIGGER_ENTER,collider)
end

function Collider:OnTriggerExit(collider)
	self:DispatchEvent(Event.TRIGGER_EXIT,collider)
end

function Collider:OnTriggerStay(collider)
	self:DispatchEvent(Event.TRIGGER_STAY,collider)
end

function Collider:OnDestroy()
	Component.Destroy(self.monoCollider)
end
-------------------------------------------------------------