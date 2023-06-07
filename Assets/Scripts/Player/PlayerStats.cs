using UnityEngine;

using BaseObject;
using StatsObject;

public class PlayerStats : MonoBehaviour
{
    private ObjectState playerStats;

    private void Awake()
    {
        playerStats = new ObjectState();
        SetStatusPlayer();
    }

    /// <summary>
    /// SetStatusPlayer Method
    /// Add More Property For playerStats
    /// </summary>
    private void SetStatusPlayer()
    {
        playerStats.Add_Property(new StringProperty(ObjectProperty.name, "Yuit"));
        playerStats.Add_Property(new IntProperty(ObjectProperty.level, 1));

        playerStats.Add_Property(new IntProperty(ObjectProperty.health_point, 100));
        playerStats.Add_Property(new IntProperty(ObjectProperty.max_health_point, 100));

        playerStats.Add_Property(new IntProperty(ObjectProperty.mana_point, 20));
        playerStats.Add_Property(new IntProperty(ObjectProperty.max_mana_point, 20));

        playerStats.Add_Property(new FloatProperty(ObjectProperty.defaut_move_speed, 5f));
        playerStats.Add_Property(new FloatProperty(ObjectProperty.move_speed, 5f));

        playerStats.Add_Property(new FloatProperty(ObjectProperty.dash_amount, 20f));
        playerStats.Add_Property(new FloatProperty(ObjectProperty.dash_cd, 1f));

        playerStats.Add_Property(new IntProperty(ObjectProperty.attack_amount, 10));
        playerStats.Add_Property(new FloatProperty(ObjectProperty.attack_speed, .5f));

        playerStats.Add_Property(new IntProperty(ObjectProperty.defense_amount, 3));

        playerStats.Add_Property(new IntProperty(ObjectProperty.anti_effect, 30));
    }

    /// <summary>
    /// Get_IntStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public int Get_IntStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_IntProperty(type);
    }

    /// <summary>
    /// Get_FloatStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public float Get_FloatStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_FloatProperty(type);
    }

    /// <summary>
    /// Get_StringStatusPlayer
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public string Get_StringStatusPlayer(ObjectProperty type)
    {
        return playerStats.Get_StringProperty(type);
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
        playerStats.Change_Property(type, operatorType, (int)value);
    }
    public void Change_StatusPlayer(ObjectProperty type, char operatorType, float value)
    {
        playerStats.Change_Property(type, operatorType, (float)value);
    }
}
