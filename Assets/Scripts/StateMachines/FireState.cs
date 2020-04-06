using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Move";
    const string IDLE_STATE = "Idle";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("FIRE STATE");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (InputManager.Instance.IsMoving())
        {
            animator.SetTrigger(MOVE_STATE);
        }
        else
        {
            if (EnemyManager.Instance.EnemyExists())
            {
                PlayerManager.Instance.Fire();
            }
            else
            {
                animator.SetTrigger(IDLE_STATE);
            }
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // this is where you make it look at the target
    }
}
