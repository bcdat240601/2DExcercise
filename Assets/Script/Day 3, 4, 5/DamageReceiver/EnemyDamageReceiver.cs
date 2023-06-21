using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHealth = 50;
        currentHealth = maxHealth;
    }
    protected override void Reborn()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
    }
    protected override void OnDead()
    {
        base.OnDead();
        Destroy(transform.parent.gameObject);
    }
    protected override void PushingBack()
    {
        Vector3 direction = transform.parent.position - FindObjectOfType<PlayerController>().transform.position;
        direction = direction.normalized * 1;
        transform.parent.position += direction;
    }
}
