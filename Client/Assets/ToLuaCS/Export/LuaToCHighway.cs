using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCHighway {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CHighway);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "LoadReq", LoadReq);
           ToLuaCS.AddMember(L, "InitProgressState", InitProgressState);
           ToLuaCS.AddMember(L, "get_currentLoading", get_currentLoading);
           ToLuaCS.AddMember(L, "get_maxLoading", get_maxLoading);
           ToLuaCS.AddMember(L, "get_totalLoading", get_totalLoading);
           ToLuaCS.AddMember(L, "set_totalLoading", set_totalLoading);
           ToLuaCS.AddMember(L, "get_currentLoaded", get_currentLoaded);
           ToLuaCS.AddMember(L, "get_cache", get_cache);
           ToLuaCS.AddMember(L, "set_cache", set_cache);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "GetInstance", GetInstance);

           ToLuaCS.AddMember(L, "__call", _chighway);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadReq(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is CRequest){
                  CRequest req_ = (CRequest)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  target.LoadReq( req_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is System.Collections.Generic.IList<CRequest>){
                  System.Collections.Generic.IList<CRequest> req_ = (System.Collections.Generic.IList<CRequest>)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  target.LoadReq( req_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InitProgressState(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  target.InitProgressState();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentLoading(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  System.Int32 currentLoading= target.currentLoading;
                  LuaDLL.lua_pushnumber(L, currentLoading);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maxLoading(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  System.Int32 maxLoading= target.maxLoading;
                  LuaDLL.lua_pushnumber(L, maxLoading);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_totalLoading(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  System.Int32 totalLoading= target.totalLoading;
                  LuaDLL.lua_pushnumber(L, totalLoading);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_totalLoading(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  target.totalLoading= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentLoaded(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  System.Int32 currentLoaded= target.currentLoaded;
                  LuaDLL.lua_pushnumber(L, currentLoaded);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  System.Object cache= target.cache;
                  ToLuaCS.push(L,cache);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CHighway target= (CHighway) original ;
                  target.cache= value_;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstance(LuaState L)
          {

                  CHighway getinstance= CHighway.GetInstance();
                  ToLuaCS.push(L,getinstance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _chighway(LuaState L)
          {

                  CHighway _chighway= new CHighway();
                  ToLuaCS.push(L,_chighway);
                  return 1;

          }
  #endregion       
}

