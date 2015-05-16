using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_AssetBundle {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.AssetBundle);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_mainAsset", get_mainAsset);
           ToLuaCS.AddMember(L, "Contains", Contains);
           ToLuaCS.AddMember(L, "LoadAsset", LoadAsset);
           ToLuaCS.AddMember(L, "LoadAssetAsync", LoadAssetAsync);
           ToLuaCS.AddMember(L, "LoadAssetWithSubAssets", LoadAssetWithSubAssets);
           ToLuaCS.AddMember(L, "LoadAssetWithSubAssetsAsync", LoadAssetWithSubAssetsAsync);
           ToLuaCS.AddMember(L, "LoadAllAssets", LoadAllAssets);
           ToLuaCS.AddMember(L, "LoadAllAssetsAsync", LoadAllAssetsAsync);
           ToLuaCS.AddMember(L, "Unload", Unload);
           ToLuaCS.AddMember(L, "AllAssetNames", AllAssetNames);
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
           ToLuaCS.AddMember(L, "CreateFromMemory", CreateFromMemory);

           ToLuaCS.AddMember(L, "CreateFromMemoryImmediate", CreateFromMemoryImmediate);

           ToLuaCS.AddMember(L, "CreateFromFile", CreateFromFile);

           ToLuaCS.AddMember(L, "__call", _assetbundle);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainAsset(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object mainAsset= target.mainAsset;
                  ToLuaCS.push(L,mainAsset);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Contains(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Boolean contains= target.Contains( name_);
                  LuaDLL.lua_pushboolean(L,contains);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAsset(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object loadasset= target.LoadAsset( name_, type_);
                  ToLuaCS.push(L,loadasset);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object loadasset= target.LoadAsset( name_);
                  ToLuaCS.push(L,loadasset);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAssetAsync(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadassetasync= target.LoadAssetAsync( name_, type_);
                  ToLuaCS.push(L,loadassetasync);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadassetasync= target.LoadAssetAsync( name_);
                  ToLuaCS.push(L,loadassetasync);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAssetWithSubAssets(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadassetwithsubassets= target.LoadAssetWithSubAssets( name_, type_);
                  ToLuaCS.push(L,loadassetwithsubassets);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadassetwithsubassets= target.LoadAssetWithSubAssets( name_);
                  ToLuaCS.push(L,loadassetwithsubassets);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAssetWithSubAssetsAsync(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadassetwithsubassetsasync= target.LoadAssetWithSubAssetsAsync( name_, type_);
                  ToLuaCS.push(L,loadassetwithsubassetsasync);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadassetwithsubassetsasync= target.LoadAssetWithSubAssetsAsync( name_);
                  ToLuaCS.push(L,loadassetwithsubassetsasync);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAllAssets(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadallassets= target.LoadAllAssets( type_);
                  ToLuaCS.push(L,loadallassets);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if(true){

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadallassets= target.LoadAllAssets();
                  ToLuaCS.push(L,loadallassets);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAllAssetsAsync(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadallassetsasync= target.LoadAllAssetsAsync( type_);
                  ToLuaCS.push(L,loadallassetsasync);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if(true){

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadallassetsasync= target.LoadAllAssetsAsync();
                  ToLuaCS.push(L,loadallassetsasync);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Unload(LuaState L)
          {
                  System.Boolean unloadAllLoadedObjects_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.Unload( unloadAllLoadedObjects_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AllAssetNames(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.String[] allassetnames= target.AllAssetNames();
                  ToLuaCS.push(L,allassetnames);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreateFromMemory(LuaState L)
          {
                  System.Byte[] binary_ = (System.Byte[])ToLuaCS.getObject(L, 1);

                  UnityEngine.AssetBundleCreateRequest createfrommemory= UnityEngine.AssetBundle.CreateFromMemory( binary_);
                  ToLuaCS.push(L,createfrommemory);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreateFromMemoryImmediate(LuaState L)
          {
                  System.Byte[] binary_ = (System.Byte[])ToLuaCS.getObject(L, 1);

                  UnityEngine.AssetBundle createfrommemoryimmediate= UnityEngine.AssetBundle.CreateFromMemoryImmediate( binary_);
                  ToLuaCS.push(L,createfrommemoryimmediate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreateFromFile(LuaState L)
          {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.AssetBundle createfromfile= UnityEngine.AssetBundle.CreateFromFile( path_);
                  ToLuaCS.push(L,createfromfile);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _assetbundle(LuaState L)
          {

                  UnityEngine.AssetBundle _assetbundle= new UnityEngine.AssetBundle();
                  ToLuaCS.push(L,_assetbundle);
                  return 1;

          }
  #endregion       
}

