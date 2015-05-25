using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_WWW {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.WWW);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Dispose", Dispose);
           ToLuaCS.AddMember(L, "InitWWW", InitWWW);
           ToLuaCS.AddMember(L, "get_responseHeaders", get_responseHeaders);
           ToLuaCS.AddMember(L, "get_text", get_text);
           ToLuaCS.AddMember(L, "get_bytes", get_bytes);
           ToLuaCS.AddMember(L, "get_size", get_size);
           ToLuaCS.AddMember(L, "get_error", get_error);
           ToLuaCS.AddMember(L, "get_texture", get_texture);
           ToLuaCS.AddMember(L, "get_textureNonReadable", get_textureNonReadable);
           ToLuaCS.AddMember(L, "get_audioClip", get_audioClip);
           ToLuaCS.AddMember(L, "GetAudioClip", GetAudioClip);
           ToLuaCS.AddMember(L, "get_movie", get_movie);
           ToLuaCS.AddMember(L, "LoadImageIntoTexture", LoadImageIntoTexture);
           ToLuaCS.AddMember(L, "get_isDone", get_isDone);
           ToLuaCS.AddMember(L, "get_progress", get_progress);
           ToLuaCS.AddMember(L, "get_uploadProgress", get_uploadProgress);
           ToLuaCS.AddMember(L, "get_bytesDownloaded", get_bytesDownloaded);
           ToLuaCS.AddMember(L, "LoadUnityWeb", LoadUnityWeb);
           ToLuaCS.AddMember(L, "get_url", get_url);
           ToLuaCS.AddMember(L, "get_assetBundle", get_assetBundle);
           ToLuaCS.AddMember(L, "get_threadPriority", get_threadPriority);
           ToLuaCS.AddMember(L, "set_threadPriority", set_threadPriority);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "GetType", GetType);
           ToLuaCS.AddMember(L, "ToString", ToString);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "EscapeURL", EscapeURL);

           ToLuaCS.AddMember(L, "UnEscapeURL", UnEscapeURL);

           ToLuaCS.AddMember(L, "LoadFromCacheOrDownload", LoadFromCacheOrDownload);

           ToLuaCS.AddMember(L, "__call", _www);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.Dispose();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InitWWW(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  System.Byte[] postData_ = (System.Byte[])ToLuaCS.getObject(L, 3);
                  System.String[] iHeaders_ = (System.String[])ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.InitWWW( url_, postData_, iHeaders_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_responseHeaders(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Collections.Generic.Dictionary<System.String,System.String> responseHeaders= target.responseHeaders;
                  ToLuaCS.push(L,responseHeaders);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_text(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String text= target.text;
                  LuaDLL.lua_pushstring(L, text);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_bytes(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Byte[] bytes= target.bytes;
                  ToLuaCS.push(L,bytes);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_size(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 size= target.size;
                  LuaDLL.lua_pushnumber(L, size);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_error(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String error= target.error;
                  LuaDLL.lua_pushstring(L, error);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_texture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.Texture2D texture= target.texture;
                  ToLuaCS.push(L,texture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_textureNonReadable(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.Texture2D textureNonReadable= target.textureNonReadable;
                  ToLuaCS.push(L,textureNonReadable);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audioClip(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip audioClip= target.audioClip;
                  ToLuaCS.push(L,audioClip);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAudioClip(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);
                  System.Boolean stream_ =  LuaDLL.lua_toboolean(L,3);
                  UnityEngine.AudioType audioType_ = (UnityEngine.AudioType)ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_, stream_, audioType_);
                  ToLuaCS.push(L,getaudioclip);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);
                  System.Boolean stream_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_, stream_);
                  ToLuaCS.push(L,getaudioclip);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_);
                  ToLuaCS.push(L,getaudioclip);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_movie(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.MovieTexture movie= target.movie;
                  ToLuaCS.push(L,movie);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadImageIntoTexture(LuaState L)
          {
                  UnityEngine.Texture2D tex_ = (UnityEngine.Texture2D)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.LoadImageIntoTexture( tex_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isDone(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Boolean isDone= target.isDone;
                  LuaDLL.lua_pushboolean(L,isDone);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_progress(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Single progress= target.progress;
                  LuaDLL.lua_pushnumber(L, progress);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_uploadProgress(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Single uploadProgress= target.uploadProgress;
                  LuaDLL.lua_pushnumber(L, uploadProgress);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_bytesDownloaded(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 bytesDownloaded= target.bytesDownloaded;
                  LuaDLL.lua_pushnumber(L, bytesDownloaded);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadUnityWeb(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  //UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  //target.LoadUnityWeb();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_url(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String url= target.url;
                  LuaDLL.lua_pushstring(L, url);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_assetBundle(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AssetBundle assetBundle= target.assetBundle;
                  ToLuaCS.push(L,assetBundle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_threadPriority(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.ThreadPriority threadPriority= target.threadPriority;
                  ToLuaCS.push(L,threadPriority);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_threadPriority(LuaState L)
          {
                  UnityEngine.ThreadPriority value_ = (UnityEngine.ThreadPriority)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.threadPriority= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int EscapeURL(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 

                  System.Text.Encoding e_ = (System.Text.Encoding)ToLuaCS.getObject(L, 2);

                  System.String escapeurl= UnityEngine.WWW.EscapeURL( s_, e_);
                  LuaDLL.lua_pushstring(L, escapeurl);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 


                  System.String escapeurl= UnityEngine.WWW.EscapeURL( s_);
                  LuaDLL.lua_pushstring(L, escapeurl);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnEscapeURL(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 

                  System.Text.Encoding e_ = (System.Text.Encoding)ToLuaCS.getObject(L, 2);

                  System.String unescapeurl= UnityEngine.WWW.UnEscapeURL( s_, e_);
                  LuaDLL.lua_pushstring(L, unescapeurl);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 


                  System.String unescapeurl= UnityEngine.WWW.UnEscapeURL( s_);
                  LuaDLL.lua_pushstring(L, unescapeurl);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadFromCacheOrDownload(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is UnityEngine.Hash128 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  UnityEngine.Hash128 hash_ = (UnityEngine.Hash128)ToLuaCS.getObject(L, 2);
                  System.UInt32 crc_ = (System.UInt32)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, hash_, crc_);
                  ToLuaCS.push(L,loadfromcacheordownload);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 version_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.UInt32 crc_ = (System.UInt32)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, version_, crc_);
                  ToLuaCS.push(L,loadfromcacheordownload);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 version_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, version_);
                  ToLuaCS.push(L,loadfromcacheordownload);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is UnityEngine.Hash128){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  UnityEngine.Hash128 hash_ = (UnityEngine.Hash128)ToLuaCS.getObject(L, 2);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, hash_);
                  ToLuaCS.push(L,loadfromcacheordownload);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _www(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               //if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Byte[] && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
               //   System.String url_ =  LuaDLL.lua_tostring(L,2); 

               //   System.Byte[] postData_ = (System.Byte[])ToLuaCS.getObject(L, 3);
               //   System.Collections.Hashtable headers_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

               //   UnityEngine.WWW _www= new UnityEngine.WWW( url_, postData_, headers_);
               //   ToLuaCS.push(L,_www);
               //   return 1;

               //}
               //if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Byte[] && ToLuaCS.getObject(L, 4) is System.Collections.Generic.Dictionary<System.String,System.String>){
                   System.String url_ = LuaDLL.lua_tostring(L, 2);

                   System.Byte[] postData_ = (System.Byte[])ToLuaCS.getObject(L, 3);
                   System.Collections.Generic.Dictionary<System.String, System.String> headers_ = (System.Collections.Generic.Dictionary<System.String, System.String>)ToLuaCS.getObject(L, 4);

                   UnityEngine.WWW _www = new UnityEngine.WWW(url_, postData_, headers_);
                   ToLuaCS.push(L, _www);
                   return 1;

               //}
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Byte[]){
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  System.Byte[] postData_ = (System.Byte[])ToLuaCS.getObject(L, 3);

                  UnityEngine.WWW _www= new UnityEngine.WWW( url_, postData_);
                  ToLuaCS.push(L,_www);
                  return 1;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.WWWForm){
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.WWWForm form_ = (UnityEngine.WWWForm)ToLuaCS.getObject(L, 3);

                  UnityEngine.WWW _www= new UnityEngine.WWW( url_, form_);
                  ToLuaCS.push(L,_www);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.WWW _www= new UnityEngine.WWW( url_);
                  ToLuaCS.push(L,_www);
                  return 1;

                 }
               return 0;
          }
  #endregion       
}

