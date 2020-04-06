using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Move";
    const string FIRE_STATE = "Fire";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("IDLE STATE");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (InputManager.Instance.IsMoving())
        {
            animator.SetTrigger(MOVE_STATE);
        }
        else if (EnemyManager.Instance.EnemyExists())
        {
            //Debug.Log("GOING TO FIRE FROM IDLE");
            animator.SetTrigger(FIRE_STATE);
        }

    }
}
