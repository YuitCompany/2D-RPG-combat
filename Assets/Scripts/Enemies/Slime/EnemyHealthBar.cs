using BaseMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private SlimeStats slimeStats;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Gradient gradientHealthColor;
    [SerializeField] private Image fillColorHealth;

    // Unity System Method
    private void Awake()
    {
        slimeStats = GetComponentInParent<SlimeStats>();
    }

    private void Start()
    {
        SetMaxHealthBar();
    }

    private void Update()
    {
        SetPresentHealthBar();
    }

    /// <summary>
    /// SetMaxHealthBar Method
    /// set Slider.maxValue = slime.max_health
    /// set Color.color = Gradient.Evaluate With 1f
    /// </summary>
    private void SetMaxHealthBar()
    {
        sliderHealth.maxValue = (float)slimeStats.Get_IntStatusSlime(MonsterProperty.max_health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(1f);
    }

    /// <summary>
    /// SetPresentHealthBar Method
    /// set Slider.value = Slime.health
    /// set Color.color = Gradient.Evaluate With Slider
    /// </summary>
    public void SetPresentHealthBar()
    {
        sliderHealth.value = (float)slimeStats.Get_IntStatusSlime(MonsterProperty.health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(sliderHealth.normalizedValue);
    }
}
