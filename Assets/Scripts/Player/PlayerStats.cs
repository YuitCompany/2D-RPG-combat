using UnityEngine;

using BaseObject;
using BaseStats;
using BaseBuff;

public class PlayerStats : MonoBehaviour
{
    public Character playerStats;

    private void Awake()
    {
        playerStats = new Character();
        playerStats.ActiveBuff();
        SetStatusPlayer();
    }

    /// <summary>
    /// SetStatusPlayer Method
    /// Add More Property For playerStats
    /// </summary>
    private void SetStatusPlayer()
    {
        playerStats.Set_DefaultState(new StringProperty(ObjectProperty.name, "Yuit"));
        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.level, 1));

        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.health_point, 100));
        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.max_health_point, 100));

        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.mana_point, 20));
        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.max_mana_point, 20));

        playerStats.Set_DefaultState(new FloatProperty(ObjectProperty.defaut_move_speed, 5f));
        playerStats.Set_DefaultState(new FloatProperty(ObjectProperty.move_speed, 5f));

        playerStats.Set_DefaultState(new FloatProperty(ObjectProperty.dash_amount, 20f));
        playerStats.Set_DefaultState(new FloatProperty(ObjectProperty.dash_cd, 1f));

        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.attack_amount, 10));
        playerStats.Set_DefaultState(new FloatProperty(ObjectProperty.attack_speed, .5f));

        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.defense_amount, 3));

        playerStats.Set_DefaultState(new IntProperty(ObjectProperty.anti_effect, 30));
    }

    /// <summary>
    /// Get_IntStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns>Int</returns>
    public int Get_IntStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_IntCurrentState(type);
    }

    /// <summary>
    /// Get_FloatStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns>Float</returns>
    public float Get_FloatStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_FloatCurrentState(type);
    }

    /// <summary>
    /// Get_StringStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns>String</returns>
    public string Get_StringStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_StringCurrentState(type);
    }

    /// <summary>
    /// Change_StatusPlayer Overload Method
    /// Change Value With Key on Dictionary
    /// Change Value According To Operator (+, -, *, /, %)
    /// </summary>
    /// <param name="type">Property Name</param>
    /// <param name="operatorType">Operator</param>
    /// <param name="value">Value Will Be Written</param>
    public void Change_StatusPlayer(ObjectProperty type, char operatorType, int value)
    {
        playerStats.Change_CurrentState(type, operatorType, (int)value);
    }
    public void Change_StatusPlayer(ObjectProperty type, char operatorType, float value)
    {
        playerStats.Change_CurrentState(type, operatorType, (float)value);
    }


    public void Take_BuffEffect(BuffStatus buff)
    {
        playerStats.Take_BuffEffect(BuffType.buff, buff);
    }
    public void Take_DebuffEffect(BuffStatus buff)
    {
        playerStats.Take_BuffEffect(BuffType.debuff, buff);
    }

    public void Remove_BuffEffect()
    {
        playerStats.Remove_BuffEffect(BuffType.debuff);
    }
}
