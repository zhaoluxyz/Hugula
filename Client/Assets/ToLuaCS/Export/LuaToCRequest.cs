using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCRequest {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CRequest);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Dispose", Dispose);
           ToLuaCS.AddMember(L, "get_suffix", get_suffix);
           ToLuaCS.AddMember(L, "set_suffix", set_suffix);
           ToLuaCS.AddMember(L, "get_head", get_head);
           ToLuaCS.AddMember(L, "set_head", set_head);
           ToLuaCS.AddMember(L, "get_data", get_data);
           ToLuaCS.AddMember(L, "set_data", set_data);
           ToLuaCS.AddMember(L, "DispatchComplete", DispatchComplete);
           ToLuaCS.AddMember(L, "DispatchEnd", DispatchEnd);
           ToLuaCS.AddMember(L, "get_isShared", get_isShared);
           ToLuaCS.AddMember(L, "set_isShared", set_isShared);
           ToLuaCS.AddMember(L, "get_url", get_url);
           ToLuaCS.AddMember(L, "set_url", set_url);
           ToLuaCS.AddMember(L, "get_key", get_key);
           ToLuaCS.AddMember(L, "set_key", set_key);
           ToLuaCS.AddMember(L, "get_udKey", get_udKey);
           ToLuaCS.AddMember(L, "set_udKey", set_udKey);
           ToLuaCS.AddMember(L, "get_relative", get_relative);
           ToLuaCS.AddMember(L, "set_relative", set_relative);
           ToLuaCS.AddMember(L, "get_domain", get_domain);
           ToLuaCS.AddMember(L, "get_cache", get_cache);
           ToLuaCS.AddMember(L, "set_cache", set_cache);
           ToLuaCS.AddMember(L, "get_userData", get_userData);
           ToLuaCS.AddMember(L, "set_userData", set_userData);
           ToLuaCS.AddMember(L, "get_priority", get_priority);
           ToLuaCS.AddMember(L, "set_priority", set_priority);
           ToLuaCS.AddMember(L, "get_times", get_times);
           ToLuaCS.AddMember(L, "set_times", set_times);
           ToLuaCS.AddMember(L, "get_childrenReq", get_childrenReq);
           ToLuaCS.AddMember(L, "set_childrenReq", set_childrenReq);
           ToLuaCS.AddMember(L, "get_dependenciesCount", get_dependenciesCount);
           ToLuaCS.AddMember(L, "set_dependenciesCount", set_dependenciesCount);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _crequest);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.Dispose();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_suffix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String suffix= target.suffix;
                  LuaDLL.lua_pushstring(L, suffix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_suffix(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.suffix= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_head(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Object head= target.head;
                  ToLuaCS.push(L,head);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_head(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.head= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_data(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Object data= target.data;
                  ToLuaCS.push(L,data);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_data(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.data= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DispatchComplete(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.DispatchComplete();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DispatchEnd(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.DispatchEnd();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isShared(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Boolean isShared= target.isShared;
                  LuaDLL.lua_pushboolean(L,isShared);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isShared(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.isShared= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_url(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String url= target.url;
                  LuaDLL.lua_pushstring(L, url);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_url(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.url= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_key(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String key= target.key;
                  LuaDLL.lua_pushstring(L, key);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_key(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.key= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_udKey(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String udKey= target.udKey;
                  LuaDLL.lua_pushstring(L, udKey);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_udKey(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.udKey= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_relative(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String relative= target.relative;
                  LuaDLL.lua_pushstring(L, relative);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_relative(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.relative= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_domain(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String domain= target.domain;
                  LuaDLL.lua_pushstring(L, domain);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Boolean cache= target.cache;
                  LuaDLL.lua_pushboolean(L,cache);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.cache= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userData(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.userData;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userData(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userData= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_priority(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.priority;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_priority(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  target.priority= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_times(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.times;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_times(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  target.times= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_childrenReq(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.childrenReq;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_childrenReq(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.childrenReq= (CRequest)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dependenciesCount(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.dependenciesCount;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dependenciesCount(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  target.dependenciesCount= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _crequest(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 priority_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.String key_ =  LuaDLL.lua_tostring(L,3); 

                  System.String type_ =  LuaDLL.lua_tostring(L,4); 


                  CRequest _crequest= new CRequest( url_, priority_, key_, type_);
                  ToLuaCS.push(L,_crequest);
                  return 1;

          }
  #endregion       
}

