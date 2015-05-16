using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToSession {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Session);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_id", get_id);
           ToLuaCS.AddMember(L, "Send", Send);
           ToLuaCS.AddMember(L, "Close", Close);
           ToLuaCS.AddMember(L, "get_Client", get_Client);
           ToLuaCS.AddMember(L, "Receive", Receive);
           ToLuaCS.AddMember(L, "GetMessage", GetMessage);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _session);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_id(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  System.Int32 id= target.id;
                  LuaDLL.lua_pushnumber(L, id);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Send(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is Msg){
                  Msg msg_ = (Msg)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  target.Send( msg_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is System.Byte[]){
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  target.Send( bytes_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Close(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  target.Close();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Client(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  System.Net.Sockets.TcpClient Client= target.Client;
                  ToLuaCS.push(L,Client);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Receive(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  target.Receive();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetMessage(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Session target= (Session) original ;
                  System.Byte[] getmessage= target.GetMessage();
                  ToLuaCS.push(L,getmessage);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _session(LuaState L)
          {
                  System.Net.Sockets.TcpClient client_ = (System.Net.Sockets.TcpClient)ToLuaCS.getObject(L, 1);

                  Session _session= new Session( client_);
                  ToLuaCS.push(L,_session);
                  return 1;

          }
  #endregion       
}

