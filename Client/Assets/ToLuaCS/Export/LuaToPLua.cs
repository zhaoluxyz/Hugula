using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToPLua {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(PLua);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_updateFn", get_updateFn);
           ToLuaCS.AddMember(L, "set_updateFn", set_updateFn);
           ToLuaCS.AddMember(L, "DoUnity3dLua", DoUnity3dLua);
           ToLuaCS.AddMember(L, "DoMain", DoMain);
           ToLuaCS.AddMember(L, "LoadBundle", LoadBundle);
           ToLuaCS.AddMember(L, "RegisterFunc", RegisterFunc);
           ToLuaCS.AddMember(L, "get_onDestroyFn", get_onDestroyFn);
           ToLuaCS.AddMember(L, "set_onDestroyFn", set_onDestroyFn);
           ToLuaCS.AddMember(L, "get_lua", get_lua);
           ToLuaCS.AddMember(L, "set_lua", set_lua);
           ToLuaCS.AddMember(L, "get_net", get_net);
           ToLuaCS.AddMember(L, "set_net", set_net);
           ToLuaCS.AddMember(L, "get_ChatNet", get_ChatNet);
           ToLuaCS.AddMember(L, "set_ChatNet", set_ChatNet);
           ToLuaCS.AddMember(L, "get_luaState", get_luaState);
           ToLuaCS.AddMember(L, "set_luaState", set_luaState);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_package_path", get_package_path);

           ToLuaCS.AddMember(L, "Loader", Loader);

           ToLuaCS.AddMember(L, "Require", Require);

           ToLuaCS.AddMember(L, "Log", Log);

           ToLuaCS.AddMember(L, "Delay", Delay);

           ToLuaCS.AddMember(L, "StopDelay", StopDelay);

           ToLuaCS.AddMember(L, "get_instance", get_instance);

           ToLuaCS.AddMember(L, "__call", _plua);

           ToLuaCS.AddMember(L, "get_enterLua", get_enterLua);

           ToLuaCS.AddMember(L, "set_enterLua", set_enterLua);

           ToLuaCS.AddMember(L, "get_isDebug", get_isDebug);

           ToLuaCS.AddMember(L, "set_isDebug", set_isDebug);

           ToLuaCS.AddMember(L, "get_luacache", get_luacache);

           ToLuaCS.AddMember(L, "set_luacache", set_luacache);

#endregion       
}
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

