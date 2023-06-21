using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDamageReceiver : DamageReceiver, IBuffReceiver
{
    [Header("PlayerDamageReceiver")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCharacterController();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    protected override void Reborn()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    public override void Healing(int amount)
    {
        base.Healing(amount);
        playerController.Animator.SetTrigger("heal");
        UpdateHealthBar();
    }
    public override void TakeDamage(int amount)
    {        
        base.TakeDamage(amount);
        playerController.Animator.SetTrigger("hit");
    }    

    protected virtual void GetCharacterController()
    {
        if (playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(playerController));
    }
    protected virtual void AttackSpeedBoost(int amount, float duration)
    {
        playerController.Animator.SetTrigger("attackSpeedBoost");
        playerController.PlayerAttack.SetAttackSpeed(amount, duration);
    }

    public void ReceiveBuff(int amount, BuffType buffType, float duration)
    {
        if(buffType == BuffType.Healing)
            Healing(amount);
        else
            AttackSpeedBoost(amount, duration);
    }
}