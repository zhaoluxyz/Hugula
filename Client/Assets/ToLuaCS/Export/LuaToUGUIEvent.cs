using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUGUIEvent {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UGUIEvent);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "onCustomerHandle", onCustomerHandle);

           ToLuaCS.AddMember(L, "onPressHandle", onPressHandle);

           ToLuaCS.AddMember(L, "onClickHandle", onClickHandle);

           ToLuaCS.AddMember(L, "onDragHandle", onDragHandle);

           ToLuaCS.AddMember(L, "onDropHandle", onDropHandle);

           ToLuaCS.AddMember(L, "onSelectHandle", onSelectHandle);

           ToLuaCS.AddMember(L, "onCancelHandle", onCancelHandle);

           ToLuaCS.AddMember(L, "get_onCustomerFn", get_onCustomerFn);

           ToLuaCS.AddMember(L, "set_onCustomerFn", set_onCustomerFn);

           ToLuaCS.AddMember(L, "get_onPressFn", get_onPressFn);

           ToLuaCS.AddMember(L, "set_onPressFn", set_onPressFn);

           ToLuaCS.AddMember(L, "get_onClickFn", get_onClickFn);

           ToLuaCS.AddMember(L, "set_onClickFn", set_onClickFn);

           ToLuaCS.AddMember(L, "get_onDragFn", get_onDragFn);

           ToLuaCS.AddMember(L, "set_onDragFn", set_onDragFn);

           ToLuaCS.AddMember(L, "get_onDropFn", get_onDropFn);

           ToLuaCS.AddMember(L, "set_onDropFn", set_onDropFn);

           ToLuaCS.AddMember(L, "get_onSelectFn", get_onSelectFn);

           ToLuaCS.AddMember(L, "set_onSelectFn", set_onSelectFn);

           ToLuaCS.AddMember(L, "get_onCancelFn", get_onCancelFn);

           ToLuaCS.AddMember(L, "set_onCancelFn", set_onCancelFn);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onCustomerHandle(LuaState L)
          {
                  System.Object sender_ = (System.Object)ToLuaCS.getObject(L, 1);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 2);

                  UGUIEvent.onCustomerHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onPressHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean arg_ =  LuaDLL.lua_toboolean(L,2);

                  UGUIEvent.onPressHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onClickHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 2);

                  UGUIEvent.onClickHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onDragHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 arg_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                  UGUIEvent.onDragHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onDropHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 2);

                  UGUIEvent.onDropHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onSelectHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 2);

                  UGUIEvent.onSelectHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onCancelHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 2);

                  UGUIEvent.onCancelHandle( sender_, arg_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCustomerFn(LuaState L)
          {
                  var val=   UGUIEvent.onCustomerFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCustomerFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onCustomerFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPressFn(LuaState L)
          {
                  var val=   UGUIEvent.onPressFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPressFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onPressFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onClickFn(LuaState L)
          {
                  var val=   UGUIEvent.onClickFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onClickFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onClickFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDragFn(LuaState L)
          {
                  var val=   UGUIEvent.onDragFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDragFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onDragFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDropFn(LuaState L)
          {
                  var val=   UGUIEvent.onDropFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDropFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onDropFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onSelectFn(LuaState L)
          {
                  var val=   UGUIEvent.onSelectFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onSelectFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onSelectFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCancelFn(LuaState L)
          {
                  var val=   UGUIEvent.onCancelFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCancelFn(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UGUIEvent.onCancelFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
}

