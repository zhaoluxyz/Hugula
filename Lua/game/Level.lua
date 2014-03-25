
Level = Class( function(self, id)
    self.id = id 
	self.setting = LevelSetting[id]

	self.isPause = false


	
end)

-----------------------------------------------
function Level:preload()

end

function Level:build()
	print("BuildLevel "..self.id)
end

function Level:start()
	print("StartLevel "..self.id)
end

function Level:pause()
	print("PauseLevel "..self.id)
end

function Level:resume()
	print("ResumeLevel "..self.id)
end







