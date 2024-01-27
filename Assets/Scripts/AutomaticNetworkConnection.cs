using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class AutomaticNetworkConnection : MonoBehaviour
{

    [SerializeField]
    NetworkManager _manager;
    public NetworkManager manager => _manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool is_hmd(){
        bool is_hmd = false;
        #if UNITY_ANDROID
            // connect as client
           is_hmd = true;
        #else
            // connect as server
            is_hmd = false;
        #endif
        return is_hmd;
    }
    public void StartServerClient(bool is_hmd_device){
        
        if(is_hmd_device){
             _manager.StartClient();
        }
        else{
            _manager.StartServer();
        }
    }
    
    private void OnValidate()
    {
        _manager = GetComponent<NetworkManager>();
    }

    public bool IsSpeaker(){
            return _manager.LocalClientId % 2 == 0;
    }

    
}
