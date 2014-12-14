------------------------------------------------
--  Copyright © 2013-2014   Hugula: Arpg game Engine
--   NGUIEvent
--  author pu
------------------------------------------------
NGUIEvent = luanet.import_type("NGUIEvent")
local NGUIEvent=NGUIEvent.instance
local StateManager = StateManager
--InputEvent={}
local InputEvent = {}
function InputEvent.onPress(sender,arg)
	StateManager:getCurrentState():onEvent("onPress",sender,arg)
end

function InputEvent.onClick(sender,arg)
	StateManager:getCurrentState():onEvent("onClick",sender,arg)
end

function InputEvent.onDrag(sender,arg)
	StateManager:getCurrentState():onEvent("onDrag",sender,arg)
end

function InputEvent.onDrop(sender,arg)
	StateManager:getCurrentState():onEvent("onDrop",sender,arg)
end

function InputEvent.onCustomer(sender,arg)
	StateManager:getCurrentState():onEvent("onCustomer",sender,arg)
end

function InputEvent.onDouble(sender,arg)
	StateManager:getCurrentState():onEvent("onDouble",sender,arg)
end

NGUIEvent.onDoubleFn=InputEvent.onDouble
NGUIEvent.onCustomerFn=InputEvent.onCustomer
NGUIEvent.onPressFn=InputEvent.onPress
NGUIEvent.onClickFn=InputEvent.onClick
NGUIEvent.onDragFn=InputEvent.onDrag
NGUIEvent.onDropFn=InputEvent.onDrop
