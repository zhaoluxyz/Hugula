using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_CanvasScaler {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.CanvasScaler);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_uiScaleMode", get_uiScaleMode);
           ToLuaCS.AddMember(L, "set_uiScaleMode", set_uiScaleMode);
           ToLuaCS.AddMember(L, "get_referencePixelsPerUnit", get_referencePixelsPerUnit);
           ToLuaCS.AddMember(L, "set_referencePixelsPerUnit", set_referencePixelsPerUnit);
           ToLuaCS.AddMember(L, "get_scaleFactor", get_scaleFactor);
           ToLuaCS.AddMember(L, "set_scaleFactor", set_scaleFactor);
           ToLuaCS.AddMember(L, "get_referenceResolution", get_referenceResolution);
           ToLuaCS.AddMember(L, "set_referenceResolution", set_referenceResolution);
           ToLuaCS.AddMember(L, "get_screenMatchMode", get_screenMatchMode);
           ToLuaCS.AddMember(L, "set_screenMatchMode", set_screenMatchMode);
           ToLuaCS.AddMember(L, "get_matchWidthOrHeight", get_matchWidthOrHeight);
           ToLuaCS.AddMember(L, "set_matchWidthOrHeight", set_matchWidthOrHeight);
           ToLuaCS.AddMember(L, "get_physicalUnit", get_physicalUnit);
           ToLuaCS.AddMember(L, "set_physicalUnit", set_physicalUnit);
           ToLuaCS.AddMember(L, "get_fallbackScreenDPI", get_fallbackScreenDPI);
           ToLuaCS.AddMember(L, "set_fallbackScreenDPI", set_fallbackScreenDPI);
           ToLuaCS.AddMember(L, "get_defaultSpriteDPI", get_defaultSpriteDPI);
           ToLuaCS.AddMember(L, "set_defaultSpriteDPI", set_defaultSpriteDPI);
           ToLuaCS.AddMember(L, "get_dynamicPixelsPerUnit", get_dynamicPixelsPerUnit);
           ToLuaCS.AddMember(L, "set_dynamicPixelsPerUnit", set_dynamicPixelsPerUnit);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_uiScaleMode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  UnityEngine.UI.CanvasScaler.ScaleMode uiScaleMode= target.uiScaleMode;
                  ToLuaCS.push(L,uiScaleMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_uiScaleMode(LuaState L)
          {
                  UnityEngine.UI.CanvasScaler.ScaleMode value_ = (UnityEngine.UI.CanvasScaler.ScaleMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.uiScaleMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_referencePixelsPerUnit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single referencePixelsPerUnit= target.referencePixelsPerUnit;
                  LuaDLL.lua_pushnumber(L, referencePixelsPerUnit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_referencePixelsPerUnit(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.referencePixelsPerUnit= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_scaleFactor(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single scaleFactor= target.scaleFactor;
                  LuaDLL.lua_pushnumber(L, scaleFactor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_scaleFactor(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.scaleFactor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_referenceResolution(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  UnityEngine.Vector2 referenceResolution= target.referenceResolution;
                  ToLuaCS.push(L,referenceResolution);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_referenceResolution(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.referenceResolution= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_screenMatchMode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  UnityEngine.UI.CanvasScaler.ScreenMatchMode screenMatchMode= target.screenMatchMode;
                  ToLuaCS.push(L,screenMatchMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_screenMatchMode(LuaState L)
          {
                  UnityEngine.UI.CanvasScaler.ScreenMatchMode value_ = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.screenMatchMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_matchWidthOrHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single matchWidthOrHeight= target.matchWidthOrHeight;
                  LuaDLL.lua_pushnumber(L, matchWidthOrHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_matchWidthOrHeight(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.matchWidthOrHeight= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_physicalUnit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  UnityEngine.UI.CanvasScaler.Unit physicalUnit= target.physicalUnit;
                  ToLuaCS.push(L,physicalUnit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_physicalUnit(LuaState L)
          {
                  UnityEngine.UI.CanvasScaler.Unit value_ = (UnityEngine.UI.CanvasScaler.Unit)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.physicalUnit= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fallbackScreenDPI(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single fallbackScreenDPI= target.fallbackScreenDPI;
                  LuaDLL.lua_pushnumber(L, fallbackScreenDPI);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fallbackScreenDPI(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.fallbackScreenDPI= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultSpriteDPI(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single defaultSpriteDPI= target.defaultSpriteDPI;
                  LuaDLL.lua_pushnumber(L, defaultSpriteDPI);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_defaultSpriteDPI(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.defaultSpriteDPI= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dynamicPixelsPerUnit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  System.Single dynamicPixelsPerUnit= target.dynamicPixelsPerUnit;
                  LuaDLL.lua_pushnumber(L, dynamicPixelsPerUnit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dynamicPixelsPerUnit(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.CanvasScaler target= (UnityEngine.UI.CanvasScaler) original ;
                  target.dynamicPixelsPerUnit= value_;
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

