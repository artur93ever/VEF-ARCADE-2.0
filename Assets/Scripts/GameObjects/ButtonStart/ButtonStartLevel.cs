using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonStartLevel : MonoBehaviour
{
    //public GameObject gravityCenter;
    public Animator startbuttonAnimator;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ActiveGravityCenter());
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TriggerAnim());
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => StartCoroutine(ExitAnimWithDelay()));
        //gravityCenter.SetActive(false);
    }

    public void ActiveGravityCenter()
    {
        //gravityCenter.SetActive(true);
    }

    IEnumerator ExitAnimWithDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        ExitAnim(); // Then play the ExitAnim
    }

    public void ExitAnim()
    {
        startbuttonAnimator.Play("startbutton_exit");
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject); // Destroy the parent object
    }

    public void TriggerAnim()
    {
        handAnimator.SetTrigger("startpositionTransition");
    }
}
