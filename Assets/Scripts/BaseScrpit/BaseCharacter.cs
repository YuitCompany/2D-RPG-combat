using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace BaseCharacter
{
    // base character status
    public enum PropertyType
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
    public interface BaseProperty<T>
    {
        PropertyType GetType();
        T Value { get; set; }
    }

    // base data for int tpye
    public class IntProperty : BaseProperty<int>
    {
        protected PropertyType type;
        protected int value;

        // Constructor
        public IntProperty(PropertyType type, int value)
        {
            this.type = type;
            this.value = value;
        }

        public PropertyType GetType()
        {
            return type;
        }

        // Get/Set Method
        public int Value { get { return value; } set { this.value = value; } }
    }

    // base data for float type
    public class FloatProperty : BaseProperty<float>
    {
        protected PropertyType type;
        protected float value;

        public FloatProperty(PropertyType type, float value)
        {
            this.type = type;
            this.value = value;
        }        

        public PropertyType GetType()
        {
            return type;
        }

        // Get/Set Method
        public float Value { get { return value; } set { this.value = value; } }
    }

    // base data for string type
    public class StringProperty : BaseProperty<string>
    {
        protected PropertyType type;
        protected string value;

        public StringProperty(PropertyType type, string value)
        {
            this.type = type;
            this.value= value;
        }

        public PropertyType GetType()
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
        private Dictionary<PropertyType, IntProperty> Dic_IntProperty = new Dictionary<PropertyType, IntProperty>();
        private Dictionary<PropertyType, FloatProperty> Dic_FloatProperty = new Dictionary<PropertyType, FloatProperty>();
        private Dictionary<PropertyType, StringProperty> Dic_StringProperty = new Dictionary<PropertyType, StringProperty>();


        // overload Method Add_Property
        public void Add_Property(IntProperty intProperty)
        {
            PropertyType type = intProperty.GetType();
            if (!Dic_IntProperty.ContainsKey(type))
            {
                Dic_IntProperty.Add(type, intProperty);
            }
        }
        public void Add_Property(FloatProperty floatProperty)
        {
            PropertyType type = floatProperty.GetType();
            if (!Dic_FloatProperty.ContainsKey(type))
            {
                Dic_FloatProperty.Add(type, floatProperty);
            }
        }
        public void Add_Property(StringProperty stringProperty)
        {
            PropertyType type = stringProperty.GetType();
            if (!Dic_StringProperty.ContainsKey(type))
            {
                Dic_StringProperty.Add(type, stringProperty);
            }
        }

        // get value
        public int Get_IntProperty(PropertyType type)
        {

            if (!Dic_IntProperty.ContainsKey(type)) return 0;

            return Dic_IntProperty[type].Value;
        }
        public float Get_FloatProperty(PropertyType type)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return 0f;

            return Dic_FloatProperty[type].Value;
        }
        public string Get_StringProperty(PropertyType type)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return "";

            return Dic_StringProperty[type].Value;
        }

        // set value
        public void Set_Property(PropertyType type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value = value;
        }
        public void Set_Property(PropertyType type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value = value;
        }
        public void Set_Property(PropertyType type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value = value;
        }

        // change value
        public void Change_Property(PropertyType type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value += value;
        }
        public void Change_Property(PropertyType type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value += value;
        }
        public void Change_Property(PropertyType type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value += value;
        }
    }
}

