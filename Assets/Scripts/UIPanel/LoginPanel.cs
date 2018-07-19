using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using MyWarCommon;

public class LoginPanel : BasePanel {

    private Button button;
    private InputField userNameIF;
    private InputField passwordIF;
    private LoginRequest loginRequest;

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        button = transform.Find("Close").GetComponent<Button>();
        button.onClick.AddListener(OnClose);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        loginRequest = GetComponent<LoginRequest>();
        userNameIF = transform.Find("UserNameLabel/UserNameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PwdLabel/PwdInput").GetComponent<InputField>();
        transform.Find("LoginButton").GetComponent<Button>().onClick.AddListener(OnLoginClick);
        transform.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
    }
    private void OnLoginClick()
    {
        string msg = "";
        if (string.IsNullOrEmpty(userNameIF.text))
        {
            msg = "用户名";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += (msg != "" ? "和" : "") + "密码";
        }
        if (msg != "")
        {
            uIManager.ShowMessage(msg + "不能为空");
            return;
        }
        // 发送登录请求
        loginRequest.SendRequest(userNameIF.text, passwordIF.text);
    }
    public void OnLoginResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            // 进入房间
        }
        else
        {
            uIManager.ShowMessageSync("用户名密码错误，请重新输入！");
        }
    }
    private void OnRegisterClick()
    {

    }
    private void OnClose()
    {
        transform.DOScale(0, 0.4f).OnComplete(() => uIManager.PopPanel());
    }
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
