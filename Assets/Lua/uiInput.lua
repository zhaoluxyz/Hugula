NGUIEvent = luanet.import_type("NGUIEvent")
local NGUIEvent=NGUIEvent.instance
local StateManager = StateManager
--InputEvent={}
local InputEvent = {}
function InputEvent.onPress(sender,arg)
	StateManager:getCurrentState():onPress(sender,arg)
end

function InputEvent.onClick(sender,arg)
	StateManager:getCurrentState():onClick(sender,arg)
end

function InputEvent.onDrag(sender,arg)
	StateManager:getCurrentState():onDrag(sender,arg)
end

function InputEvent.onDrop(sender,arg)
	StateManager:getCurrentState():onDrop(sender,arg)
end


NGUIEvent.onPressFn=InputEvent.onPress
NGUIEvent.onClickFn=InputEvent.onClick
NGUIEvent.onDragFn=InputEvent.onDrag
NGUIEvent.onDropFn=InputEvent.onDrop
