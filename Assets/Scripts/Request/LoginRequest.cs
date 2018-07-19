using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

public class LoginRequest : BaseRequest {
    private LoginPanel loginPanel;
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        loginPanel = GetComponent<LoginPanel>();
        base.Awake();
    }
	// 发送请求
    public void SendRequest(string name, string password)
    {
        string data = name + "," + password;
        base.SendRequest(data);
    }
    // 响应
    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode)int.Parse(data);
        loginPanel.OnLoginResponse(returnCode);
    }
}
