using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_MaskableGraphic {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.MaskableGraphic);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_maskable", get_maskable);
           ToLuaCS.AddMember(L, "set_maskable", set_maskable);
           ToLuaCS.AddMember(L, "get_material", get_material);
           ToLuaCS.AddMember(L, "set_material", set_material);
           ToLuaCS.AddMember(L, "ParentMaskStateChanged", ParentMaskStateChanged);
           ToLuaCS.AddMember(L, "SetMaterialDirty", SetMaterialDirty);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maskable(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  System.Boolean maskable= target.maskable;
                  LuaDLL.lua_pushboolean(L,maskable);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_maskable(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  target.maskable= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_material(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  UnityEngine.Material material= target.material;
                  ToLuaCS.push(L,material);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_material(LuaState L)
          {
                  UnityEngine.Material value_ = (UnityEngine.Material)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  target.material= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ParentMaskStateChanged(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  target.ParentMaskStateChanged();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetMaterialDirty(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.MaskableGraphic target= (UnityEngine.UI.MaskableGraphic) original ;
                  target.SetMaterialDirty();
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

