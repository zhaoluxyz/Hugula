using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_BoxCollider {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.BoxCollider);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_center", get_center);
           ToLuaCS.AddMember(L, "set_center", set_center);
           ToLuaCS.AddMember(L, "get_size", get_size);
           ToLuaCS.AddMember(L, "set_size", set_size);
           ToLuaCS.AddMember(L, "get_enabled", get_enabled);
           ToLuaCS.AddMember(L, "set_enabled", set_enabled);
           ToLuaCS.AddMember(L, "get_attachedRigidbody", get_attachedRigidbody);
           ToLuaCS.AddMember(L, "get_isTrigger", get_isTrigger);
           ToLuaCS.AddMember(L, "set_isTrigger", set_isTrigger);
           ToLuaCS.AddMember(L, "get_material", get_material);
           ToLuaCS.AddMember(L, "set_material", set_material);
           ToLuaCS.AddMember(L, "ClosestPointOnBounds", ClosestPointOnBounds);
           ToLuaCS.AddMember(L, "get_sharedMaterial", get_sharedMaterial);
           ToLuaCS.AddMember(L, "set_sharedMaterial", set_sharedMaterial);
           ToLuaCS.AddMember(L, "get_bounds", get_bounds);
           ToLuaCS.AddMember(L, "Raycast", Raycast);
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

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "__call", _boxcollider);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_center(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Vector3 center= target.center;
                  ToLuaCS.push(L,center);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_center(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.center= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_size(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Vector3 size= target.size;
                  ToLuaCS.push(L,size);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_size(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.size= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enabled(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Boolean enabled= target.enabled;
                  LuaDLL.lua_pushboolean(L,enabled);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enabled(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.enabled= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_attachedRigidbody(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Rigidbody attachedRigidbody= target.attachedRigidbody;
                  ToLuaCS.push(L,attachedRigidbody);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isTrigger(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Boolean isTrigger= target.isTrigger;
                  LuaDLL.lua_pushboolean(L,isTrigger);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isTrigger(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.isTrigger= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_material(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.PhysicMaterial material= target.material;
                  ToLuaCS.push(L,material);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_material(LuaState L)
          {
                  UnityEngine.PhysicMaterial value_ = (UnityEngine.PhysicMaterial)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.material= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ClosestPointOnBounds(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Vector3 closestpointonbounds= target.ClosestPointOnBounds( position_);
                  ToLuaCS.push(L,closestpointonbounds);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_sharedMaterial(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.PhysicMaterial sharedMaterial= target.sharedMaterial;
                  ToLuaCS.push(L,sharedMaterial);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_sharedMaterial(LuaState L)
          {
                  UnityEngine.PhysicMaterial value_ = (UnityEngine.PhysicMaterial)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.sharedMaterial= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_bounds(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Bounds bounds= target.bounds;
                  ToLuaCS.push(L,bounds);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Raycast(LuaState L)
          {
                  UnityEngine.Ray ray_ = (UnityEngine.Ray)ToLuaCS.getRay(L, 2);
                  UnityEngine.RaycastHit hitInfo_ = (UnityEngine.RaycastHit)ToLuaCS.getObject(L, 3);
                  System.Single distance_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Boolean raycast= target.Raycast( ray_, out hitInfo_, distance_);
                  LuaDLL.lua_pushboolean(L,raycast);
                  ToLuaCS.push(L,hitInfo_);
                  return 2;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.GetComponents( type_, results_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.String tag= target.tag;
                  LuaDLL.lua_pushstring(L, tag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.tag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessageUpwards( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessageUpwards( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessage( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.SendMessage( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
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
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.BroadcastMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.BroadcastMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.BoxCollider target= (UnityEngine.BoxCollider) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _boxcollider(LuaState L)
          {

                  UnityEngine.BoxCollider _boxcollider= new UnityEngine.BoxCollider();
                  ToLuaCS.push(L,_boxcollider);
                  return 1;

          }
  #endregion       
}

