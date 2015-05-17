using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_EventSystems_PointerEventData {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.EventSystems.PointerEventData);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_pointerEnter", get_pointerEnter);
           ToLuaCS.AddMember(L, "set_pointerEnter", set_pointerEnter);
           ToLuaCS.AddMember(L, "get_lastPress", get_lastPress);
           ToLuaCS.AddMember(L, "get_rawPointerPress", get_rawPointerPress);
           ToLuaCS.AddMember(L, "set_rawPointerPress", set_rawPointerPress);
           ToLuaCS.AddMember(L, "get_pointerDrag", get_pointerDrag);
           ToLuaCS.AddMember(L, "set_pointerDrag", set_pointerDrag);
           ToLuaCS.AddMember(L, "get_pointerCurrentRaycast", get_pointerCurrentRaycast);
           ToLuaCS.AddMember(L, "set_pointerCurrentRaycast", set_pointerCurrentRaycast);
           ToLuaCS.AddMember(L, "get_pointerPressRaycast", get_pointerPressRaycast);
           ToLuaCS.AddMember(L, "set_pointerPressRaycast", set_pointerPressRaycast);
           ToLuaCS.AddMember(L, "get_eligibleForClick", get_eligibleForClick);
           ToLuaCS.AddMember(L, "set_eligibleForClick", set_eligibleForClick);
           ToLuaCS.AddMember(L, "get_pointerId", get_pointerId);
           ToLuaCS.AddMember(L, "set_pointerId", set_pointerId);
           ToLuaCS.AddMember(L, "get_position", get_position);
           ToLuaCS.AddMember(L, "set_position", set_position);
           ToLuaCS.AddMember(L, "get_delta", get_delta);
           ToLuaCS.AddMember(L, "set_delta", set_delta);
           ToLuaCS.AddMember(L, "get_pressPosition", get_pressPosition);
           ToLuaCS.AddMember(L, "set_pressPosition", set_pressPosition);
           ToLuaCS.AddMember(L, "get_worldPosition", get_worldPosition);
           ToLuaCS.AddMember(L, "set_worldPosition", set_worldPosition);
           ToLuaCS.AddMember(L, "get_worldNormal", get_worldNormal);
           ToLuaCS.AddMember(L, "set_worldNormal", set_worldNormal);
           ToLuaCS.AddMember(L, "get_clickTime", get_clickTime);
           ToLuaCS.AddMember(L, "set_clickTime", set_clickTime);
           ToLuaCS.AddMember(L, "get_clickCount", get_clickCount);
           ToLuaCS.AddMember(L, "set_clickCount", set_clickCount);
           ToLuaCS.AddMember(L, "get_scrollDelta", get_scrollDelta);
           ToLuaCS.AddMember(L, "set_scrollDelta", set_scrollDelta);
           ToLuaCS.AddMember(L, "get_useDragThreshold", get_useDragThreshold);
           ToLuaCS.AddMember(L, "set_useDragThreshold", set_useDragThreshold);
           ToLuaCS.AddMember(L, "get_dragging", get_dragging);
           ToLuaCS.AddMember(L, "set_dragging", set_dragging);
           ToLuaCS.AddMember(L, "get_button", get_button);
           ToLuaCS.AddMember(L, "set_button", set_button);
           ToLuaCS.AddMember(L, "IsPointerMoving", IsPointerMoving);
           ToLuaCS.AddMember(L, "IsScrolling", IsScrolling);
           ToLuaCS.AddMember(L, "get_enterEventCamera", get_enterEventCamera);
           ToLuaCS.AddMember(L, "get_pressEventCamera", get_pressEventCamera);
           ToLuaCS.AddMember(L, "get_pointerPress", get_pointerPress);
           ToLuaCS.AddMember(L, "set_pointerPress", set_pointerPress);
           ToLuaCS.AddMember(L, "ToString", ToString);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _pointereventdata);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerEnter(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.GameObject pointerEnter= target.pointerEnter;
                  ToLuaCS.push(L,pointerEnter);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerEnter(LuaState L)
          {
                  UnityEngine.GameObject value_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerEnter= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lastPress(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.GameObject lastPress= target.lastPress;
                  ToLuaCS.push(L,lastPress);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rawPointerPress(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.GameObject rawPointerPress= target.rawPointerPress;
                  ToLuaCS.push(L,rawPointerPress);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_rawPointerPress(LuaState L)
          {
                  UnityEngine.GameObject value_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.rawPointerPress= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerDrag(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.GameObject pointerDrag= target.pointerDrag;
                  ToLuaCS.push(L,pointerDrag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerDrag(LuaState L)
          {
                  UnityEngine.GameObject value_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerDrag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerCurrentRaycast(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.EventSystems.RaycastResult pointerCurrentRaycast= target.pointerCurrentRaycast;
                  ToLuaCS.push(L,pointerCurrentRaycast);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerCurrentRaycast(LuaState L)
          {
                  UnityEngine.EventSystems.RaycastResult value_ = (UnityEngine.EventSystems.RaycastResult)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerCurrentRaycast= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerPressRaycast(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.EventSystems.RaycastResult pointerPressRaycast= target.pointerPressRaycast;
                  ToLuaCS.push(L,pointerPressRaycast);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerPressRaycast(LuaState L)
          {
                  UnityEngine.EventSystems.RaycastResult value_ = (UnityEngine.EventSystems.RaycastResult)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerPressRaycast= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eligibleForClick(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Boolean eligibleForClick= target.eligibleForClick;
                  LuaDLL.lua_pushboolean(L,eligibleForClick);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eligibleForClick(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.eligibleForClick= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerId(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Int32 pointerId= target.pointerId;
                  LuaDLL.lua_pushnumber(L, pointerId);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerId(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerId= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_position(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector2 position= target.position;
                  ToLuaCS.push(L,position);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_position(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.position= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_delta(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector2 delta= target.delta;
                  ToLuaCS.push(L,delta);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_delta(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.delta= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pressPosition(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector2 pressPosition= target.pressPosition;
                  ToLuaCS.push(L,pressPosition);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pressPosition(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pressPosition= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldPosition(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector3 worldPosition= target.worldPosition;
                  ToLuaCS.push(L,worldPosition);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_worldPosition(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.worldPosition= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldNormal(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector3 worldNormal= target.worldNormal;
                  ToLuaCS.push(L,worldNormal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_worldNormal(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.worldNormal= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clickTime(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Single clickTime= target.clickTime;
                  LuaDLL.lua_pushnumber(L, clickTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clickTime(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.clickTime= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clickCount(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Int32 clickCount= target.clickCount;
                  LuaDLL.lua_pushnumber(L, clickCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clickCount(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.clickCount= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_scrollDelta(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Vector2 scrollDelta= target.scrollDelta;
                  ToLuaCS.push(L,scrollDelta);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_scrollDelta(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.scrollDelta= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useDragThreshold(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Boolean useDragThreshold= target.useDragThreshold;
                  LuaDLL.lua_pushboolean(L,useDragThreshold);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useDragThreshold(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.useDragThreshold= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dragging(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Boolean dragging= target.dragging;
                  LuaDLL.lua_pushboolean(L,dragging);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dragging(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.dragging= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_button(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.EventSystems.PointerEventData.InputButton button= target.button;
                  ToLuaCS.push(L,button);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_button(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData.InputButton value_ = (UnityEngine.EventSystems.PointerEventData.InputButton)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.button= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsPointerMoving(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Boolean ispointermoving= target.IsPointerMoving();
                  LuaDLL.lua_pushboolean(L,ispointermoving);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsScrolling(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.Boolean isscrolling= target.IsScrolling();
                  LuaDLL.lua_pushboolean(L,isscrolling);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enterEventCamera(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Camera enterEventCamera= target.enterEventCamera;
                  ToLuaCS.push(L,enterEventCamera);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pressEventCamera(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.Camera pressEventCamera= target.pressEventCamera;
                  ToLuaCS.push(L,pressEventCamera);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pointerPress(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  UnityEngine.GameObject pointerPress= target.pointerPress;
                  ToLuaCS.push(L,pointerPress);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pointerPress(LuaState L)
          {
                  UnityEngine.GameObject value_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  target.pointerPress= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.EventSystems.PointerEventData target= (UnityEngine.EventSystems.PointerEventData) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _pointereventdata(LuaState L)
          {
                  UnityEngine.EventSystems.EventSystem eventSystem_ = (UnityEngine.EventSystems.EventSystem)ToLuaCS.getObject(L, 1);

                  UnityEngine.EventSystems.PointerEventData _pointereventdata= new UnityEngine.EventSystems.PointerEventData( eventSystem_);
                  ToLuaCS.push(L,_pointereventdata);
                  return 1;

          }
  #endregion       
}

