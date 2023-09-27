using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionCube : MonoBehaviour
{
    public float back = 1.0f; // Public variable for back
    public float up = 1.0f;   // Public variable for up

    private Rigidbody cubeRb;

    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
        Invoke("Launch", 2.0f);
    }

    public void Launch()
    {
        Vector3 ballDirection = Vector3.back * back + Vector3.up * up;
        cubeRb.AddForce(ballDirection.normalized * 10.5f, ForceMode.Impulse);
    }
}
