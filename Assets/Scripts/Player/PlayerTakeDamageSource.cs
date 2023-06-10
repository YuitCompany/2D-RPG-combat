using BaseBuff;
using BaseObject;
using System.Collections;
using UnityEngine;

public class PlayerTakeDamageSource : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private HealthChange healthChange;


    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        healthChange = GetComponentInChildren<HealthChange>();
    }

    private bool isAttacked;

    private void Update()
    {
        Debug.Log(playerStats.playerStats.Get_FloatCurrentState(ObjectProperty.move_speed));
    }
    
    /// <summary>
    /// OnTriggerEnter2D Method
    /// Check If The Slime Is Attacked By The Player
    /// </summary>
    /// <param name="collision">Collider Of Player</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        SlimeDamageSource damageSource = collision.gameObject.GetComponent<SlimeDamageSource>();
        TestBuffEffect buffSource = collision.gameObject.GetComponent<TestBuffEffect>();

        if (damageSource != null && damageSource && !isAttacked)
        {
            isAttacked = true;
            PlayerTakeDamage(damageSource.SlimeDamageSourceAmount());
            StartCoroutine(WaitForGetDamageRoutine(.7f));
        }

        if (buffSource != null && buffSource && !isAttacked)
        {
            isAttacked = true;
            StartCoroutine(PlayerTakeBuffRoutine(buffSource.healRangeState ,buffSource.GetBuffTime()));
            Debug.Log("Debuff Active");
        }
    }

    ///
    /// create PlayerTakeBuffRoutine Method
    /// 
    ///
    private IEnumerator PlayerTakeBuffRoutine(BuffStatus buff, float buffTime)
    {
        // Before Delay Time Code
        playerStats.Take_DebuffEffect(buff);
        yield return new WaitForSeconds(buffTime);
        // After Delay Time Code
        playerStats.Remove_BuffEffect();
        isAttacked = false;
    }

    /// <summary>
    /// PLayerTakeDamge Method
    /// Set Health_Point Player
    /// Show Take Damage On Screen
    /// </summary>
    /// <param name="damage">Damage Value</param>
    private void PlayerTakeDamage(int damage)
    {
        playerStats.Change_StatusPlayer(ObjectProperty.health_point, '-', damage);
        healthChange.ShowTakeDamageUI(damage);
    }

    /// <summary>
    /// create WaitForGetDamageRoutine Method
    /// Delay For Player Take Damage
    /// </summary>
    /// <param name="time">Time For Next Times Get Damage</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator WaitForGetDamageRoutine(float time)
    {
        // Before Delay Time Code
        yield return new WaitForSeconds(time);
        // After Delay Time Code
        isAttacked = false;
    }
}
