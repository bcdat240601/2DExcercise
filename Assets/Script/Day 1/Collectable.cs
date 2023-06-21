using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Collectable : SetupBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected Text quantity;
    [SerializeField] protected int maxValue;
    [SerializeField] protected int minValue;
    [SerializeField] protected int currentValue;
    public bool canBeCollected = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetSlider();
        GetText();
    }

    protected virtual void GetSlider()
    {
        if (slider != null) return;
        slider = GetComponentInChildren<Slider>();
        Debug.Log("Reset " + nameof(slider) + " in " + GetType().Name);
    }
    protected virtual void GetText()
    {
        if (quantity != null) return;
        quantity = GetComponentInChildren<Slider>()
            .transform.Find("Handle Slide Area")
            .transform.Find("Handle")
            .GetComponentInChildren<Text>();
        Debug.Log("Reset " + nameof(quantity) + " in " + GetType().Name);
    }

    protected override void ResetValue()
    {
        currentValue = 0;
        slider.value = 0;
        quantity.text = "0";
    }
    public virtual void IncreaseValue()
    {
        int startGold = 0;
        if (currentValue == 0) 
            currentValue = Random.Range(minValue, maxValue + 1);
        float sliderValue = (float)(currentValue - minValue) / maxValue;
        slider.DOValue(sliderValue, 2f).SetEase(Ease.InOutQuart)
            .OnComplete(() => canBeCollected = true);        
        DOTween.To(() => startGold, x => {
            startGold = x;
            quantity.text = startGold.ToString();
        }, currentValue, 2f);
    }
    public virtual void ResetValueUI()
    {
        slider.value = 0;
        quantity.text = "0";
    }
    public virtual void Collect()
    {
        if (!canBeCollected) return;
        int startGold = currentValue;
        canBeCollected = false;
        currentValue = 0;
        slider.DOValue(0, 2f).SetEase(Ease.InOutCirc);
        DOTween.To(() => startGold, x => {
            startGold = x;
            quantity.text = startGold.ToString();
        }, 0, 2f);
        Debug.Log("asdf");
    }
}
