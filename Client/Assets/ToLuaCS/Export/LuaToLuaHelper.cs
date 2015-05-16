using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLuaHelper {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(LuaHelper);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "GCCollect", GCCollect);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Destroy", Destroy);

           ToLuaCS.AddMember(L, "DestroyImmediate", DestroyImmediate);

           ToLuaCS.AddMember(L, "Instantiate", Instantiate);

           ToLuaCS.AddMember(L, "InstantiateLocal", InstantiateLocal);

           ToLuaCS.AddMember(L, "InstantiateGlobal", InstantiateGlobal);

           ToLuaCS.AddMember(L, "SetParent", SetParent);

           ToLuaCS.AddMember(L, "GetType", GetType);

           ToLuaCS.AddMember(L, "Find", Find);

           ToLuaCS.AddMember(L, "FindWithTag", FindWithTag);

           ToLuaCS.AddMember(L, "GetComponentInChildren", GetComponentInChildren);

           ToLuaCS.AddMember(L, "GetComponent", GetComponent);

           ToLuaCS.AddMember(L, "GetComponents", GetComponents);

           ToLuaCS.AddMember(L, "GetComponentsInChildren", GetComponentsInChildren);

           ToLuaCS.AddMember(L, "GetAllChild", GetAllChild);

           ToLuaCS.AddMember(L, "ForeachChild", ForeachChild);

           ToLuaCS.AddMember(L, "Raycast", Raycast);

           ToLuaCS.AddMember(L, "RefreshShader", RefreshShader);

           ToLuaCS.AddMember(L, "GetAngle", GetAngle);

           ToLuaCS.AddMember(L, "GetUTF8String", GetUTF8String);

           ToLuaCS.AddMember(L, "GetBytes", GetBytes);

           ToLuaCS.AddMember(L, "__call", _luahelper);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GCCollect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  LuaHelper target= (LuaHelper) original ;
                  target.GCCollect();
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Destroy(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  LuaHelper.Destroy( original_, t_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  LuaHelper.Destroy( original_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DestroyImmediate(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.Boolean allowDestroyingAssets_ =  LuaDLL.lua_toboolean(L,2);

                  LuaHelper.DestroyImmediate( original_, allowDestroyingAssets_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  LuaHelper.DestroyImmediate( original_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Instantiate(LuaState L)
          {
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  UnityEngine.Object instantiate= LuaHelper.Instantiate( original_);
                  ToLuaCS.push(L,instantiate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InstantiateLocal(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 3);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, parent_, pos_);
                  ToLuaCS.push(L,instantiatelocal);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3))){
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, pos_);
                  ToLuaCS.push(L,instantiatelocal);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.GameObject){
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, parent_);
                  ToLuaCS.push(L,instantiatelocal);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_);
                  ToLuaCS.push(L,instantiatelocal);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InstantiateGlobal(LuaState L)
          {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                  UnityEngine.GameObject instantiateglobal= LuaHelper.InstantiateGlobal( original_, parent_);
                  ToLuaCS.push(L,instantiateglobal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetParent(LuaState L)
          {
                  UnityEngine.GameObject child_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                  LuaHelper.SetParent( child_, parent_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is System.Object){
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 1);

                  System.Type gettype= LuaHelper.GetType( obj_);
                  ToLuaCS.push(L,gettype);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String classname_ =  LuaDLL.lua_tostring(L,1); 


                  System.Type gettype= LuaHelper.GetType( classname_);
                  ToLuaCS.push(L,gettype);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){

                   var original = ToLuaCS.getObject(L, 1);
                  LuaHelper target= (LuaHelper) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject find= LuaHelper.Find( name_);
                  ToLuaCS.push(L,find);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject findwithtag= LuaHelper.FindWithTag( tag_);
                  ToLuaCS.push(L,findwithtag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInChildren(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component getcomponentinchildren= LuaHelper.GetComponentInChildren( obj_, classname_);
                  ToLuaCS.push(L,getcomponentinchildren);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component getcomponent= LuaHelper.GetComponent( obj_, classname_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component[] getcomponents= LuaHelper.GetComponents( obj_, classname_);
                  ToLuaCS.push(L,getcomponents);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component[] getcomponentsinchildren= LuaHelper.GetComponentsInChildren( obj_, classname_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAllChild(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  UnityEngine.Transform[] getallchild= LuaHelper.GetAllChild( obj_);
                  ToLuaCS.push(L,getallchild);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ForeachChild(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is ReferGameObjects && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TFUNCTION){
                  ReferGameObjects parent_ = (ReferGameObjects)ToLuaCS.getObject(L, 1);
                  LuaInterface.LuaFunction eachFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);

                  LuaHelper.ForeachChild( parent_, eachFn_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TFUNCTION){
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  LuaInterface.LuaFunction eachFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);

                  LuaHelper.ForeachChild( parent_, eachFn_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Raycast(LuaState L)
          {
                  UnityEngine.Ray ray_ = (UnityEngine.Ray)ToLuaCS.getRay(L, 1);

                  System.Object raycast= LuaHelper.Raycast( ray_);
                  ToLuaCS.push(L,raycast);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RefreshShader(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.WWW){
                  UnityEngine.WWW www_ = (UnityEngine.WWW)ToLuaCS.getObject(L, 1);

                  LuaHelper.RefreshShader( www_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.AssetBundle){
                  UnityEngine.AssetBundle assetBundle_ = (UnityEngine.AssetBundle)ToLuaCS.getObject(L, 1);

                  LuaHelper.RefreshShader( assetBundle_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAngle(LuaState L)
          {
                  System.Single p1x_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single p1y_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single p2x_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single p2y_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  System.Single getangle= LuaHelper.GetAngle( p1x_, p1y_, p2x_, p2y_);
                  LuaDLL.lua_pushnumber(L, getangle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetUTF8String(LuaState L)
          {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 1);

                  System.String getutf8string= LuaHelper.GetUTF8String( bytes_);
                  LuaDLL.lua_pushstring(L, getutf8string);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetBytes(LuaState L)
          {
                  System.String utf8Str_ =  LuaDLL.lua_tostring(L,1); 


                  System.Byte[] getbytes= LuaHelper.GetBytes( utf8Str_);
                  ToLuaCS.push(L,getbytes);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _luahelper(LuaState L)
          {

                  LuaHelper _luahelper= new LuaHelper();
                  ToLuaCS.push(L,_luahelper);
                  return 1;

          }
  #endregion       
}

