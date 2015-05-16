using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUGUILocalize {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UGUILocalize);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "set_value", set_value);
           ToLuaCS.AddMember(L, "get_key", get_key);
           ToLuaCS.AddMember(L, "set_key", set_key);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _uguilocalize);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_value(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UGUILocalize target= (UGUILocalize) original ;
                  target.value= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_key(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUILocalize target= (UGUILocalize) original ;
                  var val=  target.key;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_key(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  UGUILocalize target= (UGUILocalize) original;
                  target.key= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _uguilocalize(LuaState L)
          {

                  UGUILocalize _uguilocalize= new UGUILocalize();
                  ToLuaCS.push(L,_uguilocalize);
                  return 1;

          }
  #endregion       
}

