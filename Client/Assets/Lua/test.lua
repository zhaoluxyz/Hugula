require("core.unity3d")
require("core.loader")
json=require("lib/json")
print(" ---------------lua main ---------------------")


-- -- a,b = CPrint("aa")
-- --print(a)
-- function aa( ... )
-- 	print("hello aa")
-- end
-- delay(aa,1,nil)

-- local ostime=os.clock()
-- for i=1,1000 do
-- 	-- CPrint("lua print")
-- 	-- print("lua print")
-- end
-- local end1 =os.clock()
-- local dt = end1-ostime
-- print(dt)
 return function(buffAction,args)
 local owner,target,skill,buff=buffAction.actor,buffAction.target,buffAction.skill,buffAction.buff
    local fxs = buff.model
    print(buff.name)
    print(buff.model)
    print(fxs)
    local clone = PrefabPool:GetCache(fxs[0])
    LuaHelper.SetParent(clone.gameObject,owner.gameObject)
    clone:SetActive(true)
    buffAction:AddCache(fxs[0],clone.gameObject)
 end

  return function(buffAction,args)
    local owner,target,skill,buff=buffAction.actor,buffAction.target,buffAction.skill,buffAction.buff
    local fxs = buff.model
    local clone=buffAction:GetCache(fxs[0])
    clone:SetActive(false)
 end