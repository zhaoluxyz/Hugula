using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCTransport {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CTransport);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_isFree", get_isFree);
           ToLuaCS.AddMember(L, "get_req", get_req);
           ToLuaCS.AddMember(L, "BeginLoad", BeginLoad);
           ToLuaCS.AddMember(L, "get_key", get_key);
           ToLuaCS.AddMember(L, "set_key", set_key);
           ToLuaCS.AddMember(L, "get_OnProcess", get_OnProcess);
           ToLuaCS.AddMember(L, "set_OnProcess", set_OnProcess);
           ToLuaCS.AddMember(L, "get_OnComplete", get_OnComplete);
           ToLuaCS.AddMember(L, "set_OnComplete", set_OnComplete);
           ToLuaCS.AddMember(L, "get_OnError", get_OnError);
           ToLuaCS.AddMember(L, "set_OnError", set_OnError);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _ctransport);

           ToLuaCS.AddMember(L, "get_m_AssetBundleManifest", get_m_AssetBundleManifest);

           ToLuaCS.AddMember(L, "set_m_AssetBundleManifest", set_m_AssetBundleManifest);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isFree(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  System.Boolean isFree= target.isFree;
                  LuaDLL.lua_pushboolean(L,isFree);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_req(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  CRequest req= target.req;
                  ToLuaCS.push(L,req);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BeginLoad(LuaState L)
          {
                  CRequest req_ = (CRequest)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  target.BeginLoad( req_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_key(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  var val=  target.key;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_key(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original;
                  target.key= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_OnProcess(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  var val=  target.OnProcess;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_OnProcess(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.OnProcess= (System.Action<CTransport,System.Single>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_OnComplete(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  var val=  target.OnComplete;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_OnComplete(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.OnComplete= (System.Action<CTransport,CRequest,System.Collections.Generic.IList<CRequest>>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_OnError(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original ;
                  var val=  target.OnError;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_OnError(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CTransport target= (CTransport) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.OnError= (System.Action<CTransport,CRequest>)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _ctransport(LuaState L)
          {

                  CTransport _ctransport= new CTransport();
                  ToLuaCS.push(L,_ctransport);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_m_AssetBundleManifest(LuaState L)
          {
                  var val=   CTransport.m_AssetBundleManifest;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_m_AssetBundleManifest(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  CTransport.m_AssetBundleManifest= (UnityEngine.AssetBundleManifest)val;
                  return 0;

          }
  #endregion       
}

