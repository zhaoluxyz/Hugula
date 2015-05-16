using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_PlayerPrefs {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.PlayerPrefs);
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
           ToLuaCS.AddMember(L, "SetInt", SetInt);

           ToLuaCS.AddMember(L, "GetInt", GetInt);

           ToLuaCS.AddMember(L, "SetFloat", SetFloat);

           ToLuaCS.AddMember(L, "GetFloat", GetFloat);

           ToLuaCS.AddMember(L, "SetString", SetString);

           ToLuaCS.AddMember(L, "GetString", GetString);

           ToLuaCS.AddMember(L, "HasKey", HasKey);

           ToLuaCS.AddMember(L, "DeleteKey", DeleteKey);

           ToLuaCS.AddMember(L, "DeleteAll", DeleteAll);

           ToLuaCS.AddMember(L, "Save", Save);

           ToLuaCS.AddMember(L, "__call", _playerprefs);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.PlayerPrefs target= (UnityEngine.PlayerPrefs) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.PlayerPrefs target= (UnityEngine.PlayerPrefs) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.PlayerPrefs target= (UnityEngine.PlayerPrefs) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.PlayerPrefs target= (UnityEngine.PlayerPrefs) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetInt(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.PlayerPrefs.SetInt( key_, value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInt(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 defaultValue_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 getint= UnityEngine.PlayerPrefs.GetInt( key_, defaultValue_);
                  LuaDLL.lua_pushnumber(L, getint);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.Int32 getint= UnityEngine.PlayerPrefs.GetInt( key_);
                  LuaDLL.lua_pushnumber(L, getint);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetFloat(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.PlayerPrefs.SetFloat( key_, value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFloat(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.Single defaultValue_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single getfloat= UnityEngine.PlayerPrefs.GetFloat( key_, defaultValue_);
                  LuaDLL.lua_pushnumber(L, getfloat);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.Single getfloat= UnityEngine.PlayerPrefs.GetFloat( key_);
                  LuaDLL.lua_pushnumber(L, getfloat);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetString(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.PlayerPrefs.SetString( key_, value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetString(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 

                  System.String defaultValue_ =  LuaDLL.lua_tostring(L,2); 


                  System.String getstring= UnityEngine.PlayerPrefs.GetString( key_, defaultValue_);
                  LuaDLL.lua_pushstring(L, getstring);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getstring= UnityEngine.PlayerPrefs.GetString( key_);
                  LuaDLL.lua_pushstring(L, getstring);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int HasKey(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.Boolean haskey= UnityEngine.PlayerPrefs.HasKey( key_);
                  LuaDLL.lua_pushboolean(L,haskey);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DeleteKey(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.PlayerPrefs.DeleteKey( key_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DeleteAll(LuaState L)
          {

                  UnityEngine.PlayerPrefs.DeleteAll();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Save(LuaState L)
          {

                  UnityEngine.PlayerPrefs.Save();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _playerprefs(LuaState L)
          {

                  UnityEngine.PlayerPrefs _playerprefs= new UnityEngine.PlayerPrefs();
                  ToLuaCS.push(L,_playerprefs);
                  return 1;

          }
  #endregion       
}

