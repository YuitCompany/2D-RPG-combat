using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BaseCharacter;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float attackSpeed = .5f;

    private bool isAttacked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController && !isAttacked)
        {
            PlayerTakeDamage(damageAmount);
            DoneAttacked();
            StartCoroutine(AttackedRoutine(attackSpeed));
        }
    }

    /// create Attacked Routine Method
    private IEnumerator AttackedRoutine(float attackSpeed)
    {
        // feature code
        yield return new WaitForSeconds(attackSpeed);
        HaveAttacked();
    }

    // cd attack
    private void DoneAttacked()
    {
        isAttacked = true;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void HaveAttacked()
    {
        isAttacked = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }


    public void PlayerTakeDamage(int damageAmount)
    {
        PlayerController.Instance.playerInfo.Change_Property(PropertyType.health_point, -damageAmount);
    }
}
