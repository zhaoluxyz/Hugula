using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Slider {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Slider);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_fillRect", get_fillRect);
           ToLuaCS.AddMember(L, "set_fillRect", set_fillRect);
           ToLuaCS.AddMember(L, "get_handleRect", get_handleRect);
           ToLuaCS.AddMember(L, "set_handleRect", set_handleRect);
           ToLuaCS.AddMember(L, "get_direction", get_direction);
           ToLuaCS.AddMember(L, "set_direction", set_direction);
           ToLuaCS.AddMember(L, "get_minValue", get_minValue);
           ToLuaCS.AddMember(L, "set_minValue", set_minValue);
           ToLuaCS.AddMember(L, "get_maxValue", get_maxValue);
           ToLuaCS.AddMember(L, "set_maxValue", set_maxValue);
           ToLuaCS.AddMember(L, "get_wholeNumbers", get_wholeNumbers);
           ToLuaCS.AddMember(L, "set_wholeNumbers", set_wholeNumbers);
           ToLuaCS.AddMember(L, "get_value", get_value);
           ToLuaCS.AddMember(L, "set_value", set_value);
           ToLuaCS.AddMember(L, "get_normalizedValue", get_normalizedValue);
           ToLuaCS.AddMember(L, "set_normalizedValue", set_normalizedValue);
           ToLuaCS.AddMember(L, "get_onValueChanged", get_onValueChanged);
           ToLuaCS.AddMember(L, "set_onValueChanged", set_onValueChanged);
           ToLuaCS.AddMember(L, "Rebuild", Rebuild);
           ToLuaCS.AddMember(L, "OnPointerDown", OnPointerDown);
           ToLuaCS.AddMember(L, "OnDrag", OnDrag);
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
          public static int get_fillRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.RectTransform fillRect= target.fillRect;
                  ToLuaCS.push(L,fillRect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillRect(LuaState L)
          {
                  UnityEngine.RectTransform value_ = (UnityEngine.RectTransform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.fillRect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_handleRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.RectTransform handleRect= target.handleRect;
                  ToLuaCS.push(L,handleRect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_handleRect(LuaState L)
          {
                  UnityEngine.RectTransform value_ = (UnityEngine.RectTransform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.handleRect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_direction(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Slider.Direction direction= target.direction;
                  ToLuaCS.push(L,direction);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_direction(LuaState L)
          {
                  UnityEngine.UI.Slider.Direction value_ = (UnityEngine.UI.Slider.Direction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.direction= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_minValue(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  System.Single minValue= target.minValue;
                  LuaDLL.lua_pushnumber(L, minValue);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_minValue(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.minValue= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maxValue(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  System.Single maxValue= target.maxValue;
                  LuaDLL.lua_pushnumber(L, maxValue);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_maxValue(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.maxValue= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_wholeNumbers(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  System.Boolean wholeNumbers= target.wholeNumbers;
                  LuaDLL.lua_pushboolean(L,wholeNumbers);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_wholeNumbers(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.wholeNumbers= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_value(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  System.Single value= target.value;
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_value(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.value= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_normalizedValue(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  System.Single normalizedValue= target.normalizedValue;
                  LuaDLL.lua_pushnumber(L, normalizedValue);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_normalizedValue(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.normalizedValue= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onValueChanged(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Slider.SliderEvent onValueChanged= target.onValueChanged;
                  ToLuaCS.push(L,onValueChanged);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onValueChanged(LuaState L)
          {
                  UnityEngine.UI.Slider.SliderEvent value_ = (UnityEngine.UI.Slider.SliderEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.onValueChanged= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rebuild(LuaState L)
          {
                  UnityEngine.UI.CanvasUpdate executing_ = (UnityEngine.UI.CanvasUpdate)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.Rebuild( executing_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerDown(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.OnPointerDown( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.OnDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnMove(LuaState L)
          {
                  UnityEngine.EventSystems.AxisEventData eventData_ = (UnityEngine.EventSystems.AxisEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.OnMove( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnLeft(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Selectable findselectableonleft= target.FindSelectableOnLeft();
                  ToLuaCS.push(L,findselectableonleft);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnRight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Selectable findselectableonright= target.FindSelectableOnRight();
                  ToLuaCS.push(L,findselectableonright);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnUp(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Selectable findselectableonup= target.FindSelectableOnUp();
                  ToLuaCS.push(L,findselectableonup);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnDown(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  UnityEngine.UI.Selectable findselectableondown= target.FindSelectableOnDown();
                  ToLuaCS.push(L,findselectableondown);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnInitializePotentialDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.OnInitializePotentialDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetDirection(LuaState L)
          {
                  UnityEngine.UI.Slider.Direction direction_ = (UnityEngine.UI.Slider.Direction)ToLuaCS.getObject(L, 2);
                  System.Boolean includeRectLayouts_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Slider target= (UnityEngine.UI.Slider) original ;
                  target.SetDirection( direction_, includeRectLayouts_);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

