using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUIPanelCamackTable {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UIPanelCamackTable);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _uipanelcamacktable);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _uipanelcamacktable(LuaState L)
          {

                  UIPanelCamackTable _uipanelcamacktable= new UIPanelCamackTable();
                  ToLuaCS.push(L,_uipanelcamacktable);
                  return 1;

          }
  #endregion       
}

