using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{
    public float impulse = 10f;
    public float turnrate = 200f;
    public CheckpointController target;
    public TextMeshProUGUI timelbl;
    public TextMeshProUGUI laplbl;        // add this
    public CheckpointController firstCheckpoint;  // add this

    float desired_acceleration;
    float desired_strafe;
    float starttime;
    int lapCount = 0;                     // add this

    void Start()
    {
        starttime = Time.time;
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
        desired_strafe = movement.x;
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(-desired_acceleration * impulse, 0, 0);
        rb.AddRelativeForce(0, 0, desired_strafe * impulse);

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        if (timelbl != null)
        {
            timelbl.text = string.Format("Time: {0:F2}s", Time.time - starttime);
        }

        if (laplbl != null)
        {
            laplbl.text = "Lap: " + lapCount;
        }
    }

    public void CompleteLap()          // add this whole method
    {
        lapCount++;
        starttime = Time.time;
    }
}