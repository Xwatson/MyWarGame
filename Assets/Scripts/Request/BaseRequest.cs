using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

// 场景内所有的请求
public class BaseRequest : MonoBehaviour {
    protected RequestCode requestCode = RequestCode.None;
    protected ActionCode actionCode = ActionCode.None;
    protected Game game;
	public virtual void Awake()
    {
        // 把自身交给RequestManager管理
        Game.Instance.AddRequest(actionCode, this);
        game = Game.Instance;
    }
    /// <summary>
    /// 发送请求
    /// </summary>
    public virtual void SendRequest() { }
    protected void SendRequest(string data)
    {
        game.SendRequest(requestCode, actionCode, data);
    }
    /// <summary>
    /// 响应
    /// </summary>
    /// <param name="data"></param>
    public virtual void OnResponse(string data) { }
    /// <summary>
    /// 销毁
    /// </summary>
    public virtual void OnDestroy()
    {
        Game.Instance.RemoveRequest(actionCode);
    }
}
