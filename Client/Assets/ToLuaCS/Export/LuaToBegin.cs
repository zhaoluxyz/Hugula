using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToBegin {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Begin);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_editorDebug", get_editorDebug);
           ToLuaCS.AddMember(L, "set_editorDebug", set_editorDebug);
           ToLuaCS.AddMember(L, "get_enterLua", get_enterLua);
           ToLuaCS.AddMember(L, "set_enterLua", set_enterLua);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_instance", get_instance);

           ToLuaCS.AddMember(L, "__call", _begin);

           ToLuaCS.AddMember(L, "get_VERSION_FILE_NAME", get_VERSION_FILE_NAME);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_editorDebug(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  Begin target= (Begin) original ;
                  var val=  target.editorDebug;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_editorDebug(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  Begin target= (Begin) original;
                  target.editorDebug= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enterLua(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  Begin target= (Begin) original ;
                  var val=  target.enterLua;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enterLua(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  Begin target= (Begin) original;
                  target.enterLua= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  Begin instance= Begin.instance;
                  ToLuaCS.push(L,instance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _begin(LuaState L)
          {

                  Begin _begin= new Begin();
                  ToLuaCS.push(L,_begin);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_VERSION_FILE_NAME(LuaState L)
          {
                  var val=   Begin.VERSION_FILE_NAME;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
  #endregion       
}

