namespace BaseObject
{
    /// <summary>
    /// Interface Type Base Of Data Access
    /// </summary>
    /// <typeparam name="V">Key Using For Data Access</typeparam>
    /// <typeparam name="T">Value Of Data</typeparam>
    public interface BaseProperty<V, T>
    {
        V GetType();
        T Value { get; set; }
    }


    /// <summary>
    /// Enum Type Include The Object Stats
    /// </summary>
    public enum ObjectProperty
    {
        name,
        level,
        health_point,
        max_health_point,
        mana_point,
        max_mana_point,
        defaut_move_speed,
        move_speed,
        dash_amount,
        dash_cd,
        attack_amount,
        attack_speed,
        defense_amount,
        anti_effect
    }
}