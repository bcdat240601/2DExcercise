using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyDetectTarget : DetectTargetByTriggerStay
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected Timer timer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
    }

    protected virtual void GetEnemyController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + nameof(enemyController) + " in " + GetType().Name);
    }
    protected override bool ConditionToDetect(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return false;
        if (!timer.CheckTimer()) return false;
        return base.ConditionToDetect(collision);
    }

    protected override void BeginSendingDamage(Transform target)
    {
        enemyController.EnemyDamageSender.SendDamage(target,10);
        timer.SetCooldownTime(1f);
    }
}
