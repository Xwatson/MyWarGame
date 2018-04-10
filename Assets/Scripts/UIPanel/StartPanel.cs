using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BasePanel {
    private Button startBtn;
    private Animator btnAnimator;
    public override void OnEnter()
    {
        base.OnEnter();
        startBtn = transform.GetComponent<Button>();
        btnAnimator = startBtn.GetComponent<Animator>();
        startBtn.onClick.AddListener(StartClick);
    }
    private void StartClick()
    {
        uIManager.PushPanel(UIPanelType.Login);
    }
    public override void OnPause()
    {
        base.OnPause();
        btnAnimator.enabled = false;
        startBtn.transform.DOScale(0, 0.2f).OnComplete(() => gameObject.SetActive(false));
        Debug.Log("OnPause");
    }
    public override void OnResume()
    {
        base.OnResume();
        gameObject.SetActive(true);
        startBtn.transform.DOScale(1, 0.3f).OnComplete(() => btnAnimator.enabled = true);
        Debug.Log("OnResume");
    }
}
