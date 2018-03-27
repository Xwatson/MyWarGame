using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private AudioManager audioManager;
    private CameraManager cameraManager;
    private ClientManager clientManager;
    private PlayerManager playerManager;
    private RequestManager requestManager;
    private UIManager uIManager;

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
        audioManager = new AudioManager();
        cameraManager = new CameraManager();
        clientManager = new ClientManager();
        playerManager = new PlayerManager();
        requestManager = new RequestManager();
        uIManager = new UIManager();

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
}
