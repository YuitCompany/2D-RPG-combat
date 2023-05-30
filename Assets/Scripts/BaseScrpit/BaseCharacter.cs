using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace BaseCharacter
{
    // base character status
    public enum PlayerProperty
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

    // base set Property
    public interface BaseProperty<V, T>
    {
        V GetType();
        T Value { get; set; }
    }

    // base data for int tpye
    public class IntProperty : BaseProperty<PlayerProperty, int>
    {
        protected PlayerProperty type;
        protected int value;

        // Constructor
        public IntProperty(PlayerProperty type, int value)
        {
            this.type = type;
            this.value = value;
        }

        public PlayerProperty GetType()
        {
            return type;
        }

        // Get/Set Method
        public int Value { get { return value; } set { this.value = value; } }
    }

    // base data for float type
    public class FloatProperty : BaseProperty<PlayerProperty, float>
    {
        protected PlayerProperty type;
        protected float value;

        public FloatProperty(PlayerProperty type, float value)
        {
            this.type = type;
            this.value = value;
        }        

        public PlayerProperty GetType()
        {
            return type;
        }

        // Get/Set Method
        public float Value { get { return value; } set { this.value = value; } }
    }

    // base data for string type
    public class StringProperty : BaseProperty<PlayerProperty, string>
    {
        protected PlayerProperty type;
        protected string value;

        public StringProperty(PlayerProperty type, string value)
        {
            this.type = type;
            this.value= value;
        }

        public PlayerProperty GetType()
        {
            return type;
        }

        // Get/Set Method
        public string Value { get { return value; } set { this.value= value; } }
    }

    // save data
    public class CharacterStar
    {
        // data save location
        private Dictionary<PlayerProperty, IntProperty> Dic_IntProperty = new Dictionary<PlayerProperty, IntProperty>();
        private Dictionary<PlayerProperty, FloatProperty> Dic_FloatProperty = new Dictionary<PlayerProperty, FloatProperty>();
        private Dictionary<PlayerProperty, StringProperty> Dic_StringProperty = new Dictionary<PlayerProperty, StringProperty>();


        // overload Method Add_Property
        public void Add_Property(IntProperty intProperty)
        {
            PlayerProperty type = intProperty.GetType();
            if (!Dic_IntProperty.ContainsKey(type))
            {
                Dic_IntProperty.Add(type, intProperty);
            }
        }
        public void Add_Property(FloatProperty floatProperty)
        {
            PlayerProperty type = floatProperty.GetType();
            if (!Dic_FloatProperty.ContainsKey(type))
            {
                Dic_FloatProperty.Add(type, floatProperty);
            }
        }
        public void Add_Property(StringProperty stringProperty)
        {
            PlayerProperty type = stringProperty.GetType();
            if (!Dic_StringProperty.ContainsKey(type))
            {
                Dic_StringProperty.Add(type, stringProperty);
            }
        }

        // get value
        public int Get_IntProperty(PlayerProperty type)
        {

            if (!Dic_IntProperty.ContainsKey(type)) return 0;

            return Dic_IntProperty[type].Value;
        }
        public float Get_FloatProperty(PlayerProperty type)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return 0f;

            return Dic_FloatProperty[type].Value;
        }
        public string Get_StringProperty(PlayerProperty type)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return "";

            return Dic_StringProperty[type].Value;
        }

        // set value
        public void Set_Property(PlayerProperty type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value = value;
        }
        public void Set_Property(PlayerProperty type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value = value;
        }
        public void Set_Property(PlayerProperty type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value = value;
        }

        // change value
        public void Change_Property(PlayerProperty type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value += value;
        }
        public void Change_Property(PlayerProperty type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value += value;
        }
        public void Change_Property(PlayerProperty type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value += value;
        }
    }
}

