using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToSystem_Object {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(System.Object);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "GetType", GetType);
           ToLuaCS.AddMember(L, "ToString", ToString);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "ReferenceEquals", ReferenceEquals);

           ToLuaCS.AddMember(L, "__call", _object);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.Object objA_ = (System.Object)ToLuaCS.getObject(L, 2);
                  System.Object objB_ = (System.Object)ToLuaCS.getObject(L, 3);

                  System.Boolean equals= System.Object.Equals( objA_, objB_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  System.Object target= (System.Object) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  System.Object target= (System.Object) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  System.Object target= (System.Object) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  System.Object target= (System.Object) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReferenceEquals(LuaState L)
          {
                  System.Object objA_ = (System.Object)ToLuaCS.getObject(L, 1);
                  System.Object objB_ = (System.Object)ToLuaCS.getObject(L, 2);

                  System.Boolean referenceequals= System.Object.ReferenceEquals( objA_, objB_);
                  LuaDLL.lua_pushboolean(L,referenceequals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _object(LuaState L)
          {

                  System.Object _object= new System.Object();
                  ToLuaCS.push(L,_object);
                  return 1;

          }
  #endregion       
}

