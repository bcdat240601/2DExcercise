using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyController : SetupBehaviour
{
    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;
    [SerializeField] protected Rigidbody2D enemyRigidBody;
    public Rigidbody2D EnemyRigidBody => enemyRigidBody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyDamageSender();
        GetEnemyRigidBody();
    }

    protected virtual void GetEnemyDamageSender()
    {
        if (enemyDamageSender != null) return;
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        Debug.Log("Reset " + nameof(enemyDamageSender) + " in " + GetType().Name);
    }
    protected virtual void GetEnemyRigidBody()
    {
        if (enemyRigidBody != null) return;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("Reset " + nameof(enemyRigidBody) + " in " + GetType().Name);
    }
}
