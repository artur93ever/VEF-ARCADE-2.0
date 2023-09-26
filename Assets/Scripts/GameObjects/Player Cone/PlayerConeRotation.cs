using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRGrabInteractable))]
public class PlayerConeRotation : MonoBehaviour
{
    public Transform centerCube;
    public Collider torusCollider;

    private XRGrabInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        torusCollider.enabled = false;
    }

    void Update()
    {
        Vector3 lookDirection = centerCube.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, transform.up);
        transform.rotation = rotation;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        torusCollider.enabled = true;
    }
}
