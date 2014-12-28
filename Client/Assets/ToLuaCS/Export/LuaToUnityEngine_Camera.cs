using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Camera {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Camera).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Camera).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(UnityEngine.Camera).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
          LuaDLL.lua_pushstring(L,"get_fieldOfView");
          luafn_get_fieldOfView= new LuaCSFunction(get_fieldOfView);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fieldOfView);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fieldOfView");
          luafn_set_fieldOfView= new LuaCSFunction(set_fieldOfView);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fieldOfView);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_nearClipPlane");
          luafn_get_nearClipPlane= new LuaCSFunction(get_nearClipPlane);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_nearClipPlane);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_nearClipPlane");
          luafn_set_nearClipPlane= new LuaCSFunction(set_nearClipPlane);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_nearClipPlane);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_farClipPlane");
          luafn_get_farClipPlane= new LuaCSFunction(get_farClipPlane);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_farClipPlane);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_farClipPlane");
          luafn_set_farClipPlane= new LuaCSFunction(set_farClipPlane);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_farClipPlane);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_renderingPath");
          luafn_get_renderingPath= new LuaCSFunction(get_renderingPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_renderingPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_renderingPath");
          luafn_set_renderingPath= new LuaCSFunction(set_renderingPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_renderingPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_actualRenderingPath");
          luafn_get_actualRenderingPath= new LuaCSFunction(get_actualRenderingPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_actualRenderingPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hdr");
          luafn_get_hdr= new LuaCSFunction(get_hdr);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hdr);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hdr");
          luafn_set_hdr= new LuaCSFunction(set_hdr);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hdr);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_orthographicSize");
          luafn_get_orthographicSize= new LuaCSFunction(get_orthographicSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_orthographicSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_orthographicSize");
          luafn_set_orthographicSize= new LuaCSFunction(set_orthographicSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_orthographicSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_orthographic");
          luafn_get_orthographic= new LuaCSFunction(get_orthographic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_orthographic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_orthographic");
          luafn_set_orthographic= new LuaCSFunction(set_orthographic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_orthographic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_transparencySortMode");
          luafn_get_transparencySortMode= new LuaCSFunction(get_transparencySortMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_transparencySortMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_transparencySortMode");
          luafn_set_transparencySortMode= new LuaCSFunction(set_transparencySortMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_transparencySortMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isOrthoGraphic");
          luafn_get_isOrthoGraphic= new LuaCSFunction(get_isOrthoGraphic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isOrthoGraphic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isOrthoGraphic");
          luafn_set_isOrthoGraphic= new LuaCSFunction(set_isOrthoGraphic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isOrthoGraphic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_depth");
          luafn_get_depth= new LuaCSFunction(get_depth);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_depth);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_depth");
          luafn_set_depth= new LuaCSFunction(set_depth);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_depth);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_aspect");
          luafn_get_aspect= new LuaCSFunction(get_aspect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_aspect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_aspect");
          luafn_set_aspect= new LuaCSFunction(set_aspect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_aspect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_cullingMask");
          luafn_get_cullingMask= new LuaCSFunction(get_cullingMask);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_cullingMask);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_cullingMask");
          luafn_set_cullingMask= new LuaCSFunction(set_cullingMask);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_cullingMask);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_eventMask");
          luafn_get_eventMask= new LuaCSFunction(get_eventMask);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_eventMask);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_eventMask");
          luafn_set_eventMask= new LuaCSFunction(set_eventMask);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_eventMask);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_backgroundColor");
          luafn_get_backgroundColor= new LuaCSFunction(get_backgroundColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_backgroundColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_backgroundColor");
          luafn_set_backgroundColor= new LuaCSFunction(set_backgroundColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_backgroundColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rect");
          luafn_get_rect= new LuaCSFunction(get_rect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_rect");
          luafn_set_rect= new LuaCSFunction(set_rect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_rect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pixelRect");
          luafn_get_pixelRect= new LuaCSFunction(get_pixelRect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pixelRect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_pixelRect");
          luafn_set_pixelRect= new LuaCSFunction(set_pixelRect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_pixelRect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_targetTexture");
          luafn_get_targetTexture= new LuaCSFunction(get_targetTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_targetTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_targetTexture");
          luafn_set_targetTexture= new LuaCSFunction(set_targetTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_targetTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetTargetBuffers");
          luafn_SetTargetBuffers= new LuaCSFunction(SetTargetBuffers);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetTargetBuffers);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pixelWidth");
          luafn_get_pixelWidth= new LuaCSFunction(get_pixelWidth);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pixelWidth);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pixelHeight");
          luafn_get_pixelHeight= new LuaCSFunction(get_pixelHeight);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pixelHeight);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_cameraToWorldMatrix");
          luafn_get_cameraToWorldMatrix= new LuaCSFunction(get_cameraToWorldMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_cameraToWorldMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_worldToCameraMatrix");
          luafn_get_worldToCameraMatrix= new LuaCSFunction(get_worldToCameraMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_worldToCameraMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_worldToCameraMatrix");
          luafn_set_worldToCameraMatrix= new LuaCSFunction(set_worldToCameraMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_worldToCameraMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ResetWorldToCameraMatrix");
          luafn_ResetWorldToCameraMatrix= new LuaCSFunction(ResetWorldToCameraMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ResetWorldToCameraMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_projectionMatrix");
          luafn_get_projectionMatrix= new LuaCSFunction(get_projectionMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_projectionMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_projectionMatrix");
          luafn_set_projectionMatrix= new LuaCSFunction(set_projectionMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_projectionMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ResetProjectionMatrix");
          luafn_ResetProjectionMatrix= new LuaCSFunction(ResetProjectionMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ResetProjectionMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ResetAspect");
          luafn_ResetAspect= new LuaCSFunction(ResetAspect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ResetAspect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_velocity");
          luafn_get_velocity= new LuaCSFunction(get_velocity);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_velocity);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_clearFlags");
          luafn_get_clearFlags= new LuaCSFunction(get_clearFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_clearFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_clearFlags");
          luafn_set_clearFlags= new LuaCSFunction(set_clearFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_clearFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_stereoEnabled");
          luafn_get_stereoEnabled= new LuaCSFunction(get_stereoEnabled);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_stereoEnabled);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_stereoSeparation");
          luafn_get_stereoSeparation= new LuaCSFunction(get_stereoSeparation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_stereoSeparation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_stereoSeparation");
          luafn_set_stereoSeparation= new LuaCSFunction(set_stereoSeparation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_stereoSeparation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_stereoConvergence");
          luafn_get_stereoConvergence= new LuaCSFunction(get_stereoConvergence);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_stereoConvergence);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_stereoConvergence");
          luafn_set_stereoConvergence= new LuaCSFunction(set_stereoConvergence);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_stereoConvergence);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WorldToScreenPoint");
          luafn_WorldToScreenPoint= new LuaCSFunction(WorldToScreenPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WorldToScreenPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"WorldToViewportPoint");
          luafn_WorldToViewportPoint= new LuaCSFunction(WorldToViewportPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_WorldToViewportPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ViewportToWorldPoint");
          luafn_ViewportToWorldPoint= new LuaCSFunction(ViewportToWorldPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ViewportToWorldPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScreenToWorldPoint");
          luafn_ScreenToWorldPoint= new LuaCSFunction(ScreenToWorldPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScreenToWorldPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScreenToViewportPoint");
          luafn_ScreenToViewportPoint= new LuaCSFunction(ScreenToViewportPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScreenToViewportPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ViewportToScreenPoint");
          luafn_ViewportToScreenPoint= new LuaCSFunction(ViewportToScreenPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ViewportToScreenPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ViewportPointToRay");
          luafn_ViewportPointToRay= new LuaCSFunction(ViewportPointToRay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ViewportPointToRay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScreenPointToRay");
          luafn_ScreenPointToRay= new LuaCSFunction(ScreenPointToRay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScreenPointToRay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Render");
          luafn_Render= new LuaCSFunction(Render);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Render);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RenderWithShader");
          luafn_RenderWithShader= new LuaCSFunction(RenderWithShader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RenderWithShader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetReplacementShader");
          luafn_SetReplacementShader= new LuaCSFunction(SetReplacementShader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetReplacementShader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ResetReplacementShader");
          luafn_ResetReplacementShader= new LuaCSFunction(ResetReplacementShader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ResetReplacementShader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_useOcclusionCulling");
          luafn_get_useOcclusionCulling= new LuaCSFunction(get_useOcclusionCulling);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_useOcclusionCulling);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_useOcclusionCulling");
          luafn_set_useOcclusionCulling= new LuaCSFunction(set_useOcclusionCulling);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_useOcclusionCulling);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RenderDontRestore");
          luafn_RenderDontRestore= new LuaCSFunction(RenderDontRestore);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RenderDontRestore);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RenderToCubemap");
          luafn_RenderToCubemap= new LuaCSFunction(RenderToCubemap);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RenderToCubemap);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_layerCullDistances");
          luafn_get_layerCullDistances= new LuaCSFunction(get_layerCullDistances);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_layerCullDistances);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_layerCullDistances");
          luafn_set_layerCullDistances= new LuaCSFunction(set_layerCullDistances);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_layerCullDistances);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_layerCullSpherical");
          luafn_get_layerCullSpherical= new LuaCSFunction(get_layerCullSpherical);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_layerCullSpherical);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_layerCullSpherical");
          luafn_set_layerCullSpherical= new LuaCSFunction(set_layerCullSpherical);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_layerCullSpherical);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CopyFrom");
          luafn_CopyFrom= new LuaCSFunction(CopyFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CopyFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_depthTextureMode");
          luafn_get_depthTextureMode= new LuaCSFunction(get_depthTextureMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_depthTextureMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_depthTextureMode");
          luafn_set_depthTextureMode= new LuaCSFunction(set_depthTextureMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_depthTextureMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_clearStencilAfterLightingPass");
          luafn_get_clearStencilAfterLightingPass= new LuaCSFunction(get_clearStencilAfterLightingPass);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_clearStencilAfterLightingPass);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_clearStencilAfterLightingPass");
          luafn_set_clearStencilAfterLightingPass= new LuaCSFunction(set_clearStencilAfterLightingPass);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_clearStencilAfterLightingPass);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CalculateObliqueMatrix");
          luafn_CalculateObliqueMatrix= new LuaCSFunction(CalculateObliqueMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CalculateObliqueMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_enabled");
          luafn_get_enabled= new LuaCSFunction(get_enabled);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_enabled);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_enabled");
          luafn_set_enabled= new LuaCSFunction(set_enabled);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_enabled);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_transform");
          luafn_get_transform= new LuaCSFunction(get_transform);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_transform);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rigidbody");
          luafn_get_rigidbody= new LuaCSFunction(get_rigidbody);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rigidbody);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rigidbody2D");
          luafn_get_rigidbody2D= new LuaCSFunction(get_rigidbody2D);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rigidbody2D);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_camera");
          luafn_get_camera= new LuaCSFunction(get_camera);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_camera);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_light");
          luafn_get_light= new LuaCSFunction(get_light);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_light);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_animation");
          luafn_get_animation= new LuaCSFunction(get_animation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_animation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_constantForce");
          luafn_get_constantForce= new LuaCSFunction(get_constantForce);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_constantForce);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_renderer");
          luafn_get_renderer= new LuaCSFunction(get_renderer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_renderer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_audio");
          luafn_get_audio= new LuaCSFunction(get_audio);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_audio);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_guiText");
          luafn_get_guiText= new LuaCSFunction(get_guiText);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_guiText);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_networkView");
          luafn_get_networkView= new LuaCSFunction(get_networkView);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_networkView);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_guiTexture");
          luafn_get_guiTexture= new LuaCSFunction(get_guiTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_guiTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_collider");
          luafn_get_collider= new LuaCSFunction(get_collider);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_collider);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_collider2D");
          luafn_get_collider2D= new LuaCSFunction(get_collider2D);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_collider2D);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hingeJoint");
          luafn_get_hingeJoint= new LuaCSFunction(get_hingeJoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hingeJoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_particleEmitter");
          luafn_get_particleEmitter= new LuaCSFunction(get_particleEmitter);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_particleEmitter);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_particleSystem");
          luafn_get_particleSystem= new LuaCSFunction(get_particleSystem);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_particleSystem);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_gameObject");
          luafn_get_gameObject= new LuaCSFunction(get_gameObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_gameObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponent");
          luafn_GetComponent= new LuaCSFunction(GetComponent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInChildren");
          luafn_GetComponentInChildren= new LuaCSFunction(GetComponentInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInChildren");
          luafn_GetComponentsInChildren= new LuaCSFunction(GetComponentsInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInParent");
          luafn_GetComponentInParent= new LuaCSFunction(GetComponentInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInParent");
          luafn_GetComponentsInParent= new LuaCSFunction(GetComponentsInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponents");
          luafn_GetComponents= new LuaCSFunction(GetComponents);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponents);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tag");
          luafn_get_tag= new LuaCSFunction(get_tag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tag");
          luafn_set_tag= new LuaCSFunction(set_tag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CompareTag");
          luafn_CompareTag= new LuaCSFunction(CompareTag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CompareTag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SendMessageUpwards");
          luafn_SendMessageUpwards= new LuaCSFunction(SendMessageUpwards);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SendMessageUpwards);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SendMessage");
          luafn_SendMessage= new LuaCSFunction(SendMessage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SendMessage);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"BroadcastMessage");
          luafn_BroadcastMessage= new LuaCSFunction(BroadcastMessage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_BroadcastMessage);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetInstanceID");
          luafn_GetInstanceID= new LuaCSFunction(GetInstanceID);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetInstanceID);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_name");
          luafn_get_name= new LuaCSFunction(get_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_name");
          luafn_set_name= new LuaCSFunction(set_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hideFlags");
          luafn_get_hideFlags= new LuaCSFunction(get_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hideFlags");
          luafn_set_hideFlags= new LuaCSFunction(set_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(UnityEngine.Camera).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Camera).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_main");
          luafn_get_main= new LuaCSFunction(get_main);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_main);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_current");
          luafn_get_current= new LuaCSFunction(get_current);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_current);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_allCameras");
          luafn_get_allCameras= new LuaCSFunction(get_allCameras);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_allCameras);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_allCamerasCount");
          luafn_get_allCamerasCount= new LuaCSFunction(get_allCamerasCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_allCamerasCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetAllCameras");
          luafn_GetAllCameras= new LuaCSFunction(GetAllCameras);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetAllCameras);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetupCurrent");
          luafn_SetupCurrent= new LuaCSFunction(SetupCurrent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetupCurrent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"__call");
          luafn__camera= new LuaCSFunction(_camera);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__camera);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_fieldOfView;
          private static LuaCSFunction luafn_set_fieldOfView;
          private static LuaCSFunction luafn_get_nearClipPlane;
          private static LuaCSFunction luafn_set_nearClipPlane;
          private static LuaCSFunction luafn_get_farClipPlane;
          private static LuaCSFunction luafn_set_farClipPlane;
          private static LuaCSFunction luafn_get_renderingPath;
          private static LuaCSFunction luafn_set_renderingPath;
          private static LuaCSFunction luafn_get_actualRenderingPath;
          private static LuaCSFunction luafn_get_hdr;
          private static LuaCSFunction luafn_set_hdr;
          private static LuaCSFunction luafn_get_orthographicSize;
          private static LuaCSFunction luafn_set_orthographicSize;
          private static LuaCSFunction luafn_get_orthographic;
          private static LuaCSFunction luafn_set_orthographic;
          private static LuaCSFunction luafn_get_transparencySortMode;
          private static LuaCSFunction luafn_set_transparencySortMode;
          private static LuaCSFunction luafn_get_isOrthoGraphic;
          private static LuaCSFunction luafn_set_isOrthoGraphic;
          private static LuaCSFunction luafn_get_depth;
          private static LuaCSFunction luafn_set_depth;
          private static LuaCSFunction luafn_get_aspect;
          private static LuaCSFunction luafn_set_aspect;
          private static LuaCSFunction luafn_get_cullingMask;
          private static LuaCSFunction luafn_set_cullingMask;
          private static LuaCSFunction luafn_get_eventMask;
          private static LuaCSFunction luafn_set_eventMask;
          private static LuaCSFunction luafn_get_backgroundColor;
          private static LuaCSFunction luafn_set_backgroundColor;
          private static LuaCSFunction luafn_get_rect;
          private static LuaCSFunction luafn_set_rect;
          private static LuaCSFunction luafn_get_pixelRect;
          private static LuaCSFunction luafn_set_pixelRect;
          private static LuaCSFunction luafn_get_targetTexture;
          private static LuaCSFunction luafn_set_targetTexture;
          private static LuaCSFunction luafn_SetTargetBuffers;
          private static LuaCSFunction luafn_get_pixelWidth;
          private static LuaCSFunction luafn_get_pixelHeight;
          private static LuaCSFunction luafn_get_cameraToWorldMatrix;
          private static LuaCSFunction luafn_get_worldToCameraMatrix;
          private static LuaCSFunction luafn_set_worldToCameraMatrix;
          private static LuaCSFunction luafn_ResetWorldToCameraMatrix;
          private static LuaCSFunction luafn_get_projectionMatrix;
          private static LuaCSFunction luafn_set_projectionMatrix;
          private static LuaCSFunction luafn_ResetProjectionMatrix;
          private static LuaCSFunction luafn_ResetAspect;
          private static LuaCSFunction luafn_get_velocity;
          private static LuaCSFunction luafn_get_clearFlags;
          private static LuaCSFunction luafn_set_clearFlags;
          private static LuaCSFunction luafn_get_stereoEnabled;
          private static LuaCSFunction luafn_get_stereoSeparation;
          private static LuaCSFunction luafn_set_stereoSeparation;
          private static LuaCSFunction luafn_get_stereoConvergence;
          private static LuaCSFunction luafn_set_stereoConvergence;
          private static LuaCSFunction luafn_WorldToScreenPoint;
          private static LuaCSFunction luafn_WorldToViewportPoint;
          private static LuaCSFunction luafn_ViewportToWorldPoint;
          private static LuaCSFunction luafn_ScreenToWorldPoint;
          private static LuaCSFunction luafn_ScreenToViewportPoint;
          private static LuaCSFunction luafn_ViewportToScreenPoint;
          private static LuaCSFunction luafn_ViewportPointToRay;
          private static LuaCSFunction luafn_ScreenPointToRay;
          private static LuaCSFunction luafn_Render;
          private static LuaCSFunction luafn_RenderWithShader;
          private static LuaCSFunction luafn_SetReplacementShader;
          private static LuaCSFunction luafn_ResetReplacementShader;
          private static LuaCSFunction luafn_get_useOcclusionCulling;
          private static LuaCSFunction luafn_set_useOcclusionCulling;
          private static LuaCSFunction luafn_RenderDontRestore;
          private static LuaCSFunction luafn_RenderToCubemap;
          private static LuaCSFunction luafn_get_layerCullDistances;
          private static LuaCSFunction luafn_set_layerCullDistances;
          private static LuaCSFunction luafn_get_layerCullSpherical;
          private static LuaCSFunction luafn_set_layerCullSpherical;
          private static LuaCSFunction luafn_CopyFrom;
          private static LuaCSFunction luafn_get_depthTextureMode;
          private static LuaCSFunction luafn_set_depthTextureMode;
          private static LuaCSFunction luafn_get_clearStencilAfterLightingPass;
          private static LuaCSFunction luafn_set_clearStencilAfterLightingPass;
          private static LuaCSFunction luafn_CalculateObliqueMatrix;
          private static LuaCSFunction luafn_get_enabled;
          private static LuaCSFunction luafn_set_enabled;
          private static LuaCSFunction luafn_get_transform;
          private static LuaCSFunction luafn_get_rigidbody;
          private static LuaCSFunction luafn_get_rigidbody2D;
          private static LuaCSFunction luafn_get_camera;
          private static LuaCSFunction luafn_get_light;
          private static LuaCSFunction luafn_get_animation;
          private static LuaCSFunction luafn_get_constantForce;
          private static LuaCSFunction luafn_get_renderer;
          private static LuaCSFunction luafn_get_audio;
          private static LuaCSFunction luafn_get_guiText;
          private static LuaCSFunction luafn_get_networkView;
          private static LuaCSFunction luafn_get_guiTexture;
          private static LuaCSFunction luafn_get_collider;
          private static LuaCSFunction luafn_get_collider2D;
          private static LuaCSFunction luafn_get_hingeJoint;
          private static LuaCSFunction luafn_get_particleEmitter;
          private static LuaCSFunction luafn_get_particleSystem;
          private static LuaCSFunction luafn_get_gameObject;
          private static LuaCSFunction luafn_GetComponent;
          private static LuaCSFunction luafn_GetComponentInChildren;
          private static LuaCSFunction luafn_GetComponentsInChildren;
          private static LuaCSFunction luafn_GetComponentInParent;
          private static LuaCSFunction luafn_GetComponentsInParent;
          private static LuaCSFunction luafn_GetComponents;
          private static LuaCSFunction luafn_get_tag;
          private static LuaCSFunction luafn_set_tag;
          private static LuaCSFunction luafn_CompareTag;
          private static LuaCSFunction luafn_SendMessageUpwards;
          private static LuaCSFunction luafn_SendMessage;
          private static LuaCSFunction luafn_BroadcastMessage;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetInstanceID;
          private static LuaCSFunction luafn_get_name;
          private static LuaCSFunction luafn_set_name;
          private static LuaCSFunction luafn_get_hideFlags;
          private static LuaCSFunction luafn_set_hideFlags;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_GetType;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_main;
          private static LuaCSFunction luafn_get_current;
          private static LuaCSFunction luafn_get_allCameras;
          private static LuaCSFunction luafn_get_allCamerasCount;
          private static LuaCSFunction luafn_GetAllCameras;
          private static LuaCSFunction luafn_SetupCurrent;
          private static LuaCSFunction luafn__camera;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fieldOfView(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single fieldOfView= target.fieldOfView;
                  ToLuaCS.push(L,fieldOfView); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fieldOfView(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.fieldOfView= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_nearClipPlane(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single nearClipPlane= target.nearClipPlane;
                  ToLuaCS.push(L,nearClipPlane); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_nearClipPlane(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.nearClipPlane= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_farClipPlane(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single farClipPlane= target.farClipPlane;
                  ToLuaCS.push(L,farClipPlane); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_farClipPlane(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.farClipPlane= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderingPath(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderingPath renderingPath= target.renderingPath;
                  ToLuaCS.push(L,renderingPath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_renderingPath(LuaState L)
          {
                  UnityEngine.RenderingPath value_ = (UnityEngine.RenderingPath)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.renderingPath= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_actualRenderingPath(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderingPath actualRenderingPath= target.actualRenderingPath;
                  ToLuaCS.push(L,actualRenderingPath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hdr(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean hdr= target.hdr;
                  ToLuaCS.push(L,hdr); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hdr(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.hdr= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orthographicSize(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single orthographicSize= target.orthographicSize;
                  ToLuaCS.push(L,orthographicSize); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orthographicSize(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.orthographicSize= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orthographic(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean orthographic= target.orthographic;
                  ToLuaCS.push(L,orthographic); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orthographic(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.orthographic= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transparencySortMode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.TransparencySortMode transparencySortMode= target.transparencySortMode;
                  ToLuaCS.push(L,transparencySortMode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_transparencySortMode(LuaState L)
          {
                  UnityEngine.TransparencySortMode value_ = (UnityEngine.TransparencySortMode)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.transparencySortMode= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isOrthoGraphic(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean isOrthoGraphic= target.orthographic;
                  ToLuaCS.push(L,isOrthoGraphic); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isOrthoGraphic(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.orthographic= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_depth(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single depth= target.depth;
                  ToLuaCS.push(L,depth); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_depth(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.depth= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_aspect(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single aspect= target.aspect;
                  ToLuaCS.push(L,aspect); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_aspect(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.aspect= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cullingMask(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 cullingMask= target.cullingMask;
                  ToLuaCS.push(L,cullingMask); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cullingMask(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.cullingMask= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eventMask(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 eventMask= target.eventMask;
                  ToLuaCS.push(L,eventMask); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eventMask(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.eventMask= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_backgroundColor(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Color backgroundColor= target.backgroundColor;
                  ToLuaCS.push(L,backgroundColor); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_backgroundColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.backgroundColor= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rect(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rect rect= target.rect;
                  ToLuaCS.push(L,rect); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_rect(LuaState L)
          {
                  UnityEngine.Rect value_ = (UnityEngine.Rect)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.rect= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelRect(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rect pixelRect= target.pixelRect;
                  ToLuaCS.push(L,pixelRect); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pixelRect(LuaState L)
          {
                  UnityEngine.Rect value_ = (UnityEngine.Rect)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.pixelRect= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_targetTexture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.RenderTexture targetTexture= target.targetTexture;
                  ToLuaCS.push(L,targetTexture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_targetTexture(LuaState L)
          {
                  UnityEngine.RenderTexture value_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.targetTexture= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetTargetBuffers(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderBuffer[] && ToLuaCS.getObject(L, 3) is UnityEngine.RenderBuffer)
              {
                  UnityEngine.RenderBuffer[] colorBuffer_ = (UnityEngine.RenderBuffer[])ToLuaCS.getObject(L,2);
                  UnityEngine.RenderBuffer depthBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetTargetBuffers( colorBuffer_, depthBuffer_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderBuffer && ToLuaCS.getObject(L, 3) is UnityEngine.RenderBuffer)
              {
                  UnityEngine.RenderBuffer colorBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L,2);
                  UnityEngine.RenderBuffer depthBuffer_ = (UnityEngine.RenderBuffer)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetTargetBuffers( colorBuffer_, depthBuffer_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelWidth(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single pixelWidth= target.pixelWidth;
                  ToLuaCS.push(L,pixelWidth); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelHeight(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single pixelHeight= target.pixelHeight;
                  ToLuaCS.push(L,pixelHeight); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cameraToWorldMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 cameraToWorldMatrix= target.cameraToWorldMatrix;
                  ToLuaCS.push(L,cameraToWorldMatrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldToCameraMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 worldToCameraMatrix= target.worldToCameraMatrix;
                  ToLuaCS.push(L,worldToCameraMatrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_worldToCameraMatrix(LuaState L)
          {
                  UnityEngine.Matrix4x4 value_ = (UnityEngine.Matrix4x4)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.worldToCameraMatrix= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetWorldToCameraMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetWorldToCameraMatrix();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_projectionMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 projectionMatrix= target.projectionMatrix;
                  ToLuaCS.push(L,projectionMatrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_projectionMatrix(LuaState L)
          {
                  UnityEngine.Matrix4x4 value_ = (UnityEngine.Matrix4x4)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.projectionMatrix= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetProjectionMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetProjectionMatrix();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetAspect(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetAspect();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_velocity(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 velocity= target.velocity;
                  ToLuaCS.push(L,velocity); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clearFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.CameraClearFlags clearFlags= target.clearFlags;
                  ToLuaCS.push(L,clearFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clearFlags(LuaState L)
          {
                  UnityEngine.CameraClearFlags value_ = (UnityEngine.CameraClearFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.clearFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoEnabled(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean stereoEnabled= target.stereoEnabled;
                  ToLuaCS.push(L,stereoEnabled); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoSeparation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single stereoSeparation= target.stereoSeparation;
                  ToLuaCS.push(L,stereoSeparation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_stereoSeparation(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.stereoSeparation= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_stereoConvergence(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single stereoConvergence= target.stereoConvergence;
                  ToLuaCS.push(L,stereoConvergence); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_stereoConvergence(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.stereoConvergence= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WorldToScreenPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 worldtoscreenpoint= target.WorldToScreenPoint( position_);
                  ToLuaCS.push(L,worldtoscreenpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WorldToViewportPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 worldtoviewportpoint= target.WorldToViewportPoint( position_);
                  ToLuaCS.push(L,worldtoviewportpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportToWorldPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 viewporttoworldpoint= target.ViewportToWorldPoint( position_);
                  ToLuaCS.push(L,viewporttoworldpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToWorldPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 screentoworldpoint= target.ScreenToWorldPoint( position_);
                  ToLuaCS.push(L,screentoworldpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToViewportPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 screentoviewportpoint= target.ScreenToViewportPoint( position_);
                  ToLuaCS.push(L,screentoviewportpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportToScreenPoint(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Vector3 viewporttoscreenpoint= target.ViewportToScreenPoint( position_);
                  ToLuaCS.push(L,viewporttoscreenpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ViewportPointToRay(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Ray viewportpointtoray= target.ViewportPointToRay( position_);
                  ToLuaCS.push(L,viewportpointtoray); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenPointToRay(LuaState L)
          {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Ray screenpointtoray= target.ScreenPointToRay( position_);
                  ToLuaCS.push(L,screenpointtoray); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Render(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.Render();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderWithShader(LuaState L)
          {
                  UnityEngine.Shader shader_ = (UnityEngine.Shader)ToLuaCS.getObject(L,2);
                  System.String replacementTag_ =  LuaDLL.lua_tostring(L,3); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RenderWithShader( shader_, replacementTag_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetReplacementShader(LuaState L)
          {
                  UnityEngine.Shader shader_ = (UnityEngine.Shader)ToLuaCS.getObject(L,2);
                  System.String replacementTag_ =  LuaDLL.lua_tostring(L,3); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SetReplacementShader( shader_, replacementTag_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ResetReplacementShader(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.ResetReplacementShader();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useOcclusionCulling(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean useOcclusionCulling= target.useOcclusionCulling;
                  ToLuaCS.push(L,useOcclusionCulling); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useOcclusionCulling(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.useOcclusionCulling= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderDontRestore(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.RenderDontRestore();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RenderToCubemap(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderTexture && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.RenderTexture cubemap_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L,2);
                  System.Int32 faceMask_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_, faceMask_);
                  ToLuaCS.push(L,rendertocubemap); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Cubemap && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Cubemap cubemap_ = (UnityEngine.Cubemap)ToLuaCS.getObject(L,2);
                  System.Int32 faceMask_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_, faceMask_);
                  ToLuaCS.push(L,rendertocubemap); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Cubemap)
              {
                  UnityEngine.Cubemap cubemap_ = (UnityEngine.Cubemap)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_);
                  ToLuaCS.push(L,rendertocubemap); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.RenderTexture)
              {
                  UnityEngine.RenderTexture cubemap_ = (UnityEngine.RenderTexture)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean rendertocubemap= target.RenderToCubemap( cubemap_);
                  ToLuaCS.push(L,rendertocubemap); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layerCullDistances(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Single[] layerCullDistances= target.layerCullDistances;
                  ToLuaCS.push(L,layerCullDistances); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layerCullDistances(LuaState L)
          {
                  System.Single[] value_ = (System.Single[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.layerCullDistances= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layerCullSpherical(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean layerCullSpherical= target.layerCullSpherical;
                  ToLuaCS.push(L,layerCullSpherical); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layerCullSpherical(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.layerCullSpherical= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CopyFrom(LuaState L)
          {
                  UnityEngine.Camera other_ = (UnityEngine.Camera)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.CopyFrom( other_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_depthTextureMode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.DepthTextureMode depthTextureMode= target.depthTextureMode;
                  ToLuaCS.push(L,depthTextureMode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_depthTextureMode(LuaState L)
          {
                  UnityEngine.DepthTextureMode value_ = (UnityEngine.DepthTextureMode)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.depthTextureMode= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_clearStencilAfterLightingPass(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean clearStencilAfterLightingPass= target.clearStencilAfterLightingPass;
                  ToLuaCS.push(L,clearStencilAfterLightingPass); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_clearStencilAfterLightingPass(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.clearStencilAfterLightingPass= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateObliqueMatrix(LuaState L)
          {
                  UnityEngine.Vector4 clipPlane_ = (UnityEngine.Vector4)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Matrix4x4 calculateobliquematrix= target.CalculateObliqueMatrix( clipPlane_);
                  ToLuaCS.push(L,calculateobliquematrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enabled(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean enabled= target.enabled;
                  ToLuaCS.push(L,enabled); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enabled(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.enabled= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rigidbody rigidbody= target.GetComponent<UnityEngine.Rigidbody>();
                  ToLuaCS.push(L,rigidbody); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Rigidbody2D rigidbody2D= target.GetComponent<UnityEngine.Rigidbody2D>();
                  ToLuaCS.push(L,rigidbody2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_camera(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Camera camera= target.GetComponent<UnityEngine.Camera>();
                  ToLuaCS.push(L,camera); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_light(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Light light= target.GetComponent<UnityEngine.Light>();
                  ToLuaCS.push(L,light); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Animation animation= target.GetComponent<UnityEngine.Animation>();
                  ToLuaCS.push(L,animation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_constantForce(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.ConstantForce constantForce= target.GetComponent<UnityEngine.ConstantForce>();
                  ToLuaCS.push(L,constantForce); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderer(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Renderer renderer= target.GetComponent<UnityEngine.Renderer>();
                  ToLuaCS.push(L,renderer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audio(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.AudioSource audio= target.GetComponent<UnityEngine.AudioSource>();
                  ToLuaCS.push(L,audio); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiText(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.GUIText guiText= target.GetComponent<UnityEngine.GUIText>();
                  ToLuaCS.push(L,guiText); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_networkView(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.NetworkView networkView= target.GetComponent<UnityEngine.NetworkView>();
                  ToLuaCS.push(L,networkView); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiTexture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.GUITexture guiTexture= target.GetComponent<UnityEngine.GUITexture>();
                  ToLuaCS.push(L,guiTexture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Collider collider= target.GetComponent<UnityEngine.Collider>();
                  ToLuaCS.push(L,collider); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Collider2D collider2D= target.GetComponent<UnityEngine.Collider2D>();
                  ToLuaCS.push(L,collider2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hingeJoint(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.HingeJoint hingeJoint= target.GetComponent<UnityEngine.HingeJoint>();
                  ToLuaCS.push(L,hingeJoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleEmitter(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.ParticleEmitter particleEmitter= target.GetComponent<UnityEngine.ParticleEmitter>();
                  ToLuaCS.push(L,particleEmitter); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleSystem(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.ParticleSystem particleSystem= target.GetComponent<UnityEngine.ParticleSystem>();
                  ToLuaCS.push(L,particleSystem); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.GameObject gameObject= target.gameObject;
                  ToLuaCS.push(L,gameObject); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( t_);
                  ToLuaCS.push(L,getcomponentinchildren); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( t_);
                  ToLuaCS.push(L,getcomponentinparent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.Component[] getcomponents= target.GetComponents( type_);
                  ToLuaCS.push(L,getcomponents); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String tag= target.tag;
                  ToLuaCS.push(L,tag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.tag= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean comparetag= target.CompareTag( tag_);
                  ToLuaCS.push(L,comparetag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessageUpwards(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessageUpwards( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessage(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.SendMessage( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BroadcastMessage(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.BroadcastMessage( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Camera target= (UnityEngine.Camera) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
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
                  ToLuaCS.push(L,allCamerasCount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAllCameras(LuaState L)
          {
                  UnityEngine.Camera[] cameras_ = (UnityEngine.Camera[])ToLuaCS.getObject(L,1);

                  System.Int32 getallcameras= UnityEngine.Camera.GetAllCameras( cameras_);
                  ToLuaCS.push(L,getallcameras); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetupCurrent(LuaState L)
          {
                  UnityEngine.Camera cur_ = (UnityEngine.Camera)ToLuaCS.getObject(L,1);

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
  #endregion       
}

