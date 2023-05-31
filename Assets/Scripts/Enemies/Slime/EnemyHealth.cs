using BaseMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private GameObject DeathVFXPrefas;
    [SerializeField] private SlimeStats slimeStats;

    private KnockBack knockBack;
    private Flash flash;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
        slimeStats = GetComponentInParent<SlimeStats>();
    }

    /// <summary>
    /// Enemy Private Method
    /// </summary>
    private void DetectDeath()
    {
        if (slimeStats.Get_IntStatusSlime(MonsterProperty.health_point) <= 0) 
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
        yield return new WaitForSeconds(flash.RestoreDefaultMatTime);
        DetectDeath();
    }

    /// <summary>
    /// Enemy Public Method
    /// </summary>
    public void TakeDamage(int damage)
    {
        slimeStats.Change_StatusSlime(MonsterProperty.health_point, '-', damage);
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }
}
 