using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAttack : PlayerAbstract
{
    [SerializeField] protected bool inputAttack;
    public bool InputAttack => inputAttack;
    [SerializeField] protected int _numberOfAttack = 2;
    [SerializeField] protected int currentIndexAttack;
    [SerializeField] protected Timer timerForAttackCombo;
    [SerializeField] protected Timer timerForDelayAttack;
    [SerializeField] protected PlayerState.State playerState = PlayerState.State.Attack;
    [SerializeField] protected int attackSpeed = 1;
    [SerializeField] protected Timer timerForBuffDuration;
    public int CurrentIndexAttack
    {
        get => currentIndexAttack;
        set { currentIndexAttack = value == _numberOfAttack ? 0 : value; }
    }

    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnAttack += SetAttack;
    }

    protected virtual void SetAttack(bool inputAttack)
    {
        this.inputAttack = inputAttack;
    }
    protected virtual void Update()
    {
        Attack();
        CheckBuff();
    }
    public virtual void SetAttackSpeed(int attackSpeed, float duration)
    {
        this.attackSpeed = attackSpeed;
        timerForBuffDuration.SetCooldownTime(duration);
    }
    protected virtual void CheckBuff()
    {
        if (attackSpeed == 1) return;
        if (!timerForBuffDuration.CheckTimer()) return;
        attackSpeed = 1;

    }

    protected virtual void Attack()
    {        
        if (!inputAttack) return;
        if (!timerForDelayAttack.CheckTimer()) return;
        ResetTimer();
        playerController.Animator.SetInteger("attackIndex", currentIndexAttack);
        playerController.Animator.SetTrigger("attack");
        playerController.Animator.SetFloat("attackSpeed", attackSpeed);
        timerForAttackCombo.SetCooldownTime(3f);
        timerForDelayAttack.SetCooldownTime(1.2f);
    }
    public virtual void EndAttack()
    {
        CurrentIndexAttack++;
    }
    protected virtual void ResetTimer()
    {
        if (timerForAttackCombo.CheckTimer())
        {
            currentIndexAttack = 0;
        }
    }
}
