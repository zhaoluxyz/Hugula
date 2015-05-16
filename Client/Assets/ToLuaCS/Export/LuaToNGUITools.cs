using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToNGUITools {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(NGUITools);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_soundVolume", get_soundVolume);

           ToLuaCS.AddMember(L, "set_soundVolume", set_soundVolume);

           ToLuaCS.AddMember(L, "get_fileAccess", get_fileAccess);

           ToLuaCS.AddMember(L, "PlaySound", PlaySound);

           ToLuaCS.AddMember(L, "OpenURL", OpenURL);

           ToLuaCS.AddMember(L, "RandomRange", RandomRange);

           ToLuaCS.AddMember(L, "GetHierarchy", GetHierarchy);

           ToLuaCS.AddMember(L, "FindActive", FindActive);

           ToLuaCS.AddMember(L, "FindCameraForLayer", FindCameraForLayer);

           ToLuaCS.AddMember(L, "GetTypeName", GetTypeName);

           ToLuaCS.AddMember(L, "RegisterUndo", RegisterUndo);

           ToLuaCS.AddMember(L, "SetDirty", SetDirty);

           ToLuaCS.AddMember(L, "AddChild", AddChild);

           ToLuaCS.AddMember(L, "SetChildLayer", SetChildLayer);

           ToLuaCS.AddMember(L, "GetRoot", GetRoot);

           ToLuaCS.AddMember(L, "FindInParents", FindInParents);

           ToLuaCS.AddMember(L, "Destroy", Destroy);

           ToLuaCS.AddMember(L, "DestroyImmediate", DestroyImmediate);

           ToLuaCS.AddMember(L, "Broadcast", Broadcast);

           ToLuaCS.AddMember(L, "IsChild", IsChild);

           ToLuaCS.AddMember(L, "SetActiveChildren", SetActiveChildren);

           ToLuaCS.AddMember(L, "GetActive", GetActive);

           ToLuaCS.AddMember(L, "SetActiveSelf", SetActiveSelf);

           ToLuaCS.AddMember(L, "SetLayer", SetLayer);

           ToLuaCS.AddMember(L, "Round", Round);

           ToLuaCS.AddMember(L, "Save", Save);

           ToLuaCS.AddMember(L, "Load", Load);

           ToLuaCS.AddMember(L, "ApplyPMA", ApplyPMA);

           ToLuaCS.AddMember(L, "get_clipboard", get_clipboard);

           ToLuaCS.AddMember(L, "set_clipboard", set_clipboard);

           ToLuaCS.AddMember(L, "AddMissingComponent", AddMissingComponent);

           ToLuaCS.AddMember(L, "GetSides", GetSides);

           ToLuaCS.AddMember(L, "GetWorldCorners", GetWorldCorners);

           ToLuaCS.AddMember(L, "GetFuncName", GetFuncName);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_soundVolume(LuaState L)
          {

                  System.Single soundVolume= NGUITools.soundVolume;
                  LuaDLL.lua_pushnumber(L, soundVolume);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_soundVolume(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  NGUITools.soundVolume= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fileAccess(LuaState L)
          {

                  System.Boolean fileAccess= NGUITools.fileAccess;
                  LuaDLL.lua_pushboolean(L,fileAccess);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PlaySound(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.AudioClip clip_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L, 1);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single pitch_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.AudioSource playsound= NGUITools.PlaySound( clip_, volume_, pitch_);
                  ToLuaCS.push(L,playsound);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.AudioClip clip_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L, 1);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.AudioSource playsound= NGUITools.PlaySound( clip_, volume_);
                  ToLuaCS.push(L,playsound);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.AudioClip clip_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L, 1);

                  UnityEngine.AudioSource playsound= NGUITools.PlaySound( clip_);
                  ToLuaCS.push(L,playsound);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OpenURL(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  UnityEngine.WWWForm form_ = (UnityEngine.WWWForm)ToLuaCS.getObject(L, 2);

                  UnityEngine.WWW openurl= NGUITools.OpenURL( url_, form_);
                  ToLuaCS.push(L,openurl);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.WWW openurl= NGUITools.OpenURL( url_);
                  ToLuaCS.push(L,openurl);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RandomRange(LuaState L)
          {
                  System.Int32 min_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 max_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 randomrange= NGUITools.RandomRange( min_, max_);
                  LuaDLL.lua_pushnumber(L, randomrange);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHierarchy(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  System.String gethierarchy= NGUITools.GetHierarchy( obj_);
                  LuaDLL.lua_pushstring(L, gethierarchy);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindActive(LuaState L)
          {
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindCameraForLayer(LuaState L)
          {
                  System.Int32 layer_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Camera findcameraforlayer= NGUITools.FindCameraForLayer( layer_);
                  ToLuaCS.push(L,findcameraforlayer);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetTypeName(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  System.String gettypename= NGUITools.GetTypeName( obj_);
                  LuaDLL.lua_pushstring(L, gettypename);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,0)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RegisterUndo(LuaState L)
          {
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  NGUITools.RegisterUndo( obj_, name_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetDirty(LuaState L)
          {
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  NGUITools.SetDirty( obj_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddChild(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.GameObject){
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject prefab_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 2);

                  UnityEngine.GameObject addchild= NGUITools.AddChild( parent_, prefab_);
                  ToLuaCS.push(L,addchild);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TBOOLEAN ){
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean undo_ =  LuaDLL.lua_toboolean(L,2);

                  UnityEngine.GameObject addchild= NGUITools.AddChild( parent_, undo_);
                  ToLuaCS.push(L,addchild);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  UnityEngine.GameObject addchild= NGUITools.AddChild( parent_);
                  ToLuaCS.push(L,addchild);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetChildLayer(LuaState L)
          {
                  UnityEngine.Transform t_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 1);
                  System.Int32 layer_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  NGUITools.SetChildLayer( t_, layer_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetRoot(LuaState L)
          {
                  UnityEngine.GameObject go_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  UnityEngine.GameObject getroot= NGUITools.GetRoot( go_);
                  ToLuaCS.push(L,getroot);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindInParents(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Destroy(LuaState L)
          {
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  NGUITools.Destroy( obj_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DestroyImmediate(LuaState L)
          {
                  UnityEngine.Object obj_ = (UnityEngine.Object)ToLuaCS.getObject(L, 1);

                  NGUITools.DestroyImmediate( obj_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Broadcast(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String funcName_ =  LuaDLL.lua_tostring(L,1); 

                  System.Object param_ = (System.Object)ToLuaCS.getObject(L, 2);

                  NGUITools.Broadcast( funcName_, param_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  System.String funcName_ =  LuaDLL.lua_tostring(L,1); 


                  NGUITools.Broadcast( funcName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsChild(LuaState L)
          {
                  UnityEngine.Transform parent_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform child_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                  System.Boolean ischild= NGUITools.IsChild( parent_, child_);
                  LuaDLL.lua_pushboolean(L,ischild);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetActiveChildren(LuaState L)
          {
                  UnityEngine.GameObject go_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean state_ =  LuaDLL.lua_toboolean(L,2);

                  NGUITools.SetActiveChildren( go_, state_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetActive(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,1)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject go_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);

                  System.Boolean getactive= NGUITools.GetActive( go_);
                  LuaDLL.lua_pushboolean(L,getactive);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Behaviour){
                  UnityEngine.Behaviour mb_ = (UnityEngine.Behaviour)ToLuaCS.getObject(L, 1);

                  System.Boolean getactive= NGUITools.GetActive( mb_);
                  LuaDLL.lua_pushboolean(L,getactive);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetActiveSelf(LuaState L)
          {
                  UnityEngine.GameObject go_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Boolean state_ =  LuaDLL.lua_toboolean(L,2);

                  NGUITools.SetActiveSelf( go_, state_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetLayer(LuaState L)
          {
                  UnityEngine.GameObject go_ = (UnityEngine.GameObject)ToLuaCS.getObject(L, 1);
                  System.Int32 layer_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  NGUITools.SetLayer( go_, layer_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Round(LuaState L)
          {
                  UnityEngine.Vector3 v_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);

                  UnityEngine.Vector3 round= NGUITools.Round( v_);
                  ToLuaCS.push(L,round);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Save(LuaState L)
          {
                  System.String fileName_ =  LuaDLL.lua_tostring(L,1); 

                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L, 2);

                  System.Boolean save= NGUITools.Save( fileName_, bytes_);
                  LuaDLL.lua_pushboolean(L,save);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
                  System.String fileName_ =  LuaDLL.lua_tostring(L,1); 


                  System.Byte[] load= NGUITools.Load( fileName_);
                  ToLuaCS.push(L,load);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ApplyPMA(LuaState L)
          {
                  UnityEngine.Color c_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.Color applypma= NGUITools.ApplyPMA( c_);
                  ToLuaCS.push(L,applypma);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clipboard(LuaState L)
          {

                  System.String clipboard= NGUITools.clipboard;
                  LuaDLL.lua_pushstring(L, clipboard);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clipboard(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,1); 


                  NGUITools.clipboard= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddMissingComponent(LuaState L)
          {
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetSides(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  System.Single depth_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 3);

                  UnityEngine.Vector3[] getsides= NGUITools.GetSides( cam_, depth_, relativeTo_);
                  ToLuaCS.push(L,getsides);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Camera && ToLuaCS.getObject(L, 2) is UnityEngine.Transform){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                  UnityEngine.Vector3[] getsides= NGUITools.GetSides( cam_, relativeTo_);
                  ToLuaCS.push(L,getsides);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Camera && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  System.Single depth_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3[] getsides= NGUITools.GetSides( cam_, depth_);
                  ToLuaCS.push(L,getsides);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);

                  UnityEngine.Vector3[] getsides= NGUITools.GetSides( cam_);
                  ToLuaCS.push(L,getsides);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetWorldCorners(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  System.Single depth_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 3);

                  UnityEngine.Vector3[] getworldcorners= NGUITools.GetWorldCorners( cam_, depth_, relativeTo_);
                  ToLuaCS.push(L,getworldcorners);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Camera && ToLuaCS.getObject(L, 2) is UnityEngine.Transform){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                  UnityEngine.Vector3[] getworldcorners= NGUITools.GetWorldCorners( cam_, relativeTo_);
                  ToLuaCS.push(L,getworldcorners);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Camera && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);
                  System.Single depth_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3[] getworldcorners= NGUITools.GetWorldCorners( cam_, depth_);
                  ToLuaCS.push(L,getworldcorners);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);

                  UnityEngine.Vector3[] getworldcorners= NGUITools.GetWorldCorners( cam_);
                  ToLuaCS.push(L,getworldcorners);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFuncName(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L, 1);
                  System.String method_ =  LuaDLL.lua_tostring(L,2); 


                  System.String getfuncname= NGUITools.GetFuncName( obj_, method_);
                  LuaDLL.lua_pushstring(L, getfuncname);
                  return 1;

          }
  #endregion       
}

