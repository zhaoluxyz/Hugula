using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Button {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Button);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_onClick", get_onClick);
           ToLuaCS.AddMember(L, "set_onClick", set_onClick);
           ToLuaCS.AddMember(L, "OnPointerClick", OnPointerClick);
           ToLuaCS.AddMember(L, "OnSubmit", OnSubmit);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onClick(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Button target= (UnityEngine.UI.Button) original ;
                  UnityEngine.UI.Button.ButtonClickedEvent onClick= target.onClick;
                  ToLuaCS.push(L,onClick);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onClick(LuaState L)
          {
                  UnityEngine.UI.Button.ButtonClickedEvent value_ = (UnityEngine.UI.Button.ButtonClickedEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Button target= (UnityEngine.UI.Button) original ;
                  target.onClick= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerClick(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Button target= (UnityEngine.UI.Button) original ;
                  target.OnPointerClick( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSubmit(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Button target= (UnityEngine.UI.Button) original ;
                  target.OnSubmit( eventData_);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

