using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SetupBehaviour
{
    [SerializeField] protected InputEventChannelSO inputEventChannelSO;
    public InputEventChannelSO InputEventChannelSO => inputEventChannelSO;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected Rigidbody2D playerRigidBody;
    public Rigidbody2D PlayerRigidBody => playerRigidBody;
    [SerializeField] protected PlayerAttack playerAttack;
    public PlayerAttack PlayerAttack => playerAttack;
    [SerializeField] protected PlayerDetectTarget playerDetectTarget;
    public PlayerDetectTarget PlayerDetectTarget => playerDetectTarget;
    [SerializeField] protected PlayerDamageSender playerDamageSender;
    public PlayerDamageSender PlayerDamageSender => playerDamageSender;
    [SerializeField] protected PlayerState playerState;
    public PlayerState PlayerState => playerState;
    [SerializeField] protected PlayerJump playerJump;
    public PlayerJump PlayerJump => playerJump;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetInputChannel();
        GetAnimator();
        GetRigidBody();
        GetPlayerAttack();
        GetPlayerDetectTarget();
        GetPlayerDamageSender();
        GetPlayerState();
        GetPlayerJump();
    }

    protected virtual void GetPlayerJump()
    {
        if (playerJump != null) return;
        playerJump = GetComponentInChildren<PlayerJump>();
        Debug.Log("Reset " + nameof(playerJump) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerState()
    {
        if (playerState != null) return;
        playerState = GetComponentInChildren<PlayerState>();
        Debug.Log("Reset " + nameof(playerState) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerDamageSender()
    {
        if (playerDamageSender != null) return;
        playerDamageSender = GetComponentInChildren<PlayerDamageSender>();
        Debug.Log("Reset " + nameof(playerDamageSender) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerDetectTarget()
    {
        if (playerDetectTarget != null) return;
        playerDetectTarget = GetComponentInChildren<PlayerDetectTarget>();
        Debug.Log("Reset " + nameof(playerDetectTarget) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerAttack()
    {
        if (playerAttack != null) return;
        playerAttack = GetComponentInChildren<PlayerAttack>();
        Debug.Log("Reset " + nameof(playerAttack) + " in " + GetType().Name);
    }

    protected virtual void GetRigidBody()
    {
        if (playerRigidBody != null) return;
        playerRigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("Reset " + nameof(playerRigidBody) + " in " + GetType().Name);
    }

    protected virtual void GetAnimator()
    {
        if (animator != null) return;
        animator = GetComponentInChildren<Animator>();
        Debug.Log("Reset " + nameof(animator) + " in " + GetType().Name);
    }

    protected virtual void GetInputChannel()
    {
        if (inputEventChannelSO != null) return;
        string resoucesPath = "Channel/InputEventChannel";
        inputEventChannelSO = Resources.Load<InputEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(inputEventChannelSO));
    }
}
