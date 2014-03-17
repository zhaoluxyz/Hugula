InputMan = LuaObject()
InputMan.gameObject.name = "Input"
-------------------------------------------
Event.MOUSE_DOWN = "mouseDown"
Event.MOUSE_UP = "mouseUp"
-------------------------------------------
function InputMan:Update()
	if Input.GetMouseButtonDown(0) then
		Event:DispatchEvent(Event.MOUSE_DOWN,Input.mousePosition)
	elseif Input.GetMouseButtonUp(0) then
		Event:DispatchEvent(Event.MOUSE_UP,Input.mousePosition)
	end
end

