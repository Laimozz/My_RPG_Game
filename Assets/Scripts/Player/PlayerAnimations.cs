using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int runState = Animator.StringToHash("RunState");
    private readonly int jumpState = Animator.StringToHash("JumpState");
    private readonly int deadState = Animator.StringToHash("DeadState");
    private readonly int reviveState = Animator.StringToHash("ReviveState");
    private readonly int attackNormal = Animator.StringToHash("AttackNormal");
    private readonly int attackBuff = Animator.StringToHash("AttackBuff");

    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void RunState(bool value)
    {
        playerAnimator.SetBool(runState, value);
    }

    public void JumpState()
    {
        playerAnimator.SetTrigger(jumpState);
    }

    public void DeadState()
    {
        playerAnimator.SetTrigger(deadState);
    }

    public void ReviveState()
    {
        playerAnimator.SetTrigger(reviveState);
    }

    public void AttackNormal()
    {
        playerAnimator.SetTrigger(attackNormal);
    }
    public void AttackBuff()
    {
        playerAnimator.SetTrigger(attackBuff);      
    }
}
