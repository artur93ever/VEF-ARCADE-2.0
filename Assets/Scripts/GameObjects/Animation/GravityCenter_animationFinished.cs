using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCenter_animationFinished : MonoBehaviour
{
    public GameObject torusTutorial;
    public GameObject torusLevel;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        torusTutorial.SetActive(false);
    }

    // This method will be called when the animation event is triggered.
    public void OnAnimationFinished_Active()
    {
        torusTutorial.SetActive(true);
    }

    public void OnAnimationFinished_Destroy()
    {
        Destroy(this.gameObject);
    }

    // This method will be called when the animation event is triggered.
    public void OnAnimationFinished_Active2()
    {
        torusLevel.SetActive(true);
    }

    public void TriggerAnimation()
    {
        handAnimator.SetTrigger("coneThrow");
    }
}
