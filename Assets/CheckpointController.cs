using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;
    public bool isFirstCheckpoint = false;   // add this

    private void OnTriggerEnter(Collider other)
    {
        VehicleController v = other.gameObject.GetComponent<VehicleController>();
        if (v != null && this == v.target)
        {
            if (isFirstCheckpoint)           // add this check
            {
                v.CompleteLap();
            }

            v.target = next;
            next.left.materials[0].color = Color.red;
            next.right.materials[0].color = Color.red;
            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;
        }
    }
}