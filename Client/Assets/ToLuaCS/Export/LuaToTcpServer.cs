using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToTcpServer {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(TcpServer);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "BroadCast", BroadCast);
           ToLuaCS.AddMember(L, "Kick", Kick);
           ToLuaCS.AddMember(L, "Stop", Stop);
           ToLuaCS.AddMember(L, "get_autoBroadcast", get_autoBroadcast);
           ToLuaCS.AddMember(L, "set_autoBroadcast", set_autoBroadcast);
           ToLuaCS.AddMember(L, "get_onClientConnectFn", get_onClientConnectFn);
           ToLuaCS.AddMember(L, "set_onClientConnectFn", set_onClientConnectFn);
           ToLuaCS.AddMember(L, "get_onMessageArriveFn", get_onMessageArriveFn);
           ToLuaCS.AddMember(L, "set_onMessageArriveFn", set_onMessageArriveFn);
           ToLuaCS.AddMember(L, "get_onClientCloseFn", get_onClientCloseFn);
           ToLuaCS.AddMember(L, "set_onClientCloseFn", set_onClientCloseFn);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "StartTcpServer", StartTcpServer);

           ToLuaCS.AddMember(L, "StopTcpServer", StopTcpServer);

           ToLuaCS.AddMember(L, "GetLocalIP", GetLocalIP);

           ToLuaCS.AddMember(L, "__call", _tcpserver);

           ToLuaCS.AddMember(L, "get_GAME_TYPE", get_GAME_TYPE);

           ToLuaCS.AddMember(L, "get_port", get_port);

           ToLuaCS.AddMember(L, "set_port", set_port);

           ToLuaCS.AddMember(L, "get_tcpClientConnected", get_tcpClientConnected);

           ToLuaCS.AddMember(L, "set_tcpClientConnected", set_tcpClientConnected);

           ToLuaCS.AddMember(L, "get_currTcpServer", get_currTcpServer);

           ToLuaCS.AddMember(L, "set_currTcpServer", set_currTcpServer);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BroadCast(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is Msg){
                  Msg msg_ = (Msg)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  target.BroadCast( msg_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is System.Byte[]){
                  System.Byte[] msg_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  target.BroadCast( msg_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  target.BroadCast();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Kick(LuaState L)
          {
                  System.Int32 SensionId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  target.Kick( SensionId_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Stop(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  target.Stop();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_autoBroadcast(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  var val=  target.autoBroadcast;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_autoBroadcast(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original;
                  target.autoBroadcast= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onClientConnectFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  var val=  target.onClientConnectFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onClientConnectFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onClientConnectFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onMessageArriveFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  var val=  target.onMessageArriveFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onMessageArriveFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onMessageArriveFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onClientCloseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original ;
                  var val=  target.onClientCloseFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onClientCloseFn(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  TcpServer target= (TcpServer) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onClientCloseFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StartTcpServer(LuaState L)
          {

                  TcpServer.StartTcpServer();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopTcpServer(LuaState L)
          {

                  TcpServer.StopTcpServer();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetLocalIP(LuaState L)
          {

                  System.Net.IPAddress getlocalip= TcpServer.GetLocalIP();
                  ToLuaCS.push(L,getlocalip);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _tcpserver(LuaState L)
          {

                  TcpServer _tcpserver= new TcpServer();
                  ToLuaCS.push(L,_tcpserver);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_GAME_TYPE(LuaState L)
          {
                  var val=   TcpServer.GAME_TYPE;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_port(LuaState L)
          {
                  var val=   TcpServer.port;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_port(LuaState L)
          {
                  TcpServer.port= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tcpClientConnected(LuaState L)
          {
                  var val=   TcpServer.tcpClientConnected;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tcpClientConnected(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  TcpServer.tcpClientConnected= (System.Threading.ManualResetEvent)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currTcpServer(LuaState L)
          {
                  var val=   TcpServer.currTcpServer;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_currTcpServer(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  TcpServer.currTcpServer= (TcpServer)val;
                  return 0;

          }
  #endregion       
}

