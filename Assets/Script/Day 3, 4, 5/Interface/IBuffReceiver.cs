using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffReceiver
{
    public void ReceiveBuff(int amount, BuffType buffType, float duration);
}
public enum BuffType
{
    Healing,
    AttackSpeed
}
