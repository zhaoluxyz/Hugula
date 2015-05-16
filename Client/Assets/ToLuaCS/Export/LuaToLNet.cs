using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLNet {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(LNet);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_isConnectCall", get_isConnectCall);
           ToLuaCS.AddMember(L, "Connect", Connect);
           ToLuaCS.AddMember(L, "ReConnect", ReConnect);
           ToLuaCS.AddMember(L, "Close", Close);
           ToLuaCS.AddMember(L, "Send", Send);
           ToLuaCS.AddMember(L, "get_IsConnected", get_IsConnected);
           ToLuaCS.AddMember(L, "Update", Update);
           ToLuaCS.AddMember(L, "OnApplicationPause", OnApplicationPause);
           ToLuaCS.AddMember(L, "Receive", Receive);
           ToLuaCS.AddMember(L, "get_Host", get_Host);
           ToLuaCS.AddMember(L, "get_Port", get_Port);
           ToLuaCS.AddMember(L, "SendErro", SendErro);
           ToLuaCS.AddMember(L, "Dispose", Dispose);
           ToLuaCS.AddMember(L, "get_pingDelay", get_pingDelay);
           ToLuaCS.AddMember(L, "set_pingDelay", set_pingDelay);
           ToLuaCS.AddMember(L, "get_timeoutMiliSecond", get_timeoutMiliSecond);
           ToLuaCS.AddMember(L, "set_timeoutMiliSecond", set_timeoutMiliSecond);
           ToLuaCS.AddMember(L, "get_onAppErrorFn", get_onAppErrorFn);
           ToLuaCS.AddMember(L, "set_onAppErrorFn", set_onAppErrorFn);
           ToLuaCS.AddMember(L, "get_onConnectionCloseFn", get_onConnectionCloseFn);
           ToLuaCS.AddMember(L, "set_onConnectionCloseFn", set_onConnectionCloseFn);
           ToLuaCS.AddMember(L, "get_onConnectionFn", get_onConnectionFn);
           ToLuaCS.AddMember(L, "set_onConnectionFn", set_onConnectionFn);
           ToLuaCS.AddMember(L, "get_onMessageReceiveFn", get_onMessageReceiveFn);
           ToLuaCS.AddMember(L, "set_onMessageReceiveFn", set_onMessageReceiveFn);
           ToLuaCS.AddMember(L, "get_onConnectionTimeoutFn", get_onConnectionTimeoutFn);
           ToLuaCS.AddMember(L, "set_onConnectionTimeoutFn", set_onConnectionTimeoutFn);
           ToLuaCS.AddMember(L, "get_onReConnectFn", get_onReConnectFn);
           ToLuaCS.AddMember(L, "set_onReConnectFn", set_onReConnectFn);
           ToLuaCS.AddMember(L, "get_onAppPauseFn", get_onAppPauseFn);
           ToLuaCS.AddMember(L, "set_onAppPauseFn", set_onAppPauseFn);
           ToLuaCS.AddMember(L, "get_onIntervalFn", get_onIntervalFn);
           ToLuaCS.AddMember(L, "set_onIntervalFn", set_onIntervalFn);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_ChatInstance", get_ChatInstance);

           ToLuaCS.AddMember(L, "get_instance", get_instance);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isConnectCall(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Boolean isConnectCall= target.isConnectCall;
                  LuaDLL.lua_pushboolean(L,isConnectCall);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Connect(LuaState L)
          {
                  System.String host_ =  LuaDLL.lua_tostring(L,2); 

                  System.Int32 port_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Connect( host_, port_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReConnect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.ReConnect();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Close(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Close();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Send(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is Msg){
                  Msg msg_ = (Msg)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Send( msg_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is System.Byte[]){
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Send( bytes_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsConnected(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Boolean IsConnected= target.IsConnected;
                  LuaDLL.lua_pushboolean(L,IsConnected);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Update();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnApplicationPause(LuaState L)
          {
                  System.Boolean pauseStatus_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.OnApplicationPause( pauseStatus_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Receive(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Receive();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Host(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.String Host= target.Host;
                  LuaDLL.lua_pushstring(L, Host);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Port(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Int32 Port= target.Port;
                  LuaDLL.lua_pushnumber(L, Port);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendErro(LuaState L)
          {
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 

                  System.String desc_ =  LuaDLL.lua_tostring(L,3); 


                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.SendErro( type_, desc_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Dispose();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pingDelay(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.pingDelay;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pingDelay(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  target.pingDelay= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeoutMiliSecond(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.timeoutMiliSecond;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_timeoutMiliSecond(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  target.timeoutMiliSecond= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAppErrorFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onAppErrorFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAppErrorFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAppErrorFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionCloseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionCloseFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionCloseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionCloseFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onMessageReceiveFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onMessageReceiveFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onMessageReceiveFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onMessageReceiveFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionTimeoutFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionTimeoutFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionTimeoutFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionTimeoutFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onReConnectFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onReConnectFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onReConnectFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onReConnectFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAppPauseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onAppPauseFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAppPauseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAppPauseFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onIntervalFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onIntervalFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onIntervalFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onIntervalFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ChatInstance(LuaState L)
          {

                  LNet ChatInstance= LNet.ChatInstance;
                  ToLuaCS.push(L,ChatInstance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  LNet instance= LNet.instance;
                  ToLuaCS.push(L,instance);
                  return 1;

          }
  #endregion       
}

