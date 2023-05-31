using System.Collections.Generic;
using BaseObject;

namespace BaseMonster
{
    /// <summary>
    /// Enum Type Include The Monster Stats
    /// </summary>
    public enum MonsterProperty
    {
        name,
        level,
        health_point,
        max_health_point,
        mana_point,
        max_mana_point,
        defaut_move_speed,
        move_speed,
        attack_amount,
        attack_speed,
        defense_amount,
        anti_effect
    }
    /// <summary>
    /// IntProperty Class Inheritance Of BaseProperty With Value <MonsterProperty, int>
    /// </summary>
    public class IntProperty : BaseProperty<MonsterProperty, int>
    {
        protected MonsterProperty type;
        protected int value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Int Value</param>
        public IntProperty(MonsterProperty type, int value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new MonsterProperty GetType()
        {
            return type;
        }

        /// <summary>
        /// Get/Set Value Property
        /// </summary>
        /// <returns>Int Type</returns>
        public int Value { get { return value; } set { this.value = value; } }
    }

    /// <summary>
    /// FloatProperty Class Inheritance Of BaseProperty With Value <MonsterProperty, float>
    /// </summary>
    public class FloatProperty : BaseProperty<MonsterProperty, float>
    {
        protected MonsterProperty type;
        protected float value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Float Value</param>
        public FloatProperty(MonsterProperty type, float value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new MonsterProperty GetType()
        {
            return type;
        }

        /// <summary>
        /// Get/Set Value Property
        /// </summary>
        /// <returns>Float Type</returns>
        public float Value { get { return value; } set { this.value = value; } }
    }

    /// <summary>
    /// StringProperty Class Inheritance Of BaseProperty With Value <MonsterProperty, string>
    /// </summary>
    public class StringProperty : BaseProperty<MonsterProperty, string>
    {
        protected MonsterProperty type;
        protected string value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">String Value</param>
        public StringProperty(MonsterProperty type, string value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new MonsterProperty GetType()
        {
            return type;
        }

        /// <summary>
        /// Get/Set Value Property
        /// </summary>
        /// <returns>String Type</returns>
        public string Value { get { return value; } set { this.value = value; } }
    }

    /// <summary>
    /// CharacterStats Class Save Data Using Dictionay<Key, Value>
    /// Key: Using For Data Access
    /// Value: Save Data Type: Int/Float/String--Property
    /// Value.Key = Key
    /// Value.Value: Data Stored
    /// </summary>
    public class MonsterStats
    {
        // Dictionary Save Data Stored In Type
        private Dictionary<MonsterProperty, IntProperty> Dic_IntProperty = new Dictionary<MonsterProperty, IntProperty>();
        private Dictionary<MonsterProperty, FloatProperty> Dic_FloatProperty = new Dictionary<MonsterProperty, FloatProperty>();
        private Dictionary<MonsterProperty, StringProperty> Dic_StringProperty = new Dictionary<MonsterProperty, StringProperty>();


        /// <summary>
        /// Add_Property Overload Method
        /// Using Type Input For Save Type Dictionary
        /// </summary>
        /// <param name="Property">Data.Value Will Be Written If Data.Key Not Duplicate</param>
        public void Add_Property(IntProperty intProperty)
        {
            MonsterProperty type = intProperty.GetType();

            if (!Dic_IntProperty.ContainsKey(type))
            {
                Dic_IntProperty.Add(type, intProperty);
            }
        }
        public void Add_Property(FloatProperty floatProperty)
        {
            MonsterProperty type = floatProperty.GetType();

            if (!Dic_FloatProperty.ContainsKey(type))
            {
                Dic_FloatProperty.Add(type, floatProperty);
            }
        }
        public void Add_Property(StringProperty stringProperty)
        {
            MonsterProperty type = stringProperty.GetType();

            if (!Dic_StringProperty.ContainsKey(type))
            {
                Dic_StringProperty.Add(type, stringProperty);
            }
        }

        /// <summary>
        /// Get_IntProperty Method For Each Type
        /// </summary>
        /// <param name="type">Key For Search Data</param>
        /// <returns>Int value If Data Found</returns>
        /// <returns>0 If Data Not Found </returns>
        public int Get_IntProperty(MonsterProperty type)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return 0;

            return Dic_IntProperty[type].Value;
        }
        /// <summary>
        /// Get_FloatProperty Method For Each Type
        /// </summary>
        /// <param name="type">Key For Search Data</param>
        /// <returns>Float value If Data Found</returns>
        /// <returns>0 If Data Not Found </returns>
        public float Get_FloatProperty(MonsterProperty type)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return 0f;

            return Dic_FloatProperty[type].Value;
        }
        /// <summary>
        /// Get_FloatProperty Method For Each Type
        /// </summary>
        /// <param name="type">Key For Search Data</param>
        /// <returns>String value If Data Found</returns>
        /// <returns>0 If Data Not Found </returns>
        public string Get_StringProperty(MonsterProperty type)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return "";

            return Dic_StringProperty[type].Value;
        }

        /// <summary>
        /// Set_Property Overload Method
        /// Type Of Value Affect Searchability
        /// </summary>
        /// <param name="type">Key For Search Value</param>
        /// <param name="value">Value Will Be Written If Key Found</param>
        public void Set_Property(MonsterProperty type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value = value;
        }
        public void Set_Property(MonsterProperty type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value = value;
        }
        public void Set_Property(MonsterProperty type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value = value;
        }

        /// <summary>
        /// Change_Property OverLoad Method
        /// Type Of Value Affect Searchability
        /// Opeartor Support: +, -, *, /, %
        /// Dont Support: String Type
        /// </summary>
        /// <param name="operatorType">Operator Calculus Classification</param>
        /// <param name="type">Key For Search Value</param>
        /// <param name="value">Value Will Be Written If Key Found</param>
        public void Change_Property(MonsterProperty type, char operatorType, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_IntProperty[type].Value = value;
            if (operatorType == '+') Dic_IntProperty[type].Value += value;
            if (operatorType == '-') Dic_IntProperty[type].Value -= value;
            if (operatorType == '*') Dic_IntProperty[type].Value *= value;
            if (operatorType == '/') Dic_IntProperty[type].Value /= value;
            if (operatorType == '%') Dic_IntProperty[type].Value %= value;
        }
        public void Change_Property(MonsterProperty type, char operatorType, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_FloatProperty[type].Value += value;
            if (operatorType == '+') Dic_FloatProperty[type].Value += value;
            if (operatorType == '-') Dic_FloatProperty[type].Value -= value;
            if (operatorType == '*') Dic_FloatProperty[type].Value *= value;
            if (operatorType == '/') Dic_FloatProperty[type].Value /= value;
            if (operatorType == '%') Dic_FloatProperty[type].Value %= value;
        }
        public void Change_Property(MonsterProperty type, char operatorType, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_StringProperty[type].Value = value;
            if (operatorType == '+') Dic_StringProperty[type].Value += value;
        }
    }
}
