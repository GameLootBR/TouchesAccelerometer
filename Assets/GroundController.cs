using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    AccelerationManager accelerationManager;
    void Start()
    {
        accelerationManager = FindObjectOfType<AccelerationManager>();
    }

    void Update()
    {
        Vector3 accel = accelerationManager.acceleration;
        transform.eulerAngles = accel*45;
    }
}
