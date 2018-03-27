using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Sockets;

public class ClientManager : BaseManager {

    private const string HOST = "127.0.0.1";
    private const int PORT = 3318;

    private Socket clientSocket;

    public override void OnInit()
    {
        base.OnInit();
        try
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(HOST, PORT);
        }
        catch (Exception e)
        {
            Debug.LogError("连接服务器错误，请检查网络！" + e);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("客户端关闭失败！" + e);
        }
    }
}
