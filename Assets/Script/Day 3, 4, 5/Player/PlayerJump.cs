using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerJump : PlayerAbstract
{
    [SerializeField] protected bool inputJump;
    [SerializeField] protected Timer timer;
    [SerializeField] protected float height = 3f;
    [SerializeField] protected PlayerState.State playerState = PlayerState.State.Jump;
    [SerializeField] protected bool groundCheck;
    [SerializeField] protected Transform ground;
    [SerializeField] protected LayerMask layerMask;
    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnJump += DetectJump;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetGround();
        GetLayerMask();
    }

    protected virtual void GetLayerMask()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    protected virtual void GetGround()
    {
        if (ground != null) return;
        ground = transform.GetChild(0).transform;
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(ground));
    }

    protected virtual void DetectJump(bool inputJump)
    {
        this.inputJump = inputJump;
    }
    protected virtual void Update()
    {
        GroundCheck();
    }
    protected virtual void FixedUpdate()
    {
        Jump();
    }
    public virtual void StartJump()
    {
        transform.parent.DOMoveY(transform.parent.position.y + height, 0.25f).SetEase(Ease.OutQuad);
        //float startHeight = playerController.PlayerRigidBody.velocity.y;
        //DOTween.To(() => startHeight, x => 
        //{
        //    startHeight = x;
        //    playerController.PlayerRigidBody.velocity = new Vector2(playerController.PlayerRigidBody.velocity.x , startHeight);
        //} , height, 0.1f).SetEase(Ease.InQuad);
    }
    protected virtual void GroundCheck()
    {
        groundCheck = Physics2D.OverlapCircle(ground.position, 0.1f, layerMask);
    }
    protected virtual void Jump()
    {
        if (!inputJump) return;
        if (!groundCheck) return;
        if (!timer.CheckTimer()) return;
        //playerController.PlayerRigidBody.MovePosition(transform.parent.position + Vector3.up * Time.fixedDeltaTime * height);
        //playerController.PlayerRigidBody.velocity = new Vector2(playerController.PlayerRigidBody.velocity.x, height);
        playerController.Animator.SetTrigger("jump");
        timer.SetCooldownTime(1.4f);
    }
    private void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ground.position, 0.1f);
        }
    }
}
