using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToiTween {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(iTween);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_id", get_id);
           ToLuaCS.AddMember(L, "set_id", set_id);
           ToLuaCS.AddMember(L, "get_type", get_type);
           ToLuaCS.AddMember(L, "set_type", set_type);
           ToLuaCS.AddMember(L, "get_method", get_method);
           ToLuaCS.AddMember(L, "set_method", set_method);
           ToLuaCS.AddMember(L, "get_easeType", get_easeType);
           ToLuaCS.AddMember(L, "set_easeType", set_easeType);
           ToLuaCS.AddMember(L, "get_time", get_time);
           ToLuaCS.AddMember(L, "set_time", set_time);
           ToLuaCS.AddMember(L, "get_delay", get_delay);
           ToLuaCS.AddMember(L, "set_delay", set_delay);
           ToLuaCS.AddMember(L, "get_loopType", get_loopType);
           ToLuaCS.AddMember(L, "set_loopType", set_loopType);
           ToLuaCS.AddMember(L, "get_isRunning", get_isRunning);
           ToLuaCS.AddMember(L, "set_isRunning", set_isRunning);
           ToLuaCS.AddMember(L, "get_isPaused", get_isPaused);
           ToLuaCS.AddMember(L, "set_isPaused", set_isPaused);
           ToLuaCS.AddMember(L, "get__name", get__name);
           ToLuaCS.AddMember(L, "set__name", set__name);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Init", Init);

           ToLuaCS.AddMember(L, "CameraFadeFrom", CameraFadeFrom);

           ToLuaCS.AddMember(L, "CameraFadeTo", CameraFadeTo);

           ToLuaCS.AddMember(L, "ValueTo", ValueTo);

           ToLuaCS.AddMember(L, "FadeFrom", FadeFrom);

           ToLuaCS.AddMember(L, "FadeTo", FadeTo);

           ToLuaCS.AddMember(L, "ColorFrom", ColorFrom);

           ToLuaCS.AddMember(L, "ColorTo", ColorTo);

           ToLuaCS.AddMember(L, "AudioFrom", AudioFrom);

           ToLuaCS.AddMember(L, "AudioTo", AudioTo);

           ToLuaCS.AddMember(L, "Stab", Stab);

           ToLuaCS.AddMember(L, "LookFrom", LookFrom);

           ToLuaCS.AddMember(L, "LookTo", LookTo);

           ToLuaCS.AddMember(L, "MoveTo", MoveTo);

           ToLuaCS.AddMember(L, "MoveFrom", MoveFrom);

           ToLuaCS.AddMember(L, "MoveAdd", MoveAdd);

           ToLuaCS.AddMember(L, "MoveBy", MoveBy);

           ToLuaCS.AddMember(L, "ScaleTo", ScaleTo);

           ToLuaCS.AddMember(L, "ScaleFrom", ScaleFrom);

           ToLuaCS.AddMember(L, "ScaleAdd", ScaleAdd);

           ToLuaCS.AddMember(L, "ScaleBy", ScaleBy);

           ToLuaCS.AddMember(L, "RotateTo", RotateTo);

           ToLuaCS.AddMember(L, "RotateFrom", RotateFrom);

           ToLuaCS.AddMember(L, "RotateAdd", RotateAdd);

           ToLuaCS.AddMember(L, "RotateBy", RotateBy);

           ToLuaCS.AddMember(L, "ShakePosition", ShakePosition);

           ToLuaCS.AddMember(L, "ShakeScale", ShakeScale);

           ToLuaCS.AddMember(L, "ShakeRotation", ShakeRotation);

           ToLuaCS.AddMember(L, "PunchPosition", PunchPosition);

           ToLuaCS.AddMember(L, "PunchRotation", PunchRotation);

           ToLuaCS.AddMember(L, "PunchScale", PunchScale);

           ToLuaCS.AddMember(L, "RectUpdate", RectUpdate);

           ToLuaCS.AddMember(L, "Vector3Update", Vector3Update);

           ToLuaCS.AddMember(L, "Vector2Update", Vector2Update);

           ToLuaCS.AddMember(L, "FloatUpdate", FloatUpdate);

           ToLuaCS.AddMember(L, "FadeUpdate", FadeUpdate);

           ToLuaCS.AddMember(L, "ColorUpdate", ColorUpdate);

           ToLuaCS.AddMember(L, "AudioUpdate", AudioUpdate);

           ToLuaCS.AddMember(L, "RotateUpdate", RotateUpdate);

           ToLuaCS.AddMember(L, "ScaleUpdate", ScaleUpdate);

           ToLuaCS.AddMember(L, "MoveUpdate", MoveUpdate);

           ToLuaCS.AddMember(L, "LookUpdate", LookUpdate);

           ToLuaCS.AddMember(L, "PathLength", PathLength);

           ToLuaCS.AddMember(L, "CameraTexture", CameraTexture);

           ToLuaCS.AddMember(L, "PutOnPath", PutOnPath);

           ToLuaCS.AddMember(L, "PointOnPath", PointOnPath);

           ToLuaCS.AddMember(L, "DrawLine", DrawLine);

           ToLuaCS.AddMember(L, "DrawLineGizmos", DrawLineGizmos);

           ToLuaCS.AddMember(L, "DrawLineHandles", DrawLineHandles);

           ToLuaCS.AddMember(L, "DrawPath", DrawPath);

           ToLuaCS.AddMember(L, "DrawPathGizmos", DrawPathGizmos);

           ToLuaCS.AddMember(L, "DrawPathHandles", DrawPathHandles);

           ToLuaCS.AddMember(L, "CameraFadeDepth", CameraFadeDepth);

           ToLuaCS.AddMember(L, "CameraFadeDestroy", CameraFadeDestroy);

           ToLuaCS.AddMember(L, "CameraFadeSwap", CameraFadeSwap);

           ToLuaCS.AddMember(L, "CameraFadeAdd", CameraFadeAdd);

           ToLuaCS.AddMember(L, "Resume", Resume);

           ToLuaCS.AddMember(L, "Pause", Pause);

           ToLuaCS.AddMember(L, "Count", Count);

           ToLuaCS.AddMember(L, "Stop", Stop);

           ToLuaCS.AddMember(L, "StopByName", StopByName);

           ToLuaCS.AddMember(L, "Hash", Hash);

           ToLuaCS.AddMember(L, "HashLua", HashLua);

           ToLuaCS.AddMember(L, "get_tweens", get_tweens);

           ToLuaCS.AddMember(L, "set_tweens", set_tweens);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_id(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.id;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_id(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.id= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_type(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.type;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_type(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.type= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_method(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.method;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_method(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.method= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_easeType(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.easeType;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_easeType(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.easeType= (iTween.EaseType)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_time(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.time;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_time(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.time= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_delay(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.delay;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_delay(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.delay= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_loopType(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.loopType;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_loopType(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.loopType= (iTween.LoopType)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isRunning(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.isRunning;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isRunning(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.isRunning= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isPaused(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target.isPaused;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isPaused(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target.isPaused= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get__name(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original ;
                  var val=  target._name;
                  LuaDLL.lua_pushstring(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set__name(LuaState L)
          {
                  var original = ToLuaCS.getObject(L, 1);
                  iTween target= (iTween) original;
                  target._name= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Init(LuaState L)
          {
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  iTween.Init( target_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Single amount_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  iTween.CameraFadeFrom( amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 1);

                  iTween.CameraFadeFrom( args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Single amount_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  iTween.CameraFadeTo( amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 1);

                  iTween.CameraFadeTo( args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ValueTo(LuaState L)
          {
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ValueTo( target_, args_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single alpha_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeFrom( target_, alpha_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.FadeFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single alpha_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeTo( target_, alpha_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.FadeTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorFrom( target_, color_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ColorFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorTo( target_, color_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ColorTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single pitch_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioFrom( target_, volume_, pitch_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.AudioFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single pitch_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioTo( target_, volume_, pitch_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.AudioTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Stab(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.AudioClip audioclip_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L, 2);
                  System.Single delay_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.Stab( target_, audioclip_, delay_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.Stab( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 looktarget_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookFrom( target_, looktarget_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.LookFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 looktarget_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookTo( target_, looktarget_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.LookTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveTo( target_, position_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.MoveTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveFrom( target_, position_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.MoveFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveAdd(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveAdd( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.MoveAdd( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveBy(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveBy( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.MoveBy( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 scale_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleTo( target_, scale_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ScaleTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 scale_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleFrom( target_, scale_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ScaleFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleAdd(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleAdd( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ScaleAdd( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleBy(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleBy( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ScaleBy( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTo(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 rotation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateTo( target_, rotation_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.RotateTo( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateFrom(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 rotation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateFrom( target_, rotation_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.RotateFrom( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateAdd(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateAdd( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.RotateAdd( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateBy(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateBy( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.RotateBy( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakePosition(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakePosition( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ShakePosition( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakeScale(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakeScale( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ShakeScale( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakeRotation(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakeRotation( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ShakeRotation( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchPosition(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchPosition( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.PunchPosition( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchRotation(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchRotation( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.PunchRotation( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchScale(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 amount_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchScale( target_, amount_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.PunchScale( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RectUpdate(LuaState L)
          {
                  UnityEngine.Rect currentValue_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect targetValue_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);
                  System.Single speed_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Rect rectupdate= iTween.RectUpdate( currentValue_, targetValue_, speed_);
                  ToLuaCS.push(L,rectupdate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Vector3Update(LuaState L)
          {
                  UnityEngine.Vector3 currentValue_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 targetValue_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single speed_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 vector3update= iTween.Vector3Update( currentValue_, targetValue_, speed_);
                  ToLuaCS.push(L,vector3update);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Vector2Update(LuaState L)
          {
                  UnityEngine.Vector2 currentValue_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 1);
                  UnityEngine.Vector2 targetValue_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single speed_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector2 vector2update= iTween.Vector2Update( currentValue_, targetValue_, speed_);
                  ToLuaCS.push(L,vector2update);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FloatUpdate(LuaState L)
          {
                  System.Single currentValue_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single targetValue_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single speed_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single floatupdate= iTween.FloatUpdate( currentValue_, targetValue_, speed_);
                  LuaDLL.lua_pushnumber(L, floatupdate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single alpha_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeUpdate( target_, alpha_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.FadeUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorUpdate( target_, color_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ColorUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single pitch_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioUpdate( target_, volume_, pitch_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.AudioUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 rotation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateUpdate( target_, rotation_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.RotateUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 scale_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleUpdate( target_, scale_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.ScaleUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveUpdate( target_, position_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.MoveUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookUpdate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 looktarget_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookUpdate( target_, looktarget_, time_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Collections.Hashtable args_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 2);

                  iTween.LookUpdate( target_, args_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PathLength(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  System.Single pathlength= iTween.PathLength( path_);
                  LuaDLL.lua_pushnumber(L, pathlength);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  System.Single pathlength= iTween.PathLength( path_);
                  LuaDLL.lua_pushnumber(L, pathlength);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraTexture(LuaState L)
          {
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.Texture2D cameratexture= iTween.CameraTexture( color_);
                  ToLuaCS.push(L,cameratexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PutOnPath(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Transform[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 2);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target_, path_, percent_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform && ToLuaCS.getObject(L, 2) is UnityEngine.Transform[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 2);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target_, path_, percent_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target_, path_, percent_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target_, path_, percent_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PointOnPath(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 pointonpath= iTween.PointOnPath( path_, percent_);
                  ToLuaCS.push(L,pointonpath);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  System.Single percent_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 pointonpath= iTween.PointOnPath( path_, percent_);
                  ToLuaCS.push(L,pointonpath);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLine(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLine( line_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLine( line_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLine( line_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLine( line_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLineGizmos(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLineGizmos( line_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLineGizmos( line_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLineGizmos( line_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLineGizmos( line_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLineHandles(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLineHandles( line_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawLineHandles( line_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLineHandles( line_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawLineHandles( line_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPath(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPath( path_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPath( path_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPath( path_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPath( path_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPathGizmos(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPathGizmos( path_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPathGizmos( path_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPathGizmos( path_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPathGizmos( path_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPathHandles(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPathHandles( path_, color_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Color))){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Color color_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                  iTween.DrawPathHandles( path_, color_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPathHandles( path_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path_ = (UnityEngine.Transform[])ToLuaCS.getObject(L, 1);

                  iTween.DrawPathHandles( path_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeDepth(LuaState L)
          {
                  System.Int32 depth_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  iTween.CameraFadeDepth( depth_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeDestroy(LuaState L)
          {

                  iTween.CameraFadeDestroy();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeSwap(LuaState L)
          {
                  UnityEngine.Texture2D texture_ = (UnityEngine.Texture2D)ToLuaCS.getObject(L, 1);

                  iTween.CameraFadeSwap( texture_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeAdd(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Texture2D texture_ = (UnityEngine.Texture2D)ToLuaCS.getObject(L, 1);
                  System.Int32 depth_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd( texture_, depth_);
                  ToLuaCS.push(L,camerafadeadd);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Texture2D texture_ = (UnityEngine.Texture2D)ToLuaCS.getObject(L, 1);

                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd( texture_);
                  ToLuaCS.push(L,camerafadeadd);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd();
                  ToLuaCS.push(L,camerafadeadd);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Resume(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 

                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,3);

                  iTween.Resume( target_, type_, includechildren_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  iTween.Resume( target_, type_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TBOOLEAN ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,2);

                  iTween.Resume( target_, includechildren_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,1); 


                  iTween.Resume( type_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  iTween.Resume( target_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  iTween.Resume();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Pause(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 

                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,3);

                  iTween.Pause( target_, type_, includechildren_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  iTween.Pause( target_, type_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TBOOLEAN ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,2);

                  iTween.Pause( target_, includechildren_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,1); 


                  iTween.Pause( type_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  iTween.Pause( target_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  iTween.Pause();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Count(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  System.Int32 count= iTween.Count( target_, type_);
                  LuaDLL.lua_pushnumber(L, count);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  System.Int32 count= iTween.Count( target_);
                  LuaDLL.lua_pushnumber(L, count);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,1); 


                  System.Int32 count= iTween.Count( type_);
                  LuaDLL.lua_pushnumber(L, count);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  System.Int32 count= iTween.Count();
                  LuaDLL.lua_pushnumber(L, count);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Stop(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 

                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,3);

                  iTween.Stop( target_, type_, includechildren_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TBOOLEAN ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,2);

                  iTween.Stop( target_, includechildren_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  iTween.Stop( target_, type_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,1); 


                  iTween.Stop( type_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  iTween.Stop( target_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  iTween.Stop();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopByName(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Boolean includechildren_ =  LuaDLL.lua_toboolean(L,3);

                  iTween.StopByName( target_, name_, includechildren_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject target_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  iTween.StopByName( target_, name_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  iTween.StopByName( name_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Hash(LuaState L)
          {
                  System.Object[] args_ = (System.Object[])ToLuaCS.getObject(L, 1);

                  System.Collections.Hashtable hash= iTween.Hash( args_);
                  ToLuaCS.push(L,hash);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int HashLua(LuaState L)
          {
                  LuaInterface.LuaTable args_ = (LuaInterface.LuaTable)ToLuaCS.getObject(L, 1);

                  System.Collections.Hashtable hashlua= iTween.HashLua( args_);
                  ToLuaCS.push(L,hashlua);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tweens(LuaState L)
          {
                  var val=   iTween.tweens;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tweens(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  iTween.tweens= (System.Collections.Generic.List<System.Collections.Hashtable>)val;
                  return 0;

          }
  #endregion       
}

