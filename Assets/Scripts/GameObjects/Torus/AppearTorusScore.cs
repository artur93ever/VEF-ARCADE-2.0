using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTorusScore : MonoBehaviour
{
    public int torusIndex;
    public GameObject torusController;

    private bool triggered = false; // New variable to track if the torus has been triggered

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerCube" && !triggered)
        {
            Debug.Log("Torus " + torusIndex + " triggered!");
            triggered = true; // Set the trigger flag to true
            torusController.GetComponent<TorusController>().SetActiveTorus(torusIndex + 1);
        }
    }
}
