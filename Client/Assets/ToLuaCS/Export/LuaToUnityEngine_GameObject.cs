using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_GameObject {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.GameObject);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "GetComponent", GetComponent);
           ToLuaCS.AddMember(L, "GetComponentInChildren", GetComponentInChildren);
           ToLuaCS.AddMember(L, "GetComponentInParent", GetComponentInParent);
           ToLuaCS.AddMember(L, "GetComponents", GetComponents);
           ToLuaCS.AddMember(L, "GetComponentsInChildren", GetComponentsInChildren);
           ToLuaCS.AddMember(L, "GetComponentsInParent", GetComponentsInParent);
           ToLuaCS.AddMember(L, "get_transform", get_transform);
           ToLuaCS.AddMember(L, "get_layer", get_layer);
           ToLuaCS.AddMember(L, "set_layer", set_layer);
           ToLuaCS.AddMember(L, "SetActive", SetActive);
           ToLuaCS.AddMember(L, "get_activeSelf", get_activeSelf);
           ToLuaCS.AddMember(L, "get_activeInHierarchy", get_activeInHierarchy);
           ToLuaCS.AddMember(L, "get_isStatic", get_isStatic);
           ToLuaCS.AddMember(L, "set_isStatic", set_isStatic);
           ToLuaCS.AddMember(L, "get_tag", get_tag);
           ToLuaCS.AddMember(L, "set_tag", set_tag);
           ToLuaCS.AddMember(L, "CompareTag", CompareTag);
           ToLuaCS.AddMember(L, "SendMessageUpwards", SendMessageUpwards);
           ToLuaCS.AddMember(L, "SendMessage", SendMessage);
           ToLuaCS.AddMember(L, "BroadcastMessage", BroadcastMessage);
           ToLuaCS.AddMember(L, "AddComponent", AddComponent);
           ToLuaCS.AddMember(L, "get_gameObject", get_gameObject);
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
           ToLuaCS.AddMember(L, "CreatePrimitive", CreatePrimitive);

           ToLuaCS.AddMember(L, "FindGameObjectWithTag", FindGameObjectWithTag);

           ToLuaCS.AddMember(L, "FindWithTag", FindWithTag);

           ToLuaCS.AddMember(L, "FindGameObjectsWithTag", FindGameObjectsWithTag);

           ToLuaCS.AddMember(L, "Find", Find);

           ToLuaCS.AddMember(L, "__call", _gameobject);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( type_);
                  ToLuaCS.push(L,getcomponentinchildren);
                  return 1;

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
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( type_);
                  ToLuaCS.push(L,getcomponentinparent);
                  return 1;

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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.GetComponents( type_, results_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
          public static int GetComponentsInChildren(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TBOOLEAN ){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( type_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( type_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
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
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( type_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( type_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layer(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 layer= target.layer;
                  LuaDLL.lua_pushnumber(L, layer);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layer(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.layer= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetActive(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SetActive( value_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activeSelf(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean activeSelf= target.activeSelf;
                  LuaDLL.lua_pushboolean(L,activeSelf);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activeInHierarchy(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean activeInHierarchy= target.activeInHierarchy;
                  LuaDLL.lua_pushboolean(L,activeInHierarchy);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isStatic(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean isStatic= target.isStatic;
                  LuaDLL.lua_pushboolean(L,isStatic);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isStatic(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.isStatic= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String tag= target.tag;
                  LuaDLL.lua_pushstring(L, tag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.tag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddComponent(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String className_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component addcomponent= UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent( target, "Assets/ToLuaCS/Export/LuaToUnityEngine_GameObject.cs (543,55)", className_);
                  ToLuaCS.push(L,addcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type componentType_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component addcomponent= target.AddComponent( componentType_);
                  ToLuaCS.push(L,addcomponent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.GameObject gameObject= target.gameObject;
                  ToLuaCS.push(L,gameObject);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreatePrimitive(LuaState L)
          {
                  UnityEngine.PrimitiveType type_ = (UnityEngine.PrimitiveType)ToLuaCS.getObject(L, 1);

                  UnityEngine.GameObject createprimitive= UnityEngine.GameObject.CreatePrimitive( type_);
                  ToLuaCS.push(L,createprimitive);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindGameObjectWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject findgameobjectwithtag= UnityEngine.GameObject.FindGameObjectWithTag( tag_);
                  ToLuaCS.push(L,findgameobjectwithtag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject findwithtag= UnityEngine.GameObject.FindWithTag( tag_);
                  ToLuaCS.push(L,findwithtag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindGameObjectsWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject[] findgameobjectswithtag= UnityEngine.GameObject.FindGameObjectsWithTag( tag_);
                  ToLuaCS.push(L,findgameobjectswithtag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject find= UnityEngine.GameObject.Find( name_);
                  ToLuaCS.push(L,find);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _gameobject(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type[] components_ = (System.Type[])ToLuaCS.getObject(L, 3);

                  UnityEngine.GameObject _gameobject= new UnityEngine.GameObject( name_, components_);
                  ToLuaCS.push(L,_gameobject);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.GameObject _gameobject= new UnityEngine.GameObject( name_);
                  ToLuaCS.push(L,_gameobject);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                  UnityEngine.GameObject _gameobject= new UnityEngine.GameObject();
                  ToLuaCS.push(L,_gameobject);
                  return 1;

                 }
               return 0;
          }
  #endregion       
}

