using BaseCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeTakeDamageSource : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private bool isAttacked;

    private void Awake()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    /// <summary>
    /// OnTriggerEnter2D Method
    /// Check If The Slime Is Attacked By The Player
    /// </summary>
    /// <param name="collision">Collider Of Player</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageSource damageSource = collision.gameObject.GetComponent<DamageSource>();

        if(damageSource && !isAttacked)
        {
            isAttacked = true;
            enemyHealth.TakeDamage(collision.gameObject.GetComponent<DamageSource>().PlayerDamageSourceWithSwordAmount());
            StartCoroutine(AttackedRoutine(.2f));
        }
    }

    /// <summary>
    /// AttackedRountine Method
    /// Wait For loadTime(S) After Collider Active
    /// </summary>
    /// <param name="loadTime"></param>
    /// <returns>IEnumerator</returns>
    private IEnumerator AttackedRoutine(float loadTime)
    {
        // Before Delay Time Code
        yield return new WaitForSeconds(loadTime);
        // After Delay Time Code
        isAttacked = false;
    }
}
