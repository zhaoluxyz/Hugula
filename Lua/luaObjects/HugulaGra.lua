local animation

HugulaGra = Class(LuaObject, function(self)
    LuaObject._ctor(self, "hugula")  

    self.graphic = self.gameObject.transform:FindChild("hugulaGra").gameObject
    animation = self.graphic.animation
end)

function HugulaGra:play(animationName)
	animation:Play(animationName)
end

function HugulaGra:lookToTarget(transform,time)
	Tweener.addTweener(self.gameObject,"LookTo",{looktarget=transform,axis="xyz",time=time})
end

function HugulaGra:stop()
	animation:Stop()
end

