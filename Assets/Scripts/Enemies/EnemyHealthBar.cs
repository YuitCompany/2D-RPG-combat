using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Gradient gradientHealthColor;
    [SerializeField] private Image fillColorHealth;

    [SerializeField] private EnemyHealth enemyHealth;

    // Unity System Method
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        SetMaxHealthBar();
    }

    private void Update()
    {
        SetPresentHealthBar();
    }

    // Private Method
    private void SetMaxHealthBar()
    {
        sliderHealth.maxValue = enemyHealth.MaxHealth;
        fillColorHealth.color = gradientHealthColor.Evaluate(1f);
    }

    // Public Method
    public void SetPresentHealthBar()
    {
        sliderHealth.value = enemyHealth.CurrentHealth;
        fillColorHealth.color = gradientHealthColor.Evaluate(sliderHealth.normalizedValue);
    }
}
