using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCQueueRequest {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CQueueRequest);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Add", Add);
           ToLuaCS.AddMember(L, "First", First);
           ToLuaCS.AddMember(L, "Size", Size);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _cqueuerequest);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Add(LuaState L)
          {
                  CRequest req_ = (CRequest)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  CQueueRequest target= (CQueueRequest) original ;
                  target.Add( req_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int First(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CQueueRequest target= (CQueueRequest) original ;
                  CRequest first= target.First();
                  ToLuaCS.push(L,first);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Size(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  CQueueRequest target= (CQueueRequest) original ;
                  System.Int32 size= target.Size();
                  LuaDLL.lua_pushnumber(L, size);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _cqueuerequest(LuaState L)
          {

                  CQueueRequest _cqueuerequest= new CQueueRequest();
                  ToLuaCS.push(L,_cqueuerequest);
                  return 1;

          }
  #endregion       
}

