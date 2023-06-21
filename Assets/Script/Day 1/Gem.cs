using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Collectable
{
    protected override void Awake()
    {
        base.Awake();
        maxValue = 100;
        minValue = 20;
    }
}
