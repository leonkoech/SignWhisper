using UnityEngine;
using Unity.Netcode;

public class AutomaticNetworkConnection : MonoBehaviour
{

    [SerializeField]
    private NetworkManager networkManager;
    [SerializeField]
    public TMPro.TMP_Text connect;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("creating server instance");
        bool _isHMD = is_hmd();
        StartServerClient(_isHMD);
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool is_hmd()
    {
        bool is_hmd = false;
       #if UNITY_EDITOR
            Debug.Log("Device is running in the Unity Editor.");
            // Your Editor-specific logic here
            is_hmd = false;
        #else
            Debug.Log("Device is running on an unspecified platform.");
            // Your generic logic here
            is_hmd = true;
        #endif
        return is_hmd;
    }
    public void StartServerClient(bool is_hmd_device)
    {
        if (is_hmd_device)
        {
            if (networkManager != null && !networkManager.IsServer && !networkManager.IsClient)
            {
                networkManager.StartClient();
                Debug.Log("Client connecting to server");
                if (networkManager.IsClient)
                {

                    connect.text = "client connected";
                }
            }
        }
        else
        {
            // Connect to the server (adjust the delay if needed)
            Debug.Log("Start Server");
            Invoke("ConnectToServer", 2f);
        }
    }

    void ConnectToServer()
    {
        if (networkManager != null && !networkManager.IsServer && !networkManager.IsClient)
        {
            networkManager.StartServer();
            Debug.Log("Server started");
            if (networkManager.IsServer)
            {

                connect.text = "server started";
            }
        }
        else
        {
            Debug.Log("Network Manager: " + networkManager != null + "isServer: " + !networkManager.IsServer + "isClient" + !networkManager.IsClient);
        }
    }

    public void DisconnectClient()
    {
        NetworkManager networkManager = GetComponent<NetworkManager>();

        if (networkManager != null && networkManager.IsClient)
        {
            
            networkManager.DisconnectClient(networkManager.LocalClientId);

        }
    }

    private void OnValidate()
    {
        networkManager = GetComponent<NetworkManager>();
    }


}
