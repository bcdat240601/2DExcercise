using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectable
{
    protected override void Awake()
    {
        base.Awake();
        maxValue = 6000;
        minValue = 1000;
    }
}
