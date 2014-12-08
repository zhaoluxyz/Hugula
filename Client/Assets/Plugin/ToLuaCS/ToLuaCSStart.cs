using System.Collections;
using UnityEngine;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;

public static class ToLuaCSStart  { 
  
  public static void Start(LuaState L){
  
      LuaToSystem_Object.CreateMetaTableToLua(L);
      LuaToUnityEngine_WWW.CreateMetaTableToLua(L);
      LuaToUnityEngine_Object.CreateMetaTableToLua(L);
      LuaToUnityEngine_MonoBehaviour.CreateMetaTableToLua(L);
      LuaToUnityEngine_Vector3.CreateMetaTableToLua(L);
      LuaToUnityEngine_Transform.CreateMetaTableToLua(L);
      LuaToUnityEngine_Time.CreateMetaTableToLua(L);
      LuaToUnityEngine_Quaternion.CreateMetaTableToLua(L);
      LuaToUnityEngine_Random.CreateMetaTableToLua(L);
      LuaToiTween.CreateMetaTableToLua(L);
      LuaToUnityEngine_RenderSettings.CreateMetaTableToLua(L);
      LuaToUnityEngine_Camera.CreateMetaTableToLua(L);
      LuaToUnityEngine_GameObject.CreateMetaTableToLua(L);
      LuaToUIPanelCamackTable.CreateMetaTableToLua(L);
      LuaToUnityEngine_AssetBundle.CreateMetaTableToLua(L);
      LuaToTimer.CreateMetaTableToLua(L);
      LuaToUIEventLuaTrigger.CreateMetaTableToLua(L);
      LuaToSystem_Text_Encoding.CreateMetaTableToLua(L);
      LuaToSystem_Text_UTF8Encoding.CreateMetaTableToLua(L);
      LuaToResourceCache.CreateMetaTableToLua(L);
      LuaToReferGameObjects.CreateMetaTableToLua(L);
      LuaToPLua.CreateMetaTableToLua(L);
      LuaToNGUIEvent.CreateMetaTableToLua(L);
      LuaToMultipleLoader.CreateMetaTableToLua(L);
      LuaToMsg.CreateMetaTableToLua(L);
      LuaToLuaHelper.CreateMetaTableToLua(L);
      LuaToLocalization.CreateMetaTableToLua(L);
      LuaToLoaderEventArg.CreateMetaTableToLua(L);
      LuaToLeanTween.CreateMetaTableToLua(L);
      LuaToLTSpline.CreateMetaTableToLua(L);
      LuaToLTDescr.CreateMetaTableToLua(L);
      LuaToLTBezierPath.CreateMetaTableToLua(L);
      LuaToLTBezier.CreateMetaTableToLua(L);
      LuaToCRequest.CreateMetaTableToLua(L);
      LuaToLNet.CreateMetaTableToLua(L);
      LuaToLMultipleLoader.CreateMetaTableToLua(L);
      LuaToFileHelper.CreateMetaTableToLua(L);
      LuaToCUtils.CreateMetaTableToLua(L);
      LuaToLRequest.CreateMetaTableToLua(L);
      LuaToCQueueRequest.CreateMetaTableToLua(L);
      LuaToCLoader.CreateMetaTableToLua(L);
      LuaToActivateMonos.CreateMetaTableToLua(L);
  }
}

