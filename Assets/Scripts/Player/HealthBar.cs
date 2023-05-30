using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BaseCharacter;
using Unity.VisualScripting;

public class HealthBar : Singleton <HealthBar>
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Gradient gradientHealthColor;
    [SerializeField] private Image fillColorHealth;

    private void Awake()
    {
        sliderHealth = GetComponent<Slider>();
    }

    private void Start()
    {
        SetMaxHealthBar();
    }

    private void FixedUpdate()
    {
        SetPresentHealthBar();
    }

    private void SetMaxHealthBar()
    {
        sliderHealth.maxValue = PlayerController.Instance.playerInfo.Get_IntProperty(PlayerProperty.max_health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(1f);
    }

    public void SetPresentHealthBar()
    {
        sliderHealth.value = PlayerController.Instance.playerInfo.Get_IntProperty(PlayerProperty.health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(sliderHealth.normalizedValue);
    }
}
