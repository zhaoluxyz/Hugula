using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUGUIEventSystem {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UGUIEventSystem);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_eventSystem", get_eventSystem);
           ToLuaCS.AddMember(L, "set_eventSystem", set_eventSystem);
           ToLuaCS.AddMember(L, "get_standaloneInputModule", get_standaloneInputModule);
           ToLuaCS.AddMember(L, "set_standaloneInputModule", set_standaloneInputModule);
           ToLuaCS.AddMember(L, "get_touchInputModule", get_touchInputModule);
           ToLuaCS.AddMember(L, "set_touchInputModule", set_touchInputModule);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _uguieventsystem);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eventSystem(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original ;
                  var val=  target.eventSystem;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eventSystem(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.eventSystem= (UnityEngine.EventSystems.EventSystem)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_standaloneInputModule(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original ;
                  var val=  target.standaloneInputModule;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_standaloneInputModule(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.standaloneInputModule= (UnityEngine.EventSystems.StandaloneInputModule)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_touchInputModule(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original ;
                  var val=  target.touchInputModule;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_touchInputModule(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUIEventSystem target= (UGUIEventSystem) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.touchInputModule= (UnityEngine.EventSystems.TouchInputModule)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _uguieventsystem(LuaState L)
          {

                  UGUIEventSystem _uguieventsystem= new UGUIEventSystem();
                  ToLuaCS.push(L,_uguieventsystem);
                  return 1;

          }
  #endregion       
}

