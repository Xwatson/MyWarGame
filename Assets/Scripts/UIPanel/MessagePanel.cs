using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel {

    private Text text;
    public float showTime = 1; // 默认显示时间

    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        // 把当前对象注入到UIManager中
        uIManager.InjectMessagePanel(this);
    }

    public void ShowMessage(string message)
    {
        text.CrossFadeAlpha(1, 0.2f, false);
        text.text = message;
        text.enabled = true;
        Invoke("Hide", showTime);
    }
    public void Hide()
    {
        // 1秒渐隐
        text.CrossFadeAlpha(0, 2, false);
    }
}
