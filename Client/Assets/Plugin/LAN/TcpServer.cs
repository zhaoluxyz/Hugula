// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class TcpServer :MonoBehaviour  {

	#region pulic member
    /// <summary>
    /// server端口
    /// </summary>
    public int port = 12000;

	#endregion

	#region private member
    /// <summary>
    /// IP 地址
    /// </summary>
    private IPAddress localAddr = IPAddress.Parse("127.0.0.1");

    private TcpListener server;

    private ArrayList clients;// = new List<TcpClient>();
    private ArrayList sessions;// = new List<TcpClient>();
    private ArrayList broadMsg;//广播的消息

    public static ManualResetEvent tcpClientConnected =  new ManualResetEvent(false);
	#endregion

	#region mono

    void OnDisable()
    {
        server.Stop();
        Debug.Log("server.stop");
    }

	/// <summary>
	/// 开启服务
	/// </summary>
	void Start () {
        clients = ArrayList.Synchronized(new ArrayList());
        sessions = ArrayList.Synchronized(new ArrayList());
        broadMsg = ArrayList.Synchronized(new ArrayList());
        if(server==null)server = new TcpListener(localAddr, port);
        server.Start();
        Debug.Log(localAddr.ToString() + " is Start");
        server.BeginAcceptTcpClient(DoAcceptTcpClientCallback, server); //开始监听
	}


    // Update is called once per frame
	void Update () {
        foreach (var client in sessions)
        {
            Session ses = ((Session)client);
            ses.Receive();
            byte[] msg = ses.GetMessage();
            if (msg != null)
            {
                broadMsg.Add(msg);
            }
        }

        BroadCast();
	}


    /// <summary>
    /// 广播消息
    /// </summary>
    public void BroadCast()
    {
        //Debug.Log("BroadCast");
        foreach (var client in sessions)
        {
            Session ses = ((Session)client);
            foreach (var msg in broadMsg)
            {
                //UnityEngine.Debug.Log("send to session ");
                ses.Send((byte[])msg);
            }
        }

        broadMsg.Clear();
    }
	#endregion

	#region pulic method

	#endregion

	#region private method

    private void DoAcceptTcpClientCallback(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;

        TcpClient client = listener.EndAcceptTcpClient(ar);
        //add to server list
        if (!clients.Contains(listener))
        {
            clients.Add(client);
            sessions.Add(new Session(client));
            Debug.Log("new clinet"+client.GetHashCode());
        }
        server.BeginAcceptTcpClient(DoAcceptTcpClientCallback, server); //开始监听

        // Process the connection here. (Add the client to a
        // server table, read data, etc.)

        //Debug.Log(" Available = " + client.Available);
        //tcpClientConnected.Set();
    }
	#endregion
}
