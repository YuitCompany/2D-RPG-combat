using UnityEngine;
using UnityEngine.UI;

using BaseObject;

public class HealthBar : Singleton <HealthBar>
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Gradient gradientHealthColor;
    [SerializeField] private Image fillColorHealth;
    
    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        SetMaxHealthBar();
    }

    private void FixedUpdate()
    {
        SetPresentHealthBar();
    }

    /// <summary>
    /// SetMaxHealthBar Method
    /// set Slider.maxValue = Player.max_health
    /// set Color.color = Gradient.Evaluate With 1f
    /// </summary>
    private void SetMaxHealthBar()
    {
        sliderHealth.maxValue = playerStats.Get_IntStatusPlayer(ObjectProperty.max_health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(1f);
    }

    /// <summary>
    /// SetPresentHealthBar Method
    /// set Slider.value = Player.health
    /// set Color.color = Gradient.Evaluate With Slider
    /// </summary>
    public void SetPresentHealthBar()
    {
        sliderHealth.value = playerStats.Get_IntStatusPlayer(ObjectProperty.health_point);
        fillColorHealth.color = gradientHealthColor.Evaluate(sliderHealth.normalizedValue);
    }
}
