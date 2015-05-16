using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Resources {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Resources);
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
           ToLuaCS.AddMember(L, "FindObjectsOfTypeAll", FindObjectsOfTypeAll);

           ToLuaCS.AddMember(L, "Load", Load);

           ToLuaCS.AddMember(L, "LoadAll", LoadAll);

           ToLuaCS.AddMember(L, "GetBuiltinResource", GetBuiltinResource);

           ToLuaCS.AddMember(L, "LoadAssetAtPath", LoadAssetAtPath);

           ToLuaCS.AddMember(L, "UnloadAsset", UnloadAsset);

           ToLuaCS.AddMember(L, "UnloadUnusedAssets", UnloadUnusedAssets);

           ToLuaCS.AddMember(L, "__call", _resources);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindObjectsOfTypeAll(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object[] findobjectsoftypeall= UnityEngine.Resources.FindObjectsOfTypeAll( type_);
                  ToLuaCS.push(L,findobjectsoftypeall);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type systemTypeInstance_ = (System.Type)ToLuaCS.getObject(L, 2);

                  UnityEngine.Object load= UnityEngine.Resources.Load( path_, systemTypeInstance_);
                  ToLuaCS.push(L,load);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.Object load= UnityEngine.Resources.Load( path_);
                  ToLuaCS.push(L,load);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAll(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type systemTypeInstance_ = (System.Type)ToLuaCS.getObject(L, 2);

                  UnityEngine.Object[] loadall= UnityEngine.Resources.LoadAll( path_, systemTypeInstance_);
                  ToLuaCS.push(L,loadall);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.Object[] loadall= UnityEngine.Resources.LoadAll( path_);
                  ToLuaCS.push(L,loadall);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetBuiltinResource(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 1);
                  System.String path_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Object getbuiltinresource= UnityEngine.Resources.GetBuiltinResource( type_, path_);
                  ToLuaCS.push(L,getbuiltinresource);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAssetAtPath(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String assetPath_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                  UnityEngine.Object loadassetatpath= UnityEngine.Resources.LoadAssetAtPath( assetPath_, type_);
                  ToLuaCS.push(L,loadassetatpath);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnloadAsset(LuaState L)
          {
                  UnityEngine.Object assetToUnload_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Resources.UnloadAsset( assetToUnload_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnloadUnusedAssets(LuaState L)
          {

                  UnityEngine.AsyncOperation unloadunusedassets= UnityEngine.Resources.UnloadUnusedAssets();
                  ToLuaCS.push(L,unloadunusedassets);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _resources(LuaState L)
          {

                  UnityEngine.Resources _resources= new UnityEngine.Resources();
                  ToLuaCS.push(L,_resources);
                  return 1;

          }
  #endregion       
}

