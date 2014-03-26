DelayDo = LuaObject()
DelayDo.gameObject.name = "DelayDo"

DelayDo.isPause = nil
DelayDo.plusTime = 0
DelayDo.callbacks = {}
--------------------------------------------------------------------

function DelayDo:Add(callback,delayTime,callbackVal,dontPause)
	local data = {time=Time.time, delay=delayTime, callback=callback, callbackVal=callbackVal, dontPause=dontPause, plusTime=0}
	table.insert(self.callbacks,data)
end

function DelayDo:Remove(callback)
	for i,data in ipairs(self.callbacks) do 
		if data.callback == callback then
			table.remove(self.callbacks,i)
		end
	end
end

function DelayDo:Pause()
	self.isPause = Time.time
	self.time = self.time + (self.isPause - self.time)
end

function DelayDo:Resume()
	local plusTime = Time.time - self.isPause

	for i,data in ipairs(self.callbacks) do
		data.plusTime = data.plusTime+plusTime
	end

	self.isPause = nil
end

function DelayDo:Update()
	if #self.callbacks>0 then
		local cTime = Time.time
		for i,data in ipairs(self.callbacks) do
			if not self.isPause or data.dontPause then
				if cTime-data.time>(data.delay+data.plusTime) then
					data.callback(data.callbackVal)
					table.remove(self.callbacks,i)
				end
			end
		end
	end
end