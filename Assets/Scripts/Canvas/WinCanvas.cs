using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WinCanvas : MonoBehaviour
{
    public GameObject canvasWin;
    //public XRRayInteractor rayInteractor;
    public ScoreSystem scoreSystem; // Add this line

    void Start()
    {
        //rayInteractor.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerCube")
        {
            canvasWin.SetActive(true);
            //rayInteractor.enabled = true;

            scoreSystem.countingAllowed = false; // Disable counting
        }
    }
}
