using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Resources {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Resources).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Resources).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(UnityEngine.Resources).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(UnityEngine.Resources).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Resources).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"FindObjectsOfTypeAll");
          luafn_FindObjectsOfTypeAll= new LuaCSFunction(FindObjectsOfTypeAll);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FindObjectsOfTypeAll);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Load");
          luafn_Load= new LuaCSFunction(Load);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Load);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadAll");
          luafn_LoadAll= new LuaCSFunction(LoadAll);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadAll);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetBuiltinResource");
          luafn_GetBuiltinResource= new LuaCSFunction(GetBuiltinResource);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetBuiltinResource);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadAssetAtPath");
          luafn_LoadAssetAtPath= new LuaCSFunction(LoadAssetAtPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadAssetAtPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnloadAsset");
          luafn_UnloadAsset= new LuaCSFunction(UnloadAsset);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnloadAsset);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnloadUnusedAssets");
          luafn_UnloadUnusedAssets= new LuaCSFunction(UnloadUnusedAssets);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnloadUnusedAssets);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"__call");
          luafn__resources= new LuaCSFunction(_resources);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__resources);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_FindObjectsOfTypeAll;
          private static LuaCSFunction luafn_Load;
          private static LuaCSFunction luafn_LoadAll;
          private static LuaCSFunction luafn_GetBuiltinResource;
          private static LuaCSFunction luafn_LoadAssetAtPath;
          private static LuaCSFunction luafn_UnloadAsset;
          private static LuaCSFunction luafn_UnloadUnusedAssets;
          private static LuaCSFunction luafn__resources;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Resources target= (UnityEngine.Resources) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindObjectsOfTypeAll(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,1);

                  UnityEngine.Object[] findobjectsoftypeall= UnityEngine.Resources.FindObjectsOfTypeAll( type_);
                  ToLuaCS.push(L,findobjectsoftypeall); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type systemTypeInstance_ = (System.Type)ToLuaCS.getObject(L,2);

                  UnityEngine.Object load= UnityEngine.Resources.Load( path_, systemTypeInstance_);
                  ToLuaCS.push(L,load); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.Object load= UnityEngine.Resources.Load( path_);
                  ToLuaCS.push(L,load); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAll(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type systemTypeInstance_ = (System.Type)ToLuaCS.getObject(L,2);

                  UnityEngine.Object[] loadall= UnityEngine.Resources.LoadAll( path_, systemTypeInstance_);
                  ToLuaCS.push(L,loadall); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.Object[] loadall= UnityEngine.Resources.LoadAll( path_);
                  ToLuaCS.push(L,loadall); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetBuiltinResource(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is System.Type && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,1);
                  System.String path_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Object getbuiltinresource= UnityEngine.Resources.GetBuiltinResource( type_, path_);
                  ToLuaCS.push(L,getbuiltinresource); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAssetAtPath(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.String assetPath_ =  LuaDLL.lua_tostring(L,1); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  UnityEngine.Object loadassetatpath= UnityEngine.Resources.LoadAssetAtPath( assetPath_, type_);
                  ToLuaCS.push(L,loadassetatpath); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnloadAsset(LuaState L)
          {
                  UnityEngine.Object assetToUnload_ = (UnityEngine.Object)ToLuaCS.getObject(L,1);

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

