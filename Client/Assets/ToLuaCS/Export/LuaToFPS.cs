using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToFPS {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(FPS);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_updateInterval", get_updateInterval);
           ToLuaCS.AddMember(L, "set_updateInterval", set_updateInterval);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _fps);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_updateInterval(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  FPS target= (FPS) original ;
                  var val=  target.updateInterval;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_updateInterval(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  FPS target= (FPS) original;
                  target.updateInterval= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _fps(LuaState L)
          {

                  FPS _fps= new FPS();
                  ToLuaCS.push(L,_fps);
                  return 1;

          }
  #endregion       
}

