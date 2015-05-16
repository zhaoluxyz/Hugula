using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToActivateMonos {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(ActivateMonos);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_monos", get_monos);
           ToLuaCS.AddMember(L, "set_monos", set_monos);
           ToLuaCS.AddMember(L, "get_activateGameObj", get_activateGameObj);
           ToLuaCS.AddMember(L, "set_activateGameObj", set_activateGameObj);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _activatemonos);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_monos(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original ;
                  var val=  target.monos;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_monos(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.monos= (System.Collections.Generic.List<UnityEngine.MonoBehaviour>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activateGameObj(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original ;
                  var val=  target.activateGameObj;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_activateGameObj(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.activateGameObj= (System.Collections.Generic.List<UnityEngine.GameObject>)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _activatemonos(LuaState L)
          {

                  ActivateMonos _activatemonos= new ActivateMonos();
                  ToLuaCS.push(L,_activatemonos);
                  return 1;

          }
  #endregion       
}

