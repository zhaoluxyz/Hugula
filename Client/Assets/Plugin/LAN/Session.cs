// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;

public class Session  {

    private TcpClient client;

    private NetworkStream stream;

    private ArrayList queue;//消息队列

    private int len;// msg len

    public Session(TcpClient client)
    {
        queue = ArrayList.Synchronized(new ArrayList());
        this.client = client;
        stream = this.client.GetStream();
    }

    public int id
    {
        get
        {
            return client.GetHashCode();
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="bytes"></param>
    public void Send(byte[] bytes)
    {
        Debug.Log("send msg " + bytes.Length + "  " + client.Connected);
        if (client.Connected)
            stream.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(SendCallback), stream);
    }

    public void Send(Msg msg)
    {
        if (client != null && client.Connected)
            Send(msg.ToCArray());
    }

    /// <summary>
    /// 关闭连接
    /// </summary>
    public void Close()
    {
        if (client != null) client.Close();
        if (stream != null) stream.Close();
    }

    /// <summary>
    /// 读取消息
    /// </summary>
    public void Receive()
    {
        if (client.Connected && stream.DataAvailable)
        {
            //Debug.Log(stream + " Available = " + stream.DataAvailable);
            if (len == 0)
            {
                byte[] header = new byte[2];
                stream.Read(header, 0, 2);
                Array.Reverse(header);
                len = BitConverter.ToUInt16(header, 0);
            }

            if (len > 0 && len <= client.Available)
            {
                byte[] message = new byte[len];
                stream.Read(message, 0, message.Length);
                Msg msg = new Msg(message);
                len = 0;
                queue.Add(msg.ToCArray());
            }
        }
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    /// <returns></returns>
    public byte[] GetMessage()
    {
        if (queue.Count > 0)
        {
            var msg = queue[0];
            queue.RemoveAt(0);
            return (byte[])msg;
        }
        return null;
    }
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

	#endregion

	#region pulic method

	#endregion

	#region private method
    /// <summary>
    /// 发送完成回调
    /// </summary>
    /// <param name="rs"></param>
    private void SendCallback(IAsyncResult rs)
    {
        try
        {
            Debug.Log("  send suceess"+id.ToString());
            client.Client.EndSend(rs);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
	#endregion
}
