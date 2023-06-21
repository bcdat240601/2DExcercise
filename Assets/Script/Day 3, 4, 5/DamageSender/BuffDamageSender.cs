using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDamageSender : DamageSender
{
    [SerializeField] protected BuffController buffController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetBuffController();
    }

    protected virtual void GetBuffController()
    {
        if (buffController != null) return;
        buffController = GetComponentInParent<BuffController>();
        Debug.Log("Reset " + nameof(buffController) + " in " + GetType().Name);
    }

    public override void SendDamage(Transform gameObject, int amount)
    {
        IBuffReceiver buffObject = gameObject.GetComponent<IBuffReceiver>();
        if (buffObject == null) return;
        SendDamage(buffObject, amount);
    }
    protected virtual void SendDamage(IBuffReceiver damageableObject, int amount)
    {
        float duration = 0;
        if (buffController.BuffType == BuffType.AttackSpeed)
            duration = 10f;
        damageableObject.ReceiveBuff(amount, buffController.BuffType, duration);
        Destroy(transform.parent.gameObject);
    }
}
