using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToTimer {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Timer);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "AddFn", AddFn);

           ToLuaCS.AddMember(L, "RemoveFn", RemoveFn);

           ToLuaCS.AddMember(L, "Update", Update);

           ToLuaCS.AddMember(L, "__call", _timer);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddFn(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 1);
                  System.Single delaytime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L, 3);

                  Timer.AddFn( fn_, delaytime_, arg_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 1);
                  System.Single delaytime_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  Timer.AddFn( fn_, delaytime_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RemoveFn(LuaState L)
          {
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 1);

                  Timer.RemoveFn( fn_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                  Timer.Update();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _timer(LuaState L)
          {

                  Timer _timer= new Timer();
                  ToLuaCS.push(L,_timer);
                  return 1;

          }
  #endregion       
}

