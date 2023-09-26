using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject spawner;
    public GameObject torusParent1;
    public GameObject torusParent2;

    public bool torus1Destroy = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Resets the scene
    public void ResetTheGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working.");
    }

    public void NextLevel()
    {
        torus1Destroy = true;
        DestroyImmediate(torusParent1, true);
        GameObject newCube = Instantiate(torusParent2, spawner.transform.position, Quaternion.identity);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
