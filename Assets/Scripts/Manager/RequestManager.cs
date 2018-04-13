using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

public class RequestManager : BaseManager {

    private Dictionary<ActionCode, BaseRequest> requestDic = new Dictionary<ActionCode, BaseRequest>();

    public RequestManager(Game gameFacade): base(gameFacade) { }

    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="actionCode"></param>
    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        requestDic.Add(actionCode, request);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        requestDic.Remove(actionCode);
    }
    /// <summary>
    /// 响应数据
    /// </summary>
    public void HandleResponse(ActionCode actionCode, string data)
    {
        BaseRequest request = requestDic.TryGet(actionCode);
        if (request == null)
        {
            Debug.Log("无法找到ActionCode[" + actionCode + "]对应的Request类");
            return;
        }
        request.OnResponse(data);
    }
}
