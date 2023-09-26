using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody), typeof(XRGrabInteractable))]
public class PlayerCubeEnabledAttractor : MonoBehaviour
{
    [Header("Force Settings")]
    public float ballForce = 5.0f;
    public float forceDuration = 0.2f;

    [Header("References")]

    private Rigidbody rb;
    private XRGrabInteractable interactable;
    private float forceTimer = 0.0f;
    private bool caught = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);

    }

    private void Update()
    {
        if (caught)
        {
            if (forceTimer <= forceDuration)
            {
                ApplyForce();
                forceTimer += Time.deltaTime;
            }
            else
            {
                caught = false;
                forceTimer = 0.0f;
            }
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        UnityEngine.Debug.Log("Grabbed");
    }

    private void ApplyForce()
    {
        Vector3 coneDirection = Vector3.right;
        rb.AddForce(coneDirection.normalized * ballForce, ForceMode.Impulse);
    }
}
