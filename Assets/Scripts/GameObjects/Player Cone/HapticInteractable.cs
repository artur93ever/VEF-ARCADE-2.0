using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]

public class Haptic
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    public void TriggerHaptics(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptics(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptics(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}

public class HapticInteractable : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExit;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptics);

        interactable.hoverEntered.AddListener(hapticHoverEntered.TriggerHaptics);
        interactable.hoverExited.AddListener(hapticHoverExited.TriggerHaptics);
        interactable.selectEntered.AddListener(hapticSelectEntered.TriggerHaptics);
        interactable.selectExited.AddListener(hapticSelectExit.TriggerHaptics);
    }
}
