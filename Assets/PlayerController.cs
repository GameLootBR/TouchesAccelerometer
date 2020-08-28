using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rbody.AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }
}
