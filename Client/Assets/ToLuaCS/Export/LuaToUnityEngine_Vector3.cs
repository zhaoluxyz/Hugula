using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Vector3 {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Vector3);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_Item", get_Item);
           ToLuaCS.AddMember(L, "set_Item", set_Item);
           ToLuaCS.AddMember(L, "Set", Set);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "get_normalized", get_normalized);
           ToLuaCS.AddMember(L, "ToString", ToString);
           ToLuaCS.AddMember(L, "get_magnitude", get_magnitude);
           ToLuaCS.AddMember(L, "get_sqrMagnitude", get_sqrMagnitude);
           ToLuaCS.AddMember(L, "GetType", GetType);
           ToLuaCS.AddMember(L, "get_x", get_x);
           ToLuaCS.AddMember(L, "set_x", set_x);
           ToLuaCS.AddMember(L, "get_y", get_y);
           ToLuaCS.AddMember(L, "set_y", set_y);
           ToLuaCS.AddMember(L, "get_z", get_z);
           ToLuaCS.AddMember(L, "set_z", set_z);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Lerp", Lerp);

           ToLuaCS.AddMember(L, "Slerp", Slerp);

           ToLuaCS.AddMember(L, "OrthoNormalize", OrthoNormalize);

           ToLuaCS.AddMember(L, "MoveTowards", MoveTowards);

           ToLuaCS.AddMember(L, "RotateTowards", RotateTowards);

           ToLuaCS.AddMember(L, "SmoothDamp", SmoothDamp);

           ToLuaCS.AddMember(L, "Scale", Scale);

           ToLuaCS.AddMember(L, "Cross", Cross);

           ToLuaCS.AddMember(L, "Reflect", Reflect);

           ToLuaCS.AddMember(L, "Normalize", Normalize);

           ToLuaCS.AddMember(L, "Dot", Dot);

           ToLuaCS.AddMember(L, "Project", Project);

           ToLuaCS.AddMember(L, "ProjectOnPlane", ProjectOnPlane);

           ToLuaCS.AddMember(L, "Angle", Angle);

           ToLuaCS.AddMember(L, "Distance", Distance);

           ToLuaCS.AddMember(L, "ClampMagnitude", ClampMagnitude);

           ToLuaCS.AddMember(L, "Magnitude", Magnitude);

           ToLuaCS.AddMember(L, "SqrMagnitude", SqrMagnitude);

           ToLuaCS.AddMember(L, "Min", Min);

           ToLuaCS.AddMember(L, "Max", Max);

           ToLuaCS.AddMember(L, "get_zero", get_zero);

           ToLuaCS.AddMember(L, "get_one", get_one);

           ToLuaCS.AddMember(L, "get_forward", get_forward);

           ToLuaCS.AddMember(L, "get_back", get_back);

           ToLuaCS.AddMember(L, "get_up", get_up);

           ToLuaCS.AddMember(L, "get_down", get_down);

           ToLuaCS.AddMember(L, "get_left", get_left);

           ToLuaCS.AddMember(L, "get_right", get_right);

           ToLuaCS.AddMember(L, "__call", _vector3);

           ToLuaCS.AddMember(L, "get_kEpsilon", get_kEpsilon);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Single Item= target[ index_];
                  LuaDLL.lua_pushnumber(L, Item);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target[  index_]= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Set(LuaState L)
          {
                  System.Single new_x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single new_y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single new_z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Set( new_x_, new_y_, new_z_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object other_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Boolean equals= target.Equals( other_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_normalized(LuaState L)
          {

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  UnityEngine.Vector3 normalized= target.normalized;
                  ToLuaCS.push(L,normalized);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String format_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.String tostring= target.ToString( format_);
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_magnitude(LuaState L)
          {

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Single magnitude= target.magnitude;
                  LuaDLL.lua_pushnumber(L, magnitude);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_sqrMagnitude(LuaState L)
          {

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Single sqrMagnitude= target.sqrMagnitude;
                  LuaDLL.lua_pushnumber(L, sqrMagnitude);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_x(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.x;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_x(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  target.x= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_y(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.y;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_y(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  target.y= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_z(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.z;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_z(LuaState L)
          {
                  var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  target.z= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Lerp(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 lerp= UnityEngine.Vector3.Lerp( from_, to_, t_);
                  ToLuaCS.push(L,lerp);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Slerp(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 slerp= UnityEngine.Vector3.Slerp( from_, to_, t_);
                  ToLuaCS.push(L,slerp);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OrthoNormalize(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Vector3 normal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 tangent_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 binormal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 3);

                  UnityEngine.Vector3.OrthoNormalize( ref normal_, ref tangent_, ref binormal_);
                  ToLuaCS.push(L,normal_);
                  ToLuaCS.push(L,tangent_);
                  ToLuaCS.push(L,binormal_);
                  return 3;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 normal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 tangent_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 2);

                  UnityEngine.Vector3.OrthoNormalize( ref normal_, ref tangent_);
                  ToLuaCS.push(L,normal_);
                  ToLuaCS.push(L,tangent_);
                  return 2;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTowards(LuaState L)
          {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single maxDistanceDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 movetowards= UnityEngine.Vector3.MoveTowards( current_, target_, maxDistanceDelta_);
                  ToLuaCS.push(L,movetowards);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTowards(LuaState L)
          {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single maxRadiansDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single maxMagnitudeDelta_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 rotatetowards= UnityEngine.Vector3.RotateTowards( current_, target_, maxRadiansDelta_, maxMagnitudeDelta_);
                  ToLuaCS.push(L,rotatetowards);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SmoothDamp(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,6)){
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single maxSpeed_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,6);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_, maxSpeed_, deltaTime_);
                  ToLuaCS.push(L,smoothdamp);
                  ToLuaCS.push(L,currentVelocity_);
                  return 2;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,5)){
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single maxSpeed_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_, maxSpeed_);
                  ToLuaCS.push(L,smoothdamp);
                  ToLuaCS.push(L,currentVelocity_);
                  return 2;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_);
                  ToLuaCS.push(L,smoothdamp);
                  ToLuaCS.push(L,currentVelocity_);
                  return 2;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Scale(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 scale= UnityEngine.Vector3.Scale( a_, b_);
                  ToLuaCS.push(L,scale);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Vector3 scale_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Scale( scale_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Cross(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 cross= UnityEngine.Vector3.Cross( lhs_, rhs_);
                  ToLuaCS.push(L,cross);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Reflect(LuaState L)
          {
                  UnityEngine.Vector3 inDirection_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 inNormal_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 reflect= UnityEngine.Vector3.Reflect( inDirection_, inNormal_);
                  ToLuaCS.push(L,reflect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Normalize(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  UnityEngine.Vector3 normalize= UnityEngine.Vector3.Normalize( value_);
                  ToLuaCS.push(L,normalize);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                   var original = ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Normalize();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dot(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  System.Single dot= UnityEngine.Vector3.Dot( lhs_, rhs_);
                  LuaDLL.lua_pushnumber(L, dot);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Project(LuaState L)
          {
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 onNormal_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 project= UnityEngine.Vector3.Project( vector_, onNormal_);
                  ToLuaCS.push(L,project);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ProjectOnPlane(LuaState L)
          {
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 planeNormal_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 projectonplane= UnityEngine.Vector3.ProjectOnPlane( vector_, planeNormal_);
                  ToLuaCS.push(L,projectonplane);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Angle(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  System.Single angle= UnityEngine.Vector3.Angle( from_, to_);
                  LuaDLL.lua_pushnumber(L, angle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Distance(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  System.Single distance= UnityEngine.Vector3.Distance( a_, b_);
                  LuaDLL.lua_pushnumber(L, distance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ClampMagnitude(LuaState L)
          {
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  System.Single maxLength_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 clampmagnitude= UnityEngine.Vector3.ClampMagnitude( vector_, maxLength_);
                  ToLuaCS.push(L,clampmagnitude);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Magnitude(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  System.Single magnitude= UnityEngine.Vector3.Magnitude( a_);
                  LuaDLL.lua_pushnumber(L, magnitude);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SqrMagnitude(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  System.Single sqrmagnitude= UnityEngine.Vector3.SqrMagnitude( a_);
                  LuaDLL.lua_pushnumber(L, sqrmagnitude);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Min(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 min= UnityEngine.Vector3.Min( lhs_, rhs_);
                  ToLuaCS.push(L,min);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Max(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Vector3 max= UnityEngine.Vector3.Max( lhs_, rhs_);
                  ToLuaCS.push(L,max);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_zero(LuaState L)
          {

                  UnityEngine.Vector3 zero= UnityEngine.Vector3.zero;
                  ToLuaCS.push(L,zero);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_one(LuaState L)
          {

                  UnityEngine.Vector3 one= UnityEngine.Vector3.one;
                  ToLuaCS.push(L,one);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_forward(LuaState L)
          {

                  UnityEngine.Vector3 forward= UnityEngine.Vector3.forward;
                  ToLuaCS.push(L,forward);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_back(LuaState L)
          {

                  UnityEngine.Vector3 back= UnityEngine.Vector3.back;
                  ToLuaCS.push(L,back);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_up(LuaState L)
          {

                  UnityEngine.Vector3 up= UnityEngine.Vector3.up;
                  ToLuaCS.push(L,up);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_down(LuaState L)
          {

                  UnityEngine.Vector3 down= UnityEngine.Vector3.down;
                  ToLuaCS.push(L,down);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_left(LuaState L)
          {

                  UnityEngine.Vector3 left= UnityEngine.Vector3.left;
                  ToLuaCS.push(L,left);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_right(LuaState L)
          {

                  UnityEngine.Vector3 right= UnityEngine.Vector3.right;
                  ToLuaCS.push(L,right);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _vector3(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 _vector3= new UnityEngine.Vector3( x_, y_, z_);
                  ToLuaCS.push(L,_vector3);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 _vector3= new UnityEngine.Vector3( x_, y_);
                  ToLuaCS.push(L,_vector3);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_kEpsilon(LuaState L)
          {
                  var val=   UnityEngine.Vector3.kEpsilon;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
  #endregion       
}

