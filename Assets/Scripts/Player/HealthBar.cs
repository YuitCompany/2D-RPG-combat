using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Singleton <HealthBar>
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Gradient gradientHealthColor;
    [SerializeField] private Image fillColorHealth;

    private void Start()
    {
        SetMaxHealthBar();
    }

    private void Update()
    {
        SetPresentHealthBar();
    }

    private void SetMaxHealthBar()
    {
        sliderHealth.maxValue = PlayerController.Instance.PlayerMaxHealth;
        fillColorHealth.color = gradientHealthColor.Evaluate(1f);
    }

    public void SetPresentHealthBar()
    {
        sliderHealth.value = PlayerController.Instance.PlayerPresentHealth;
        fillColorHealth.color = gradientHealthColor.Evaluate(sliderHealth.normalizedValue);
    }
}
