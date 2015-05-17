using System.Collections;
using UnityEngine;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;

public static class ToLuaCSStart  { 
  
  public static void Start(LuaState L){
  
      LuaToUnityEngine_Object.CreateMetaTableToLua(L);
      LuaToSystem_Object.CreateMetaTableToLua(L);
      LuaToUnityEngine_WWW.CreateMetaTableToLua(L);
      LuaToVersion.CreateMetaTableToLua(L);
      LuaToUnityEngine_MonoBehaviour.CreateMetaTableToLua(L);
      LuaToUnityEngine_Vector3.CreateMetaTableToLua(L);
      LuaToUnityEngine_Resources.CreateMetaTableToLua(L);
      LuaToUnityEngine_Time.CreateMetaTableToLua(L);
      LuaToUnityEngine_Rect.CreateMetaTableToLua(L);
      LuaToUnityEngine_Transform.CreateMetaTableToLua(L);
      LuaToUnityEngine_Quaternion.CreateMetaTableToLua(L);
      LuaToUnityEngine_Random.CreateMetaTableToLua(L);
      LuaToUnityEngine_RenderSettings.CreateMetaTableToLua(L);
      LuaToUnityEngine_PlayerPrefs.CreateMetaTableToLua(L);
      LuaToUnityEngine_GameObject.CreateMetaTableToLua(L);
      LuaToiTween.CreateMetaTableToLua(L);
      LuaToUnityEngine_BoxCollider.CreateMetaTableToLua(L);
      LuaToUnityEngine_Camera.CreateMetaTableToLua(L);
      LuaToUnityEngine_AssetBundle.CreateMetaTableToLua(L);
      LuaToUnityEngine_AudioListener.CreateMetaTableToLua(L);
      LuaToUIPanelCamackTable.CreateMetaTableToLua(L);
      LuaToUdpMasterServer.CreateMetaTableToLua(L);
      LuaToUGUIEventSystem.CreateMetaTableToLua(L);
      LuaToUGUILocalize.CreateMetaTableToLua(L);
      LuaToTcpServer.CreateMetaTableToLua(L);
      LuaToTimer.CreateMetaTableToLua(L);
      LuaToSession.CreateMetaTableToLua(L);
      LuaToReferGameObjects.CreateMetaTableToLua(L);
      LuaToProfilerPanel.CreateMetaTableToLua(L);
      LuaToPLua.CreateMetaTableToLua(L);
      LuaToNGUITools.CreateMetaTableToLua(L);
      LuaToNGUIMath.CreateMetaTableToLua(L);
      LuaToNGUIEvent.CreateMetaTableToLua(L);
      LuaToMsg.CreateMetaTableToLua(L);
      LuaToLuaHelper.CreateMetaTableToLua(L);
      LuaToLocalization.CreateMetaTableToLua(L);
      LuaToLeanTween.CreateMetaTableToLua(L);
      LuaToCRequest.CreateMetaTableToLua(L);
      LuaToLNet.CreateMetaTableToLua(L);
      LuaToCHighway.CreateMetaTableToLua(L);
      LuaToFileHelper.CreateMetaTableToLua(L);
      LuaToFPS.CreateMetaTableToLua(L);
      LuaToCryptographHelper.CreateMetaTableToLua(L);
      LuaToCommon.CreateMetaTableToLua(L);
      LuaToCUtils.CreateMetaTableToLua(L);
      LuaToCTransport.CreateMetaTableToLua(L);
      LuaToLRequest.CreateMetaTableToLua(L);
      LuaToCQueueRequest.CreateMetaTableToLua(L);
      LuaToLHighway.CreateMetaTableToLua(L);
      LuaToCDependenciesScript.CreateMetaTableToLua(L);
      LuaToCDependencies.CreateMetaTableToLua(L);
      LuaToByteReader.CreateMetaTableToLua(L);
      LuaToBegin.CreateMetaTableToLua(L);
      LuaToActivateMonos.CreateMetaTableToLua(L);
  }
}

