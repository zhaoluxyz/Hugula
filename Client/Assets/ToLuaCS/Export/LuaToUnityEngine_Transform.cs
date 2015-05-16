using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Transform {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Transform);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_position", get_position);
           ToLuaCS.AddMember(L, "set_position", set_position);
           ToLuaCS.AddMember(L, "get_localPosition", get_localPosition);
           ToLuaCS.AddMember(L, "set_localPosition", set_localPosition);
           ToLuaCS.AddMember(L, "get_eulerAngles", get_eulerAngles);
           ToLuaCS.AddMember(L, "set_eulerAngles", set_eulerAngles);
           ToLuaCS.AddMember(L, "get_localEulerAngles", get_localEulerAngles);
           ToLuaCS.AddMember(L, "set_localEulerAngles", set_localEulerAngles);
           ToLuaCS.AddMember(L, "get_right", get_right);
           ToLuaCS.AddMember(L, "set_right", set_right);
           ToLuaCS.AddMember(L, "get_up", get_up);
           ToLuaCS.AddMember(L, "set_up", set_up);
           ToLuaCS.AddMember(L, "get_forward", get_forward);
           ToLuaCS.AddMember(L, "set_forward", set_forward);
           ToLuaCS.AddMember(L, "get_rotation", get_rotation);
           ToLuaCS.AddMember(L, "set_rotation", set_rotation);
           ToLuaCS.AddMember(L, "get_localRotation", get_localRotation);
           ToLuaCS.AddMember(L, "set_localRotation", set_localRotation);
           ToLuaCS.AddMember(L, "get_localScale", get_localScale);
           ToLuaCS.AddMember(L, "set_localScale", set_localScale);
           ToLuaCS.AddMember(L, "get_parent", get_parent);
           ToLuaCS.AddMember(L, "set_parent", set_parent);
           ToLuaCS.AddMember(L, "SetParent", SetParent);
           ToLuaCS.AddMember(L, "get_worldToLocalMatrix", get_worldToLocalMatrix);
           ToLuaCS.AddMember(L, "get_localToWorldMatrix", get_localToWorldMatrix);
           ToLuaCS.AddMember(L, "Translate", Translate);
           ToLuaCS.AddMember(L, "Rotate", Rotate);
           ToLuaCS.AddMember(L, "RotateAround", RotateAround);
           ToLuaCS.AddMember(L, "LookAt", LookAt);
           ToLuaCS.AddMember(L, "TransformDirection", TransformDirection);
           ToLuaCS.AddMember(L, "InverseTransformDirection", InverseTransformDirection);
           ToLuaCS.AddMember(L, "TransformVector", TransformVector);
           ToLuaCS.AddMember(L, "InverseTransformVector", InverseTransformVector);
           ToLuaCS.AddMember(L, "TransformPoint", TransformPoint);
           ToLuaCS.AddMember(L, "InverseTransformPoint", InverseTransformPoint);
           ToLuaCS.AddMember(L, "get_root", get_root);
           ToLuaCS.AddMember(L, "get_childCount", get_childCount);
           ToLuaCS.AddMember(L, "DetachChildren", DetachChildren);
           ToLuaCS.AddMember(L, "SetAsFirstSibling", SetAsFirstSibling);
           ToLuaCS.AddMember(L, "SetAsLastSibling", SetAsLastSibling);
           ToLuaCS.AddMember(L, "SetSiblingIndex", SetSiblingIndex);
           ToLuaCS.AddMember(L, "GetSiblingIndex", GetSiblingIndex);
           ToLuaCS.AddMember(L, "Find", Find);
           ToLuaCS.AddMember(L, "get_lossyScale", get_lossyScale);
           ToLuaCS.AddMember(L, "IsChildOf", IsChildOf);
           ToLuaCS.AddMember(L, "get_hasChanged", get_hasChanged);
           ToLuaCS.AddMember(L, "set_hasChanged", set_hasChanged);
           ToLuaCS.AddMember(L, "FindChild", FindChild);
           ToLuaCS.AddMember(L, "GetEnumerator", GetEnumerator);
           ToLuaCS.AddMember(L, "GetChild", GetChild);
           ToLuaCS.AddMember(L, "get_transform", get_transform);
           ToLuaCS.AddMember(L, "get_gameObject", get_gameObject);
           ToLuaCS.AddMember(L, "GetComponent", GetComponent);
           ToLuaCS.AddMember(L, "GetComponentInChildren", GetComponentInChildren);
           ToLuaCS.AddMember(L, "GetComponentsInChildren", GetComponentsInChildren);
           ToLuaCS.AddMember(L, "GetComponentInParent", GetComponentInParent);
           ToLuaCS.AddMember(L, "GetComponentsInParent", GetComponentsInParent);
           ToLuaCS.AddMember(L, "GetComponents", GetComponents);
           ToLuaCS.AddMember(L, "get_tag", get_tag);
           ToLuaCS.AddMember(L, "set_tag", set_tag);
           ToLuaCS.AddMember(L, "CompareTag", CompareTag);
           ToLuaCS.AddMember(L, "SendMessageUpwards", SendMessageUpwards);
           ToLuaCS.AddMember(L, "SendMessage", SendMessage);
           ToLuaCS.AddMember(L, "BroadcastMessage", BroadcastMessage);
           ToLuaCS.AddMember(L, "get_name", get_name);
           ToLuaCS.AddMember(L, "set_name", set_name);
           ToLuaCS.AddMember(L, "get_hideFlags", get_hideFlags);
           ToLuaCS.AddMember(L, "set_hideFlags", set_hideFlags);
           ToLuaCS.AddMember(L, "ToString", ToString);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "GetInstanceID", GetInstanceID);
           ToLuaCS.AddMember(L, "GetType", GetType);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_position(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 position= target.position;
                  ToLuaCS.push(L,position);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_position(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.position= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localPosition(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localPosition= target.localPosition;
                  ToLuaCS.push(L,localPosition);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localPosition(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localPosition= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eulerAngles(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 eulerAngles= target.eulerAngles;
                  ToLuaCS.push(L,eulerAngles);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.eulerAngles= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localEulerAngles(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localEulerAngles= target.localEulerAngles;
                  ToLuaCS.push(L,localEulerAngles);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localEulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localEulerAngles= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_right(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 right= target.right;
                  ToLuaCS.push(L,right);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_right(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.right= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_up(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 up= target.up;
                  ToLuaCS.push(L,up);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_up(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.up= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_forward(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 forward= target.forward;
                  ToLuaCS.push(L,forward);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_forward(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.forward= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotation(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Quaternion rotation= target.rotation;
                  ToLuaCS.push(L,rotation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_rotation(LuaState L)
          {
                  UnityEngine.Quaternion value_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.rotation= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localRotation(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Quaternion localRotation= target.localRotation;
                  ToLuaCS.push(L,localRotation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localRotation(LuaState L)
          {
                  UnityEngine.Quaternion value_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localRotation= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localScale(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localScale= target.localScale;
                  ToLuaCS.push(L,localScale);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localScale(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localScale= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_parent(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform parent= target.parent;
                  ToLuaCS.push(L,parent);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_parent(LuaState L)
          {
                  UnityEngine.Transform value_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.parent= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetParent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Transform parent_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);
                  System.Boolean worldPositionStays_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetParent( parent_, worldPositionStays_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Transform parent_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetParent( parent_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldToLocalMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Matrix4x4 worldToLocalMatrix= target.worldToLocalMatrix;
                  ToLuaCS.push(L,worldToLocalMatrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localToWorldMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Matrix4x4 localToWorldMatrix= target.localToWorldMatrix;
                  ToLuaCS.push(L,localToWorldMatrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Translate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,5)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is UnityEngine.Space){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L, 5);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_, relativeTo_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is UnityEngine.Transform){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 5);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_, relativeTo_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && ToLuaCS.getObject(L, 3) is UnityEngine.Transform){
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_, relativeTo_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && ToLuaCS.getObject(L, 3) is UnityEngine.Space){
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_, relativeTo_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rotate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,5)){
                  System.Single xAngle_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single yAngle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single zAngle_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L, 5);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( xAngle_, yAngle_, zAngle_, relativeTo_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,4)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is UnityEngine.Space){
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( axis_, angle_, relativeTo_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  System.Single xAngle_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single yAngle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single zAngle_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( xAngle_, yAngle_, zAngle_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( axis_, angle_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && ToLuaCS.getObject(L, 3) is UnityEngine.Space){
                  UnityEngine.Vector3 eulerAngles_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( eulerAngles_, relativeTo_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 eulerAngles_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( eulerAngles_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateAround(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  UnityEngine.Vector3 point_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.RotateAround( point_, axis_, angle_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.RotateAround( axis_, angle_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookAt(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3))){
                  UnityEngine.Vector3 worldPosition_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( worldPosition_, worldUp_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && LuaDLL.lua_type(L,3)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 3, typeof(UnityEngine.Vector3))){
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( target_, worldUp_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3))){
                  UnityEngine.Vector3 worldPosition_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( worldPosition_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform){
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( target_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int TransformDirection(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformdirection= target.TransformDirection( x_, y_, z_);
                  ToLuaCS.push(L,transformdirection);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 direction_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformdirection= target.TransformDirection( direction_);
                  ToLuaCS.push(L,transformdirection);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InverseTransformDirection(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformdirection= target.InverseTransformDirection( x_, y_, z_);
                  ToLuaCS.push(L,inversetransformdirection);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 direction_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformdirection= target.InverseTransformDirection( direction_);
                  ToLuaCS.push(L,inversetransformdirection);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int TransformVector(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformvector= target.TransformVector( x_, y_, z_);
                  ToLuaCS.push(L,transformvector);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformvector= target.TransformVector( vector_);
                  ToLuaCS.push(L,transformvector);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InverseTransformVector(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformvector= target.InverseTransformVector( x_, y_, z_);
                  ToLuaCS.push(L,inversetransformvector);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformvector= target.InverseTransformVector( vector_);
                  ToLuaCS.push(L,inversetransformvector);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int TransformPoint(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformpoint= target.TransformPoint( x_, y_, z_);
                  ToLuaCS.push(L,transformpoint);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformpoint= target.TransformPoint( position_);
                  ToLuaCS.push(L,transformpoint);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InverseTransformPoint(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformpoint= target.InverseTransformPoint( x_, y_, z_);
                  ToLuaCS.push(L,inversetransformpoint);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformpoint= target.InverseTransformPoint( position_);
                  ToLuaCS.push(L,inversetransformpoint);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_root(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform root= target.root;
                  ToLuaCS.push(L,root);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_childCount(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 childCount= target.childCount;
                  LuaDLL.lua_pushnumber(L, childCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DetachChildren(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.DetachChildren();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAsFirstSibling(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetAsFirstSibling();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAsLastSibling(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetAsLastSibling();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetSiblingIndex(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetSiblingIndex( index_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetSiblingIndex(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 getsiblingindex= target.GetSiblingIndex();
                  LuaDLL.lua_pushnumber(L, getsiblingindex);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform find= target.Find( name_);
                  ToLuaCS.push(L,find);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lossyScale(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 lossyScale= target.lossyScale;
                  ToLuaCS.push(L,lossyScale);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsChildOf(LuaState L)
          {
                  UnityEngine.Transform parent_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean ischildof= target.IsChildOf( parent_);
                  LuaDLL.lua_pushboolean(L,ischildof);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hasChanged(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean hasChanged= target.hasChanged;
                  LuaDLL.lua_pushboolean(L,hasChanged);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hasChanged(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.hasChanged= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindChild(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform findchild= target.FindChild( name_);
                  ToLuaCS.push(L,findchild);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEnumerator(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Collections.IEnumerator getenumerator= target.GetEnumerator();
                  ToLuaCS.push(L,getenumerator);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetChild(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform getchild= target.GetChild( index_);
                  ToLuaCS.push(L,getchild);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.GameObject gameObject= target.gameObject;
                  ToLuaCS.push(L,gameObject);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInChildren(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( t_);
                  ToLuaCS.push(L,getcomponentinchildren);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TBOOLEAN ){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInParent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( t_);
                  ToLuaCS.push(L,getcomponentinparent);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInParent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TBOOLEAN ){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);
                  System.Collections.Generic.List<UnityEngine.Component> results_ = (System.Collections.Generic.List<UnityEngine.Component>)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.GetComponents( type_, results_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponents= target.GetComponents( type_);
                  ToLuaCS.push(L,getcomponents);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String tag= target.tag;
                  LuaDLL.lua_pushstring(L, tag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.tag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean comparetag= target.CompareTag( tag_);
                  LuaDLL.lua_pushboolean(L,comparetag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessageUpwards(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessage(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BroadcastMessage(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
  #endregion       
}

