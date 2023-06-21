using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarHolder : SetupBehaviour
{
    [SerializeField] protected HealthBarController _healthBarController;
    public HealthBarController healthBarController { get => _healthBarController; set { _healthBarController = value; } }

    protected virtual void FixedUpdate()
    {
        GetConnection();
    }
    protected virtual void GetConnection()
    {
        if (healthBarController == null) return;
        if (healthBarController.HealthBarFollowTarget.target != null) return;
        healthBarController.HealthBarFollowTarget.target = transform;
    }
}