using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToVersion {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Version);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _version);

           ToLuaCS.AddMember(L, "get_VERSION", get_VERSION);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _version(LuaState L)
          {

                  Version _version= new Version();
                  ToLuaCS.push(L,_version);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_VERSION(LuaState L)
          {
                  var val=   Version.VERSION;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
  #endregion       
}

