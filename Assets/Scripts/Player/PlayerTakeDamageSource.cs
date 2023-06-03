using BaseCharacter;
using System.Collections;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        SlimeDamageSource damageSource = collision.gameObject.GetComponent<SlimeDamageSource>();

        if (damageSource != null && damageSource && !isAttacked)
        {
            isAttacked = true;
            PlayerTakeDamage(collision.gameObject.GetComponent<SlimeDamageSource>().SlimeDamageSourceAmount());
            StartCoroutine(WaitForGetDamageRoutine(.7f));
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
    private IEnumerator WaitForGetDamageRoutine(float time)
    {
        // Before Delay Time Code
        yield return new WaitForSeconds(time);
        // After Delay Time Code
        isAttacked = false;
    }
}
