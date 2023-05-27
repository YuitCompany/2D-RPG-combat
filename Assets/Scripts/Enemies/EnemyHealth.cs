using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth { set { maxHealth = value; } get { return MaxHealth; } }
    public int CurrentHealth { set { currentHealth = value; } get { return currentHealth; } }

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject DeathVFXPrefas;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;

    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Enemy Private Method
    /// </summary>
    private void DetectDeath()
    {
        if (currentHealth <= 0) 
        {
            Instantiate(DeathVFXPrefas, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// public method
    /// </summary>
    private IEnumerator CheckDetectDeathRoutine()
    {
        // feature code
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    /// <summary>
    /// Enemy Public Method
    /// </summary>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }
}
 