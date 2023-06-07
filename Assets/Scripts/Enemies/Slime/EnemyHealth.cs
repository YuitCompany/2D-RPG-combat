using System.Collections;
using UnityEngine;

using BaseObject;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private GameObject DeathVFXPrefas;
    [SerializeField] private SlimeStats slimeStats;
    [SerializeField] private HealthChange healthChange;

    private KnockBack knockBack;
    private Flash flash;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
        slimeStats = GetComponentInParent<SlimeStats>();
        healthChange = GetComponentInChildren<HealthChange>();
    }

    /// <summary>
    /// Enemy Private Method
    /// </summary>
    private void DetectDeath()
    {
        if (slimeStats.Get_IntStatusSlime(ObjectProperty.health_point) <= 0) 
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
    /// TakeDamage Method
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        slimeStats.Change_StatusSlime(ObjectProperty.health_point, '-', damage);
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        healthChange.ShowTakeDamageUI(damage);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }
}
 