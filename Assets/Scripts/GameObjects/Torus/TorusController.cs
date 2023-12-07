using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TorusController : MonoBehaviour
{
    public GameObject[] torusArray = new GameObject[7];
    private bool[] torusActivated = new bool[7]; // Track which torus objects are activated
    private int activeTorusIndex = 0;

    public Animator centerCubeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveTorus(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all torus objects have been activated
        if (activeTorusIndex == torusArray.Length)
        {

        }
    }

    public void SetActiveTorus(int index)
    {
        // Ensure that the index is within bounds
        index = Mathf.Clamp(index, 0, torusArray.Length - 1);

        // Deactivate the previously active torus
        if (activeTorusIndex >= 0 && activeTorusIndex < torusArray.Length)
        {
            torusArray[activeTorusIndex].SetActive(false);
            torusArray[activeTorusIndex].transform.GetChild(0).gameObject.SetActive(false);
        }

        // Activate the target torus
        torusArray[index].SetActive(true);
        torusArray[index].transform.GetChild(0).gameObject.SetActive(true);

        // Update the activeTorusIndex to the new index
        activeTorusIndex = index;

        // Deactivate the tori after the target torus
        for (int i = index + 1; i < torusArray.Length; i++)
        {
            torusArray[i].SetActive(false);
            torusArray[i].transform.GetChild(0).gameObject.SetActive(false);
            if (!torusActivated[i]) // Only activate if not already activated
            {
                torusArray[i].SetActive(true);
                torusArray[i].transform.GetChild(0).gameObject.SetActive(true);
                torusActivated[i] = true;
            }
        }
    }


}
