using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Selectable {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Selectable);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_navigation", get_navigation);
           ToLuaCS.AddMember(L, "set_navigation", set_navigation);
           ToLuaCS.AddMember(L, "get_transition", get_transition);
           ToLuaCS.AddMember(L, "set_transition", set_transition);
           ToLuaCS.AddMember(L, "get_colors", get_colors);
           ToLuaCS.AddMember(L, "set_colors", set_colors);
           ToLuaCS.AddMember(L, "get_spriteState", get_spriteState);
           ToLuaCS.AddMember(L, "set_spriteState", set_spriteState);
           ToLuaCS.AddMember(L, "get_animationTriggers", get_animationTriggers);
           ToLuaCS.AddMember(L, "set_animationTriggers", set_animationTriggers);
           ToLuaCS.AddMember(L, "get_targetGraphic", get_targetGraphic);
           ToLuaCS.AddMember(L, "set_targetGraphic", set_targetGraphic);
           ToLuaCS.AddMember(L, "get_interactable", get_interactable);
           ToLuaCS.AddMember(L, "set_interactable", set_interactable);
           ToLuaCS.AddMember(L, "get_image", get_image);
           ToLuaCS.AddMember(L, "set_image", set_image);
           ToLuaCS.AddMember(L, "get_animator", get_animator);
           ToLuaCS.AddMember(L, "IsInteractable", IsInteractable);
           ToLuaCS.AddMember(L, "FindSelectable", FindSelectable);
           ToLuaCS.AddMember(L, "FindSelectableOnLeft", FindSelectableOnLeft);
           ToLuaCS.AddMember(L, "FindSelectableOnRight", FindSelectableOnRight);
           ToLuaCS.AddMember(L, "FindSelectableOnUp", FindSelectableOnUp);
           ToLuaCS.AddMember(L, "FindSelectableOnDown", FindSelectableOnDown);
           ToLuaCS.AddMember(L, "OnMove", OnMove);
           ToLuaCS.AddMember(L, "OnPointerDown", OnPointerDown);
           ToLuaCS.AddMember(L, "OnPointerUp", OnPointerUp);
           ToLuaCS.AddMember(L, "OnPointerEnter", OnPointerEnter);
           ToLuaCS.AddMember(L, "OnPointerExit", OnPointerExit);
           ToLuaCS.AddMember(L, "OnSelect", OnSelect);
           ToLuaCS.AddMember(L, "OnDeselect", OnDeselect);
           ToLuaCS.AddMember(L, "Select", Select);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_allSelectables", get_allSelectables);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_navigation(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Navigation navigation= target.navigation;
                  ToLuaCS.push(L,navigation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_navigation(LuaState L)
          {
                  UnityEngine.UI.Navigation value_ = (UnityEngine.UI.Navigation)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.navigation= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transition(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable.Transition transition= target.transition;
                  ToLuaCS.push(L,transition);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_transition(LuaState L)
          {
                  UnityEngine.UI.Selectable.Transition value_ = (UnityEngine.UI.Selectable.Transition)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.transition= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_colors(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.ColorBlock colors= target.colors;
                  ToLuaCS.push(L,colors);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_colors(LuaState L)
          {
                  UnityEngine.UI.ColorBlock value_ = (UnityEngine.UI.ColorBlock)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.colors= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_spriteState(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.SpriteState spriteState= target.spriteState;
                  ToLuaCS.push(L,spriteState);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_spriteState(LuaState L)
          {
                  UnityEngine.UI.SpriteState value_ = (UnityEngine.UI.SpriteState)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.spriteState= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animationTriggers(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.AnimationTriggers animationTriggers= target.animationTriggers;
                  ToLuaCS.push(L,animationTriggers);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_animationTriggers(LuaState L)
          {
                  UnityEngine.UI.AnimationTriggers value_ = (UnityEngine.UI.AnimationTriggers)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.animationTriggers= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_targetGraphic(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Graphic targetGraphic= target.targetGraphic;
                  ToLuaCS.push(L,targetGraphic);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_targetGraphic(LuaState L)
          {
                  UnityEngine.UI.Graphic value_ = (UnityEngine.UI.Graphic)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.targetGraphic= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_interactable(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  System.Boolean interactable= target.interactable;
                  LuaDLL.lua_pushboolean(L,interactable);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_interactable(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.interactable= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_image(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Image image= target.image;
                  ToLuaCS.push(L,image);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_image(LuaState L)
          {
                  UnityEngine.UI.Image value_ = (UnityEngine.UI.Image)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.image= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animator(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.Animator animator= target.animator;
                  ToLuaCS.push(L,animator);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsInteractable(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  System.Boolean isinteractable= target.IsInteractable();
                  LuaDLL.lua_pushboolean(L,isinteractable);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectable(LuaState L)
          {
                  UnityEngine.Vector3 dir_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable findselectable= target.FindSelectable( dir_);
                  ToLuaCS.push(L,findselectable);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnLeft(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable findselectableonleft= target.FindSelectableOnLeft();
                  ToLuaCS.push(L,findselectableonleft);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnRight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable findselectableonright= target.FindSelectableOnRight();
                  ToLuaCS.push(L,findselectableonright);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnUp(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable findselectableonup= target.FindSelectableOnUp();
                  ToLuaCS.push(L,findselectableonup);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindSelectableOnDown(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  UnityEngine.UI.Selectable findselectableondown= target.FindSelectableOnDown();
                  ToLuaCS.push(L,findselectableondown);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnMove(LuaState L)
          {
                  UnityEngine.EventSystems.AxisEventData eventData_ = (UnityEngine.EventSystems.AxisEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnMove( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerDown(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnPointerDown( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerUp(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnPointerUp( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerEnter(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnPointerEnter( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerExit(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnPointerExit( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSelect(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnSelect( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDeselect(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.OnDeselect( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Select(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Selectable target= (UnityEngine.UI.Selectable) original ;
                  target.Select();
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_allSelectables(LuaState L)
          {

                  System.Collections.Generic.List<UnityEngine.UI.Selectable> allSelectables= UnityEngine.UI.Selectable.allSelectables;
                  ToLuaCS.push(L,allSelectables);
                  return 1;

          }
  #endregion       
}

