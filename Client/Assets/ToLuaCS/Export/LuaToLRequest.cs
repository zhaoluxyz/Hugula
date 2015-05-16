using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLRequest {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(LRequest);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_onCompleteFn", get_onCompleteFn);
           ToLuaCS.AddMember(L, "set_onCompleteFn", set_onCompleteFn);
           ToLuaCS.AddMember(L, "get_onEndFn", get_onEndFn);
           ToLuaCS.AddMember(L, "set_onEndFn", set_onEndFn);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _lrequest);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original ;
                  var val=  target.onCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCompleteFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onEndFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original ;
                  var val=  target.onEndFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onEndFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onEndFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _lrequest(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 priority_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.String key_ =  LuaDLL.lua_tostring(L,3); 

                  System.String type_ =  LuaDLL.lua_tostring(L,4); 


                  LRequest _lrequest= new LRequest( url_, priority_, key_, type_);
                  ToLuaCS.push(L,_lrequest);
                  return 1;

          }
  #endregion       
}

