using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Image {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Image);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_sprite", get_sprite);
           ToLuaCS.AddMember(L, "set_sprite", set_sprite);
           ToLuaCS.AddMember(L, "get_overrideSprite", get_overrideSprite);
           ToLuaCS.AddMember(L, "set_overrideSprite", set_overrideSprite);
           ToLuaCS.AddMember(L, "get_type", get_type);
           ToLuaCS.AddMember(L, "set_type", set_type);
           ToLuaCS.AddMember(L, "get_preserveAspect", get_preserveAspect);
           ToLuaCS.AddMember(L, "set_preserveAspect", set_preserveAspect);
           ToLuaCS.AddMember(L, "get_fillCenter", get_fillCenter);
           ToLuaCS.AddMember(L, "set_fillCenter", set_fillCenter);
           ToLuaCS.AddMember(L, "get_fillMethod", get_fillMethod);
           ToLuaCS.AddMember(L, "set_fillMethod", set_fillMethod);
           ToLuaCS.AddMember(L, "get_fillAmount", get_fillAmount);
           ToLuaCS.AddMember(L, "set_fillAmount", set_fillAmount);
           ToLuaCS.AddMember(L, "get_fillClockwise", get_fillClockwise);
           ToLuaCS.AddMember(L, "set_fillClockwise", set_fillClockwise);
           ToLuaCS.AddMember(L, "get_fillOrigin", get_fillOrigin);
           ToLuaCS.AddMember(L, "set_fillOrigin", set_fillOrigin);
           ToLuaCS.AddMember(L, "get_eventAlphaThreshold", get_eventAlphaThreshold);
           ToLuaCS.AddMember(L, "set_eventAlphaThreshold", set_eventAlphaThreshold);
           ToLuaCS.AddMember(L, "get_mainTexture", get_mainTexture);
           ToLuaCS.AddMember(L, "get_hasBorder", get_hasBorder);
           ToLuaCS.AddMember(L, "get_pixelsPerUnit", get_pixelsPerUnit);
           ToLuaCS.AddMember(L, "OnBeforeSerialize", OnBeforeSerialize);
           ToLuaCS.AddMember(L, "OnAfterDeserialize", OnAfterDeserialize);
           ToLuaCS.AddMember(L, "SetNativeSize", SetNativeSize);
           ToLuaCS.AddMember(L, "CalculateLayoutInputHorizontal", CalculateLayoutInputHorizontal);
           ToLuaCS.AddMember(L, "CalculateLayoutInputVertical", CalculateLayoutInputVertical);
           ToLuaCS.AddMember(L, "get_minWidth", get_minWidth);
           ToLuaCS.AddMember(L, "get_preferredWidth", get_preferredWidth);
           ToLuaCS.AddMember(L, "get_flexibleWidth", get_flexibleWidth);
           ToLuaCS.AddMember(L, "get_minHeight", get_minHeight);
           ToLuaCS.AddMember(L, "get_preferredHeight", get_preferredHeight);
           ToLuaCS.AddMember(L, "get_flexibleHeight", get_flexibleHeight);
           ToLuaCS.AddMember(L, "get_layoutPriority", get_layoutPriority);
           ToLuaCS.AddMember(L, "IsRaycastLocationValid", IsRaycastLocationValid);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_sprite(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  UnityEngine.Sprite sprite= target.sprite;
                  ToLuaCS.push(L,sprite);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_sprite(LuaState L)
          {
                  UnityEngine.Sprite value_ = (UnityEngine.Sprite)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.sprite= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_overrideSprite(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  UnityEngine.Sprite overrideSprite= target.overrideSprite;
                  ToLuaCS.push(L,overrideSprite);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_overrideSprite(LuaState L)
          {
                  UnityEngine.Sprite value_ = (UnityEngine.Sprite)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.overrideSprite= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_type(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  UnityEngine.UI.Image.Type type= target.type;
                  ToLuaCS.push(L,type);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_type(LuaState L)
          {
                  UnityEngine.UI.Image.Type value_ = (UnityEngine.UI.Image.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.type= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_preserveAspect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Boolean preserveAspect= target.preserveAspect;
                  LuaDLL.lua_pushboolean(L,preserveAspect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_preserveAspect(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.preserveAspect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fillCenter(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Boolean fillCenter= target.fillCenter;
                  LuaDLL.lua_pushboolean(L,fillCenter);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillCenter(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.fillCenter= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fillMethod(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  UnityEngine.UI.Image.FillMethod fillMethod= target.fillMethod;
                  ToLuaCS.push(L,fillMethod);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillMethod(LuaState L)
          {
                  UnityEngine.UI.Image.FillMethod value_ = (UnityEngine.UI.Image.FillMethod)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.fillMethod= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fillAmount(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single fillAmount= target.fillAmount;
                  LuaDLL.lua_pushnumber(L, fillAmount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillAmount(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.fillAmount= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fillClockwise(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Boolean fillClockwise= target.fillClockwise;
                  LuaDLL.lua_pushboolean(L,fillClockwise);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillClockwise(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.fillClockwise= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fillOrigin(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Int32 fillOrigin= target.fillOrigin;
                  LuaDLL.lua_pushnumber(L, fillOrigin);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fillOrigin(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.fillOrigin= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eventAlphaThreshold(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single eventAlphaThreshold= target.eventAlphaThreshold;
                  LuaDLL.lua_pushnumber(L, eventAlphaThreshold);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eventAlphaThreshold(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.eventAlphaThreshold= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainTexture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  UnityEngine.Texture mainTexture= target.mainTexture;
                  ToLuaCS.push(L,mainTexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hasBorder(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Boolean hasBorder= target.hasBorder;
                  LuaDLL.lua_pushboolean(L,hasBorder);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelsPerUnit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single pixelsPerUnit= target.pixelsPerUnit;
                  LuaDLL.lua_pushnumber(L, pixelsPerUnit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnBeforeSerialize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.OnBeforeSerialize();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnAfterDeserialize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.OnAfterDeserialize();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetNativeSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.SetNativeSize();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateLayoutInputHorizontal(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.CalculateLayoutInputHorizontal();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateLayoutInputVertical(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  target.CalculateLayoutInputVertical();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_minWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single minWidth= target.minWidth;
                  LuaDLL.lua_pushnumber(L, minWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_preferredWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single preferredWidth= target.preferredWidth;
                  LuaDLL.lua_pushnumber(L, preferredWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flexibleWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single flexibleWidth= target.flexibleWidth;
                  LuaDLL.lua_pushnumber(L, flexibleWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_minHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single minHeight= target.minHeight;
                  LuaDLL.lua_pushnumber(L, minHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_preferredHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single preferredHeight= target.preferredHeight;
                  LuaDLL.lua_pushnumber(L, preferredHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flexibleHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Single flexibleHeight= target.flexibleHeight;
                  LuaDLL.lua_pushnumber(L, flexibleHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layoutPriority(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Int32 layoutPriority= target.layoutPriority;
                  LuaDLL.lua_pushnumber(L, layoutPriority);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsRaycastLocationValid(LuaState L)
          {
                  UnityEngine.Vector2 screenPoint_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  UnityEngine.Camera eventCamera_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Image target= (UnityEngine.UI.Image) original ;
                  System.Boolean israycastlocationvalid= target.IsRaycastLocationValid( screenPoint_, eventCamera_);
                  LuaDLL.lua_pushboolean(L,israycastlocationvalid);
                  return 1;

          }
  #endregion       
  #region  static method       
  #endregion       
}

