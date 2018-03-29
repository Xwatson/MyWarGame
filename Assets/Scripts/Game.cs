using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyWarCommon;

public class Game : MonoBehaviour
{
    private static Game _instance;
    // 为了解决耦合这里使用单列模式，所有管理类的中间类
    public static Game Instance { get { return _instance; } }

    private AudioManager audioManager;
    private CameraManager cameraManager;
    private ClientManager clientManager;
    private PlayerManager playerManager;
    private RequestManager requestManager;
    private UIManager uIManager;

    private void Awake()
    {
        // 单列
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
    // Use this for initialization
    void Start()
    {
        InitManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        DestroyManager();
    }
    private void InitManager()
    {
        audioManager = new AudioManager(this);
        cameraManager = new CameraManager(this);
        clientManager = new ClientManager(this);
        playerManager = new PlayerManager(this);
        requestManager = new RequestManager(this);
        uIManager = new UIManager(this);

        audioManager.OnInit();
        cameraManager.OnInit();
        clientManager.OnInit();
        playerManager.OnInit();
        requestManager.OnInit();
        uIManager.OnInit();
    }
    private void DestroyManager()
    {
        audioManager.OnDestroy();
        cameraManager.OnDestroy();
        clientManager.OnDestroy();
        playerManager.OnDestroy();
        requestManager.OnDestroy();
        uIManager.OnDestroy();
    }
    /// <summary>
    /// 添加request
    /// </summary>
    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestManager.AddRequest(requestCode, request);
    }
    /// <summary>
    /// 删除request
    /// </summary>
    /// <param name="requestCode"></param>
    public void RemoveRequest(RequestCode requestCode)
    {
        requestManager.RemoveRequest(requestCode);
    }
    /// <summary>
    /// 处理响应
    /// </summary>
    /// <param name="requestCode"></param>
    /// <param name="data"></param>
    public void HandleResponse(RequestCode requestCode, string data)
    {
        requestManager.HandleResponse(requestCode, data);
    }
}
