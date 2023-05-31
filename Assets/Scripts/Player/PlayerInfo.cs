using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BaseCharacter;

namespace Character
{

    public class PlayerInfo
    {
        public void CreatePlayer(CharacterStats player)
        {
            player.Add_Property(new StringProperty(CharacterProperty.name, "Yuit"));
            player.Add_Property(new IntProperty(CharacterProperty.level, 1));

            player.Add_Property(new IntProperty(CharacterProperty.health_point, 100));
            player.Add_Property(new IntProperty(CharacterProperty.max_health_point, 100));

            player.Add_Property(new IntProperty(CharacterProperty.mana_point, 0));
            player.Add_Property(new IntProperty(CharacterProperty.max_mana_point, 0));

            player.Add_Property(new FloatProperty(CharacterProperty.defaut_move_speed, 5f));
            player.Add_Property(new FloatProperty(CharacterProperty.move_speed, 5f));

            player.Add_Property(new FloatProperty(CharacterProperty.dash_amount, 20f));
            player.Add_Property(new FloatProperty(CharacterProperty.dash_cd, 3f));

            player.Add_Property(new IntProperty(CharacterProperty.attack_amount, 5));
            player.Add_Property(new FloatProperty(CharacterProperty.attack_speed, 1f));

            player.Add_Property(new IntProperty(CharacterProperty.defense_amount, 3));

            player.Add_Property(new IntProperty(CharacterProperty.anti_effect, 30));
        }
    }
}