local MakeLongTongue = Class(EdibleEffect, function(self)
	EdibleEffect._ctor(self)
	self.name = "MakeLongTongue"

	self.life = TUNING.HUGULA_TONGUE_LONG_TIME
end)
LuaComponents:Add("MakeLongTongue",MakeLongTongue)
--------------------------------------------------
local function resetTongue(mouth)
	mouth.tongueLen = TUNING.HUGULA_TONGUE_DEFAULT
end

function MakeLongTongue:onEatted(mouth)
	mouth.tongueLen = TUNING.HUGULA_TONGUE_LONG

	DelayDo:Add(resetTongue,mouth.longTongueTime,mouth)
end
--------------------------------------------------
