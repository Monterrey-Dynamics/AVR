using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjSpawnerButton : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Button button;
    public Vector3 scale;

    private PlacementIndicator placementIndicator;

    private GameObject obj;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        obj = Instantiate(objectToSpawn);
        //obj.SetActive(false);

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        obj.transform.position = placementIndicator.transform.position;
        obj.transform.rotation = placementIndicator.transform.rotation;
        obj.transform.localScale = scale;
        //obj.SetActive(true);
    }
}
