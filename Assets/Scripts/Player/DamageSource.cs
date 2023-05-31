using UnityEngine;
using BaseCharacter;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        // ? = if(enemyHealth)
        enemyHealth?.TakeDamage(playerStats.Get_IntStatusPlayer(CharacterProperty.attack_amount));
    }
}
