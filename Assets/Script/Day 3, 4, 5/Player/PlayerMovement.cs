using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float moveValue;
    [SerializeField] protected float moveValueTarget;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float speedChangeRate = 0.5f;
    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnMove += SetMoveDirection;
    }
    
    protected virtual void FixedUpdate()
    {
        Moving();
    }
    protected virtual void SetMoveDirection(float inputMovement)
    {
        moveValueTarget = inputMovement;
        

    }

    protected virtual void Moving()
    {
        PlayerFacing();
        if (moveValueTarget == 0)
            moveValue = 0;
        else
            moveValue = Mathf.Lerp(moveValue, moveValueTarget, speedChangeRate * Time.fixedDeltaTime);
        playerController.Animator.SetFloat("walk", MagnitudeMoveValue());
        float currentSpeed = (Vector3.right * playerController.PlayerRigidBody.velocity.x).magnitude;        
        //playerController.PlayerRigidBody.MovePosition(transform.parent.position + new Vector3(moveValue, 0, 0) * speed * Time.fixedDeltaTime);
        playerController.PlayerRigidBody.velocity = new Vector2(moveValue * speed * Time.fixedDeltaTime, playerController.PlayerRigidBody.velocity.y);        
    }
    protected virtual void PlayerFacing()
    {
        if (moveValue == 0) return;
        if (moveValue > 0)
            transform.parent.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.parent.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    protected virtual float MagnitudeMoveValue()
    {
        if (moveValue > 0)
            return moveValue;
        return moveValue * -1;
    }
}
