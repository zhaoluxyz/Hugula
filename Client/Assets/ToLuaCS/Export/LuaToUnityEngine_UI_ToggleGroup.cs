using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_ToggleGroup {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.ToggleGroup);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_allowSwitchOff", get_allowSwitchOff);
           ToLuaCS.AddMember(L, "set_allowSwitchOff", set_allowSwitchOff);
           ToLuaCS.AddMember(L, "NotifyToggleOn", NotifyToggleOn);
           ToLuaCS.AddMember(L, "UnregisterToggle", UnregisterToggle);
           ToLuaCS.AddMember(L, "RegisterToggle", RegisterToggle);
           ToLuaCS.AddMember(L, "AnyTogglesOn", AnyTogglesOn);
           ToLuaCS.AddMember(L, "ActiveToggles", ActiveToggles);
           ToLuaCS.AddMember(L, "SetAllTogglesOff", SetAllTogglesOff);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_allowSwitchOff(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  System.Boolean allowSwitchOff= target.allowSwitchOff;
                  LuaDLL.lua_pushboolean(L,allowSwitchOff);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_allowSwitchOff(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  target.allowSwitchOff= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int NotifyToggleOn(LuaState L)
          {
                  UnityEngine.UI.Toggle toggle_ = (UnityEngine.UI.Toggle)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  target.NotifyToggleOn( toggle_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnregisterToggle(LuaState L)
          {
                  UnityEngine.UI.Toggle toggle_ = (UnityEngine.UI.Toggle)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  target.UnregisterToggle( toggle_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterToggle(LuaState L)
          {
                  UnityEngine.UI.Toggle toggle_ = (UnityEngine.UI.Toggle)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  target.RegisterToggle( toggle_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AnyTogglesOn(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  System.Boolean anytoggleson= target.AnyTogglesOn();
                  LuaDLL.lua_pushboolean(L,anytoggleson);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ActiveToggles(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  System.Collections.Generic.IEnumerable<UnityEngine.UI.Toggle> activetoggles= target.ActiveToggles();
                  ToLuaCS.push(L,activetoggles);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAllTogglesOff(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.ToggleGroup target= (UnityEngine.UI.ToggleGroup) original ;
                  target.SetAllTogglesOff();
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

