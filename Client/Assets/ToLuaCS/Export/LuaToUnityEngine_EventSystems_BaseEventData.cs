using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_EventSystems_BaseEventData {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.EventSystems.BaseEventData);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Reset", Reset);
           ToLuaCS.AddMember(L, "Use", Use);
           ToLuaCS.AddMember(L, "get_used", get_used);
           ToLuaCS.AddMember(L, "get_currentInputModule", get_currentInputModule);
           ToLuaCS.AddMember(L, "get_selectedObject", get_selectedObject);
           ToLuaCS.AddMember(L, "set_selectedObject", set_selectedObject);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _baseeventdata);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Reset(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  target.Reset();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Use(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  target.Use();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_used(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  System.Boolean used= target.used;
                  LuaDLL.lua_pushboolean(L,used);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentInputModule(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  UnityEngine.EventSystems.BaseInputModule currentInputModule= target.currentInputModule;
                  ToLuaCS.push(L,currentInputModule);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_selectedObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  UnityEngine.GameObject selectedObject= target.selectedObject;
                  ToLuaCS.push(L,selectedObject);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_selectedObject(LuaState L)
          {
                  UnityEngine.GameObject value_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.BaseEventData target= (UnityEngine.EventSystems.BaseEventData) original ;
                  target.selectedObject= value_;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _baseeventdata(LuaState L)
          {
                  UnityEngine.EventSystems.EventSystem eventSystem_ = (UnityEngine.EventSystems.EventSystem)ToLuaCS.getObject(L, 1);

                  UnityEngine.EventSystems.BaseEventData _baseeventdata= new UnityEngine.EventSystems.BaseEventData( eventSystem_);
                  ToLuaCS.push(L,_baseeventdata);
                  return 1;

          }
  #endregion       
}

