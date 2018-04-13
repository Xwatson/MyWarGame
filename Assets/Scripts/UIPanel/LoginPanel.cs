using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoginPanel : BasePanel {

    private Button button;
    private InputField userNameIF;
    private InputField passwordIF;
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        button = transform.Find("Close").GetComponent<Button>();
        button.onClick.AddListener(OnClose);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
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
