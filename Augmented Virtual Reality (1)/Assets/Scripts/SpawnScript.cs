using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : NetworkBehaviour
{
    public List<GameObject> spawnPrefabs;
    public NetworkConnection conn;
    public float xIncrement = 1;
    public float zIncrement = 1;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    void Update()
    {
        if (NetworkServer.active)
        {
            float x = 0;
            float z = 0;

            foreach (GameObject spawnObj in spawnPrefabs)
            {
                GameObject obj = Instantiate(spawnObj, new Vector3(x, 0, z), Quaternion.identity);
                x += xIncrement;
                z += zIncrement;
                NetworkServer.Spawn(obj, conn);
            }
            enabled = false;
        }
    }

}
