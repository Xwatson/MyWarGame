using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoginPanel : BasePanel {
    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
    }
}
