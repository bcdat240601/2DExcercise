using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : PlayerAbstract
{
    public virtual void EndAttack()
    {
        playerController.PlayerAttack.EndAttack();
    }
    public virtual void SetShapeIndex(int shapeIndex)
    {
        playerController.PlayerDetectTarget.SetShapeIndex(shapeIndex);
    }
    public virtual void DetectTarget()
    {
        playerController.PlayerDetectTarget.DetectTarget();
    }
    public virtual void SetPlayerIdleState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Idle);
    }
    public virtual void SetPlayerMoveState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Move);
    }
    public virtual void SetPlayerAttackState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Attack);
    }
    public virtual void SetPlayerJumpState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Jump);
    }
    public virtual void StartJump()
    {
        playerController.PlayerJump.StartJump();
    }
}
