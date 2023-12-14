using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonRestart : MonoBehaviour
{

    public PauseMenu gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Invoke("RestartGame", 2.0f));
    }

    void RestartGame()
    {
        gameManager.ResetTheGame();
    }
}
