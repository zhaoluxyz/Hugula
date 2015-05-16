using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_RenderSettings {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.RenderSettings);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
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
           ToLuaCS.AddMember(L, "get_fog", get_fog);

           ToLuaCS.AddMember(L, "set_fog", set_fog);

           ToLuaCS.AddMember(L, "get_fogMode", get_fogMode);

           ToLuaCS.AddMember(L, "set_fogMode", set_fogMode);

           ToLuaCS.AddMember(L, "get_fogColor", get_fogColor);

           ToLuaCS.AddMember(L, "set_fogColor", set_fogColor);

           ToLuaCS.AddMember(L, "get_fogDensity", get_fogDensity);

           ToLuaCS.AddMember(L, "set_fogDensity", set_fogDensity);

           ToLuaCS.AddMember(L, "get_fogStartDistance", get_fogStartDistance);

           ToLuaCS.AddMember(L, "set_fogStartDistance", set_fogStartDistance);

           ToLuaCS.AddMember(L, "get_fogEndDistance", get_fogEndDistance);

           ToLuaCS.AddMember(L, "set_fogEndDistance", set_fogEndDistance);

           ToLuaCS.AddMember(L, "get_ambientMode", get_ambientMode);

           ToLuaCS.AddMember(L, "set_ambientMode", set_ambientMode);

           ToLuaCS.AddMember(L, "get_ambientSkyColor", get_ambientSkyColor);

           ToLuaCS.AddMember(L, "set_ambientSkyColor", set_ambientSkyColor);

           ToLuaCS.AddMember(L, "get_ambientEquatorColor", get_ambientEquatorColor);

           ToLuaCS.AddMember(L, "set_ambientEquatorColor", set_ambientEquatorColor);

           ToLuaCS.AddMember(L, "get_ambientGroundColor", get_ambientGroundColor);

           ToLuaCS.AddMember(L, "set_ambientGroundColor", set_ambientGroundColor);

           ToLuaCS.AddMember(L, "get_ambientLight", get_ambientLight);

           ToLuaCS.AddMember(L, "set_ambientLight", set_ambientLight);

           ToLuaCS.AddMember(L, "get_ambientSkyboxAmount", get_ambientSkyboxAmount);

           ToLuaCS.AddMember(L, "set_ambientSkyboxAmount", set_ambientSkyboxAmount);

           ToLuaCS.AddMember(L, "get_reflectionBounces", get_reflectionBounces);

           ToLuaCS.AddMember(L, "set_reflectionBounces", set_reflectionBounces);

           ToLuaCS.AddMember(L, "get_ambientProbe", get_ambientProbe);

           ToLuaCS.AddMember(L, "set_ambientProbe", set_ambientProbe);

           ToLuaCS.AddMember(L, "get_haloStrength", get_haloStrength);

           ToLuaCS.AddMember(L, "set_haloStrength", set_haloStrength);

           ToLuaCS.AddMember(L, "get_flareStrength", get_flareStrength);

           ToLuaCS.AddMember(L, "set_flareStrength", set_flareStrength);

           ToLuaCS.AddMember(L, "get_flareFadeSpeed", get_flareFadeSpeed);

           ToLuaCS.AddMember(L, "set_flareFadeSpeed", set_flareFadeSpeed);

           ToLuaCS.AddMember(L, "get_skybox", get_skybox);

           ToLuaCS.AddMember(L, "set_skybox", set_skybox);

           ToLuaCS.AddMember(L, "get_defaultReflectionMode", get_defaultReflectionMode);

           ToLuaCS.AddMember(L, "set_defaultReflectionMode", set_defaultReflectionMode);

           ToLuaCS.AddMember(L, "get_defaultReflectionResolution", get_defaultReflectionResolution);

           ToLuaCS.AddMember(L, "set_defaultReflectionResolution", set_defaultReflectionResolution);

           ToLuaCS.AddMember(L, "get_customReflection", get_customReflection);

           ToLuaCS.AddMember(L, "set_customReflection", set_customReflection);

           ToLuaCS.AddMember(L, "__call", _rendersettings);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.String name= target.name;
                  LuaDLL.lua_pushstring(L, name);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  target.name= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  target.hideFlags= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Boolean equals= target.Equals( o_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  LuaDLL.lua_pushnumber(L, getinstanceid);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fog(LuaState L)
          {

                  System.Boolean fog= UnityEngine.RenderSettings.fog;
                  LuaDLL.lua_pushboolean(L,fog);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fog(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,1);

                  UnityEngine.RenderSettings.fog= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogMode(LuaState L)
          {

                  UnityEngine.FogMode fogMode= UnityEngine.RenderSettings.fogMode;
                  ToLuaCS.push(L,fogMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogMode(LuaState L)
          {
                  UnityEngine.FogMode value_ = (UnityEngine.FogMode)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.fogMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogColor(LuaState L)
          {

                  UnityEngine.Color fogColor= UnityEngine.RenderSettings.fogColor;
                  ToLuaCS.push(L,fogColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.RenderSettings.fogColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogDensity(LuaState L)
          {

                  System.Single fogDensity= UnityEngine.RenderSettings.fogDensity;
                  LuaDLL.lua_pushnumber(L, fogDensity);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogDensity(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogDensity= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogStartDistance(LuaState L)
          {

                  System.Single fogStartDistance= UnityEngine.RenderSettings.fogStartDistance;
                  LuaDLL.lua_pushnumber(L, fogStartDistance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogStartDistance(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogStartDistance= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogEndDistance(LuaState L)
          {

                  System.Single fogEndDistance= UnityEngine.RenderSettings.fogEndDistance;
                  LuaDLL.lua_pushnumber(L, fogEndDistance);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogEndDistance(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogEndDistance= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientMode(LuaState L)
          {

                  UnityEngine.Rendering.AmbientMode ambientMode= UnityEngine.RenderSettings.ambientMode;
                  ToLuaCS.push(L,ambientMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientMode(LuaState L)
          {
                  UnityEngine.Rendering.AmbientMode value_ = (UnityEngine.Rendering.AmbientMode)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.ambientMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientSkyColor(LuaState L)
          {

                  UnityEngine.Color ambientSkyColor= UnityEngine.RenderSettings.ambientSkyColor;
                  ToLuaCS.push(L,ambientSkyColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientSkyColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.RenderSettings.ambientSkyColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientEquatorColor(LuaState L)
          {

                  UnityEngine.Color ambientEquatorColor= UnityEngine.RenderSettings.ambientEquatorColor;
                  ToLuaCS.push(L,ambientEquatorColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientEquatorColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.RenderSettings.ambientEquatorColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientGroundColor(LuaState L)
          {

                  UnityEngine.Color ambientGroundColor= UnityEngine.RenderSettings.ambientGroundColor;
                  ToLuaCS.push(L,ambientGroundColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientGroundColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.RenderSettings.ambientGroundColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientLight(LuaState L)
          {

                  UnityEngine.Color ambientLight= UnityEngine.RenderSettings.ambientLight;
                  ToLuaCS.push(L,ambientLight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientLight(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  UnityEngine.RenderSettings.ambientLight= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientSkyboxAmount(LuaState L)
          {

                  System.Single ambientSkyboxAmount= UnityEngine.RenderSettings.ambientSkyboxAmount;
                  LuaDLL.lua_pushnumber(L, ambientSkyboxAmount);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientSkyboxAmount(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.ambientSkyboxAmount= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_reflectionBounces(LuaState L)
          {

                  System.Int32 reflectionBounces= UnityEngine.RenderSettings.reflectionBounces;
                  LuaDLL.lua_pushnumber(L, reflectionBounces);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_reflectionBounces(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.reflectionBounces= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientProbe(LuaState L)
          {

                  UnityEngine.Rendering.SphericalHarmonicsL2 ambientProbe= UnityEngine.RenderSettings.ambientProbe;
                  ToLuaCS.push(L,ambientProbe);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientProbe(LuaState L)
          {
                  UnityEngine.Rendering.SphericalHarmonicsL2 value_ = (UnityEngine.Rendering.SphericalHarmonicsL2)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.ambientProbe= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_haloStrength(LuaState L)
          {

                  System.Single haloStrength= UnityEngine.RenderSettings.haloStrength;
                  LuaDLL.lua_pushnumber(L, haloStrength);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_haloStrength(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.haloStrength= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flareStrength(LuaState L)
          {

                  System.Single flareStrength= UnityEngine.RenderSettings.flareStrength;
                  LuaDLL.lua_pushnumber(L, flareStrength);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_flareStrength(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.flareStrength= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flareFadeSpeed(LuaState L)
          {

                  System.Single flareFadeSpeed= UnityEngine.RenderSettings.flareFadeSpeed;
                  LuaDLL.lua_pushnumber(L, flareFadeSpeed);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_flareFadeSpeed(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.flareFadeSpeed= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_skybox(LuaState L)
          {

                  UnityEngine.Material skybox= UnityEngine.RenderSettings.skybox;
                  ToLuaCS.push(L,skybox);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_skybox(LuaState L)
          {
                  UnityEngine.Material value_ = (UnityEngine.Material)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.skybox= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultReflectionMode(LuaState L)
          {

                  UnityEngine.Rendering.DefaultReflectionMode defaultReflectionMode= UnityEngine.RenderSettings.defaultReflectionMode;
                  ToLuaCS.push(L,defaultReflectionMode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_defaultReflectionMode(LuaState L)
          {
                  UnityEngine.Rendering.DefaultReflectionMode value_ = (UnityEngine.Rendering.DefaultReflectionMode)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.defaultReflectionMode= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultReflectionResolution(LuaState L)
          {

                  System.Int32 defaultReflectionResolution= UnityEngine.RenderSettings.defaultReflectionResolution;
                  LuaDLL.lua_pushnumber(L, defaultReflectionResolution);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_defaultReflectionResolution(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.defaultReflectionResolution= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_customReflection(LuaState L)
          {

                  UnityEngine.Cubemap customReflection= UnityEngine.RenderSettings.customReflection;
                  ToLuaCS.push(L,customReflection);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_customReflection(LuaState L)
          {
                  UnityEngine.Cubemap value_ = (UnityEngine.Cubemap)ToLuaCS.getObject(L, 1);

                  UnityEngine.RenderSettings.customReflection= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _rendersettings(LuaState L)
          {

                  UnityEngine.RenderSettings _rendersettings= new UnityEngine.RenderSettings();
                  ToLuaCS.push(L,_rendersettings);
                  return 1;

          }
  #endregion       
}

