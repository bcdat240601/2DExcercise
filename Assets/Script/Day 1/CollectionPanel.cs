using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPanel : SetupBehaviour
{
    [SerializeField] protected Gold coin;
    public Collectable Coin => coin;
    [SerializeField] protected Gem gem;
    public Collectable Gem => gem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCoin();
        GetGem();
    }
    protected virtual void GetCoin()
    {
        if (coin != null) return;
        coin = GetComponentInChildren<Gold>();
        Debug.Log("Reset " + nameof(coin) + " in " + GetType().Name);
    }
    protected virtual void GetGem()
    {
        if (gem != null) return;
        gem = GetComponentInChildren<Gem>();
        Debug.Log("Reset " + nameof(gem) + " in " + GetType().Name);
    }
    public virtual void Collect()
    {
        coin.Collect();
        gem.Collect();
    }
}
