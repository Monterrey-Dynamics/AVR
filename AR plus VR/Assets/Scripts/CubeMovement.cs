using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CubeMovement : NetworkBehaviour
{
    [SyncVar]
    public Vector3 Control; //This is a sync var, mirror automatically shares and syncs this variable across all of the scripts on objects with the same network identity, but it can only be set by the server.

    public Color c;//color to change to if we are controlling this one
   
    void Update()
    {
        if (GetComponent<NetworkIdentity>().hasAuthority)//make sure this is an object that we ae controlling
        {
            //GetComponent<Renderer>().material.color = c;//change color
            Control = new Vector3(Input.GetAxis("Horizontal")*.1f, 0, Input.GetAxis("Vertical")*.1f);//update our controll varible
            GetComponent<PhysicsLink>().ApplyForce(Control,ForceMode.VelocityChange);//Use our custom force function
            if (Input.GetAxis("Cancel")==1)//if we press the esc button
            {
                GetComponent<PhysicsLink>().CmdResetPose();//reset our position
            }
        }
    }
}