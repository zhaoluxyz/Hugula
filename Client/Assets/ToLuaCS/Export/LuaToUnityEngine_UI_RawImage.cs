using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_RawImage {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.RawImage);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_mainTexture", get_mainTexture);
           ToLuaCS.AddMember(L, "get_texture", get_texture);
           ToLuaCS.AddMember(L, "set_texture", set_texture);
           ToLuaCS.AddMember(L, "get_uvRect", get_uvRect);
           ToLuaCS.AddMember(L, "set_uvRect", set_uvRect);
           ToLuaCS.AddMember(L, "SetNativeSize", SetNativeSize);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainTexture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  UnityEngine.Texture mainTexture= target.mainTexture;
                  ToLuaCS.push(L,mainTexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_texture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  UnityEngine.Texture texture= target.texture;
                  ToLuaCS.push(L,texture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_texture(LuaState L)
          {
                  UnityEngine.Texture value_ = (UnityEngine.Texture)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  target.texture= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_uvRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  UnityEngine.Rect uvRect= target.uvRect;
                  ToLuaCS.push(L,uvRect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_uvRect(LuaState L)
          {
                  UnityEngine.Rect value_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  target.uvRect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetNativeSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.RawImage target= (UnityEngine.UI.RawImage) original ;
                  target.SetNativeSize();
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

