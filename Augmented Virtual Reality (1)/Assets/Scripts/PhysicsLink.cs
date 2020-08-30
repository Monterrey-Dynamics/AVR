using UnityEngine;
using Mirror;
using System.Diagnostics;
using System;

public class PhysicsLink : NetworkBehaviour
{
    public Rigidbody rb;

    [SyncVar]//all the essental varibles of a rigidbody
    public Vector3 Velocity;
    [SyncVar]
    public Quaternion Rotation;
    [SyncVar]
    public Vector3 Position;
    [SyncVar]
    public Vector3 AngularVelocity;


    private Vector3 parentPosition;
    private GameObject parent;

    private bool validParent = false;

    public float smoothing = 20;

    void findParent()
    {
        var origins = GameObject.FindGameObjectsWithTag("MirrorOrigin");

        validParent = !(origins == null || origins.Length == 0);

        if (validParent) parent = origins[0];
    }

    void Start()
    {

    }

    void Update()
    {
        if (GetComponent<NetworkIdentity>().isServer)//if we are the server update the varibles with our cubes rigidbody info
        {
            Position = rb.position;
            Rotation = rb.rotation;
            Velocity = rb.velocity;
            //AngularVelocity = ServerSide.angularVelocity;
            //rb.position = Position;
            //rb.rotation = Rotation;
            //rb.velocity = Velocity;
            //rb.angularVelocity = AngularVelocity;
        }
        else if (GetComponent<NetworkIdentity>().isClient)//if we are a client update our rigidbody with the servers rigidbody info
        {
            findParent();

            if (validParent)
            {
                parentPosition = parent.transform.position;
                UnityEngine.Debug.LogError("ORIGIN");
            }
            else
            {
                UnityEngine.Debug.LogError("NO ORIGIN");
                parentPosition = new Vector3(0, 0, 0);
            }

            rb.position = Vector3.Slerp(rb.position, Position + parentPosition, Time.deltaTime * smoothing);
            rb.rotation = Quaternion.Slerp(rb.rotation, Rotation, Time.deltaTime * smoothing);
            rb.velocity = Vector3.Slerp(rb.velocity, Velocity, Time.deltaTime * smoothing);
            rb.angularVelocity = Vector3.Slerp(rb.angularVelocity, AngularVelocity, Time.deltaTime * smoothing);

            //rb.position = (Position);//account for the lag and update our varibles
            //rb.position = Position + parentPosition;
            //rb.rotation = Rotation;
            //rb.velocity = Velocity;
            //rb.angularVelocity = AngularVelocity;
        }
    }
    [Command]//function that runs on server when called by a client
    public void CmdResetPose()
    {
        rb.position = new Vector3(0, 1, 0);
        rb.velocity = new Vector3();
    }
    public void ApplyForce(Vector3 force, ForceMode FMode)//apply force on the client-side to reduce the appearance of lag and then apply it on the server-side
    {
        rb.AddForce(force, FMode);
        CmdApplyForce(force, FMode);

    }
    [Command]//function that runs on server when called by a client
    public void CmdApplyForce(Vector3 force, ForceMode FMode)
    {
        rb.AddForce(force, FMode);//apply the force on the server side
    }

}