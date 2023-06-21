using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System;

public class CollectionUI : SetupBehaviour
{
    [SerializeField] protected CollectionPanel collectionPanel;
    [SerializeField] protected RectTransform collectionPanelTransform;
    [SerializeField] protected bool isCompleted = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCollectionPanel();
        GetRectTransform();
    }

    protected virtual void GetRectTransform()
    {
        if (collectionPanelTransform != null) return;
        collectionPanelTransform = GetComponentInChildren<CollectionPanel>().GetComponent<RectTransform>();
        Debug.Log("Reset " + nameof(collectionPanelTransform) + " in " + GetType().Name);
    }

    protected virtual void GetCollectionPanel()
    {
        if (collectionPanel != null) return;
        collectionPanel = GetComponentInChildren<CollectionPanel>();
        Debug.Log("Reset " + nameof(collectionPanel) + " in " + GetType().Name);
    }

    [ContextMenu("OpenPanelTransistion")]
    protected virtual void OpenPanel()
    {
        if (!isCompleted) return;
        collectionPanelTransform.DOAnchorPosX(0, 2f).SetEase(Ease.OutExpo)
            .OnPlay(() =>
                {
                    isCompleted = false;
                    ResetPanelPosition();
                }
            )            
            .OnComplete(() => isCompleted = true);
        collectionPanel.Coin.IncreaseValue();
        collectionPanel.Gem.IncreaseValue();
    }    
    public virtual void ClosePanel()
    {
        if (!isCompleted) return;
        collectionPanelTransform.DOAnchorPosX(1100, 2f).SetEase(Ease.OutExpo)
            .OnPlay(() =>
                {
                    isCompleted = false;
                    collectionPanel.Coin.canBeCollected = false;
                    collectionPanel.Gem.canBeCollected = false;
                }
            )
            .OnComplete(() =>
                {
                    ResetPanelPosition();
                    isCompleted = true;
                    collectionPanel.Coin.ResetValueUI();
                    collectionPanel.Gem.ResetValueUI();
                }
            );
    }
    protected virtual void ResetPanelPosition()
    {
        Debug.Log("Reset");
        collectionPanelTransform.anchoredPosition = new Vector2(-1100, collectionPanelTransform.anchoredPosition.y);
    }

}
