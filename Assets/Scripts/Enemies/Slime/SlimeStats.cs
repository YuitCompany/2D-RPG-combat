using UnityEngine;

using BaseMonster;

public class SlimeStats : MonoBehaviour
{
    private MonsterStats slimeStats;

    private void Awake()
    {
        slimeStats = new MonsterStats();
        SetStatusSlime();
    }

    /// <summary>
    /// SetStatusSlime Method
    /// Add More Property For slimeStats
    /// </summary>
    private void SetStatusSlime()
    {
        slimeStats.Add_Property(new StringProperty(MonsterProperty.name, "Slime"));
        slimeStats.Add_Property(new IntProperty(MonsterProperty.level, 1));

        slimeStats.Add_Property(new IntProperty(MonsterProperty.health_point, 50));
        slimeStats.Add_Property(new IntProperty(MonsterProperty.max_health_point, 50));

        slimeStats.Add_Property(new FloatProperty(MonsterProperty.defaut_move_speed, 5f));
        slimeStats.Add_Property(new FloatProperty(MonsterProperty.move_speed, 3f));

        slimeStats.Add_Property(new IntProperty(MonsterProperty.attack_amount, 3));
        slimeStats.Add_Property(new FloatProperty(MonsterProperty.attack_speed, 1f));

        slimeStats.Add_Property(new FloatProperty(MonsterProperty.defense_amount, 1f));

        slimeStats.Add_Property(new IntProperty(MonsterProperty.anti_effect, 20));
    }

    /// <summary>
    /// Get_IntStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public int Get_IntStatusSlime(MonsterProperty type)
    {
        return slimeStats.Get_IntProperty(type);
    }

    /// <summary>
    /// Get_FloatStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public float Get_FloatStatusSlime(MonsterProperty type)
    {
        return slimeStats.Get_FloatProperty(type);
    }

    /// <summary>
    /// Get_StringStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public string Get_StringStatusSlime(MonsterProperty type)
    {
        return slimeStats.Get_StringProperty(type);
    }

    /// <summary>
    /// Change_StatusSlime Overload Method
    /// Change Value With Key on Dictionary
    /// Change Value According To Operator (+, -, *, /, %)
    /// </summary>
    /// <param name="type">Property Name</param>
    /// <param name="operatorType">Operator</param>
    /// <param name="value">Value Will Be Written</param>
    public void Change_StatusSlime(MonsterProperty type, char operatorType, int value)
    {
        slimeStats.Change_Property(type, operatorType, (int)value);
    }public void Change_StatusSlime(MonsterProperty type, char operatorType, float value)
    {
        slimeStats.Change_Property(type, operatorType, (float)value);
    }
}
