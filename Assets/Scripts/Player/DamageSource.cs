using UnityEngine;
using BaseCharacter;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int weaponDamageBonus;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    /// <summary>
    /// PlayerDamageSourceWithSword Method
    /// return Player.attack_amount
    /// When Get OnTrigger Method
    /// </summary>
    /// <returns>Int</returns>
    public int PlayerDamageSourceWithSwordAmount()
    {
        return playerStats.Get_IntStatusPlayer(CharacterProperty.attack_amount) + weaponDamageBonus;
    }
}
