using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartConnection : MonoBehaviour
{
    public NetworkManager manager;

    public Button button;
    public string defaultIp;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        manager.StartHost();
        manager.networkAddress = defaultIp;
        UnityEngine.Debug.Log("Connecting");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
