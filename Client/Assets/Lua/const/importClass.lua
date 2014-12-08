local luanet=luanet
UnityEngine=luanet.UnityEngine
local UnityEngine = UnityEngine
----------------------global-------------------------
GameObject=UnityEngine.GameObject
Vector3=UnityEngine.Vector3
Quaternion = UnityEngine.Quaternion
-----------------------init---------------------------

-- local   tolua1 = luanet.import_type("CUtils")
--         tolua1 = luanet.import_type("LuaHelper")
--         tolua1 = luanet.import_type("Localization")
-- local tolua11 = luanet.ReferGameObjects
-- local tolua12 =luanet.UnityEngine.MonoBehaviour
-- local tolua13 =luanet.UnityEngine.Random
-- local tolua14 =luanet.UnityEngine.Time 
-- ----------------------leantween--------------------------
-- local tolua14=luanet.LeanTween
-- local tolua14=luanet.LTBezier
-- local tolua14=luanet.LTBezierPath
-- local tolua14=luanet.LTDescr
-- local tolua14=luanet.LTSpline

iTween = luanet.import_type("iTween")
LeanTweenType=luanet.LeanTweenType

------------------------------static 变量---------------------------
LeanTween=toluacs.LeanTween
Random = toluacs.UnityEngine.Random
CUtils=toluacs.CUtils --luanet.import_type("CUtils") -- --LCUtils --
LuaHelper=toluacs.LuaHelper --LLuaHelper --luanet.import_type("LuaHelper")
toluaiTween=toluacs.iTween

-- PLua = luanet.import_type("PLua")
NetChat=luanet.import_type("LNet").ChatInstance
Net=luanet.import_type("LNet").instance
Msg=luanet.import_type("Msg")
Request=luanet.import_type("LRequest")
FileUtils=luanet.import_type("FileUtils")


-----------------------------toluacs import-----------------------------------
-- local luanet = luanet
-- local tolua0 = luanet.RoleActor
-- local tolua1 = luanet.RoleSkill
-- local tolua2 = luanet.RoleAnimator
-- local tolua3 = luanet.RoleProperty
-- local tolua4 = luanet.RoleSlider
-- local tolua5 = luanet.PrefabPool
-- local tolua6 = luanet.BuffAction
-- local tolua7 = luanet.BuffHelper
-- local tolua8 = luanet.MapCamera
-- local tolua9 = luanet.SkillData
-- local tolua10 = luanet.BuffData
-- local tolua10 = luanet.HeroBrain
-- local BTInput = luanet.BTInput
-- local BTOutput = luanet.BTOutput

local ConditionNodes = luanet.ConditionNodes
local ActionNodes = luanet.ActionNodes
---------------------------------NGUI--------------------------
-- local tolua = luanet.UIPanelCamackTable
-- 	tolua = luanet.UIEventLuaTrigger
-- 	tolua = luanet.NGUIEvent
-- 	tolua = luanet.ActivateMonos

local LocalizationMy = toluacs.Localization
--获取语言包内容
function getValue(key)
    return LocalizationMy.Get(key)
end