using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCommon {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Common);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _common);

           ToLuaCS.AddMember(L, "get_ASSETBUNDLE_SUFFIX", get_ASSETBUNDLE_SUFFIX);

           ToLuaCS.AddMember(L, "get_LUACFOLDER", get_LUACFOLDER);

           ToLuaCS.AddMember(L, "get_LUA_LC_SUFFIX", get_LUA_LC_SUFFIX);

           ToLuaCS.AddMember(L, "get_CONFIG_ZIP_PWD", get_CONFIG_ZIP_PWD);

           ToLuaCS.AddMember(L, "get_DEPENDENCIES_OBJECT_NAME", get_DEPENDENCIES_OBJECT_NAME);

           ToLuaCS.AddMember(L, "get_LANGUAGE_FLODER", get_LANGUAGE_FLODER);

           ToLuaCS.AddMember(L, "get_LANGUAGE_SUFFIX", get_LANGUAGE_SUFFIX);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _common(LuaState L)
          {

                  Common _common= new Common();
                  ToLuaCS.push(L,_common);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ASSETBUNDLE_SUFFIX(LuaState L)
          {
                  var val=   Common.ASSETBUNDLE_SUFFIX;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LUACFOLDER(LuaState L)
          {
                  var val=   Common.LUACFOLDER;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LUA_LC_SUFFIX(LuaState L)
          {
                  var val=   Common.LUA_LC_SUFFIX;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_CONFIG_ZIP_PWD(LuaState L)
          {
                  var val=   Common.CONFIG_ZIP_PWD;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_DEPENDENCIES_OBJECT_NAME(LuaState L)
          {
                  var val=   Common.DEPENDENCIES_OBJECT_NAME;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LANGUAGE_FLODER(LuaState L)
          {
                  var val=   Common.LANGUAGE_FLODER;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LANGUAGE_SUFFIX(LuaState L)
          {
                  var val=   Common.LANGUAGE_SUFFIX;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
  #endregion       
}

