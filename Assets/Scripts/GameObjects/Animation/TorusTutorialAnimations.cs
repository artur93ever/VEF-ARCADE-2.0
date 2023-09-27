using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusTutorialAnimations : MonoBehaviour
{
    public GameObject torusParent;
    public Animator handAnimator;

    public void TriggerAnimation()
    {
        handAnimator.Play("hand-coneThrow");
    }

    public void TorusParentActive()
    {
        torusParent.SetActive(true);
    }

    public void DestroyTorus()
    {
        Destroy(this.gameObject);
    }
}
