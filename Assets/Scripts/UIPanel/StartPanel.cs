using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel {
    public override void OnEnter()
    {
        base.OnEnter();
        Button startBtn = transform.GetComponent<Button>();
        startBtn.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        uIManager.PushPanel(UIPanelType.Login);
    }
}
