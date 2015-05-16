using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToByteReader {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(ByteReader);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_canRead", get_canRead);
           ToLuaCS.AddMember(L, "ReadLine", ReadLine);
           ToLuaCS.AddMember(L, "ReadDictionary", ReadDictionary);
           ToLuaCS.AddMember(L, "ReadCSV", ReadCSV);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Open", Open);

           ToLuaCS.AddMember(L, "__call", _bytereader);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_canRead(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  ByteReader target= (ByteReader) original ;
                  System.Boolean canRead= target.canRead;
                  LuaDLL.lua_pushboolean(L,canRead);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadLine(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Boolean skipEmptyLines_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  ByteReader target= (ByteReader) original ;
                  System.String readline= target.ReadLine( skipEmptyLines_);
                  LuaDLL.lua_pushstring(L, readline);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
                  ByteReader target= (ByteReader) original ;
                  System.String readline= target.ReadLine();
                  LuaDLL.lua_pushstring(L, readline);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadDictionary(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  ByteReader target= (ByteReader) original ;
                  System.Collections.Generic.Dictionary<System.String,System.String> readdictionary= target.ReadDictionary();
                  ToLuaCS.push(L,readdictionary);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReadCSV(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  ByteReader target= (ByteReader) original ;
                  BetterList<System.String> readcsv= target.ReadCSV();
                  ToLuaCS.push(L,readcsv);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Open(LuaState L)
          {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  ByteReader open= ByteReader.Open( path_);
                  ToLuaCS.push(L,open);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _bytereader(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is UnityEngine.TextAsset){
                  UnityEngine.TextAsset asset_ = (UnityEngine.TextAsset)ToLuaCS.getObject(L, 2);

                  ByteReader _bytereader= new ByteReader( asset_);
                  ToLuaCS.push(L,_bytereader);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Byte[]){
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                  ByteReader _bytereader= new ByteReader( bytes_);
                  ToLuaCS.push(L,_bytereader);
                  return 1;

               }
                 }
               return 0;
          }
  #endregion       
}

