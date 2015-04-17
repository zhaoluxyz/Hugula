﻿using UnityEngine;
using System.Collections;

public class ClientTest : MonoBehaviour {

	#region pulic member

	#endregion

	#region private member

	#endregion

	#region mono

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDisable()
    {
        LNet.instance.Close();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f), "");

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        //Debug.Log(Network.peerType);
        //if (Network.peerType == NetworkPeerType.Disconnected)
        //{
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);

            GUILayout.BeginVertical();
            if (!LNet.instance.IsConnected && GUILayout.Button("Connect"))
            {
                LNet.instance.Connect("127.0.0.1", 12000);
            }
            if (LNet.instance.IsConnected && GUILayout.Button("send msg Server"))
            {
                Msg m = new Msg();
                m.Type = 2;
                m.WriteString("hello server "+System.DateTime.Now.ToShortTimeString());
                LNet.instance.Send(m);
                //Debug.Log("send:" + Msg.Debug(m.ToCArray()));
            }
            GUILayout.EndVertical();
          
            {
               
            }
        //}
        //else
        //{
        //    GUILayout.Label("GUID: " + Network.player.guid + " - ");
        //    GUILayout.Label("Local IP/port: " + Network.player.ipAddress + "/" + Network.player.port);
        //    GUILayout.Label(" - External IP/port: " + Network.player.externalIP + "/" + Network.player.externalPort);
        //    GUILayout.EndHorizontal();
        //    GUILayout.BeginHorizontal();
        //    if (GUILayout.Button("Disconnect"))
        //        Network.Disconnect(200);
        //}
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

	#endregion

	#region pulic method

	#endregion

	#region private method

	#endregion
}
