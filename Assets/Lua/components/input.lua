local UInput=UnityEngine.Input
local Vector3=UnityEngine.Vector3
local KeyCode=UnityEngine.KeyCode
local Mathf=UnityEngine.Mathf
local Random=UnityEngine.Random
local Quaternion = UnityEngine.Quaternion
local Time=UnityEngine.Time
local LuaHelper=LuaHelper
local Vector2 = UnityEngine.Vector2
local Vector3Helper = luanet.import_type("Vector3Helper")
local RuntimePlatform = UnityEngine.RuntimePlatform
local Application = UnityEngine.Application
local TouchPhase = UnityEngine.TouchPhase

local touchClickThreshold = 0.04
local startPos,directionChosen,direction
local beginTime,clickDt

local Input=class(function(self,luaObj)
	self.luaObj=luaObj
	self.enable = true
end)

function Input:onUpdate(time)
	if UInput.touchCount > 0  then
		local touch = UInput.GetTouch(0)
		
		if touch then
			-- Handle finger movements based on touch phase.
			if touch.phase ==TouchPhase.Began then
				-- Record initial touch position.
					startPos = touch.position;
					beginTime=time
					--directionChosen = false;
					-- print("onPress down "..tostring(beginTime))
					self.luaObj:sendMessage("onPress",true)
			elseif touch.phase == TouchPhase.Moved then
				-- Determine direction by comparing the current touch
				--position with the initial one.
					--direction = Vector3Helper(touch.position,startPos)
					--print(direction)
				--Report that a direction has been chosen when the finger is lifted.
			elseif	touch.phase == TouchPhase.Ended then
					self.luaObj:sendMessage("onPress",false)
					clickDt=time - beginTime
					if clickDt>touchClickThreshold and startPos==touch.position then
						-- print("onClick event "..tostring(clickDt))
						self.luaObj:sendMessage("onClick")
					else
						-- print(startPos)
						-- print(touch.position) --Math.Atan2(v2.y - v1.y, v2.x - v1.x) / Math.PI * 180
						direction = math.atan2(startPos.y-touch.position.y,startPos.x-touch.position.x)/ math.pi * 180 --Vector2.Angle(startPos,touch.position)--Vector3Helper.Subtracts(startPos,touch.position)
						self.luaObj:sendMessage("onTouch",direction,touch.position)
					end
			end
		end
	end
end


return Input