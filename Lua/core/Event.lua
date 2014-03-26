
local eventMan = Class( function(self)
    self.events = {}
end)
------------------------------------------
Event = eventMan()
------------------------------------------
function eventMan:AddEvent(eventName, callBack, receiver)
	if eventName and callBack then
		if not self.events[eventName] then
			self.events[eventName] = {}
		end

		local event = {callBack = callBack,receiver = receiver}
		table.insert(self.events[eventName],event)
	end
end

function eventMan:RevomeEvent(eventName, callBack, receiver)
	if self.events[eventName] then
		for i,event in ipairs(self.events[eventName]) do
			if event.callBack == callBack and event.receiver == receiver then
				table.remove(self.events[eventName],i)
			end
		end
	end
end

function eventMan:DispatchEvent(eventName, value, receiver)
	if self.events[eventName] then
		for i,event in ipairs(self.events[eventName]) do
			event.data = value

			if receiver and event.receiver==receiver then
				print("event 1")
				event.callBack(receiver,event)
			elseif not receiver then
				if event.receiver then
					print("event 2")
					event.callBack(event.receiver,event)
				else
					print("event 3")
					event.callBack(event)
				end
			end
		end
	end
end

