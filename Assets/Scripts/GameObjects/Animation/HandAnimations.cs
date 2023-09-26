using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimations : MonoBehaviour
{
    public GameObject gravityCenter;
    public GameObject playerCone;

    public void GravityActive()
    {
        gravityCenter.SetActive(true);
    }

    public void PlayerConeActive()
    {
        playerCone.SetActive(true);
    }
}
