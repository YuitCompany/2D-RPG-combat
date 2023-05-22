using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int defaultHealth = 3;

    private int currentHealth;
    private KnockBack knockBack;

    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
    }
    private void Start()
    {
        currentHealth = defaultHealth;
    }

    /// <summary>
    /// Enemy Private Method
    /// </summary>
    private void DetectDeath()
    {
        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Enemy Public Method
    /// </summary>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform, 15f);
        DetectDeath();
    }
}
