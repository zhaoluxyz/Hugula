using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_MonoBehaviour {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.MonoBehaviour);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Invoke", Invoke);
           ToLuaCS.AddMember(L, "InvokeRepeating", InvokeRepeating);
           ToLuaCS.AddMember(L, "CancelInvoke", CancelInvoke);
           ToLuaCS.AddMember(L, "IsInvoking", IsInvoking);
           ToLuaCS.AddMember(L, "StartCoroutine", StartCoroutine);
           ToLuaCS.AddMember(L, "StartCoroutine_Auto", StartCoroutine_Auto);
           ToLuaCS.AddMember(L, "StopCoroutine", StopCoroutine);
           ToLuaCS.AddMember(L, "StopAllCoroutines", StopAllCoroutines);
           ToLuaCS.AddMember(L, "get_useGUILayout", get_useGUILayout);
           ToLuaCS.AddMember(L, "set_useGUILayout", set_useGUILayout);
           ToLuaCS.AddMember(L, "get_enabled", get_enabled);
           ToLuaCS.AddMember(L, "set_enabled", set_enabled);
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
           ToLuaCS.AddMember(L, "print", print);

           ToLuaCS.AddMember(L, "__call", _monobehaviour);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Invoke(LuaState L)
          {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.Invoke( methodName_, time_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InvokeRepeating(LuaState L)
          {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single repeatRate_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.InvokeRepeating( methodName_, time_, repeatRate_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CancelInvoke(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.CancelInvoke( methodName_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.CancelInvoke();
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsInvoking(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean isinvoking= target.IsInvoking( methodName_);
                  LuaDLL.lua_pushboolean(L,isinvoking);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean isinvoking= target.IsInvoking();
                  LuaDLL.lua_pushboolean(L,isinvoking);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StartCoroutine(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( methodName_, value_);
                  ToLuaCS.push(L,startcoroutine);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( methodName_);
                  ToLuaCS.push(L,startcoroutine);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Collections.IEnumerator){
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( routine_);
                  ToLuaCS.push(L,startcoroutine);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StartCoroutine_Auto(LuaState L)
          {
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine_auto= target.StartCoroutine_Auto( routine_);
                  ToLuaCS.push(L,startcoroutine_auto);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopCoroutine(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is UnityEngine.Coroutine){
                  UnityEngine.Coroutine routine_ = (UnityEngine.Coroutine)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopCoroutine( routine_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is System.Collections.IEnumerator){
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopCoroutine( routine_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopCoroutine( methodName_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopAllCoroutines(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopAllCoroutines();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useGUILayout(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean useGUILayout= target.useGUILayout;
                  LuaDLL.lua_pushboolean(L,useGUILayout);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useGUILayout(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.useGUILayout= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enabled(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean enabled= target.enabled;
                  LuaDLL.lua_pushboolean(L,enabled);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enabled(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.enabled= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.GetComponents( type_, results_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String tag= target.tag;
                  LuaDLL.lua_pushstring(L, tag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.tag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
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
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int print(LuaState L)
          {
                  System.Object message_ = (System.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.MonoBehaviour.print( message_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _monobehaviour(LuaState L)
          {

                  UnityEngine.MonoBehaviour _monobehaviour= new UnityEngine.MonoBehaviour();
                  ToLuaCS.push(L,_monobehaviour);
                  return 1;

          }
  #endregion       
}

