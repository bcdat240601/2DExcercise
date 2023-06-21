using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : SetupBehaviour, IDamageable
{
    [Header("DamageReceiver")]
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected HealthBarHolder healthBarHolder;
    public bool isDead;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetHealthBarHolder();
    }
    protected virtual void Start()
    {        
        Transform healthbar = HealthBarSpawner.Instance.Spawn("HealthBar", healthBarHolder.transform.position, Quaternion.identity);
        healthbar.TryGetComponent<HealthBarController>(out HealthBarController healthBarController);
        healthBarHolder.healthBarController = healthBarController;
    }
    protected virtual void UpdateHealthBar()
    {
        healthBarHolder.healthBarController.HealthBarForEnemy.UpdateHealthBarUI(currentHealth, maxHealth);
    }

    protected virtual void GetHealthBarHolder()
    {
        if (healthBarHolder != null) return;
        healthBarHolder = GetComponentInChildren<HealthBarHolder>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarHolder));
    }

    protected override void ResetValue()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }
    protected virtual void OnEnable()
    {
        Reborn();
    }
    protected virtual void Reborn()
    {
        isDead = false;
        //for override
    }
    public virtual void Healing(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public virtual void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        //float offset = DamageSpawner.Instance.GetRandomOffsetPosition(0.5f, 1.5f);
        //DamageSpawner.Instance.Spawn("DamagePopup", transform.parent.position + Vector3.up * offset, Quaternion.identity, amount.ToString());
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDead();
        }
        UpdateHealthBar();
        PushingBack();
    }
    protected virtual void OnDead()
    {
        HealthBarSpawner.Instance.Despawn(healthBarHolder.healthBarController.transform);
        isDead = true;
        //for override
    }
    public virtual void TurnOffAnimationHurt()
    {
        //for override
    }

    protected virtual void PushingBack()
    {
        //for override
    }
}