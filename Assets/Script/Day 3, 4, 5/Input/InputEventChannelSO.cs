using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new InputChannel", menuName = "Scriptable Objects/Channel/InputChannel")]
public class InputEventChannelSO : ScriptableObject
{
    public event Action<bool> OnAttack;
    public event Action<bool> OnJump;
    public event Action<float> OnMove;

    public virtual void RaiseMove(float vectorMovement)
    {
        OnMove?.Invoke(vectorMovement);
    }
    public virtual void RaiseJump(bool input)
    {
        OnJump?.Invoke(input);
    }
    public virtual void RaiseAttack(bool input)
    {
        OnAttack?.Invoke(input);
    }
}
