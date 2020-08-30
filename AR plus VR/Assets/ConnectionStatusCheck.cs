using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionStatusCheck : MonoBehaviour
{
    public Text textTarg;
    // Start is called before the first frame update
    void Start()
    {
        textTarg.text = "Disconnected";
    }

    // Update is called once per frame
    void Update()
    {
        textTarg.text = NetworkClient.active ? "Connected" : "Disconnected";
    }
}
