using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCryptographHelper {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CryptographHelper);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "CrypfString", CrypfString);

           ToLuaCS.AddMember(L, "__call", _cryptographhelper);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CrypfString(LuaState L)
          {
                  System.String source_ =  LuaDLL.lua_tostring(L,1); 

                  System.String key_ =  LuaDLL.lua_tostring(L,2); 


                  System.String crypfstring= CryptographHelper.CrypfString( source_, key_);
                  LuaDLL.lua_pushstring(L, crypfstring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _cryptographhelper(LuaState L)
          {

                  CryptographHelper _cryptographhelper= new CryptographHelper();
                  ToLuaCS.push(L,_cryptographhelper);
                  return 1;

          }
  #endregion       
}

