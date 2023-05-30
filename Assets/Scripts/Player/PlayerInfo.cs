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
        player.Add_Property(new StringProperty(PlayerProperty.name, "Yuit"));
        player.Add_Property(new IntProperty(PlayerProperty.level, 1));

        player.Add_Property(new IntProperty(PlayerProperty.health_point, 100));
        player.Add_Property(new IntProperty(PlayerProperty.max_health_point, 100));

        player.Add_Property(new IntProperty(PlayerProperty.mana_point, 0));
        player.Add_Property(new IntProperty(PlayerProperty.max_mana_point, 0));

        player.Add_Property(new FloatProperty(PlayerProperty.defaut_move_speed, 5f));
        player.Add_Property(new FloatProperty(PlayerProperty.move_speed, 5f));

        player .Add_Property(new FloatProperty(PlayerProperty.dash_amount, 20f));
        player.Add_Property(new FloatProperty(PlayerProperty.dash_cd, 3f));

        player.Add_Property(new IntProperty(PlayerProperty.attack_amount, 5));
        player.Add_Property(new FloatProperty(PlayerProperty.attack_speed, 1f));

        player.Add_Property(new IntProperty(PlayerProperty.defense_amount, 3));

        player.Add_Property(new IntProperty(PlayerProperty.anti_effect, 30));
    }

    // get/set/change
    //public int Get_Property(PlayerProperty type)
    //{
    //    return player.Get_IntProperty(type);
    //}
}

}