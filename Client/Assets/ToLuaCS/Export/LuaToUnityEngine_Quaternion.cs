using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Quaternion {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Quaternion);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_Item", get_Item);
           ToLuaCS.AddMember(L, "set_Item", set_Item);
           ToLuaCS.AddMember(L, "Set", Set);
           ToLuaCS.AddMember(L, "ToAngleAxis", ToAngleAxis);
           ToLuaCS.AddMember(L, "SetFromToRotation", SetFromToRotation);
           ToLuaCS.AddMember(L, "SetLookRotation", SetLookRotation);
           ToLuaCS.AddMember(L, "ToString", ToString);
           ToLuaCS.AddMember(L, "get_eulerAngles", get_eulerAngles);
           ToLuaCS.AddMember(L, "set_eulerAngles", set_eulerAngles);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetType", GetType);
           ToLuaCS.AddMember(L, "get_x", get_x);
           ToLuaCS.AddMember(L, "set_x", set_x);
           ToLuaCS.AddMember(L, "get_y", get_y);
           ToLuaCS.AddMember(L, "set_y", set_y);
           ToLuaCS.AddMember(L, "get_z", get_z);
           ToLuaCS.AddMember(L, "set_z", set_z);
           ToLuaCS.AddMember(L, "get_w", get_w);
           ToLuaCS.AddMember(L, "set_w", set_w);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_identity", get_identity);

           ToLuaCS.AddMember(L, "Dot", Dot);

           ToLuaCS.AddMember(L, "AngleAxis", AngleAxis);

           ToLuaCS.AddMember(L, "FromToRotation", FromToRotation);

           ToLuaCS.AddMember(L, "LookRotation", LookRotation);

           ToLuaCS.AddMember(L, "Slerp", Slerp);

           ToLuaCS.AddMember(L, "Lerp", Lerp);

           ToLuaCS.AddMember(L, "RotateTowards", RotateTowards);

           ToLuaCS.AddMember(L, "Inverse", Inverse);

           ToLuaCS.AddMember(L, "Angle", Angle);

           ToLuaCS.AddMember(L, "Euler", Euler);

           ToLuaCS.AddMember(L, "__call", _quaternion);

           ToLuaCS.AddMember(L, "get_kEpsilon", get_kEpsilon);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Single Item= target[ index_];
                  LuaDLL.lua_pushnumber(L, Item);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target[  index_]= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Set(LuaState L)
          {
                  System.Single new_x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single new_y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single new_z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single new_w_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.Set( new_x_, new_y_, new_z_, new_w_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToAngleAxis(LuaState L)
          {
                  System.Single angle_ = (System.Single)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.ToAngleAxis( out angle_, out axis_);
                  ToLuaCS.push(L,angle_);
                  ToLuaCS.push(L,axis_);
                  return 2;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetFromToRotation(LuaState L)
          {
                  UnityEngine.Vector3 fromDirection_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 toDirection_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetFromToRotation( fromDirection_, toDirection_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetLookRotation(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Vector3 view_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 up_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetLookRotation( view_, up_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 view_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetLookRotation( view_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String format_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.String tostring= target.ToString( format_);
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eulerAngles(LuaState L)
          {

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  UnityEngine.Vector3 eulerAngles= target.eulerAngles;
                  ToLuaCS.push(L,eulerAngles);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.eulerAngles= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object other_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Boolean equals= target.Equals( other_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_x(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.x;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_x(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.x= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_y(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.y;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_y(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.y= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_z(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.z;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_z(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.z= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_w(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.w;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_w(LuaState L)
          {
                  var original = ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.w= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_identity(LuaState L)
          {

                  UnityEngine.Quaternion identity= UnityEngine.Quaternion.identity;
                  ToLuaCS.push(L,identity);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dot(LuaState L)
          {
                  UnityEngine.Quaternion a_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion b_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);

                  System.Single dot= UnityEngine.Quaternion.Dot( a_, b_);
                  LuaDLL.lua_pushnumber(L, dot);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AngleAxis(LuaState L)
          {
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Quaternion angleaxis= UnityEngine.Quaternion.AngleAxis( angle_, axis_);
                  ToLuaCS.push(L,angleaxis);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FromToRotation(LuaState L)
          {
                  UnityEngine.Vector3 fromDirection_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 toDirection_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Quaternion fromtorotation= UnityEngine.Quaternion.FromToRotation( fromDirection_, toDirection_);
                  ToLuaCS.push(L,fromtorotation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookRotation(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 forward_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 upwards_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.Quaternion lookrotation= UnityEngine.Quaternion.LookRotation( forward_, upwards_);
                  ToLuaCS.push(L,lookrotation);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Vector3 forward_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  UnityEngine.Quaternion lookrotation= UnityEngine.Quaternion.LookRotation( forward_);
                  ToLuaCS.push(L,lookrotation);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Slerp(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion slerp= UnityEngine.Quaternion.Slerp( from_, to_, t_);
                  ToLuaCS.push(L,slerp);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Lerp(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion lerp= UnityEngine.Quaternion.Lerp( from_, to_, t_);
                  ToLuaCS.push(L,lerp);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTowards(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);
                  System.Single maxDegreesDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion rotatetowards= UnityEngine.Quaternion.RotateTowards( from_, to_, maxDegreesDelta_);
                  ToLuaCS.push(L,rotatetowards);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Inverse(LuaState L)
          {
                  UnityEngine.Quaternion rotation_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);

                  UnityEngine.Quaternion inverse= UnityEngine.Quaternion.Inverse( rotation_);
                  ToLuaCS.push(L,inverse);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Angle(LuaState L)
          {
                  UnityEngine.Quaternion a_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion b_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);

                  System.Single angle= UnityEngine.Quaternion.Angle( a_, b_);
                  LuaDLL.lua_pushnumber(L, angle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Euler(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion euler= UnityEngine.Quaternion.Euler( x_, y_, z_);
                  ToLuaCS.push(L,euler);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Vector3 euler_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  UnityEngine.Quaternion euler= UnityEngine.Quaternion.Euler( euler_);
                  ToLuaCS.push(L,euler);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _quaternion(LuaState L)
          {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single w_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Quaternion _quaternion= new UnityEngine.Quaternion( x_, y_, z_, w_);
                  ToLuaCS.push(L,_quaternion);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_kEpsilon(LuaState L)
          {
                  var val=   UnityEngine.Quaternion.kEpsilon;
                  LuaDLL.lua_pushnumber(L, val);
                  return 1;

          }
  #endregion       
}

