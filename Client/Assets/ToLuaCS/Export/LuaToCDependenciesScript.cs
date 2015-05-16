using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCDependenciesScript {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(CDependenciesScript);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_paths", get_paths);
           ToLuaCS.AddMember(L, "set_paths", set_paths);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _cdependenciesscript);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_paths(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CDependenciesScript target= (CDependenciesScript) original ;
                  var val=  target.paths;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_paths(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  CDependenciesScript target= (CDependenciesScript) original;
                  target.paths= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _cdependenciesscript(LuaState L)
          {

                  CDependenciesScript _cdependenciesscript= new CDependenciesScript();
                  ToLuaCS.push(L,_cdependenciesscript);
                  return 1;

          }
  #endregion       
}

