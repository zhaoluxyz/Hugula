using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToSystem_Text_UTF8Encoding {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(System.Text.UTF8Encoding).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(System.Text.UTF8Encoding).AssemblyQualifiedName);
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
          System.Type superT = typeof(System.Text.UTF8Encoding).BaseType;
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

          LuaDLL.lua_pushstring(L,"GetMaxByteCount");
          luafn_GetMaxByteCount= new LuaCSFunction(GetMaxByteCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetMaxByteCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetMaxCharCount");
          luafn_GetMaxCharCount= new LuaCSFunction(GetMaxCharCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetMaxCharCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetDecoder");
          luafn_GetDecoder= new LuaCSFunction(GetDecoder);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetDecoder);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetEncoder");
          luafn_GetEncoder= new LuaCSFunction(GetEncoder);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetEncoder);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetPreamble");
          luafn_GetPreamble= new LuaCSFunction(GetPreamble);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetPreamble);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetString");
          luafn_GetString= new LuaCSFunction(GetString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetString);
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
    
          string[] names = typeof(System.Text.UTF8Encoding).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(System.Text.UTF8Encoding).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"__call");
          luafn__utf8encoding= new LuaCSFunction(_utf8encoding);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__utf8encoding);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_GetByteCount;
          private static LuaCSFunction luafn_GetBytes;
          private static LuaCSFunction luafn_GetCharCount;
          private static LuaCSFunction luafn_GetChars;
          private static LuaCSFunction luafn_GetMaxByteCount;
          private static LuaCSFunction luafn_GetMaxCharCount;
          private static LuaCSFunction luafn_GetDecoder;
          private static LuaCSFunction luafn_GetEncoder;
          private static LuaCSFunction luafn_GetPreamble;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetString;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__utf8encoding;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetByteCount(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Char[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( chars_, index_, count_);
                  ToLuaCS.push(L,getbytecount); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Char* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Char* chars_ = (System.Char*)ToLuaCS.getObject(L,2);
              //    System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
              //    System.Int32 getbytecount= target.GetByteCount( chars_, count_);
              //    ToLuaCS.push(L,getbytecount); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Char[])
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( chars_);
                  ToLuaCS.push(L,getbytecount); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String chars_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getbytecount= target.GetByteCount( chars_);
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
              //    System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Byte[] getbytes= target.GetBytes( chars_, index_, count_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Char[])
              {
                  System.Char[] chars_ = (System.Char[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Byte[] getbytes= target.GetBytes( chars_);
                  ToLuaCS.push(L,getbytes); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getcharcount= target.GetCharCount( bytes_, index_, count_);
                  ToLuaCS.push(L,getcharcount); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 2) is System.Byte* && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              //{
              //    System.Byte* bytes_ = (System.Byte*)ToLuaCS.getObject(L,2);
              //    System.Int32 count_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
              //    System.Int32 getcharcount= target.GetCharCount( bytes_, count_);
              //    ToLuaCS.push(L,getcharcount); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
              //    System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Char[] getchars= target.GetChars( bytes_, index_, count_);
                  ToLuaCS.push(L,getchars); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Char[] getchars= target.GetChars( bytes_);
                  ToLuaCS.push(L,getchars); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetMaxByteCount(LuaState L)
          {
                  System.Int32 charCount_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getmaxbytecount= target.GetMaxByteCount( charCount_);
                  ToLuaCS.push(L,getmaxbytecount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetMaxCharCount(LuaState L)
          {
                  System.Int32 byteCount_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 getmaxcharcount= target.GetMaxCharCount( byteCount_);
                  ToLuaCS.push(L,getmaxcharcount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetDecoder(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Text.Decoder getdecoder= target.GetDecoder();
                  ToLuaCS.push(L,getdecoder); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEncoder(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Text.Encoder getencoder= target.GetEncoder();
                  ToLuaCS.push(L,getencoder); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetPreamble(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Byte[] getpreamble= target.GetPreamble();
                  ToLuaCS.push(L,getpreamble); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Boolean equals= target.Equals( value_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
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
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.String getstring= target.GetString( bytes_, index_, count_);
                  ToLuaCS.push(L,getstring); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  System.Text.UTF8Encoding target= (System.Text.UTF8Encoding) original ;
                  System.String getstring= target.GetString( bytes_);
                  ToLuaCS.push(L,getstring); 
                  return 1;

              }
          return 0;
          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _utf8encoding(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Boolean encoderShouldEmitUTF8Identifier_ =  LuaDLL.lua_toboolean(L,2);
                  System.Boolean throwOnInvalidBytes_ =  LuaDLL.lua_toboolean(L,3);

                  System.Text.UTF8Encoding _utf8encoding= new System.Text.UTF8Encoding( encoderShouldEmitUTF8Identifier_, throwOnInvalidBytes_);
                  ToLuaCS.push(L,_utf8encoding); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  System.Boolean encoderShouldEmitUTF8Identifier_ =  LuaDLL.lua_toboolean(L,2);

                  System.Text.UTF8Encoding _utf8encoding= new System.Text.UTF8Encoding( encoderShouldEmitUTF8Identifier_);
                  ToLuaCS.push(L,_utf8encoding); 
                  return 1;

              }
              if(true)
              {

                  System.Text.UTF8Encoding _utf8encoding= new System.Text.UTF8Encoding();
                  ToLuaCS.push(L,_utf8encoding); 
                  return 1;

              }
          return 0;
          }
  #endregion       
}

