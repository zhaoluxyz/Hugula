using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCEventReceive {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CEventReceive);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "OnPointerDown", OnPointerDown);
           ToLuaCS.AddMember(L, "OnPointerUp", OnPointerUp);
           ToLuaCS.AddMember(L, "OnBeginDrag", OnBeginDrag);
           ToLuaCS.AddMember(L, "OnDrag", OnDrag);
           ToLuaCS.AddMember(L, "OnDrop", OnDrop);
           ToLuaCS.AddMember(L, "OnPointerClick", OnPointerClick);
           ToLuaCS.AddMember(L, "OnSelect", OnSelect);
           ToLuaCS.AddMember(L, "OnCancel", OnCancel);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _ceventreceive);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerDown(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnPointerDown( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerUp(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnPointerUp( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnBeginDrag(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnBeginDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDrag(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDrop(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnDrop( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerClick(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnPointerClick( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSelect(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnSelect( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnCancel(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CEventReceive target= (CEventReceive) original ;
                  target.OnCancel( eventData_);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _ceventreceive(LuaState L)
          {

                  CEventReceive _ceventreceive= new CEventReceive();
                  ToLuaCS.push(L,_ceventreceive);
                  return 1;

          }
  #endregion       
}

