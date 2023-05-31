using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BaseCharacter;
using BaseMonster;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private SlimeStats slimeStats;
    private bool isAttacked = false;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        slimeStats = GetComponentInParent<SlimeStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController && !isAttacked)
        {   
            PlayerTakeDamage(slimeStats.Get_IntStatusSlime(MonsterProperty.attack_amount));
            DoneAttacked();
            StartCoroutine(AttackedRoutine(slimeStats.Get_FloatStatusSlime(MonsterProperty.attack_speed)));
        }
    }

    /// <summary>
    /// AttackedRoutine Method
    /// Attack Being CD
    /// </summary>
    /// <param name="attackSpeed">Monster Attack Speed</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator AttackedRoutine(float attackSpeed)
    {
        // feature code
        yield return new WaitForSeconds(attackSpeed);
        HaveAttacked();
    }

    /// <summary>
    /// DoneAttacked Method
    /// Monter Attack Is Done
    /// </summary>
    private void DoneAttacked()
    {
        isAttacked = true;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    /// <summary>
    /// DoneAttacked Method
    /// Monter Attack Is Not Done
    /// </summary>
    private void HaveAttacked()
    {
        isAttacked = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    /// <summary>
    /// PlayerTakeDamage Method
    /// Monster Will Be Create Damage For Player
    /// </summary>
    /// <param name="damageAmount">Value Get Damage</param>
    public void PlayerTakeDamage(int damageAmount)
    {
        playerStats.Change_StatusPlayer(CharacterProperty.health_point, '-', damageAmount);
    }
}
