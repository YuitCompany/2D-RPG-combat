using BaseCharacter;
using BaseMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDamageSource : MonoBehaviour
{
    [SerializeField] private SlimeStats slimeStats;

    private void Awake()
    {
        slimeStats = GetComponentInParent<SlimeStats>();
    }

    /// <summary>
    /// SlimeDamageSource Method
    /// return Slime.attack_amount
    /// When Get OnTrigger Method
    /// </summary>
    /// <returns>Int</returns>
    public int SlimeDamageSourceAmount()
    {
        return slimeStats.Get_IntStatusSlime(MonsterProperty.attack_amount);
    }

    /// <summary>
    /// DoneAttacked Method
    /// Monter Attack Is Not Done
    /// Unenable Collider
    /// </summary>
    public void DoneAttacked()
    {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    /// <summary>
    /// DoneAttacked Method
    /// Monter Attack Is Done
    /// Enable Collider
    /// </summary>
    public void HaveAttacked()
    {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
