local animation

HugulaGra = Class(LuaObject, function(self)
    LuaObject._ctor(self, "hugula")  

    animation = self.gameObject.transform:FindChild("hugulaGra").animation
end)

function HugulaGra:play(animationName)
	animation:Play(animationName)
end

function HugulaGra:stop()
	animation:Stop()
end

