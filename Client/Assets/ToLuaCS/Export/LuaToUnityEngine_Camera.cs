using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Camera {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Camera);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_fieldOfView", get_fieldOfView);
           ToLuaCS.AddMember(L, "set_fieldOfView", set_fieldOfView);
           ToLuaCS.AddMember(L, "get_nearClipPlane", get_nearClipPlane);
           ToLuaCS.AddMember(L, "set_nearClipPlane", set_nearClipPlane);
           ToLuaCS.AddMember(L, "get_farClipPlane", get_farClipPlane);
           ToLuaCS.AddMember(L, "set_farClipPlane", set_farClipPlane);
           ToLuaCS.AddMember(L, "get_renderingPath", get_renderingPath);
           ToLuaCS.AddMember(L, "set_renderingPath", set_renderingPath);
           ToLuaCS.AddMember(L, "get_actualRenderingPath", get_actualRenderingPath);
           ToLuaCS.AddMember(L, "get_hdr", get_hdr);
           ToLuaCS.AddMember(L, "set_hdr", set_hdr);
           ToLuaCS.AddMember(L, "get_orthographicSize", get_orthographicSize);
           ToLuaCS.AddMember(L, "set_orthographicSize", set_orthographicSize);
           ToLuaCS.AddMember(L, "get_orthographic", get_orthographic);
           ToLuaCS.AddMember(L, "set_orthographic", set_orthographic);
           ToLuaCS.AddMember(L, "get_transparencySortMode", get_transparencySortMode);
           ToLuaCS.AddMember(L, "set_transparencySortMode", set_transparencySortMode);
           ToLuaCS.AddMember(L, "get_depth", get_depth);
           ToLuaCS.AddMember(L, "set_depth", set_depth);
           ToLuaCS.AddMember(L, "get_aspect", get_aspect);
           ToLuaCS.AddMember(L, "set_aspect", set_aspect);
           ToLuaCS.AddMember(L, "get_cullingMask", get_cullingMask);
           ToLuaCS.AddMember(L, "set_cullingMask", set_cullingMask);
           ToLuaCS.AddMember(L, "get_eventMask", get_eventMask);
           ToLuaCS.AddMember(L, "set_eventMask", set_eventMask);
           ToLuaCS.AddMember(L, "get_backgroundColor", get_backgroundColor);
           ToLuaCS.AddMember(L, "set_backgroundColor", set_backgroundColor);
           ToLuaCS.AddMember(L, "get_rect", get_rect);
           ToLuaCS.AddMember(L, "set_rect", set_rect);
           ToLuaCS.AddMember(L, "get_pixelRect", get_pixelRect);
           ToLuaCS.AddMember(L, "set_pixelRect", set_pixelRect);
           ToLuaCS.AddMember(L, "get_targetTexture", get_targetTexture);
           ToLuaCS.AddMember(L, "set_targetTexture", set_targetTexture);
           ToLuaCS.AddMember(L, "SetTargetBuffers", SetTargetBuffers);
           ToLuaCS.AddMember(L, "get_pixelWidth", get_pixelWidth);
           ToLuaCS.AddMember(L, "get_pixelHeight", get_pixelHeight);
           ToLuaCS.AddMember(L, "get_cameraToWorldMatrix", get_cameraToWorldMatrix);
           ToLuaCS.AddMember(L, "get_worldToCameraMatrix", get_worldToCameraMatrix);
           ToLuaCS.AddMember(L, "set_worldToCameraMatrix", set_worldToCameraMatrix);
           ToLuaCS.AddMember(L, "ResetWorldToCameraMatrix", ResetWorldToCameraMatrix);
           ToLuaCS.AddMember(L, "get_projectionMatrix", get_projectionMatrix);
           ToLuaCS.AddMember(L, "set_projectionMatrix", set_projectionMatrix);
           ToLuaCS.AddMember(L, "ResetProjectionMatrix", ResetProjectionMatrix);
           ToLuaCS.AddMember(L, "ResetAspect", ResetAspect);
           ToLuaCS.AddMember(L, "get_velocity", get_velocity);
           ToLuaCS.AddMember(L, "get_clearFlags", get_clearFlags);
           ToLuaCS.AddMember(L, "set_clearFlags", set_clearFlags);
           ToLuaCS.AddMember(L, "get_stereoEnabled", get_stereoEnabled);
           ToLuaCS.AddMember(L, "get_stereoSeparation", get_stereoSeparation);
           ToLuaCS.AddMember(L, "set_stereoSeparation", set_stereoSeparation);
           ToLuaCS.AddMember(L, "get_stereoConvergence", get_stereoConvergence);
           ToLuaCS.AddMember(L, "set_stereoConvergence", set_stereoConvergence);
           ToLuaCS.AddMember(L, "get_targetDisplay", get_targetDisplay);
           ToLuaCS.AddMember(L, "set_targetDisplay", set_targetDisplay);
           ToLuaCS.AddMember(L, "WorldToScreenPoint", WorldToScreenPoint);
           ToLuaCS.AddMember(L, "WorldToViewportPoint", WorldToViewportPoint);
           ToLuaCS.AddMember(L, "ViewportToWorldPoint", ViewportToWorldPoint);
           ToLuaCS.AddMember(L, "ScreenToWorldPoint", ScreenToWorldPoint);
           ToLuaCS.AddMember(L, "ScreenToViewportPoint", ScreenToViewportPoint);
           ToLuaCS.AddMember(L, "ViewportToScreenPoint", ViewportToScreenPoint);
           ToLuaCS.AddMember(L, "ViewportPointToRay", ViewportPointToRay);
           ToLuaCS.AddMember(L, "ScreenPointToRay", ScreenPointToRay);
           ToLuaCS.AddMember(L, "Render", Render);
           ToLuaCS.AddMember(L, "RenderWithShader", RenderWithShader);
           ToLuaCS.AddMember(L, "SetReplacementShader", SetReplacementShader);
           ToLuaCS.AddMember(L, "ResetReplacementShader", ResetReplacementShader);
           ToLuaCS.AddMember(L, "get_useOcclusionCulling", get_useOcclusionCulling);
           ToLuaCS.AddMember(L, "set_useOcclusionCulling", set_useOcclusionCulling);
           ToLuaCS.AddMember(L, "RenderDontRestore", RenderDontRestore);
           ToLuaCS.AddMember(L, "RenderToCubemap", RenderToCubemap);
           ToLuaCS.AddMember(L, "get_layerCullDistances", get_layerCullDistances);
           ToLuaCS.AddMember(L, "set_layerCullDistances", set_layerCullDistances);
           ToLuaCS.AddMember(L, "get_layerCullSpherical", get_layerCullSpherical);
           ToLuaCS.AddMember(L, "set_layerCullSpherical", set_layerCullSpherical);
           ToLuaCS.AddMember(L, "CopyFrom", CopyFrom);
           ToLuaCS.AddMember(L, "get_depthTextureMode", get_depthTextureMode);
           ToLuaCS.AddMember(L, "set_depthTextureMode", set_depthTextureMode);
           ToLuaCS.AddMember(L, "get_clearStencilAfterLightingPass", get_clearStencilAfterLightingPass);
           ToLuaCS.AddMember(L, "set_clearStencilAfterLightingPass", set_clearStencilAfterLightingPass);
           ToLuaCS.AddMember(L, "AddCommandBuffer", AddCommandBuffer);
           ToLuaCS.AddMember(L, "RemoveCommandBuffer", RemoveCommandBuffer);
           ToLuaCS.AddMember(L, "RemoveCommandBuffers", RemoveCommandBuffers);
           ToLuaCS.AddMember(L, "RemoveAllCommandBuffers", RemoveAllCommandBuffers);
           ToLuaCS.AddMember(L, "GetCommandBuffers", GetCommandBuffers);
           ToLuaCS.AddMember(L, "get_commandBufferCount", get_commandBufferCount);
           ToLuaCS.AddMember(L, "CalculateObliqueMatrix", CalculateObliqueMatrix);
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
           ToLuaCS.AddMember(L, "get_main", get_main);

           ToLuaCS.AddMember(L, "get_current", get_current);

           ToLuaCS.AddMember(L, "get_allCameras", get_allCameras);

           ToLuaCS.AddMember(L, "get_allCamerasCount", get_allCamerasCount);

           ToLuaCS.AddMember(L, "GetAllCameras", GetAllCameras);

           ToLuaCS.AddMember(L, "SetupCurrent", SetupCurrent);

           ToLuaCS.AddMember(L, "__call", _camera);

           ToLuaCS.AddMember(L, "get_onPreCull", get_onPreCull);

           ToLuaCS.AddMember(L, "set_onPreCull", set_onPreCull);

           ToLuaCS.AddMember(L, "get_onPreRender", get_onPreRender);

           ToLuaCS.AddMember(L, "set_onPreRender", set_onPreRender);

           ToLuaCS.AddMember(L, "get_onPostRender", get_onPostRender);

           ToLuaCS.AddMember(L, "set_onPostRender", set_onPostRender);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fieldOfView(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single fieldOfView= target.fieldOfView;
                  LuaDLL.lua_pushnumber(L, fieldOfView);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fieldOfView(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.fieldOfView= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_nearClipPlane(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single nearClipPlane= target.nearClipPlane;
                  LuaDLL.lua_pushnumber(L, nearClipPlane);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_nearClipPlane(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.nearClipPlane= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_farClipPlane(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single farClipPlane= target.farClipPlane;
                  LuaDLL.lua_pushnumber(L, farClipPlane);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_farClipPlane(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.farClipPlane= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderingPath(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderingPath renderingPath= target.renderingPath;
                  ToLuaCS.push(L,renderingPath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_renderingPath(LuaState L)
          {
                  UnityEngine.RenderingPath value_ = (UnityEngine.RenderingPath)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.renderingPath= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_actualRenderingPath(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderingPath actualRenderingPath= target.actualRenderingPath;
                  ToLuaCS.push(L,actualRenderingPath);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hdr(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean hdr= target.hdr;
                  LuaDLL.lua_pushboolean(L,hdr);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hdr(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.hdr= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orthographicSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single orthographicSize= target.orthographicSize;
                  LuaDLL.lua_pushnumber(L, orthographicSize);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orthographicSize(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.orthographicSize= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orthographic(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean orthographic= target.orthographic;
                  LuaDLL.lua_pushboolean(L,orthographic);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orthographic(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.orthographic= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transparencySortMode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.TransparencySortMode transparencySortMode= target.transparencySortMode;
                  ToLuaCS.push(L,transparencySortMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_transparencySortMode(LuaState L)
          {
                  UnityEngine.TransparencySortMode value_ = (UnityEngine.TransparencySortMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.transparencySortMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_depth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single depth= target.depth;
                  LuaDLL.lua_pushnumber(L, depth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_depth(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.depth= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_aspect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single aspect= target.aspect;
                  LuaDLL.lua_pushnumber(L, aspect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_aspect(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.aspect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cullingMask(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 cullingMask= target.cullingMask;
                  LuaDLL.lua_pushnumber(L, cullingMask);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cullingMask(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.cullingMask= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eventMask(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 eventMask= target.eventMask;
                  LuaDLL.lua_pushnumber(L, eventMask);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eventMask(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.eventMask= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_backgroundColor(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Color backgroundColor= target.backgroundColor;
                  ToLuaCS.push(L,backgroundColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_backgroundColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.backgroundColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rect rect= target.rect;
                  ToLuaCS.push(L,rect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_rect(LuaState L)
          {
                  UnityEngine.Rect value_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.rect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelRect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rect pixelRect= target.pixelRect;
                  ToLuaCS.push(L,pixelRect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pixelRect(LuaState L)
          {
                  UnityEngine.Rect value_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.pixelRect= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_targetTexture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderTexture targetTexture= target.targetTexture;
                  ToLuaCS.push(L,targetTexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_targetTexture(LuaState L)
          {
                  UnityEngine.RenderTexture value_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.targetTexture= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetTargetBuffers(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderBuffer[] && ToLuaCS.getObject(L, 3) is UnityEngine.RenderBuffer){
                  UnityEngine.RenderBuffer[] colorBuffer_ = (UnityEngine.RenderBuffer[])ToLuaCS.getObject(L, 2);
                  UnityEngine.RenderBuffer depthBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetTargetBuffers( colorBuffer_, depthBuffer_);
                  return 0;

               }
               if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderBuffer && ToLuaCS.getObject(L, 3) is UnityEngine.RenderBuffer){
                  UnityEngine.RenderBuffer colorBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L, 2);
                  UnityEngine.RenderBuffer depthBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetTargetBuffers( colorBuffer_, depthBuffer_);
                  return 0;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 pixelWidth= target.pixelWidth;
                  LuaDLL.lua_pushnumber(L, pixelWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 pixelHeight= target.pixelHeight;
                  LuaDLL.lua_pushnumber(L, pixelHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cameraToWorldMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 cameraToWorldMatrix= target.cameraToWorldMatrix;
                  ToLuaCS.push(L,cameraToWorldMatrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldToCameraMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 worldToCameraMatrix= target.worldToCameraMatrix;
                  ToLuaCS.push(L,worldToCameraMatrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_worldToCameraMatrix(LuaState L)
          {
                  UnityEngine.Matrix4x4 value_ = (UnityEngine.Matrix4x4)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.worldToCameraMatrix= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetWorldToCameraMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetWorldToCameraMatrix();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_projectionMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 projectionMatrix= target.projectionMatrix;
                  ToLuaCS.push(L,projectionMatrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_projectionMatrix(LuaState L)
          {
                  UnityEngine.Matrix4x4 value_ = (UnityEngine.Matrix4x4)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.projectionMatrix= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetProjectionMatrix(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetProjectionMatrix();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetAspect(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetAspect();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_velocity(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 velocity= target.velocity;
                  ToLuaCS.push(L,velocity);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clearFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.CameraClearFlags clearFlags= target.clearFlags;
                  ToLuaCS.push(L,clearFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clearFlags(LuaState L)
          {
                  UnityEngine.CameraClearFlags value_ = (UnityEngine.CameraClearFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.clearFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoEnabled(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean stereoEnabled= target.stereoEnabled;
                  LuaDLL.lua_pushboolean(L,stereoEnabled);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoSeparation(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single stereoSeparation= target.stereoSeparation;
                  LuaDLL.lua_pushnumber(L, stereoSeparation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_stereoSeparation(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.stereoSeparation= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoConvergence(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single stereoConvergence= target.stereoConvergence;
                  LuaDLL.lua_pushnumber(L, stereoConvergence);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_stereoConvergence(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.stereoConvergence= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_targetDisplay(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 targetDisplay= target.targetDisplay;
                  LuaDLL.lua_pushnumber(L, targetDisplay);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_targetDisplay(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.targetDisplay= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WorldToScreenPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 worldtoscreenpoint= target.WorldToScreenPoint( position_);
                  ToLuaCS.push(L,worldtoscreenpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WorldToViewportPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 worldtoviewportpoint= target.WorldToViewportPoint( position_);
                  ToLuaCS.push(L,worldtoviewportpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportToWorldPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 viewporttoworldpoint= target.ViewportToWorldPoint( position_);
                  ToLuaCS.push(L,viewporttoworldpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToWorldPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 screentoworldpoint= target.ScreenToWorldPoint( position_);
                  ToLuaCS.push(L,screentoworldpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToViewportPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 screentoviewportpoint= target.ScreenToViewportPoint( position_);
                  ToLuaCS.push(L,screentoviewportpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportToScreenPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 viewporttoscreenpoint= target.ViewportToScreenPoint( position_);
                  ToLuaCS.push(L,viewporttoscreenpoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportPointToRay(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Ray viewportpointtoray= target.ViewportPointToRay( position_);
                  ToLuaCS.push(L,viewportpointtoray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenPointToRay(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Ray screenpointtoray= target.ScreenPointToRay( position_);
                  ToLuaCS.push(L,screenpointtoray);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Render(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.Render();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderWithShader(LuaState L)
          {
                  UnityEngine.Shader shader_ = (UnityEngine.Shader)ToLuaCS.getObject(L, 2);
                  System.String replacementTag_ =  LuaDLL.lua_tostring(L,3); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RenderWithShader( shader_, replacementTag_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetReplacementShader(LuaState L)
          {
                  UnityEngine.Shader shader_ = (UnityEngine.Shader)ToLuaCS.getObject(L, 2);
                  System.String replacementTag_ =  LuaDLL.lua_tostring(L,3); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetReplacementShader( shader_, replacementTag_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetReplacementShader(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetReplacementShader();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useOcclusionCulling(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean useOcclusionCulling= target.useOcclusionCulling;
                  LuaDLL.lua_pushboolean(L,useOcclusionCulling);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useOcclusionCulling(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.useOcclusionCulling= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderDontRestore(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RenderDontRestore();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderToCubemap(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderTexture && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.RenderTexture cubemap_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L, 2);
                  System.Int32 faceMask_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_, faceMask_);
                  LuaDLL.lua_pushboolean(L,rendertocubemap);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is UnityEngine.Cubemap && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Cubemap cubemap_ = (UnityEngine.Cubemap)ToLuaCS.getObject(L, 2);
                  System.Int32 faceMask_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_, faceMask_);
                  LuaDLL.lua_pushboolean(L,rendertocubemap);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is UnityEngine.Cubemap){
                  UnityEngine.Cubemap cubemap_ = (UnityEngine.Cubemap)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_);
                  LuaDLL.lua_pushboolean(L,rendertocubemap);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderTexture){
                  UnityEngine.RenderTexture cubemap_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_);
                  LuaDLL.lua_pushboolean(L,rendertocubemap);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layerCullDistances(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single[] layerCullDistances= target.layerCullDistances;
                  ToLuaCS.push(L,layerCullDistances);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layerCullDistances(LuaState L)
          {
                  System.Single[] value_ = (System.Single[])ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.layerCullDistances= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layerCullSpherical(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean layerCullSpherical= target.layerCullSpherical;
                  LuaDLL.lua_pushboolean(L,layerCullSpherical);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layerCullSpherical(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.layerCullSpherical= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CopyFrom(LuaState L)
          {
                  UnityEngine.Camera other_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.CopyFrom( other_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_depthTextureMode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.DepthTextureMode depthTextureMode= target.depthTextureMode;
                  ToLuaCS.push(L,depthTextureMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_depthTextureMode(LuaState L)
          {
                  UnityEngine.DepthTextureMode value_ = (UnityEngine.DepthTextureMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.depthTextureMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clearStencilAfterLightingPass(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean clearStencilAfterLightingPass= target.clearStencilAfterLightingPass;
                  LuaDLL.lua_pushboolean(L,clearStencilAfterLightingPass);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clearStencilAfterLightingPass(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.clearStencilAfterLightingPass= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddCommandBuffer(LuaState L)
          {
                  UnityEngine.Rendering.CameraEvent evt_ = (UnityEngine.Rendering.CameraEvent)ToLuaCS.getObject(L, 2);
                  UnityEngine.Rendering.CommandBuffer buffer_ = (UnityEngine.Rendering.CommandBuffer)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.AddCommandBuffer( evt_, buffer_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RemoveCommandBuffer(LuaState L)
          {
                  UnityEngine.Rendering.CameraEvent evt_ = (UnityEngine.Rendering.CameraEvent)ToLuaCS.getObject(L, 2);
                  UnityEngine.Rendering.CommandBuffer buffer_ = (UnityEngine.Rendering.CommandBuffer)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RemoveCommandBuffer( evt_, buffer_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RemoveCommandBuffers(LuaState L)
          {
                  UnityEngine.Rendering.CameraEvent evt_ = (UnityEngine.Rendering.CameraEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RemoveCommandBuffers( evt_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RemoveAllCommandBuffers(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RemoveAllCommandBuffers();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetCommandBuffers(LuaState L)
          {
                  UnityEngine.Rendering.CameraEvent evt_ = (UnityEngine.Rendering.CameraEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rendering.CommandBuffer[] getcommandbuffers= target.GetCommandBuffers( evt_);
                  ToLuaCS.push(L,getcommandbuffers);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_commandBufferCount(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 commandBufferCount= target.commandBufferCount;
                  LuaDLL.lua_pushnumber(L, commandBufferCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateObliqueMatrix(LuaState L)
          {
                  UnityEngine.Vector4 clipPlane_ = (UnityEngine.Vector4)ToLuaCS.getVector4(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 calculateobliquematrix= target.CalculateObliqueMatrix( clipPlane_);
                  ToLuaCS.push(L,calculateobliquematrix);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enabled(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean enabled= target.enabled;
                  LuaDLL.lua_pushboolean(L,enabled);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enabled(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.enabled= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent);
                  return 1;

               }
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.GetComponents( type_, results_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( ToLuaCS.getObject(L, 2) is System.Type){
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String tag= target.tag;
                  LuaDLL.lua_pushstring(L, tag);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.tag= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, value_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, value_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
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
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                  return 0;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,3)){
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, options_);
                  return 0;

               }
               if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L, 3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                  return 0;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_);
                  return 0;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_main(LuaState L)
          {

                  UnityEngine.Camera main= UnityEngine.Camera.main;
                  ToLuaCS.push(L,main);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_current(LuaState L)
          {

                  UnityEngine.Camera current= UnityEngine.Camera.current;
                  ToLuaCS.push(L,current);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_allCameras(LuaState L)
          {

                  UnityEngine.Camera[] allCameras= UnityEngine.Camera.allCameras;
                  ToLuaCS.push(L,allCameras);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_allCamerasCount(LuaState L)
          {

                  System.Int32 allCamerasCount= UnityEngine.Camera.allCamerasCount;
                  LuaDLL.lua_pushnumber(L, allCamerasCount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAllCameras(LuaState L)
          {
                  UnityEngine.Camera[] cameras_ = (UnityEngine.Camera[])ToLuaCS.getObject(L, 1);

                  System.Int32 getallcameras= UnityEngine.Camera.GetAllCameras( cameras_);
                  LuaDLL.lua_pushnumber(L, getallcameras);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetupCurrent(LuaState L)
          {
                  UnityEngine.Camera cur_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 1);

                  UnityEngine.Camera.SetupCurrent( cur_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _camera(LuaState L)
          {

                  UnityEngine.Camera _camera= new UnityEngine.Camera();
                  ToLuaCS.push(L,_camera);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPreCull(LuaState L)
          {
                  var val=   UnityEngine.Camera.onPreCull;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPreCull(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera.onPreCull= (UnityEngine.Camera.CameraCallback)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPreRender(LuaState L)
          {
                  var val=   UnityEngine.Camera.onPreRender;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPreRender(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera.onPreRender= (UnityEngine.Camera.CameraCallback)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPostRender(LuaState L)
          {
                  var val=   UnityEngine.Camera.onPostRender;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPostRender(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera.onPostRender= (UnityEngine.Camera.CameraCallback)val;
                  return 0;

          }
  #endregion       
}

