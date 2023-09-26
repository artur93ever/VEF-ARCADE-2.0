using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonStartLevel : MonoBehaviour
{
    public GameObject gravityCenter;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ActiveGravityCenter());
        gravityCenter.SetActive(false);
    }

    public void ActiveGravityCenter()
    {
        gravityCenter.SetActive(true);
    }
}
