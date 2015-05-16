using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLHighway {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(LHighway);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "LoadLuaTable", LoadLuaTable);
           ToLuaCS.AddMember(L, "get_cache", get_cache);
           ToLuaCS.AddMember(L, "set_cache", set_cache);
           ToLuaCS.AddMember(L, "get_onAllCompleteFn", get_onAllCompleteFn);
           ToLuaCS.AddMember(L, "set_onAllCompleteFn", set_onAllCompleteFn);
           ToLuaCS.AddMember(L, "get_onProgressFn", get_onProgressFn);
           ToLuaCS.AddMember(L, "set_onProgressFn", set_onProgressFn);
           ToLuaCS.AddMember(L, "get_onSharedCompleteFn", get_onSharedCompleteFn);
           ToLuaCS.AddMember(L, "set_onSharedCompleteFn", set_onSharedCompleteFn);
           ToLuaCS.AddMember(L, "get_onCacheFn", get_onCacheFn);
           ToLuaCS.AddMember(L, "set_onCacheFn", set_onCacheFn);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_instance", get_instance);

           ToLuaCS.AddMember(L, "__call", _lhighway);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadLuaTable(LuaState L)
          {
                  LuaInterface.LuaTable reqs_ = (LuaInterface.LuaTable)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  target.LoadLuaTable( reqs_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  System.Object cache= target.cache;
                  ToLuaCS.push(L,cache);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  target.cache= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAllCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  var val=  target.onAllCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAllCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAllCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onProgressFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  var val=  target.onProgressFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onProgressFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onProgressFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onSharedCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  var val=  target.onSharedCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onSharedCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onSharedCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCacheFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original ;
                  var val=  target.onCacheFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCacheFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LHighway target= (LHighway) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCacheFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  LHighway instance= LHighway.instance;
                  ToLuaCS.push(L,instance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _lhighway(LuaState L)
          {

                  LHighway _lhighway= new LHighway();
                  ToLuaCS.push(L,_lhighway);
                  return 1;

          }
  #endregion       
}

