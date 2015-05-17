using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Graphic {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Graphic);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_color", get_color);
           ToLuaCS.AddMember(L, "set_color", set_color);
           ToLuaCS.AddMember(L, "SetAllDirty", SetAllDirty);
           ToLuaCS.AddMember(L, "SetLayoutDirty", SetLayoutDirty);
           ToLuaCS.AddMember(L, "SetVerticesDirty", SetVerticesDirty);
           ToLuaCS.AddMember(L, "SetMaterialDirty", SetMaterialDirty);
           ToLuaCS.AddMember(L, "get_depth", get_depth);
           ToLuaCS.AddMember(L, "get_rectTransform", get_rectTransform);
           ToLuaCS.AddMember(L, "get_canvas", get_canvas);
           ToLuaCS.AddMember(L, "get_canvasRenderer", get_canvasRenderer);
           ToLuaCS.AddMember(L, "get_defaultMaterial", get_defaultMaterial);
           ToLuaCS.AddMember(L, "get_material", get_material);
           ToLuaCS.AddMember(L, "set_material", set_material);
           ToLuaCS.AddMember(L, "get_materialForRendering", get_materialForRendering);
           ToLuaCS.AddMember(L, "get_mainTexture", get_mainTexture);
           ToLuaCS.AddMember(L, "Rebuild", Rebuild);
           ToLuaCS.AddMember(L, "OnRebuildRequested", OnRebuildRequested);
           ToLuaCS.AddMember(L, "SetNativeSize", SetNativeSize);
           ToLuaCS.AddMember(L, "Raycast", Raycast);
           ToLuaCS.AddMember(L, "PixelAdjustPoint", PixelAdjustPoint);
           ToLuaCS.AddMember(L, "GetPixelAdjustedRect", GetPixelAdjustedRect);
           ToLuaCS.AddMember(L, "CrossFadeColor", CrossFadeColor);
           ToLuaCS.AddMember(L, "CrossFadeAlpha", CrossFadeAlpha);
           ToLuaCS.AddMember(L, "RegisterDirtyLayoutCallback", RegisterDirtyLayoutCallback);
           ToLuaCS.AddMember(L, "UnregisterDirtyLayoutCallback", UnregisterDirtyLayoutCallback);
           ToLuaCS.AddMember(L, "RegisterDirtyVerticesCallback", RegisterDirtyVerticesCallback);
           ToLuaCS.AddMember(L, "UnregisterDirtyVerticesCallback", UnregisterDirtyVerticesCallback);
           ToLuaCS.AddMember(L, "RegisterDirtyMaterialCallback", RegisterDirtyMaterialCallback);
           ToLuaCS.AddMember(L, "UnregisterDirtyMaterialCallback", UnregisterDirtyMaterialCallback);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_defaultGraphicMaterial", get_defaultGraphicMaterial);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_color(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Color color= target.color;
                  ToLuaCS.push(L,color);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_color(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.color= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAllDirty(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.SetAllDirty();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetLayoutDirty(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.SetLayoutDirty();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetVerticesDirty(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.SetVerticesDirty();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetMaterialDirty(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.SetMaterialDirty();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_depth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  System.Int32 depth= target.depth;
                  LuaDLL.lua_pushnumber(L, depth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rectTransform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.RectTransform rectTransform= target.rectTransform;
                  ToLuaCS.push(L,rectTransform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_canvas(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Canvas canvas= target.canvas;
                  ToLuaCS.push(L,canvas);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_canvasRenderer(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.CanvasRenderer canvasRenderer= target.canvasRenderer;
                  ToLuaCS.push(L,canvasRenderer);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultMaterial(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Material defaultMaterial= target.defaultMaterial;
                  ToLuaCS.push(L,defaultMaterial);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_material(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Material material= target.material;
                  ToLuaCS.push(L,material);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_material(LuaState L)
          {
                  UnityEngine.Material value_ = (UnityEngine.Material)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.material= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_materialForRendering(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Material materialForRendering= target.materialForRendering;
                  ToLuaCS.push(L,materialForRendering);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainTexture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Texture mainTexture= target.mainTexture;
                  ToLuaCS.push(L,mainTexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rebuild(LuaState L)
          {
                  UnityEngine.UI.CanvasUpdate update_ = (UnityEngine.UI.CanvasUpdate)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.Rebuild( update_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnRebuildRequested(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.OnRebuildRequested();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetNativeSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.SetNativeSize();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Raycast(LuaState L)
          {
                  UnityEngine.Vector2 sp_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  UnityEngine.Camera eventCamera_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  System.Boolean raycast= target.Raycast( sp_, eventCamera_);
                  LuaDLL.lua_pushboolean(L,raycast);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PixelAdjustPoint(LuaState L)
          {
                  UnityEngine.Vector2 point_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Vector2 pixeladjustpoint= target.PixelAdjustPoint( point_);
                  ToLuaCS.push(L,pixeladjustpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetPixelAdjustedRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  UnityEngine.Rect getpixeladjustedrect= target.GetPixelAdjustedRect();
                  ToLuaCS.push(L,getpixeladjustedrect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CrossFadeColor(LuaState L)
          {
                  UnityEngine.Color targetColor_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);
                  System.Single duration_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Boolean ignoreTimeScale_ =  LuaDLL.lua_toboolean(L,4);
                  System.Boolean useAlpha_ =  LuaDLL.lua_toboolean(L,5);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.CrossFadeColor( targetColor_, duration_, ignoreTimeScale_, useAlpha_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CrossFadeAlpha(LuaState L)
          {
                  System.Single alpha_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single duration_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Boolean ignoreTimeScale_ =  LuaDLL.lua_toboolean(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.CrossFadeAlpha( alpha_, duration_, ignoreTimeScale_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterDirtyLayoutCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.RegisterDirtyLayoutCallback( action_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnregisterDirtyLayoutCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.UnregisterDirtyLayoutCallback( action_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterDirtyVerticesCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.RegisterDirtyVerticesCallback( action_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnregisterDirtyVerticesCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.UnregisterDirtyVerticesCallback( action_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterDirtyMaterialCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.RegisterDirtyMaterialCallback( action_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnregisterDirtyMaterialCallback(LuaState L)
          {
                  UnityEngine.Events.UnityAction action_ = (UnityEngine.Events.UnityAction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Graphic target= (UnityEngine.UI.Graphic) original ;
                  target.UnregisterDirtyMaterialCallback( action_);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultGraphicMaterial(LuaState L)
          {

                  UnityEngine.Material defaultGraphicMaterial= UnityEngine.UI.Graphic.defaultGraphicMaterial;
                  ToLuaCS.push(L,defaultGraphicMaterial);
                  return 1;

          }
  #endregion       
}

