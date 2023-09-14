using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : StateMachineBehaviour
{


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Jump");
    }


}
