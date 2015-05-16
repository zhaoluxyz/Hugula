using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLeanTween {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(LeanTween);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Update", Update);
           ToLuaCS.AddMember(L, "OnLevelWasLoaded", OnLevelWasLoaded);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "init", init);

           ToLuaCS.AddMember(L, "reset", reset);

           ToLuaCS.AddMember(L, "update", update);

           ToLuaCS.AddMember(L, "removeTween", removeTween);

           ToLuaCS.AddMember(L, "add", add);

           ToLuaCS.AddMember(L, "closestRot", closestRot);

           ToLuaCS.AddMember(L, "cancel", cancel);

           ToLuaCS.AddMember(L, "description", description);

           ToLuaCS.AddMember(L, "pause", pause);

           ToLuaCS.AddMember(L, "resume", resume);

           ToLuaCS.AddMember(L, "isTweening", isTweening);

           ToLuaCS.AddMember(L, "drawBezierPath", drawBezierPath);

           ToLuaCS.AddMember(L, "logError", logError);

           ToLuaCS.AddMember(L, "options", options);

           ToLuaCS.AddMember(L, "get_tweenEmpty", get_tweenEmpty);

           ToLuaCS.AddMember(L, "alpha", alpha);

           ToLuaCS.AddMember(L, "alphaVertex", alphaVertex);

           ToLuaCS.AddMember(L, "color", color);

           ToLuaCS.AddMember(L, "delayedCall", delayedCall);

           ToLuaCS.AddMember(L, "destroyAfter", destroyAfter);

           ToLuaCS.AddMember(L, "move", move);

           ToLuaCS.AddMember(L, "moveSpline", moveSpline);

           ToLuaCS.AddMember(L, "moveSplineLocal", moveSplineLocal);

           ToLuaCS.AddMember(L, "moveMargin", moveMargin);

           ToLuaCS.AddMember(L, "moveX", moveX);

           ToLuaCS.AddMember(L, "moveY", moveY);

           ToLuaCS.AddMember(L, "moveZ", moveZ);

           ToLuaCS.AddMember(L, "moveLocal", moveLocal);

           ToLuaCS.AddMember(L, "moveLocalX", moveLocalX);

           ToLuaCS.AddMember(L, "moveLocalY", moveLocalY);

           ToLuaCS.AddMember(L, "moveLocalZ", moveLocalZ);

           ToLuaCS.AddMember(L, "rotate", rotate);

           ToLuaCS.AddMember(L, "rotateLocal", rotateLocal);

           ToLuaCS.AddMember(L, "rotateX", rotateX);

           ToLuaCS.AddMember(L, "rotateY", rotateY);

           ToLuaCS.AddMember(L, "rotateZ", rotateZ);

           ToLuaCS.AddMember(L, "rotateAround", rotateAround);

           ToLuaCS.AddMember(L, "rotateAroundLocal", rotateAroundLocal);

           ToLuaCS.AddMember(L, "scale", scale);

           ToLuaCS.AddMember(L, "scaleX", scaleX);

           ToLuaCS.AddMember(L, "scaleY", scaleY);

           ToLuaCS.AddMember(L, "scaleZ", scaleZ);

           ToLuaCS.AddMember(L, "value", value);

           ToLuaCS.AddMember(L, "delayedSound", delayedSound);

           ToLuaCS.AddMember(L, "h", h);

           ToLuaCS.AddMember(L, "addListener", addListener);

           ToLuaCS.AddMember(L, "removeListener", removeListener);

           ToLuaCS.AddMember(L, "dispatchEvent", dispatchEvent);

           ToLuaCS.AddMember(L, "__call", _leantween);

           ToLuaCS.AddMember(L, "get_throwErrors", get_throwErrors);

           ToLuaCS.AddMember(L, "set_throwErrors", set_throwErrors);

           ToLuaCS.AddMember(L, "get_startSearch", get_startSearch);

           ToLuaCS.AddMember(L, "set_startSearch", set_startSearch);

           ToLuaCS.AddMember(L, "get_descr", get_descr);

           ToLuaCS.AddMember(L, "set_descr", set_descr);

           ToLuaCS.AddMember(L, "get_EVENTS_MAX", get_EVENTS_MAX);

           ToLuaCS.AddMember(L, "set_EVENTS_MAX", set_EVENTS_MAX);

           ToLuaCS.AddMember(L, "get_LISTENERS_MAX", get_LISTENERS_MAX);

           ToLuaCS.AddMember(L, "set_LISTENERS_MAX", set_LISTENERS_MAX);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LeanTween target= (LeanTween) original ;
                  target.Update();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnLevelWasLoaded(LuaState L)
          {
                  System.Int32 lvl_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  LeanTween target= (LeanTween) original ;
                  target.OnLevelWasLoaded( lvl_);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int init(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Int32 maxSimultaneousTweens_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.init( maxSimultaneousTweens_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  LeanTween.init();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int reset(LuaState L)
          {

                  LeanTween.reset();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int update(LuaState L)
          {

                  LeanTween.update();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeTween(LuaState L)
          {
                  System.Int32 i_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.removeTween( i_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int add(LuaState L)
          {
                  UnityEngine.Vector3[] a_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3[] add= LeanTween.add( a_, b_);
                  ToLuaCS.push(L,add);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int closestRot(LuaState L)
          {
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single closestrot= LeanTween.closestRot( from_, to_);
                  LuaDLL.lua_pushnumber(L, closestrot);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int cancel(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.cancel( ltRect_, uniqueId_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.cancel( gameObject_, uniqueId_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  LeanTween.cancel( gameObject_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int description(LuaState L)
          {
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LTDescr description= LeanTween.description( uniqueId_);
                  ToLuaCS.push(L,description);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int pause(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.pause( gameObject_, uniqueId_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  LeanTween.pause( gameObject_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER ){
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.pause( uniqueId_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int resume(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.resume( gameObject_, uniqueId_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  LeanTween.resume( gameObject_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER ){
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.resume( uniqueId_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int isTweening(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is LTRect){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);

                  System.Boolean istweening= LeanTween.isTweening( ltRect_);
                  LuaDLL.lua_pushboolean(L,istweening);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER ){
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.Boolean istweening= LeanTween.isTweening( uniqueId_);
                  LuaDLL.lua_pushboolean(L,istweening);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  System.Boolean istweening= LeanTween.isTweening( gameObject_);
                  LuaDLL.lua_pushboolean(L,istweening);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int drawBezierPath(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 c_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 d_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);

                  LeanTween.drawBezierPath( a_, b_, c_, d_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int logError(LuaState L)
          {
                  System.String error_ =  LuaDLL.lua_tostring(L,1); 


                  System.Object logerror= LeanTween.logError( error_);
                  ToLuaCS.push(L,logerror);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int options(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  LTDescr seed_ = (LTDescr)ToLuaCS.getObject(L, 1);

                  LTDescr options= LeanTween.options( seed_);
                  ToLuaCS.push(L,options);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                  LTDescr options= LeanTween.options();
                  ToLuaCS.push(L,options);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tweenEmpty(LuaState L)
          {

                  UnityEngine.GameObject tweenEmpty= LeanTween.tweenEmpty;
                  ToLuaCS.push(L,tweenEmpty);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int alpha(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 alpha= LeanTween.alpha( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, alpha);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 alpha= LeanTween.alpha( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, alpha);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 alpha= LeanTween.alpha( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, alpha);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 alpha= LeanTween.alpha( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, alpha);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alpha= LeanTween.alpha( gameObject_, to_, time_);
                  ToLuaCS.push(L,alpha);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alpha= LeanTween.alpha( ltRect_, to_, time_);
                  ToLuaCS.push(L,alpha);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int alphaVertex(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alphavertex= LeanTween.alphaVertex( gameObject_, to_, time_);
                  ToLuaCS.push(L,alphavertex);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int color(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Color to_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr color= LeanTween.color( gameObject_, to_, time_);
                  ToLuaCS.push(L,color);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int delayedCall(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.String callback_ =  LuaDLL.lua_tostring(L,3); 

                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Action callback_ = (System.Action)ToLuaCS.getObject(L, 3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.String callback_ =  LuaDLL.lua_tostring(L,3); 

                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<System.Object> && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L, 3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Action callback_ = (System.Action)ToLuaCS.getObject(L, 3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TFUNCTION && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action && ToLuaCS.getObject(L, 3) is System.Object[]){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Action callback_ = (System.Action)ToLuaCS.getObject(L, 2);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<System.Object>){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L, 3);

                  LTDescr delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_);
                  ToLuaCS.push(L,delayedcall);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Action callback_ = (System.Action)ToLuaCS.getObject(L, 3);

                  LTDescr delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_);
                  ToLuaCS.push(L,delayedcall);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TFUNCTION && ToLuaCS.getObject(L, 3) is System.Collections.Hashtable){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Collections.Hashtable){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.String callback_ =  LuaDLL.lua_tostring(L,2); 

                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TFUNCTION && ToLuaCS.getObject(L, 3) is System.Object[]){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
                  LuaDLL.lua_pushnumber(L, delayedcall);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Action callback_ = (System.Action)ToLuaCS.getObject(L, 2);

                  LTDescr delayedcall= LeanTween.delayedCall( delayTime_, callback_);
                  ToLuaCS.push(L,delayedcall);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action<System.Object>){
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L, 2);

                  LTDescr delayedcall= LeanTween.delayedCall( delayTime_, callback_);
                  ToLuaCS.push(L,delayedcall);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int destroyAfter(LuaState L)
          {
                  LTRect rect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  LTDescr destroyafter= LeanTween.destroyAfter( rect_, delayTime_);
                  ToLuaCS.push(L,destroyafter);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int move(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, move);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( ltRect_, to_, time_);
                  ToLuaCS.push(L,move);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveSpline(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movespline= LeanTween.moveSpline( gameObject_, to_, time_);
                  ToLuaCS.push(L,movespline);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveSplineLocal(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movesplinelocal= LeanTween.moveSplineLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movesplinelocal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveMargin(LuaState L)
          {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movemargin= LeanTween.moveMargin( ltRect_, to_, time_);
                  ToLuaCS.push(L,movemargin);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveX(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movex= LeanTween.moveX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movex);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movex= LeanTween.moveX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movex);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movex= LeanTween.moveX( gameObject_, to_, time_);
                  ToLuaCS.push(L,movex);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveY(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movey= LeanTween.moveY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movey);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movey= LeanTween.moveY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movey);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movey= LeanTween.moveY( gameObject_, to_, time_);
                  ToLuaCS.push(L,movey);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveZ(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movez= LeanTween.moveZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movez);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movez= LeanTween.moveZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movez);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movez= LeanTween.moveZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,movez);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocal(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocal);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocal= LeanTween.moveLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocal= LeanTween.moveLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocal);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalX(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocalx);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocalx);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocalx);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalY(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocaly);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocaly);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocaly);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalZ(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocalz);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, movelocalz);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocalz);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotate= LeanTween.rotate( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotate);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotate= LeanTween.rotate( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotate);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotate= LeanTween.rotate( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotate);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotate= LeanTween.rotate( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotate);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotate= LeanTween.rotate( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotate);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotate= LeanTween.rotate( ltRect_, to_, time_);
                  ToLuaCS.push(L,rotate);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateLocal(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatelocal);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatelocal);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateX(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotatex= LeanTween.rotateX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatex);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotatex= LeanTween.rotateX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatex);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatex= LeanTween.rotateX( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatex);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateY(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotatey= LeanTween.rotateY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatey);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotatey= LeanTween.rotateY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatey);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatey= LeanTween.rotateY( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatey);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateZ(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 rotatez= LeanTween.rotateZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatez);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 rotatez= LeanTween.rotateZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatez);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatez= LeanTween.rotateZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatez);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateAround(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,5)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 5);

                  System.Int32 rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatearound);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 5);

                  System.Int32 rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, rotatearound);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  LTDescr rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_);
                  ToLuaCS.push(L,rotatearound);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateAroundLocal(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  LTDescr rotatearoundlocal= LeanTween.rotateAroundLocal( gameObject_, axis_, add_, time_);
                  ToLuaCS.push(L,rotatearoundlocal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scale(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 scale= LeanTween.scale( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scale);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 scale= LeanTween.scale( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scale);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 scale= LeanTween.scale( ltRect_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scale);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 scale= LeanTween.scale( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scale);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scale= LeanTween.scale( gameObject_, to_, time_);
                  ToLuaCS.push(L,scale);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scale= LeanTween.scale( ltRect_, to_, time_);
                  ToLuaCS.push(L,scale);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleX(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 scalex= LeanTween.scaleX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scalex);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 scalex= LeanTween.scaleX( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scalex);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scalex= LeanTween.scaleX( gameObject_, to_, time_);
                  ToLuaCS.push(L,scalex);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleY(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 scaley= LeanTween.scaleY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scaley);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 scaley= LeanTween.scaleY( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scaley);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scaley= LeanTween.scaleY( gameObject_, to_, time_);
                  ToLuaCS.push(L,scaley);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleZ(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 4);

                  System.Int32 scalez= LeanTween.scaleZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scalez);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 4);

                  System.Int32 scalez= LeanTween.scaleZ( gameObject_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, scalez);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scalez= LeanTween.scaleZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,scalez);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int value(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,6)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single,System.Collections.Hashtable> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single,System.Collections.Hashtable> callOnUpdate_ = (System.Action<System.Single,System.Collections.Hashtable>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3,System.Collections.Hashtable> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Vector3,System.Collections.Hashtable> callOnUpdate_ = (System.Action<UnityEngine.Vector3,System.Collections.Hashtable>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3,System.Collections.Hashtable> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Vector3,System.Collections.Hashtable> callOnUpdate_ = (System.Action<UnityEngine.Vector3,System.Collections.Hashtable>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single,System.Collections.Hashtable> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[]){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single,System.Collections.Hashtable> callOnUpdate_ = (System.Action<System.Single,System.Collections.Hashtable>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,5)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Color> && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Color)) && LuaDLL.lua_type(L,4)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 4, typeof(UnityEngine.Color)) && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<UnityEngine.Color> callOnUpdate_ = (System.Action<UnityEngine.Color>)ToLuaCS.getObject(L, 2);
                  UnityEngine.Color from_ = (UnityEngine.Color)ToLuaCS.getColor(L, 3);
                  UnityEngine.Color to_ = (UnityEngine.Color)ToLuaCS.getColor(L, 4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Collections.Hashtable){
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,1); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 5);

                  System.Int32 value= LeanTween.value( callOnUpdate_, from_, to_, time_, optional_);
                  LuaDLL.lua_pushnumber(L, value);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single,System.Object> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Action<System.Single,System.Object> callOnUpdate_ = (System.Action<System.Single,System.Object>)ToLuaCS.getObject(L, 2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int delayedSound(LuaState L)
          {
                  UnityEngine.AudioClip audio_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr delayedsound= LeanTween.delayedSound( audio_, pos_, volume_);
                  ToLuaCS.push(L,delayedsound);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int h(LuaState L)
          {
                  System.Object[] arr_ = (System.Object[])ToLuaCS.getObject(L, 1);

                  System.Collections.Hashtable h= LeanTween.h( arr_);
                  ToLuaCS.push(L,h);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int addListener(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject caller_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L, 3);

                  LeanTween.addListener( caller_, eventId_, callback_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L, 2);

                  LeanTween.addListener( eventId_, callback_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeListener(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject caller_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L, 3);

                  System.Boolean removelistener= LeanTween.removeListener( caller_, eventId_, callback_);
                  LuaDLL.lua_pushboolean(L,removelistener);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L, 2);

                  System.Boolean removelistener= LeanTween.removeListener( eventId_, callback_);
                  LuaDLL.lua_pushboolean(L,removelistener);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int dispatchEvent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Object data_ = (System.Object)ToLuaCS.getObject(L, 2);

                  LeanTween.dispatchEvent( eventId_, data_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.dispatchEvent( eventId_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _leantween(LuaState L)
          {

                  LeanTween _leantween= new LeanTween();
                  ToLuaCS.push(L,_leantween);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_throwErrors(LuaState L)
          {
                  var val=   LeanTween.throwErrors;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_throwErrors(LuaState L)
          {
                  LeanTween.throwErrors= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_startSearch(LuaState L)
          {
                  var val=   LeanTween.startSearch;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_startSearch(LuaState L)
          {
                  LeanTween.startSearch= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_descr(LuaState L)
          {
                  var val=   LeanTween.descr;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_descr(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  LeanTween.descr= (LTDescr)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_EVENTS_MAX(LuaState L)
          {
                  var val=   LeanTween.EVENTS_MAX;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_EVENTS_MAX(LuaState L)
          {
                  LeanTween.EVENTS_MAX= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LISTENERS_MAX(LuaState L)
          {
                  var val=   LeanTween.LISTENERS_MAX;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_LISTENERS_MAX(LuaState L)
          {
                  LeanTween.LISTENERS_MAX= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
  #endregion       
}

