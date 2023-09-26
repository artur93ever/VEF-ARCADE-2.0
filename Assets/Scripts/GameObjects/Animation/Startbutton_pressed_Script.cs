using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbutton_pressed_Script : MonoBehaviour
{
    private Animator animator;
    private Animator startButtonAnimator;
    public GameObject startButton;
    //public GameObject gravityCenter;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startButtonAnimator = startButton.GetComponent<Animator>();
        //gravityCenter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("Start Button Pressed");
            animator.Play("startbutton_pressedAnim");
            //gravityCenter.SetActive(true);
            StartCoroutine(ExitStartButton()); // Move this line inside the if block
        }
    }

    IEnumerator ExitStartButton()
    {
        yield return new WaitForSeconds(2f);
        startButtonAnimator.Play("startbutton_startbutton_exitAnim");
        yield return new WaitForSeconds(3f);
        Destroy(startButton.gameObject);
    }
}
