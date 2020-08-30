using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;

    private GameObject obj;

    void Start() {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        obj = Instantiate(objectToSpawn);
        obj.SetActive(false);
    }

    void Update() {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            obj.transform.position = placementIndicator.transform.position;
            obj.transform.rotation = placementIndicator.transform.rotation;
            obj.SetActive(true);
        }
    }
}
