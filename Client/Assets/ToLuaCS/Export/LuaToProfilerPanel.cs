using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToProfilerPanel {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(ProfilerPanel);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _profilerpanel);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _profilerpanel(LuaState L)
          {

                  ProfilerPanel _profilerpanel= new ProfilerPanel();
                  ToLuaCS.push(L,_profilerpanel);
                  return 1;

          }
  #endregion       
}

