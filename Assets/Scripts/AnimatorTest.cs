using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;
    public string flyTrigger = "FlyBool";
    public KeyCode keyToTrigger = KeyCode.A;
    public KeyCode keyToExitTrigger = KeyCode.S;

    private void OnValidate() {
        if(animator == null) animator = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown(keyToTrigger)){
            animator.SetBool(flyTrigger, true);
        }else if(Input.GetKeyDown(keyToExitTrigger)){
            animator.SetBool(flyTrigger, false);

        }
    }


}
