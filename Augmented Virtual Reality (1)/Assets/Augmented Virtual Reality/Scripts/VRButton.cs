using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{

    public MonoBehaviour targetScript;

    public string targetEvent;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTouch"))
        {
            //targetScript.SendMessage(targetEvent);
            button.Select();
            //button.gameObject.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTouch"))
        {
            //targetScript.SendMessage(targetEvent);
            //button.
        }
    }
}
