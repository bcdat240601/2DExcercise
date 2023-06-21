using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : SetupBehaviour
{
    [SerializeField] protected Transform _target;
    public Transform target { get => _target; set { _target = value; } }
    protected virtual void FixedUpdate()
    {
        if (IsHavingTarget())
            FollowingTarget();
    }
    protected virtual bool IsHavingTarget()
    {
        if (_target == null) return false;
        return true;
    }
    protected virtual void FollowingTarget()
    {
        transform.parent.position = _target.position;
    }
    public virtual void RemoveTarget()
    {
        target = null;
    }
}