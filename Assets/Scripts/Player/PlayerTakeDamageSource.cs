using BaseCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTakeDamageSource : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private HealthChange healthChange;

    private bool isAttacked;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        healthChange = GetComponentInChildren<HealthChange>();
    }

    /// <summary>
    /// OnTriggerEnter2D Method
    /// Check If The Slime Is Attacked By The Player
    /// </summary>
    /// <param name="collision">Collider Of Player</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SlimeDamageSource damageSource = collision.gameObject.GetComponent<SlimeDamageSource>();

        if (damageSource && !isAttacked)
        {
            isAttacked = true;
            collision.gameObject.GetComponent<SlimeDamageSource>().DoneAttacked();
            PlayerTakeDamage(collision.gameObject.GetComponent<SlimeDamageSource>().SlimeDamageSourceAmount());
            StartCoroutine(WaitForGetDamageRoutine(damageSource, .5f));
        }
    }

    private void PlayerTakeDamage(int damage)
    {
        playerStats.Change_StatusPlayer(CharacterProperty.health_point, '-', damage);
        healthChange.ShowTakeDamageUI(damage);
    }

    ///
    /// create WaitForGetDamageRoutine Method
    /// 
    ///
    private IEnumerator WaitForGetDamageRoutine(SlimeDamageSource collision, float time)
    {
        // Before Delay Time Code
        yield return new WaitForSeconds(time);
        isAttacked = false;
        collision.gameObject.GetComponent<SlimeDamageSource>().HaveAttacked();
        // After Delay Time Code
    }
}
