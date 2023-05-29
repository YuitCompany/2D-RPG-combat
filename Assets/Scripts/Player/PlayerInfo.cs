using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BaseCharacter;

namespace Character
{

public class PlayerInfo
{
    public void CreatePlayer(CharacterStar player)
    {
        player.Add_Property(new StringProperty(PropertyType.name, "Yuit"));
        player.Add_Property(new IntProperty(PropertyType.level, 1));

        player.Add_Property(new IntProperty(PropertyType.health_point, 100));
        player.Add_Property(new IntProperty(PropertyType.max_health_point, 100));

        player.Add_Property(new IntProperty(PropertyType.mana_point, 0));
        player.Add_Property(new IntProperty(PropertyType.max_mana_point, 0));

        player.Add_Property(new FloatProperty(PropertyType.defaut_move_speed, 5f));
        player.Add_Property(new FloatProperty(PropertyType.move_speed, 5f));

        player .Add_Property(new FloatProperty(PropertyType.dash_amount, 20f));
        player.Add_Property(new FloatProperty(PropertyType.dash_cd, 3f));

        player.Add_Property(new IntProperty(PropertyType.attack_amount, 5));
        player.Add_Property(new FloatProperty(PropertyType.attack_speed, 1f));

        player.Add_Property(new IntProperty(PropertyType.defense_amount, 3));

        player.Add_Property(new IntProperty(PropertyType.anti_effect, 30));
    }

    // get/set/change
    //public int Get_Property(PropertyType type)
    //{
    //    return player.Get_IntProperty(type);
    //}
}

}