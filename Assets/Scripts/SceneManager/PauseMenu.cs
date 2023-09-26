using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;

    public bool activeWristUI;

    //public XRRayInteractor rayInteractor;

    public DestroySpawn destroySpawn;


    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    public void PauseButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayWristUI();
        }
    }

    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            //rayInteractor.enabled = false;
            Time.timeScale = 1;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            //rayInteractor.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void ResetTheGame()
    {
        destroySpawn.InitializeVariables();
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneUsingName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            //rayInteractor.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void RayInteractor()
    {
        /*if(rayInteractor.enabled == true)
        {
            rayInteractor.enabled = false;
        }
        */
    }
}
