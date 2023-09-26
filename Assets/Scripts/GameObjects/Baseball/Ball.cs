using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public Attractor attractor; // Reference to the Attractor script
    public float ballForce = 5.0f;
    public float ballUp = 0.2f;
    public float ballLeft = 0.2f;
    public float forceDuration = 0.5f; // Duration to apply force after collision

    private bool ballHit = false;
    private float forceTimer = 0.0f;

    void Start()
    {
        Invoke("Launch", 5.0f);
        //Launch();
        attractor.enabled = false;
    }

    void Update()
    {
        /*if (ballHit)
        {
            if (forceTimer <= forceDuration)
            {
                ApplyForce();
                forceTimer += Time.deltaTime;
            }
            else
            {
                ballHit = false;
                forceTimer = 0.0f;
            }
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baseball")
        {
            UnityEngine.Debug.Log("Hit");
            ballHit = true;
            attractor.enabled = true; // Enable the Attractor script
        }
    }

    public void ApplyForce()
    {
        Vector3 ballDirection = Vector3.forward + Vector3.up * ballUp + Vector3.left * ballLeft;
        ballRigidbody.AddForce(ballDirection.normalized * ballForce, ForceMode.Impulse);
    }

    public void Launch()
    {
        Vector3 ballDirection = Vector3.back + Vector3.up * 1f; // Use Vector3.back instead of Vector3.backwards
        ballRigidbody.AddForce(ballDirection.normalized * 10.5f, ForceMode.Impulse);
    }
}
