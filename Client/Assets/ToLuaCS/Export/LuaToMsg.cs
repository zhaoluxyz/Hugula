using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToMsg {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(Msg).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(Msg).AssemblyQualifiedName);
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
          System.Type superT = typeof(Msg).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_Length");
          luafn_get_Length= new LuaCSFunction(get_Length);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Length);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Position");
          luafn_get_Position= new LuaCSFunction(get_Position);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Position);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_Position");
          luafn_set_Position= new LuaCSFunction(set_Position);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_Position);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToArray");
          luafn_ToArray= new LuaCSFunction(ToArray);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToArray);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Debug");
          luafn_Debug= new LuaCSFunction(Debug);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Debug);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToCArray");
          luafn_ToCArray= new LuaCSFunction(ToCArray);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToCArray);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Type");
          luafn_get_Type= new LuaCSFunction(get_Type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_Type");
          luafn_set_Type= new LuaCSFunction(set_Type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_Type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Write");
          luafn_Write= new LuaCSFunction(Write);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Write);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteBoolean");
          luafn_WriteBoolean= new LuaCSFunction(WriteBoolean);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteBoolean);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteByte");
          luafn_WriteByte= new LuaCSFunction(WriteByte);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteByte);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteChar");
          luafn_WriteChar= new LuaCSFunction(WriteChar);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteChar);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteUShort");
          luafn_WriteUShort= new LuaCSFunction(WriteUShort);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteUShort);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteUInt");
          luafn_WriteUInt= new LuaCSFunction(WriteUInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteUInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteULong");
          luafn_WriteULong= new LuaCSFunction(WriteULong);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteULong);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteShort");
          luafn_WriteShort= new LuaCSFunction(WriteShort);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteShort);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteFloat");
          luafn_WriteFloat= new LuaCSFunction(WriteFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteInt");
          luafn_WriteInt= new LuaCSFunction(WriteInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteString");
          luafn_WriteString= new LuaCSFunction(WriteString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WriteUTFBytes");
          luafn_WriteUTFBytes= new LuaCSFunction(WriteUTFBytes);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WriteUTFBytes);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadBoolean");
          luafn_ReadBoolean= new LuaCSFunction(ReadBoolean);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadBoolean);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadByte");
          luafn_ReadByte= new LuaCSFunction(ReadByte);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadByte);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadChar");
          luafn_ReadChar= new LuaCSFunction(ReadChar);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadChar);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadUShort");
          luafn_ReadUShort= new LuaCSFunction(ReadUShort);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadUShort);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadUInt");
          luafn_ReadUInt= new LuaCSFunction(ReadUInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadUInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadULong");
          luafn_ReadULong= new LuaCSFunction(ReadULong);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadULong);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadShort");
          luafn_ReadShort= new LuaCSFunction(ReadShort);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadShort);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadInt");
          luafn_ReadInt= new LuaCSFunction(ReadInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadFloat");
          luafn_ReadFloat= new LuaCSFunction(ReadFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadString");
          luafn_ReadString= new LuaCSFunction(ReadString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReadUTF");
          luafn_ReadUTF= new LuaCSFunction(ReadUTF);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadUTF);
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
    
          string[] names = typeof(Msg).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(Msg).FullName);
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
          luafn__msg= new LuaCSFunction(_msg);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__msg);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_Length;
          private static LuaCSFunction luafn_get_Position;
          private static LuaCSFunction luafn_set_Position;
          private static LuaCSFunction luafn_ToArray;
          private static LuaCSFunction luafn_Debug;
          private static LuaCSFunction luafn_ToCArray;
          private static LuaCSFunction luafn_get_Type;
          private static LuaCSFunction luafn_set_Type;
          private static LuaCSFunction luafn_Write;
          private static LuaCSFunction luafn_WriteBoolean;
          private static LuaCSFunction luafn_WriteByte;
          private static LuaCSFunction luafn_WriteChar;
          private static LuaCSFunction luafn_WriteUShort;
          private static LuaCSFunction luafn_WriteUInt;
          private static LuaCSFunction luafn_WriteULong;
          private static LuaCSFunction luafn_WriteShort;
          private static LuaCSFunction luafn_WriteFloat;
          private static LuaCSFunction luafn_WriteInt;
          private static LuaCSFunction luafn_WriteString;
          private static LuaCSFunction luafn_WriteUTFBytes;
          private static LuaCSFunction luafn_ReadBoolean;
          private static LuaCSFunction luafn_ReadByte;
          private static LuaCSFunction luafn_ReadChar;
          private static LuaCSFunction luafn_ReadUShort;
          private static LuaCSFunction luafn_ReadUInt;
          private static LuaCSFunction luafn_ReadULong;
          private static LuaCSFunction luafn_ReadShort;
          private static LuaCSFunction luafn_ReadInt;
          private static LuaCSFunction luafn_ReadFloat;
          private static LuaCSFunction luafn_ReadString;
          private static LuaCSFunction luafn_ReadUTF;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__msg;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Length(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int64 Length= target.Length;
                  LuaDLL.lua_pushnumber(L, Length);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Position(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int64 Position= target.Position;
                  LuaDLL.lua_pushnumber(L, Position);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Position(LuaState L)
          {
                  System.Int64 value_ = (System.Int64)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Position= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToArray(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte[] toarray= target.ToArray();
                  ToLuaCS.push(L,toarray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Debug(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bts_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  System.String debug= Msg.Debug( bts_);
                  LuaDLL.lua_pushstring(L, debug);
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.String debug= target.Debug();
                  LuaDLL.lua_pushstring(L, debug);
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToCArray(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte[] tocarray= target.ToCArray();
                  ToLuaCS.push(L,tocarray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Type(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int32 Type= target.Type;
                  LuaDLL.lua_pushnumber(L, Type);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Type(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Type= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Write(LuaState L)
          {
                  System.Byte[] value_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Write( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteBoolean(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteBoolean( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteByte(LuaState L)
          {
                  System.Byte value_ = (System.Byte)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteByte( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteChar(LuaState L)
          {
                  System.Char value_ = (System.Char)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteChar( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUShort(LuaState L)
          {
                  System.UInt16 value_ = (System.UInt16)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUShort( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUInt(LuaState L)
          {
                  System.UInt32 value_ = (System.UInt32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUInt( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteULong(LuaState L)
          {
                  System.UInt64 value_ = (System.UInt64)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteULong( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteShort(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteShort( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteFloat(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteFloat( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteInt(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteInt( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteString(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteString( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUTFBytes(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUTFBytes( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadBoolean(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Boolean readboolean= target.ReadBoolean();
                  LuaDLL.lua_pushboolean(L,readboolean);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadByte(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte readbyte= target.ReadByte();
                  LuaDLL.lua_pushnumber(L, readbyte);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadChar(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Char readchar= target.ReadChar();
                  LuaDLL.lua_pushnumber(L, readchar);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUShort(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt16 readushort= target.ReadUShort();
                  LuaDLL.lua_pushnumber(L, readushort);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUInt(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt32 readuint= target.ReadUInt();
                  LuaDLL.lua_pushnumber(L, readuint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadULong(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt64 readulong= target.ReadULong();
                  LuaDLL.lua_pushnumber(L, readulong);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadShort(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int16 readshort= target.ReadShort();
                  LuaDLL.lua_pushnumber(L, readshort);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadInt(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int32 readint= target.ReadInt();
                  LuaDLL.lua_pushnumber(L, readint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadFloat(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Single readfloat= target.ReadFloat();
                  LuaDLL.lua_pushnumber(L, readfloat);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.String readstring= target.ReadString();
                  LuaDLL.lua_pushstring(L, readstring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUTF(LuaState L)
          {
                  System.Int32 length_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.String readutf= target.ReadUTF( length_);
                  LuaDLL.lua_pushstring(L, readutf);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _msg(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  Msg _msg= new Msg( bytes_);
                  ToLuaCS.push(L,_msg);
                  return 1;

              }
              if(true)
              {

                  Msg _msg= new Msg();
                  ToLuaCS.push(L,_msg);
                  return 1;

              }
          return 0;
          }
  #endregion       
}

