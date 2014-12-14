using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_MasterServer {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.MasterServer).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.MasterServer).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(UnityEngine.MasterServer).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(UnityEngine.MasterServer).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.MasterServer).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_ipAddress");
          luafn_get_ipAddress= new LuaCSFunction(get_ipAddress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_ipAddress);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_ipAddress");
          luafn_set_ipAddress= new LuaCSFunction(set_ipAddress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_ipAddress);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_port");
          luafn_get_port= new LuaCSFunction(get_port);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_port);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_port");
          luafn_set_port= new LuaCSFunction(set_port);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_port);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RequestHostList");
          luafn_RequestHostList= new LuaCSFunction(RequestHostList);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RequestHostList);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PollHostList");
          luafn_PollHostList= new LuaCSFunction(PollHostList);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PollHostList);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RegisterHost");
          luafn_RegisterHost= new LuaCSFunction(RegisterHost);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RegisterHost);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnregisterHost");
          luafn_UnregisterHost= new LuaCSFunction(UnregisterHost);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnregisterHost);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ClearHostList");
          luafn_ClearHostList= new LuaCSFunction(ClearHostList);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ClearHostList);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_updateRate");
          luafn_get_updateRate= new LuaCSFunction(get_updateRate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_updateRate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_updateRate");
          luafn_set_updateRate= new LuaCSFunction(set_updateRate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_updateRate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_dedicatedServer");
          luafn_get_dedicatedServer= new LuaCSFunction(get_dedicatedServer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_dedicatedServer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_dedicatedServer");
          luafn_set_dedicatedServer= new LuaCSFunction(set_dedicatedServer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_dedicatedServer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"__call");
          luafn__masterserver= new LuaCSFunction(_masterserver);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__masterserver);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_ipAddress;
          private static LuaCSFunction luafn_set_ipAddress;
          private static LuaCSFunction luafn_get_port;
          private static LuaCSFunction luafn_set_port;
          private static LuaCSFunction luafn_RequestHostList;
          private static LuaCSFunction luafn_PollHostList;
          private static LuaCSFunction luafn_RegisterHost;
          private static LuaCSFunction luafn_UnregisterHost;
          private static LuaCSFunction luafn_ClearHostList;
          private static LuaCSFunction luafn_get_updateRate;
          private static LuaCSFunction luafn_set_updateRate;
          private static LuaCSFunction luafn_get_dedicatedServer;
          private static LuaCSFunction luafn_set_dedicatedServer;
          private static LuaCSFunction luafn__masterserver;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ipAddress(LuaState L)
          {

                  System.String ipAddress= UnityEngine.MasterServer.ipAddress;
                  ToLuaCS.push(L,ipAddress); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ipAddress(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.MasterServer.ipAddress= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_port(LuaState L)
          {

                  System.Int32 port= UnityEngine.MasterServer.port;
                  ToLuaCS.push(L,port); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_port(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.MasterServer.port= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RequestHostList(LuaState L)
          {
                  System.String gameTypeName_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.MasterServer.RequestHostList( gameTypeName_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PollHostList(LuaState L)
          {

                  UnityEngine.HostData[] pollhostlist= UnityEngine.MasterServer.PollHostList();
                  ToLuaCS.push(L,pollhostlist); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterHost(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TSTRING )
              {
                  System.String gameTypeName_ =  LuaDLL.lua_tostring(L,1); 

                  System.String gameName_ =  LuaDLL.lua_tostring(L,2); 

                  System.String comment_ =  LuaDLL.lua_tostring(L,3); 


                  UnityEngine.MasterServer.RegisterHost( gameTypeName_, gameName_, comment_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String gameTypeName_ =  LuaDLL.lua_tostring(L,1); 

                  System.String gameName_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.MasterServer.RegisterHost( gameTypeName_, gameName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnregisterHost(LuaState L)
          {

                  UnityEngine.MasterServer.UnregisterHost();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ClearHostList(LuaState L)
          {

                  UnityEngine.MasterServer.ClearHostList();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_updateRate(LuaState L)
          {

                  System.Int32 updateRate= UnityEngine.MasterServer.updateRate;
                  ToLuaCS.push(L,updateRate); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_updateRate(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.MasterServer.updateRate= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dedicatedServer(LuaState L)
          {

                  System.Boolean dedicatedServer= UnityEngine.MasterServer.dedicatedServer;
                  ToLuaCS.push(L,dedicatedServer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dedicatedServer(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,1);

                  UnityEngine.MasterServer.dedicatedServer= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _masterserver(LuaState L)
          {

                  UnityEngine.MasterServer _masterserver= new UnityEngine.MasterServer();
                  ToLuaCS.push(L,_masterserver); 
                  return 1;

          }
  #endregion       
}

