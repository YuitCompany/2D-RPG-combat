using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BaseCharacter;


public class DamageSource : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        enemyHealth?.TakeDamage(PlayerController.Instance.playerInfo.Get_IntProperty(PlayerProperty.attack_amount));
    }
}
