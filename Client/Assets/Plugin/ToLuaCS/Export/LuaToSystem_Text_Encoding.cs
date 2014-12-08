using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToSystem_Text_Encoding {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(System.Text.Encoding).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(System.Text.Encoding).AssemblyQualifiedName);
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
          System.Type superT = typeof(System.Text.Encoding).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_IsReadOnly");
          luafn_get_IsReadOnly= new LuaCSFunction(get_IsReadOnly);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsReadOnly);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsSingleByte");
          luafn_get_IsSingleByte= new LuaCSFunction(get_IsSingleByte);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsSingleByte);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_DecoderFallback");
          luafn_get_DecoderFallback= new LuaCSFunction(get_DecoderFallback);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_DecoderFallback);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_DecoderFallback");
          luafn_set_DecoderFallback= new LuaCSFunction(set_DecoderFallback);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_DecoderFallback);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_EncoderFallback");
          luafn_get_EncoderFallback= new LuaCSFunction(get_EncoderFallback);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_EncoderFallback);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_EncoderFallback");
          luafn_set_EncoderFallback= new LuaCSFunction(set_EncoderFallback);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_EncoderFallback);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetByteCount");
          luafn_GetByteCount= new LuaCSFunction(GetByteCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetByteCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetBytes");
          luafn_GetBytes= new LuaCSFunction(GetBytes);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetBytes);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetCharCount");
          luafn_GetCharCount= new LuaCSFunction(GetCharCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetCharCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetChars");
          luafn_GetChars= new LuaCSFunction(GetChars);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetChars);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetDecoder");
          luafn_GetDecoder= new LuaCSFunction(GetDecoder);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetDecoder);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetEncoder");
          luafn_GetEncoder= new LuaCSFunction(GetEncoder);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetEncoder);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Clone");
          luafn_Clone= new LuaCSFunction(Clone);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Clone);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"IsAlwaysNormalized");
          luafn_IsAlwaysNormalized= new LuaCSFunction(IsAlwaysNormalized);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_IsAlwaysNormalized);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetMaxByteCount");
          luafn_GetMaxByteCount= new LuaCSFunction(GetMaxByteCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetMaxByteCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetMaxCharCount");
          luafn_GetMaxCharCount= new LuaCSFunction(GetMaxCharCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetMaxCharCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetPreamble");
          luafn_GetPreamble= new LuaCSFunction(GetPreamble);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetPreamble);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetString");
          luafn_GetString= new LuaCSFunction(GetString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_BodyName");
          luafn_get_BodyName= new LuaCSFunction(get_BodyName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_BodyName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_CodePage");
          luafn_get_CodePage= new LuaCSFunction(get_CodePage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_CodePage);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_EncodingName");
          luafn_get_EncodingName= new LuaCSFunction(get_EncodingName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_EncodingName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_HeaderName");
          luafn_get_HeaderName= new LuaCSFunction(get_HeaderName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_HeaderName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsBrowserDisplay");
          luafn_get_IsBrowserDisplay= new LuaCSFunction(get_IsBrowserDisplay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsBrowserDisplay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsBrowserSave");
          luafn_get_IsBrowserSave= new LuaCSFunction(get_IsBrowserSave);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsBrowserSave);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsMailNewsDisplay");
          luafn_get_IsMailNewsDisplay= new LuaCSFunction(get_IsMailNewsDisplay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsMailNewsDisplay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsMailNewsSave");
          luafn_get_IsMailNewsSave= new LuaCSFunction(get_IsMailNewsSave);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsMailNewsSave);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_WebName");
          luafn_get_WebName= new LuaCSFunction(get_WebName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_WebName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_WindowsCodePage");
          luafn_get_WindowsCodePage= new LuaCSFunction(get_WindowsCodePage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_WindowsCodePage);
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
    
          string[] names = typeof(System.Text.Encoding).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(System.Text.Encoding).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"Convert");
          luafn_Convert= new LuaCSFunction(Convert);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Convert);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetEncoding");
          luafn_GetEncoding= new LuaCSFunction(GetEncoding);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetEncoding);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetEncodings");
          luafn_GetEncodings= new LuaCSFunction(GetEncodings);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetEncodings);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_ASCII");
          luafn_get_ASCII= new LuaCSFunction(get_ASCII);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_ASCII);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_BigEndianUnicode");
          luafn_get_BigEndianUnicode= new LuaCSFunction(get_BigEndianUnicode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_BigEndianUnicode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Default");
          luafn_get_Default= new LuaCSFunction(get_Default);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Default);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_UTF7");
          luafn_get_UTF7= new LuaCSFunction(get_UTF7);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_UTF7);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_UTF8");
          luafn_get_UTF8= new LuaCSFunction(get_UTF8);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_UTF8);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Unicode");
          luafn_get_Unicode= new LuaCSFunction(get_Unicode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Unicode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_UTF32");
          luafn_get_UTF32= new LuaCSFunction(get_UTF32);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_UTF32);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_IsReadOnly;
          private static LuaCSFunction luafn_get_IsSingleByte;
          private static LuaCSFunction luafn_get_DecoderFallback;
          private static LuaCSFunction luafn_set_DecoderFallback;
          private static LuaCSFunction luafn_get_EncoderFallback;
          private static LuaCSFunction luafn_set_EncoderFallback;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetByteCount;
          private static LuaCSFunction luafn_GetBytes;
          private static LuaCSFunction luafn_GetCharCount;
          private static LuaCSFunction luafn_GetChars;
          private static LuaCSFunction luafn_GetDecoder;
          private static LuaCSFunction luafn_GetEncoder;
          private static LuaCSFunction luafn_Clone;
          private static LuaCSFunction luafn_IsAlwaysNormalized;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetMaxByteCount;
          private static LuaCSFunction luafn_GetMaxCharCount;
          private static LuaCSFunction luafn_GetPreamble;
          private static LuaCSFunction luafn_GetString;
          private static LuaCSFunction luafn_get_BodyName;
          private static LuaCSFunction luafn_get_CodePage;
          private static LuaCSFunction luafn_get_EncodingName;
          private static LuaCSFunction luafn_get_HeaderName;
          private static LuaCSFunction luafn_get_IsBrowserDisplay;
          private static LuaCSFunction luafn_get_IsBrowserSave;
          private static LuaCSFunction luafn_get_IsMailNewsDisplay;
          private static LuaCSFunction luafn_get_IsMailNewsSave;
          private static LuaCSFunction luafn_get_WebName;
          private static LuaCSFunction luafn_get_WindowsCodePage;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_Convert;
          private static LuaCSFunction luafn_GetEncoding;
          private static LuaCSFunction luafn_GetEncodings;
          private static LuaCSFunction luafn_get_ASCII;
          private static LuaCSFunction luafn_get_BigEndianUnicode;
          private static LuaCSFunction luafn_get_Default;
          private static LuaCSFunction luafn_get_UTF7;
          private static LuaCSFunction luafn_get_UTF8;
          private static LuaCSFunction luafn_get_Unicode;
          private static LuaCSFunction luafn_get_UTF32;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsReadOnly(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsReadOnly= target.IsReadOnly;
                  ToLuaCS.push(L,IsReadOnly); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsSingleByte(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsSingleByte= target.IsSingleByte;
                  ToLuaCS.push(L,IsSingleByte); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_DecoderFallback(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Text.DecoderFallback DecoderFallback= target.DecoderFallback;
                  ToLuaCS.push(L,DecoderFallback); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_DecoderFallback(LuaState L)
          {
                  System.Text.DecoderFallback value_ = (System.Text.DecoderFallback)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  target.DecoderFallback= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_EncoderFallback(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Text.EncoderFallback EncoderFallback= target.EncoderFallback;
                  ToLuaCS.push(L,EncoderFallback); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_EncoderFallback(LuaState L)
          {
                  System.Text.EncoderFallback value_ = (System.Text.EncoderFallback)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  target.EncoderFallback= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean equals= target.Equals( value_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public  static int GetByteCount(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Char[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( chars_, index_, count_);
                  ToLuaCS.push(L,getbytecount); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Char* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Char* chars_ = (System.Char*)ToLuaCS.getObject(L,2);
              //    System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.Encoding target= (System.Text.Encoding) original ;
              //    System.Int32 getbytecount= target.GetByteCount( chars_, count_);
              //    ToLuaCS.push(L,getbytecount); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Char[])
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( chars_);
                  ToLuaCS.push(L,getbytecount); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( s_);
                  ToLuaCS.push(L,getbytecount); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetBytes(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Byte[] && LuaDLL.lua_type(L,6)==LuaTypes.LUA_TNUMBER )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,2); 

                  System.Int32 charIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,4);
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,5);
                  System.Int32 byteIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,6);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getbytes= target.GetBytes( s_, charIndex_, charCount_, bytes_, byteIndex_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Char[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Byte[] && LuaDLL.lua_type(L,6)==LuaTypes.LUA_TNUMBER )
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);
                  System.Int32 charIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,4);
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,5);
                  System.Int32 byteIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,6);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getbytes= target.GetBytes( chars_, charIndex_, charCount_, bytes_, byteIndex_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Char* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Byte* && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Char* chars_ = (System.Char*)ToLuaCS.getObject(L,2);
              //    System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
              //    System.Byte* bytes_ = (System.Byte*)ToLuaCS.getObject(L,4);
              //    System.Int32 byteCount_ = (System.Int32)LuaDLL.lua_tonumber(L,5);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.Encoding target= (System.Text.Encoding) original ;
              //    System.Int32 getbytes= target.GetBytes( chars_, charCount_, bytes_, byteCount_);
              //    ToLuaCS.push(L,getbytes); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Char[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Byte[] getbytes= target.GetBytes( chars_, index_, count_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Char[])
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Byte[] getbytes= target.GetBytes( chars_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Byte[] getbytes= target.GetBytes( s_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetCharCount(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Byte[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getcharcount= target.GetCharCount( bytes_, index_, count_);
                  ToLuaCS.push(L,getcharcount); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Byte* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Byte* bytes_ = (System.Byte*)ToLuaCS.getObject(L,2);
              //    System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.Encoding target= (System.Text.Encoding) original ;
              //    System.Int32 getcharcount= target.GetCharCount( bytes_, count_);
              //    ToLuaCS.push(L,getcharcount); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getcharcount= target.GetCharCount( bytes_);
                  ToLuaCS.push(L,getcharcount); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetChars(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Byte[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Char[] && LuaDLL.lua_type(L,6)==LuaTypes.LUA_TNUMBER )
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);
                  System.Int32 byteIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 byteCount_ = (System.Int32)LuaDLL.lua_tonumber(L,4);
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,5);
                  System.Int32 charIndex_ = (System.Int32)LuaDLL.lua_tonumber(L,6);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getchars= target.GetChars( bytes_, byteIndex_, byteCount_, chars_, charIndex_);
                  ToLuaCS.push(L,getchars); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Byte* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Char* && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Byte* bytes_ = (System.Byte*)ToLuaCS.getObject(L,2);
              //    System.Int32 byteCount_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
              //    System.Char* chars_ = (System.Char*)ToLuaCS.getObject(L,4);
              //    System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,5);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.Encoding target= (System.Text.Encoding) original ;
              //    System.Int32 getchars= target.GetChars( bytes_, byteCount_, chars_, charCount_);
              //    ToLuaCS.push(L,getchars); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Byte[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Char[] getchars= target.GetChars( bytes_, index_, count_);
                  ToLuaCS.push(L,getchars); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Char[] getchars= target.GetChars( bytes_);
                  ToLuaCS.push(L,getchars); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetDecoder(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Text.Decoder getdecoder= target.GetDecoder();
                  ToLuaCS.push(L,getdecoder); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEncoder(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Text.Encoder getencoder= target.GetEncoder();
                  ToLuaCS.push(L,getencoder); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Clone(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Object clone= target.Clone();
                  ToLuaCS.push(L,clone); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsAlwaysNormalized(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Text.NormalizationForm)
              {
                  System.Text.NormalizationForm form_ = (System.Text.NormalizationForm)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean isalwaysnormalized= target.IsAlwaysNormalized( form_);
                  ToLuaCS.push(L,isalwaysnormalized); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean isalwaysnormalized= target.IsAlwaysNormalized();
                  ToLuaCS.push(L,isalwaysnormalized); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetMaxByteCount(LuaState L)
          {
                  System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getmaxbytecount= target.GetMaxByteCount( charCount_);
                  ToLuaCS.push(L,getmaxbytecount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetMaxCharCount(LuaState L)
          {
                  System.Int32 byteCount_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 getmaxcharcount= target.GetMaxCharCount( byteCount_);
                  ToLuaCS.push(L,getmaxcharcount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetPreamble(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Byte[] getpreamble= target.GetPreamble();
                  ToLuaCS.push(L,getpreamble); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetString(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Byte[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String getstring= target.GetString( bytes_, index_, count_);
                  ToLuaCS.push(L,getstring); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String getstring= target.GetString( bytes_);
                  ToLuaCS.push(L,getstring); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_BodyName(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String BodyName= target.BodyName;
                  ToLuaCS.push(L,BodyName); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_CodePage(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 CodePage= target.CodePage;
                  ToLuaCS.push(L,CodePage); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_EncodingName(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String EncodingName= target.EncodingName;
                  ToLuaCS.push(L,EncodingName); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_HeaderName(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String HeaderName= target.HeaderName;
                  ToLuaCS.push(L,HeaderName); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsBrowserDisplay(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsBrowserDisplay= target.IsBrowserDisplay;
                  ToLuaCS.push(L,IsBrowserDisplay); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsBrowserSave(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsBrowserSave= target.IsBrowserSave;
                  ToLuaCS.push(L,IsBrowserSave); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsMailNewsDisplay(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsMailNewsDisplay= target.IsMailNewsDisplay;
                  ToLuaCS.push(L,IsMailNewsDisplay); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsMailNewsSave(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Boolean IsMailNewsSave= target.IsMailNewsSave;
                  ToLuaCS.push(L,IsMailNewsSave); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_WebName(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String WebName= target.WebName;
                  ToLuaCS.push(L,WebName); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_WindowsCodePage(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Int32 WindowsCodePage= target.WindowsCodePage;
                  ToLuaCS.push(L,WindowsCodePage); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.Encoding target= (System.Text.Encoding) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Convert(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is System.Text.Encoding && ToLuaCS.getObject(L, 2) is System.Text.Encoding && ToLuaCS.getObject(L, 3) is System.Byte[] && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  System.Text.Encoding srcEncoding_ = (System.Text.Encoding)ToLuaCS.getObject(L,1);
                  System.Text.Encoding dstEncoding_ = (System.Text.Encoding)ToLuaCS.getObject(L,2);
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,3);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,4);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,5);

                  System.Byte[] convert= System.Text.Encoding.Convert( srcEncoding_, dstEncoding_, bytes_, index_, count_);
                  ToLuaCS.push(L,convert); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is System.Text.Encoding && ToLuaCS.getObject(L, 2) is System.Text.Encoding && ToLuaCS.getObject(L, 3) is System.Byte[])
              {
                  System.Text.Encoding srcEncoding_ = (System.Text.Encoding)ToLuaCS.getObject(L,1);
                  System.Text.Encoding dstEncoding_ = (System.Text.Encoding)ToLuaCS.getObject(L,2);
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,3);

                  System.Byte[] convert= System.Text.Encoding.Convert( srcEncoding_, dstEncoding_, bytes_);
                  ToLuaCS.push(L,convert); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEncoding(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Text.EncoderFallback && ToLuaCS.getObject(L, 3) is System.Text.DecoderFallback)
              {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 

                  System.Text.EncoderFallback encoderFallback_ = (System.Text.EncoderFallback)ToLuaCS.getObject(L,2);
                  System.Text.DecoderFallback decoderFallback_ = (System.Text.DecoderFallback)ToLuaCS.getObject(L,3);

                  System.Text.Encoding getencoding= System.Text.Encoding.GetEncoding( name_, encoderFallback_, decoderFallback_);
                  ToLuaCS.push(L,getencoding); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Text.EncoderFallback && ToLuaCS.getObject(L, 3) is System.Text.DecoderFallback)
              {
                  System.Int32 codepage_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Text.EncoderFallback encoderFallback_ = (System.Text.EncoderFallback)ToLuaCS.getObject(L,2);
                  System.Text.DecoderFallback decoderFallback_ = (System.Text.DecoderFallback)ToLuaCS.getObject(L,3);

                  System.Text.Encoding getencoding= System.Text.Encoding.GetEncoding( codepage_, encoderFallback_, decoderFallback_);
                  ToLuaCS.push(L,getencoding); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  System.Text.Encoding getencoding= System.Text.Encoding.GetEncoding( name_);
                  ToLuaCS.push(L,getencoding); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 codepage_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.Text.Encoding getencoding= System.Text.Encoding.GetEncoding( codepage_);
                  ToLuaCS.push(L,getencoding); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEncodings(LuaState L)
          {

                  System.Text.EncodingInfo[] getencodings= System.Text.Encoding.GetEncodings();
                  ToLuaCS.push(L,getencodings); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ASCII(LuaState L)
          {

                  System.Text.Encoding ASCII= System.Text.Encoding.ASCII;
                  ToLuaCS.push(L,ASCII); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_BigEndianUnicode(LuaState L)
          {

                  System.Text.Encoding BigEndianUnicode= System.Text.Encoding.BigEndianUnicode;
                  ToLuaCS.push(L,BigEndianUnicode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Default(LuaState L)
          {

                  System.Text.Encoding Default= System.Text.Encoding.Default;
                  ToLuaCS.push(L,Default); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_UTF7(LuaState L)
          {

                  System.Text.Encoding UTF7= System.Text.Encoding.UTF7;
                  ToLuaCS.push(L,UTF7); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_UTF8(LuaState L)
          {

                  System.Text.Encoding UTF8= System.Text.Encoding.UTF8;
                  UnityEngine.Debug.Log("get_UTF8" + UTF8);
                  ToLuaCS.push(L,UTF8); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Unicode(LuaState L)
          {

                  System.Text.Encoding Unicode= System.Text.Encoding.Unicode;
                  ToLuaCS.push(L,Unicode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_UTF32(LuaState L)
          {

                  System.Text.Encoding UTF32= System.Text.Encoding.UTF32;
                  ToLuaCS.push(L,UTF32); 
                  return 1;

          }
  #endregion       
}

