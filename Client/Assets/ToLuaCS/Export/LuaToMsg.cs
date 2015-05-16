using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToMsg {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Msg);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_Length", get_Length);
           ToLuaCS.AddMember(L, "get_Position", get_Position);
           ToLuaCS.AddMember(L, "set_Position", set_Position);
           ToLuaCS.AddMember(L, "ToArray", ToArray);
           ToLuaCS.AddMember(L, "Debug", Debug);
           ToLuaCS.AddMember(L, "ToCArray", ToCArray);
           ToLuaCS.AddMember(L, "get_Type", get_Type);
           ToLuaCS.AddMember(L, "set_Type", set_Type);
           ToLuaCS.AddMember(L, "Write", Write);
           ToLuaCS.AddMember(L, "WriteBoolean", WriteBoolean);
           ToLuaCS.AddMember(L, "WriteByte", WriteByte);
           ToLuaCS.AddMember(L, "WriteChar", WriteChar);
           ToLuaCS.AddMember(L, "WriteUShort", WriteUShort);
           ToLuaCS.AddMember(L, "WriteUInt", WriteUInt);
           ToLuaCS.AddMember(L, "WriteULong", WriteULong);
           ToLuaCS.AddMember(L, "WriteShort", WriteShort);
           ToLuaCS.AddMember(L, "WriteFloat", WriteFloat);
           ToLuaCS.AddMember(L, "WriteInt", WriteInt);
           ToLuaCS.AddMember(L, "WriteString", WriteString);
           ToLuaCS.AddMember(L, "WriteUTFBytes", WriteUTFBytes);
           ToLuaCS.AddMember(L, "ReadBoolean", ReadBoolean);
           ToLuaCS.AddMember(L, "ReadByte", ReadByte);
           ToLuaCS.AddMember(L, "ReadChar", ReadChar);
           ToLuaCS.AddMember(L, "ReadUShort", ReadUShort);
           ToLuaCS.AddMember(L, "ReadUInt", ReadUInt);
           ToLuaCS.AddMember(L, "ReadULong", ReadULong);
           ToLuaCS.AddMember(L, "ReadShort", ReadShort);
           ToLuaCS.AddMember(L, "ReadInt", ReadInt);
           ToLuaCS.AddMember(L, "ReadFloat", ReadFloat);
           ToLuaCS.AddMember(L, "ReadString", ReadString);
           ToLuaCS.AddMember(L, "ReadUTF", ReadUTF);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _msg);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Length(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int64 Length= target.Length;
                  LuaDLL.lua_pushnumber(L, Length);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Position(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int64 Position= target.Position;
                  LuaDLL.lua_pushnumber(L, Position);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Position(LuaState L)
          {
                  System.Int64 value_ = (System.Int64)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Position= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToArray(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte[] toarray= target.ToArray();
                  ToLuaCS.push(L,toarray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Debug(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Byte[] bts_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                  System.String debug= Msg.Debug( bts_);
                  LuaDLL.lua_pushstring(L, debug);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
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

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte[] tocarray= target.ToCArray();
                  ToLuaCS.push(L,tocarray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Type(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int32 Type= target.Type;
                  LuaDLL.lua_pushnumber(L, Type);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Type(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Type= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Write(LuaState L)
          {
                  System.Byte[] value_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.Write( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteBoolean(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteBoolean( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteByte(LuaState L)
          {
                  System.Byte value_ = (System.Byte)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteByte( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteChar(LuaState L)
          {
                  System.Char value_ = (System.Char)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteChar( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUShort(LuaState L)
          {
                  System.UInt16 value_ = (System.UInt16)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUShort( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUInt(LuaState L)
          {
                  System.UInt32 value_ = (System.UInt32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUInt( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteULong(LuaState L)
          {
                  System.UInt64 value_ = (System.UInt64)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteULong( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteShort(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteShort( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteFloat(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteFloat( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteInt(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteInt( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteString(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteString( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WriteUTFBytes(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  target.WriteUTFBytes( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadBoolean(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Boolean readboolean= target.ReadBoolean();
                  LuaDLL.lua_pushboolean(L,readboolean);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadByte(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Byte readbyte= target.ReadByte();
                  LuaDLL.lua_pushnumber(L, readbyte);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadChar(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Char readchar= target.ReadChar();
                  LuaDLL.lua_pushnumber(L, readchar);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUShort(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt16 readushort= target.ReadUShort();
                  LuaDLL.lua_pushnumber(L, readushort);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUInt(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt32 readuint= target.ReadUInt();
                  LuaDLL.lua_pushnumber(L, readuint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadULong(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.UInt64 readulong= target.ReadULong();
                  LuaDLL.lua_pushnumber(L, readulong);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadShort(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int16 readshort= target.ReadShort();
                  LuaDLL.lua_pushnumber(L, readshort);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadInt(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Int32 readint= target.ReadInt();
                  LuaDLL.lua_pushnumber(L, readint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadFloat(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.Single readfloat= target.ReadFloat();
                  LuaDLL.lua_pushnumber(L, readfloat);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  Msg target= (Msg) original ;
                  System.String readstring= target.ReadString();
                  LuaDLL.lua_pushstring(L, readstring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadUTF(LuaState L)
          {
                  System.Int32 length_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
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
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                  Msg _msg= new Msg( bytes_);
                  ToLuaCS.push(L,_msg);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                  Msg _msg= new Msg();
                  ToLuaCS.push(L,_msg);
                  return 1;

                 }
               return 0;
          }
  #endregion       
}

