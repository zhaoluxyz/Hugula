using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Object {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Object);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_name", get_name);
           ToLuaCS.AddMember(L, "set_name", set_name);
           ToLuaCS.AddMember(L, "get_hideFlags", get_hideFlags);
           ToLuaCS.AddMember(L, "set_hideFlags", set_hideFlags);
           ToLuaCS.AddMember(L, "ToString", ToString);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "GetInstanceID", GetInstanceID);
           ToLuaCS.AddMember(L, "GetType", GetType);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Destroy", Destroy);

           ToLuaCS.AddMember(L, "DestroyImmediate", DestroyImmediate);

           ToLuaCS.AddMember(L, "FindObjectsOfType", FindObjectsOfType);

           ToLuaCS.AddMember(L, "DontDestroyOnLoad", DontDestroyOnLoad);

           ToLuaCS.AddMember(L, "DestroyObject", DestroyObject);

           ToLuaCS.AddMember(L, "Instantiate", Instantiate);

           ToLuaCS.AddMember(L, "FindObjectOfType", FindObjectOfType);

           ToLuaCS.AddMember(L, "__call", _object);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Object target= (UnityEngine.Object) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Destroy(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Object.Destroy( obj_, t_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object.Destroy( obj_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DestroyImmediate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.Boolean allowDestroyingAssets_ =  LuaDLL.lua_toboolean(L,2);

                  UnityEngine.Object.DestroyImmediate( obj_, allowDestroyingAssets_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object.DestroyImmediate( obj_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindObjectsOfType(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object[] findobjectsoftype= UnityEngine.Object.FindObjectsOfType( type_);
                  ToLuaCS.push(L,findobjectsoftype);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DontDestroyOnLoad(LuaState L)
          {
                  UnityEngine.Object target_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object.DontDestroyOnLoad( target_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DestroyObject(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Object.DestroyObject( obj_, t_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object.DestroyObject( obj_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Instantiate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Quaternion rotation_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 3);

                  UnityEngine.Object instantiate= UnityEngine.Object.Instantiate( original_, position_, rotation_);
                  ToLuaCS.push(L,instantiate);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Object){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object instantiate= UnityEngine.Object.Instantiate( original_);
                  ToLuaCS.push(L,instantiate);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindObjectOfType(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object findobjectoftype= UnityEngine.Object.FindObjectOfType( type_);
                  ToLuaCS.push(L,findobjectoftype);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _object(LuaState L)
          {

                  UnityEngine.Object _object= new UnityEngine.Object();
                  ToLuaCS.push(L,_object);
                  return 1;

          }
  #endregion       
}

