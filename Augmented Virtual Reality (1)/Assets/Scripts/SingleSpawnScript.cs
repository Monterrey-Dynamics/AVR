using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpawnScript : NetworkBehaviour
{
    public GameObject spawnPrefab;
    public NetworkConnection conn;

    public Vector3 pos;
    public Quaternion rot = Quaternion.identity;
    public Vector3 scale = new Vector3(1, 1, 1);
    // Start is called before the first frame update

    void Start()
    {

    }

    void Update()
    {
        if (NetworkServer.active)
        {
            GameObject obj = Instantiate(spawnPrefab, pos, rot);
            obj.transform.localScale = scale;

            NetworkServer.Spawn(obj, conn);
            enabled = false;
        }
    }

}
