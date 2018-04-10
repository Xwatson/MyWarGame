using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoginPanel : BasePanel {

    private Button button;
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        button = transform.Find("Close").GetComponent<Button>();
        button.onClick.AddListener(OnClose);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
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
