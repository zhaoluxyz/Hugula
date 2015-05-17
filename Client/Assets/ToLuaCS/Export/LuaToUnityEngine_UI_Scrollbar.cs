using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Scrollbar {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Scrollbar);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_handleRect", get_handleRect);
           ToLuaCS.AddMember(L, "set_handleRect", set_handleRect);
           ToLuaCS.AddMember(L, "get_direction", get_direction);
           ToLuaCS.AddMember(L, "set_direction", set_direction);
           ToLuaCS.AddMember(L, "get_value", get_value);
           ToLuaCS.AddMember(L, "set_value", set_value);
           ToLuaCS.AddMember(L, "get_size", get_size);
           ToLuaCS.AddMember(L, "set_size", set_size);
           ToLuaCS.AddMember(L, "get_numberOfSteps", get_numberOfSteps);
           ToLuaCS.AddMember(L, "set_numberOfSteps", set_numberOfSteps);
           ToLuaCS.AddMember(L, "get_onValueChanged", get_onValueChanged);
           ToLuaCS.AddMember(L, "set_onValueChanged", set_onValueChanged);
           ToLuaCS.AddMember(L, "Rebuild", Rebuild);
           ToLuaCS.AddMember(L, "OnBeginDrag", OnBeginDrag);
           ToLuaCS.AddMember(L, "OnDrag", OnDrag);
           ToLuaCS.AddMember(L, "OnPointerDown", OnPointerDown);
           ToLuaCS.AddMember(L, "OnPointerUp", OnPointerUp);
           ToLuaCS.AddMember(L, "OnMove", OnMove);
           ToLuaCS.AddMember(L, "FindSelectableOnLeft", FindSelectableOnLeft);
           ToLuaCS.AddMember(L, "FindSelectableOnRight", FindSelectableOnRight);
           ToLuaCS.AddMember(L, "FindSelectableOnUp", FindSelectableOnUp);
           ToLuaCS.AddMember(L, "FindSelectableOnDown", FindSelectableOnDown);
           ToLuaCS.AddMember(L, "OnInitializePotentialDrag", OnInitializePotentialDrag);
           ToLuaCS.AddMember(L, "SetDirection", SetDirection);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_handleRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.RectTransform handleRect= target.handleRect;
                  ToLuaCS.push(L,handleRect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_handleRect(LuaState L)
          {
                  UnityEngine.RectTransform value_ = (UnityEngine.RectTransform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.handleRect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_direction(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Scrollbar.Direction direction= target.direction;
                  ToLuaCS.push(L,direction);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_direction(LuaState L)
          {
                  UnityEngine.UI.Scrollbar.Direction value_ = (UnityEngine.UI.Scrollbar.Direction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.direction= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_value(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  System.Single value= target.value;
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_value(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.value= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_size(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  System.Single size= target.size;
                  LuaDLL.lua_pushnumber(L, size);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_size(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.size= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_numberOfSteps(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  System.Int32 numberOfSteps= target.numberOfSteps;
                  LuaDLL.lua_pushnumber(L, numberOfSteps);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_numberOfSteps(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.numberOfSteps= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onValueChanged(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Scrollbar.ScrollEvent onValueChanged= target.onValueChanged;
                  ToLuaCS.push(L,onValueChanged);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onValueChanged(LuaState L)
          {
                  UnityEngine.UI.Scrollbar.ScrollEvent value_ = (UnityEngine.UI.Scrollbar.ScrollEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.onValueChanged= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rebuild(LuaState L)
          {
                  UnityEngine.UI.CanvasUpdate executing_ = (UnityEngine.UI.CanvasUpdate)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.Rebuild( executing_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnBeginDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnBeginDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerDown(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnPointerDown( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerUp(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnPointerUp( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnMove(LuaState L)
          {
                  UnityEngine.EventSystems.AxisEventData eventData_ = (UnityEngine.EventSystems.AxisEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnMove( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnLeft(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Selectable findselectableonleft= target.FindSelectableOnLeft();
                  ToLuaCS.push(L,findselectableonleft);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnRight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Selectable findselectableonright= target.FindSelectableOnRight();
                  ToLuaCS.push(L,findselectableonright);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnUp(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Selectable findselectableonup= target.FindSelectableOnUp();
                  ToLuaCS.push(L,findselectableonup);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnDown(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  UnityEngine.UI.Selectable findselectableondown= target.FindSelectableOnDown();
                  ToLuaCS.push(L,findselectableondown);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnInitializePotentialDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.OnInitializePotentialDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetDirection(LuaState L)
          {
                  UnityEngine.UI.Scrollbar.Direction direction_ = (UnityEngine.UI.Scrollbar.Direction)ToLuaCS.getObject(L, 2);
                  System.Boolean includeRectLayouts_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Scrollbar target= (UnityEngine.UI.Scrollbar) original ;
                  target.SetDirection( direction_, includeRectLayouts_);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

