using System.Collections;
using UnityEngine;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;

public static class ToLuaCSStart  { 
  
  public static void Start(LuaState L){
  
      LuaToiTween.CreateMetaTableToLua(L);
      LuaToVersion.CreateMetaTableToLua(L);
      LuaToUdpMasterServer.CreateMetaTableToLua(L);
      LuaToUIPanelCamackTable.CreateMetaTableToLua(L);
      LuaToUGUILocalize.CreateMetaTableToLua(L);
      LuaToUGUIEventSystem.CreateMetaTableToLua(L);
      LuaToTimer.CreateMetaTableToLua(L);
      LuaToTcpServer.CreateMetaTableToLua(L);
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

