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
}
