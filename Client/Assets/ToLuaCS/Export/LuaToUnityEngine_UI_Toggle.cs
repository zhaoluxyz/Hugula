using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Toggle {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Toggle);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_group", get_group);
           ToLuaCS.AddMember(L, "set_group", set_group);
           ToLuaCS.AddMember(L, "Rebuild", Rebuild);
           ToLuaCS.AddMember(L, "get_isOn", get_isOn);
           ToLuaCS.AddMember(L, "set_isOn", set_isOn);
           ToLuaCS.AddMember(L, "OnPointerClick", OnPointerClick);
           ToLuaCS.AddMember(L, "OnSubmit", OnSubmit);
           ToLuaCS.AddMember(L, "get_toggleTransition", get_toggleTransition);
           ToLuaCS.AddMember(L, "set_toggleTransition", set_toggleTransition);
           ToLuaCS.AddMember(L, "get_graphic", get_graphic);
           ToLuaCS.AddMember(L, "set_graphic", set_graphic);
           ToLuaCS.AddMember(L, "get_onValueChanged", get_onValueChanged);
           ToLuaCS.AddMember(L, "set_onValueChanged", set_onValueChanged);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_group(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  UnityEngine.UI.ToggleGroup group= target.group;
                  ToLuaCS.push(L,group);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_group(LuaState L)
          {
                  UnityEngine.UI.ToggleGroup value_ = (UnityEngine.UI.ToggleGroup)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  target.group= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rebuild(LuaState L)
          {
                  UnityEngine.UI.CanvasUpdate executing_ = (UnityEngine.UI.CanvasUpdate)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  target.Rebuild( executing_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isOn(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  System.Boolean isOn= target.isOn;
                  LuaDLL.lua_pushboolean(L,isOn);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isOn(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  target.isOn= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerClick(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  target.OnPointerClick( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSubmit(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  target.OnSubmit( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_toggleTransition(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  var val=  target.toggleTransition;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_toggleTransition(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.toggleTransition= (UnityEngine.UI.Toggle.ToggleTransition)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_graphic(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  var val=  target.graphic;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_graphic(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.graphic= (UnityEngine.UI.Graphic)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onValueChanged(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original ;
                  var val=  target.onValueChanged;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onValueChanged(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Toggle target= (UnityEngine.UI.Toggle) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onValueChanged= (UnityEngine.UI.Toggle.ToggleEvent)val;
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

