using UnityEngine;

using BaseObject;
using StatsObject;

public class SlimeStats : MonoBehaviour
{
    private ObjectState slimeStats;

    private void Awake()
    {
        slimeStats = new ObjectState();
        SetStatusSlime();
    }

    /// <summary>
    /// SetStatusSlime Method
    /// Add More Property For slimeStats
    /// </summary>
    private void SetStatusSlime()
    {
        slimeStats.Add_Property(new StringProperty(ObjectProperty.name, "Slime"));
        slimeStats.Add_Property(new IntProperty(ObjectProperty.level, 1));

        slimeStats.Add_Property(new IntProperty(ObjectProperty.health_point, 50));
        slimeStats.Add_Property(new IntProperty(ObjectProperty.max_health_point, 50));

        slimeStats.Add_Property(new FloatProperty(ObjectProperty.defaut_move_speed, 5f));
        slimeStats.Add_Property(new FloatProperty(ObjectProperty.move_speed, 3f));

        slimeStats.Add_Property(new IntProperty(ObjectProperty.attack_amount, 3));
        slimeStats.Add_Property(new FloatProperty(ObjectProperty.attack_speed, 1f));

        slimeStats.Add_Property(new FloatProperty(ObjectProperty.defense_amount, 1f));

        slimeStats.Add_Property(new IntProperty(ObjectProperty.anti_effect, 20));
    }

    /// <summary>
    /// Get_IntStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public int Get_IntStatusSlime(ObjectProperty type)
    {
        return slimeStats.Get_IntProperty(type);
    }

    /// <summary>
    /// Get_FloatStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public float Get_FloatStatusSlime(ObjectProperty type)
    {
        return slimeStats.Get_FloatProperty(type);
    }

    /// <summary>
    /// Get_StringStatusSlime
    /// Get Value With Key
    /// </summary>
    /// <param name="type">Key Using For Get Value</param>
    /// <returns></returns>
    public string Get_StringStatusSlime(ObjectProperty type)
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
    public void Change_StatusSlime(ObjectProperty type, char operatorType, int value)
    {
        slimeStats.Change_Property(type, operatorType, (int)value);
    }
    public void Change_StatusSlime(ObjectProperty type, char operatorType, float value)
    {
        slimeStats.Change_Property(type, operatorType, (float)value);
    }
}
