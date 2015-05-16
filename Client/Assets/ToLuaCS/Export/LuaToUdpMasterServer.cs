using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUdpMasterServer {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UdpMasterServer);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _udpmasterserver);

           ToLuaCS.AddMember(L, "get_UdpPort", get_UdpPort);

           ToLuaCS.AddMember(L, "set_UdpPort", set_UdpPort);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _udpmasterserver(LuaState L)
          {

                  UdpMasterServer _udpmasterserver= new UdpMasterServer();
                  ToLuaCS.push(L,_udpmasterserver);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_UdpPort(LuaState L)
          {
                  var val=   UdpMasterServer.UdpPort;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_UdpPort(LuaState L)
          {
                  UdpMasterServer.UdpPort= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
  #endregion       
}

