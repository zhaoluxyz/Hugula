using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToFileHelper {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(FileHelper);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "UnZipFile", UnZipFile);

           ToLuaCS.AddMember(L, "UnpackConfigZip", UnpackConfigZip);

           ToLuaCS.AddMember(L, "PersistentUTF8File", PersistentUTF8File);

           ToLuaCS.AddMember(L, "UnpackConfigAssetBundleFn", UnpackConfigAssetBundleFn);

           ToLuaCS.AddMember(L, "__call", _filehelper);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnZipFile(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is System.Byte[] && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 1);
                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( bytes_, outPath_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is System.IO.Stream && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.IO.Stream stream_ = (System.IO.Stream)ToLuaCS.getObject(L, 1);
                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( stream_, outPath_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( path_, outPath_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnpackConfigZip(LuaState L)
          {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 1);
                  System.Action<System.String,System.String> ontz_ = (System.Action<System.String,System.String>)ToLuaCS.getObject(L, 2);

                  FileHelper.UnpackConfigZip( bytes_, ontz_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PersistentUTF8File(LuaState L)
          {
                  System.String context_ =  LuaDLL.lua_tostring(L,1); 

                  System.String fileName_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.PersistentUTF8File( context_, fileName_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnpackConfigAssetBundleFn(LuaState L)
          {
                  UnityEngine.AssetBundle ab_ = (UnityEngine.AssetBundle)ToLuaCS.getObject(L, 1);
                  LuaInterface.LuaFunction luaFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);

                  FileHelper.UnpackConfigAssetBundleFn( ab_, luaFn_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _filehelper(LuaState L)
          {

                  FileHelper _filehelper= new FileHelper();
                  ToLuaCS.push(L,_filehelper);
                  return 1;

          }
  #endregion       
}

