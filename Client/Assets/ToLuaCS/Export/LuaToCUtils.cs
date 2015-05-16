using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCUtils {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CUtils);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "GetURLFileSuffix", GetURLFileSuffix);

           ToLuaCS.AddMember(L, "GetURLFileName", GetURLFileName);

           ToLuaCS.AddMember(L, "GetKeyURLFileName", GetKeyURLFileName);

           ToLuaCS.AddMember(L, "GetURLFullFileName", GetURLFullFileName);

           ToLuaCS.AddMember(L, "GetFileFullPath", GetFileFullPath);

           ToLuaCS.AddMember(L, "GetAssetFullPath", GetAssetFullPath);

           ToLuaCS.AddMember(L, "GetFileFullPathNoProtocol", GetFileFullPathNoProtocol);

           ToLuaCS.AddMember(L, "GetDirectoryFullPathNoProtocol", GetDirectoryFullPathNoProtocol);

           ToLuaCS.AddMember(L, "get_dataPath", get_dataPath);

           ToLuaCS.AddMember(L, "GetAssetPath", GetAssetPath);

           ToLuaCS.AddMember(L, "Collect", Collect);

           ToLuaCS.AddMember(L, "Execute", Execute);

           ToLuaCS.AddMember(L, "__call", _cutils);

           ToLuaCS.AddMember(L, "get_currPersistentExist", get_currPersistentExist);

           ToLuaCS.AddMember(L, "set_currPersistentExist", set_currPersistentExist);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFileSuffix(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfilesuffix= CUtils.GetURLFileSuffix( url_);
                  LuaDLL.lua_pushstring(L, geturlfilesuffix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfilename= CUtils.GetURLFileName( url_);
                  LuaDLL.lua_pushstring(L, geturlfilename);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetKeyURLFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getkeyurlfilename= CUtils.GetKeyURLFileName( url_);
                  LuaDLL.lua_pushstring(L, getkeyurlfilename);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFullFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfullfilename= CUtils.GetURLFullFileName( url_);
                  LuaDLL.lua_pushstring(L, geturlfullfilename);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFileFullPath(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getfilefullpath= CUtils.GetFileFullPath( absolutePath_);
                  LuaDLL.lua_pushstring(L, getfilefullpath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAssetFullPath(LuaState L)
          {
                  System.String assetPath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getassetfullpath= CUtils.GetAssetFullPath( assetPath_);
                  LuaDLL.lua_pushstring(L, getassetfullpath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFileFullPathNoProtocol(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getfilefullpathnoprotocol= CUtils.GetFileFullPathNoProtocol( absolutePath_);
                  LuaDLL.lua_pushstring(L, getfilefullpathnoprotocol);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetDirectoryFullPathNoProtocol(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getdirectoryfullpathnoprotocol= CUtils.GetDirectoryFullPathNoProtocol( absolutePath_);
                  LuaDLL.lua_pushstring(L, getdirectoryfullpathnoprotocol);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dataPath(LuaState L)
          {

                  System.String dataPath= CUtils.dataPath;
                  LuaDLL.lua_pushstring(L, dataPath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAssetPath(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getassetpath= CUtils.GetAssetPath( name_);
                  LuaDLL.lua_pushstring(L, getassetpath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Collect(LuaState L)
          {

                  CUtils.Collect();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Execute(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is BetterList<System.Action>){
                  BetterList<System.Action> list_ = (BetterList<System.Action>)ToLuaCS.getObject(L, 1);

                  CUtils.Execute( list_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is System.Collections.Generic.IList<System.Action>){
                  System.Collections.Generic.IList<System.Action> list_ = (System.Collections.Generic.IList<System.Action>)ToLuaCS.getObject(L, 1);

                  CUtils.Execute( list_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _cutils(LuaState L)
          {

                  CUtils _cutils= new CUtils();
                  ToLuaCS.push(L,_cutils);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currPersistentExist(LuaState L)
          {
                  var val=   CUtils.currPersistentExist;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_currPersistentExist(LuaState L)
          {
                  CUtils.currPersistentExist= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
  #endregion       
}

