using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

public class RequestManager : BaseManager {

    private Dictionary<RequestCode, BaseRequest> requestDic = new Dictionary<RequestCode, BaseRequest>();

    public RequestManager(Game gameFacade): base(gameFacade) { }

    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="requestCode"></param>
    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestDic.Add(requestCode, request);
    }
    public void RemoveRequest(RequestCode requestCode)
    {
        requestDic.Remove(requestCode);
    }
    /// <summary>
    /// 响应数据
    /// </summary>
    public void HandleResponse(RequestCode requestCode, string data)
    {
        BaseRequest request = requestDic.TryGet(requestCode);
        if (request == null)
        {
            Debug.Log("无法找到RequestCode[" + requestCode + "]对应的Request类");
            return;
        }
        request.OnResponse(data);
    }
}
