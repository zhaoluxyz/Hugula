using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToReferGameObjects {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(ReferGameObjects);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_refers", get_refers);
           ToLuaCS.AddMember(L, "set_refers", set_refers);
           ToLuaCS.AddMember(L, "get_monos", get_monos);
           ToLuaCS.AddMember(L, "set_monos", set_monos);
           ToLuaCS.AddMember(L, "get_userObject", get_userObject);
           ToLuaCS.AddMember(L, "set_userObject", set_userObject);
           ToLuaCS.AddMember(L, "get_userBool", get_userBool);
           ToLuaCS.AddMember(L, "set_userBool", set_userBool);
           ToLuaCS.AddMember(L, "get_userInt", get_userInt);
           ToLuaCS.AddMember(L, "set_userInt", set_userInt);
           ToLuaCS.AddMember(L, "get_userFloat", get_userFloat);
           ToLuaCS.AddMember(L, "set_userFloat", set_userFloat);
           ToLuaCS.AddMember(L, "get_userString", get_userString);
           ToLuaCS.AddMember(L, "set_userString", set_userString);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _refergameobjects);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_refers(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.refers;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_refers(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.refers= (System.Collections.Generic.List<UnityEngine.GameObject>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_monos(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.monos;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_monos(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.monos= (System.Collections.Generic.List<UnityEngine.Behaviour>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userObject(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userObject;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userObject(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userObject= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userBool(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userBool;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userBool(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userBool= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userInt(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userInt;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userInt(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userInt= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userFloat(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userFloat;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userFloat(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userFloat= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userString(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userString;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userString(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userString= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _refergameobjects(LuaState L)
          {

                  ReferGameObjects _refergameobjects= new ReferGameObjects();
                  ToLuaCS.push(L,_refergameobjects);
                  return 1;

          }
  #endregion       
}

