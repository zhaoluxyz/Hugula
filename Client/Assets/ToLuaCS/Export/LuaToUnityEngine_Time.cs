using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Time {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Time);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "GetType", GetType);
           ToLuaCS.AddMember(L, "ToString", ToString);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_time", get_time);

           ToLuaCS.AddMember(L, "get_timeSinceLevelLoad", get_timeSinceLevelLoad);

           ToLuaCS.AddMember(L, "get_deltaTime", get_deltaTime);

           ToLuaCS.AddMember(L, "get_fixedTime", get_fixedTime);

           ToLuaCS.AddMember(L, "get_unscaledTime", get_unscaledTime);

           ToLuaCS.AddMember(L, "get_unscaledDeltaTime", get_unscaledDeltaTime);

           ToLuaCS.AddMember(L, "get_fixedDeltaTime", get_fixedDeltaTime);

           ToLuaCS.AddMember(L, "set_fixedDeltaTime", set_fixedDeltaTime);

           ToLuaCS.AddMember(L, "get_maximumDeltaTime", get_maximumDeltaTime);

           ToLuaCS.AddMember(L, "set_maximumDeltaTime", set_maximumDeltaTime);

           ToLuaCS.AddMember(L, "get_smoothDeltaTime", get_smoothDeltaTime);

           ToLuaCS.AddMember(L, "get_timeScale", get_timeScale);

           ToLuaCS.AddMember(L, "set_timeScale", set_timeScale);

           ToLuaCS.AddMember(L, "get_frameCount", get_frameCount);

           ToLuaCS.AddMember(L, "get_renderedFrameCount", get_renderedFrameCount);

           ToLuaCS.AddMember(L, "get_realtimeSinceStartup", get_realtimeSinceStartup);

           ToLuaCS.AddMember(L, "get_captureFramerate", get_captureFramerate);

           ToLuaCS.AddMember(L, "set_captureFramerate", set_captureFramerate);

           ToLuaCS.AddMember(L, "__call", _time);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Boolean equals= target.Equals( obj_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_time(LuaState L)
          {

                  System.Single time= UnityEngine.Time.time;
                  LuaDLL.lua_pushnumber(L, time);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeSinceLevelLoad(LuaState L)
          {

                  System.Single timeSinceLevelLoad= UnityEngine.Time.timeSinceLevelLoad;
                  LuaDLL.lua_pushnumber(L, timeSinceLevelLoad);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_deltaTime(LuaState L)
          {

                  System.Single deltaTime= UnityEngine.Time.deltaTime;
                  LuaDLL.lua_pushnumber(L, deltaTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fixedTime(LuaState L)
          {

                  System.Single fixedTime= UnityEngine.Time.fixedTime;
                  LuaDLL.lua_pushnumber(L, fixedTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_unscaledTime(LuaState L)
          {

                  System.Single unscaledTime= UnityEngine.Time.unscaledTime;
                  LuaDLL.lua_pushnumber(L, unscaledTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_unscaledDeltaTime(LuaState L)
          {

                  System.Single unscaledDeltaTime= UnityEngine.Time.unscaledDeltaTime;
                  LuaDLL.lua_pushnumber(L, unscaledDeltaTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fixedDeltaTime(LuaState L)
          {

                  System.Single fixedDeltaTime= UnityEngine.Time.fixedDeltaTime;
                  LuaDLL.lua_pushnumber(L, fixedDeltaTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fixedDeltaTime(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.fixedDeltaTime= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maximumDeltaTime(LuaState L)
          {

                  System.Single maximumDeltaTime= UnityEngine.Time.maximumDeltaTime;
                  LuaDLL.lua_pushnumber(L, maximumDeltaTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_maximumDeltaTime(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.maximumDeltaTime= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_smoothDeltaTime(LuaState L)
          {

                  System.Single smoothDeltaTime= UnityEngine.Time.smoothDeltaTime;
                  LuaDLL.lua_pushnumber(L, smoothDeltaTime);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeScale(LuaState L)
          {

                  System.Single timeScale= UnityEngine.Time.timeScale;
                  LuaDLL.lua_pushnumber(L, timeScale);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_timeScale(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.timeScale= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_frameCount(LuaState L)
          {

                  System.Int32 frameCount= UnityEngine.Time.frameCount;
                  LuaDLL.lua_pushnumber(L, frameCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderedFrameCount(LuaState L)
          {

                  System.Int32 renderedFrameCount= UnityEngine.Time.renderedFrameCount;
                  LuaDLL.lua_pushnumber(L, renderedFrameCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_realtimeSinceStartup(LuaState L)
          {

                  System.Single realtimeSinceStartup= UnityEngine.Time.realtimeSinceStartup;
                  LuaDLL.lua_pushnumber(L, realtimeSinceStartup);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_captureFramerate(LuaState L)
          {

                  System.Int32 captureFramerate= UnityEngine.Time.captureFramerate;
                  LuaDLL.lua_pushnumber(L, captureFramerate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_captureFramerate(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.captureFramerate= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _time(LuaState L)
          {

                  UnityEngine.Time _time= new UnityEngine.Time();
                  ToLuaCS.push(L,_time);
                  return 1;

          }
  #endregion       
}

