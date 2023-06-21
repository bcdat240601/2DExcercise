using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : SetupBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected float distanceToMove;
    [SerializeField] protected EnemyDirection direction;
    [SerializeField] protected float speed = 2f;
    public enum EnemyDirection
    {
        Left,
        Right
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
    }

    protected virtual void GetEnemyController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(enemyController));
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if(distanceToMove <= 0)
        {
            GetDirection();
            distanceToMove = UnityEngine.Random.Range(3, 11);
        }
        if(direction == EnemyDirection.Left)
            enemyController.EnemyRigidBody.MovePosition(transform.parent.position + Vector3.left * Time.fixedDeltaTime * speed);
        else
            enemyController.EnemyRigidBody.MovePosition(transform.parent.position + Vector3.right * Time.fixedDeltaTime * speed);
        distanceToMove -= Time.fixedDeltaTime * speed;

    }
    protected virtual void GetDirection()
    {
        if (distanceToMove > 0) return;
        if (direction == EnemyDirection.Left)
            direction = EnemyDirection.Right;
        else
            direction = EnemyDirection.Left;
    }
}
