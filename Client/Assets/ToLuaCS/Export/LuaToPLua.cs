using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToPLua {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(PLua).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(PLua).AssemblyQualifiedName);
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
          System.Type superT = typeof(PLua).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_updateFn");
          luafn_get_updateFn= new LuaCSFunction(get_updateFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_updateFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_updateFn");
          luafn_set_updateFn= new LuaCSFunction(set_updateFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_updateFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DoUnity3dLua");
          luafn_DoUnity3dLua= new LuaCSFunction(DoUnity3dLua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DoUnity3dLua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DoMain");
          luafn_DoMain= new LuaCSFunction(DoMain);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DoMain);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadBundle");
          luafn_LoadBundle= new LuaCSFunction(LoadBundle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadBundle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RegisterFunc");
          luafn_RegisterFunc= new LuaCSFunction(RegisterFunc);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RegisterFunc);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDestroyFn");
          luafn_get_onDestroyFn= new LuaCSFunction(get_onDestroyFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDestroyFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDestroyFn");
          luafn_set_onDestroyFn= new LuaCSFunction(set_onDestroyFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDestroyFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_lua");
          luafn_get_lua= new LuaCSFunction(get_lua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_lua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_lua");
          luafn_set_lua= new LuaCSFunction(set_lua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_lua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_net");
          luafn_get_net= new LuaCSFunction(get_net);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_net);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_net");
          luafn_set_net= new LuaCSFunction(set_net);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_net);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_ChatNet");
          luafn_get_ChatNet= new LuaCSFunction(get_ChatNet);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_ChatNet);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_ChatNet");
          luafn_set_ChatNet= new LuaCSFunction(set_ChatNet);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_ChatNet);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_luaState");
          luafn_get_luaState= new LuaCSFunction(get_luaState);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_luaState);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_luaState");
          luafn_set_luaState= new LuaCSFunction(set_luaState);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_luaState);
          LuaDLL.lua_rawset(L, -3);

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
    
          string[] names = typeof(PLua).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(PLua).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_package_path");
          luafn_get_package_path= new LuaCSFunction(get_package_path);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_package_path);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Loader");
          luafn_Loader= new LuaCSFunction(Loader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Loader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Require");
          luafn_Require= new LuaCSFunction(Require);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Require);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Log");
          luafn_Log= new LuaCSFunction(Log);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Log);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Delay");
          luafn_Delay= new LuaCSFunction(Delay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Delay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StopDelay");
          luafn_StopDelay= new LuaCSFunction(StopDelay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StopDelay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_instance");
          luafn_get_instance= new LuaCSFunction(get_instance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_instance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"__call");
          luafn__plua= new LuaCSFunction(_plua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__plua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_enterLua");
          luafn_get_enterLua= new LuaCSFunction(get_enterLua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_enterLua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_enterLua");
          luafn_set_enterLua= new LuaCSFunction(set_enterLua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_enterLua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isDebug");
          luafn_get_isDebug= new LuaCSFunction(get_isDebug);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isDebug);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isDebug");
          luafn_set_isDebug= new LuaCSFunction(set_isDebug);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isDebug);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_luacache");
          luafn_get_luacache= new LuaCSFunction(get_luacache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_luacache);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_luacache");
          luafn_set_luacache= new LuaCSFunction(set_luacache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_luacache);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_updateFn;
          private static LuaCSFunction luafn_set_updateFn;
          private static LuaCSFunction luafn_DoUnity3dLua;
          private static LuaCSFunction luafn_DoMain;
          private static LuaCSFunction luafn_LoadBundle;
          private static LuaCSFunction luafn_RegisterFunc;
          private static LuaCSFunction luafn_get_onDestroyFn;
          private static LuaCSFunction luafn_set_onDestroyFn;
          private static LuaCSFunction luafn_get_lua;
          private static LuaCSFunction luafn_set_lua;
          private static LuaCSFunction luafn_get_net;
          private static LuaCSFunction luafn_set_net;
          private static LuaCSFunction luafn_get_ChatNet;
          private static LuaCSFunction luafn_set_ChatNet;
          private static LuaCSFunction luafn_get_luaState;
          private static LuaCSFunction luafn_set_luaState;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_package_path;
          private static LuaCSFunction luafn_Loader;
          private static LuaCSFunction luafn_Require;
          private static LuaCSFunction luafn_Log;
          private static LuaCSFunction luafn_Delay;
          private static LuaCSFunction luafn_StopDelay;
          private static LuaCSFunction luafn_get_instance;
          private static LuaCSFunction luafn__plua;
          private static LuaCSFunction luafn_get_enterLua;
          private static LuaCSFunction luafn_set_enterLua;
          private static LuaCSFunction luafn_get_isDebug;
          private static LuaCSFunction luafn_set_isDebug;
          private static LuaCSFunction luafn_get_luacache;
          private static LuaCSFunction luafn_set_luacache;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_updateFn(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  LuaInterface.LuaFunction updateFn= target.updateFn;
                  ToLuaCS.push(L,updateFn);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_updateFn(LuaState L)
          {
                  LuaInterface.LuaFunction value_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  target.updateFn= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DoUnity3dLua(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  target.DoUnity3dLua();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DoMain(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  target.DoMain();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadBundle(LuaState L)
          {
                  System.Boolean domain_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  target.LoadBundle( domain_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterFunc(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  target.RegisterFunc();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDestroyFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  var val=  target.onDestroyFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDestroyFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDestroyFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lua(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  var val=  target.lua;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_lua(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.lua= (LuaInterface.LuaState)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_net(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  var val=  target.net;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_net(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.net= (LNet)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ChatNet(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  var val=  target.ChatNet;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ChatNet(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.ChatNet= (LNet)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_luaState(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original ;
                  var val=  target.luaState;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_luaState(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  PLua target= (PLua) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.luaState= (System.IntPtr)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_package_path(LuaState L)
          {

                  System.String package_path= PLua.package_path;
                  LuaDLL.lua_pushstring(L, package_path);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Loader(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  System.Byte[] loader= PLua.Loader( name_);
                  ToLuaCS.push(L,loader);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Require(LuaState L)
          {
                  System.IntPtr L_ = (System.IntPtr)ToLuaCS.getObject(L, 1);

                  System.Int32 require= PLua.Require( L_);
                  LuaDLL.lua_pushnumber(L, require);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Log(LuaState L)
          {
                  System.Object msg_ = (System.Object)ToLuaCS.getObject(L, 1);

                  PLua.Log( msg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Delay(LuaState L)
          {
                  LuaInterface.LuaFunction luafun_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 1);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Object args_ = (System.Object)ToLuaCS.getObject(L, 3);

                  PLua.Delay( luafun_, time_, args_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopDelay(LuaState L)
          {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,1); 


                  PLua.StopDelay( methodName_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  PLua instance= PLua.instance;
                  ToLuaCS.push(L,instance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _plua(LuaState L)
          {

                  PLua _plua= new PLua();
                  ToLuaCS.push(L,_plua);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enterLua(LuaState L)
          {
                  var val=   PLua.enterLua;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enterLua(LuaState L)
          {
                  PLua.enterLua= LuaDLL.lua_tostring(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isDebug(LuaState L)
          {
                  var val=   PLua.isDebug;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isDebug(LuaState L)
          {
                  PLua.isDebug= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_luacache(LuaState L)
          {
                  var val=   PLua.luacache;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_luacache(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  PLua.luacache= (System.Collections.Generic.Dictionary<System.String,UnityEngine.TextAsset>)val;
                  return 0;

          }
  #endregion       
}

