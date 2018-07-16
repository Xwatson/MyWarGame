using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

public class LoginRequest : BaseRequest {

	// Use this for initialization
	void Start () {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
	}
	// 发送请求
    public void SendRequest(string name, string password)
    {
        string data = name + "," + password;
        base.SendRequest(data);
    }
}
