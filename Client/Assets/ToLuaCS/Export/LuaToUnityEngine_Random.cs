using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Random {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Random);
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
           ToLuaCS.AddMember(L, "get_seed", get_seed);

           ToLuaCS.AddMember(L, "set_seed", set_seed);

           ToLuaCS.AddMember(L, "Range", Range);

           ToLuaCS.AddMember(L, "get_value", get_value);

           ToLuaCS.AddMember(L, "get_insideUnitSphere", get_insideUnitSphere);

           ToLuaCS.AddMember(L, "get_insideUnitCircle", get_insideUnitCircle);

           ToLuaCS.AddMember(L, "get_onUnitSphere", get_onUnitSphere);

           ToLuaCS.AddMember(L, "get_rotation", get_rotation);

           ToLuaCS.AddMember(L, "get_rotationUniform", get_rotationUniform);

           ToLuaCS.AddMember(L, "__call", _random);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_seed(LuaState L)
          {

                  System.Int32 seed= UnityEngine.Random.seed;
                  LuaDLL.lua_pushnumber(L, seed);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_seed(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Random.seed= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Range(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  System.Int32 min_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 max_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 range= UnityEngine.Random.Range( min_, max_);
                  LuaDLL.lua_pushnumber(L, range);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  System.Single min_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single max_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single range= UnityEngine.Random.Range( min_, max_);
                  LuaDLL.lua_pushnumber(L, range);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_value(LuaState L)
          {

                  System.Single value= UnityEngine.Random.value;
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_insideUnitSphere(LuaState L)
          {

                  UnityEngine.Vector3 insideUnitSphere= UnityEngine.Random.insideUnitSphere;
                  ToLuaCS.push(L,insideUnitSphere);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_insideUnitCircle(LuaState L)
          {

                  UnityEngine.Vector2 insideUnitCircle= UnityEngine.Random.insideUnitCircle;
                  ToLuaCS.push(L,insideUnitCircle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUnitSphere(LuaState L)
          {

                  UnityEngine.Vector3 onUnitSphere= UnityEngine.Random.onUnitSphere;
                  ToLuaCS.push(L,onUnitSphere);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotation(LuaState L)
          {

                  UnityEngine.Quaternion rotation= UnityEngine.Random.rotation;
                  ToLuaCS.push(L,rotation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotationUniform(LuaState L)
          {

                  UnityEngine.Quaternion rotationUniform= UnityEngine.Random.rotationUniform;
                  ToLuaCS.push(L,rotationUniform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _random(LuaState L)
          {

                  UnityEngine.Random _random= new UnityEngine.Random();
                  ToLuaCS.push(L,_random);
                  return 1;

          }
  #endregion       
}

