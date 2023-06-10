using BaseObject;
using BaseStats;
using System.Collections.Generic;

namespace BaseBuff
{
    /// <summary>
    /// IntPropertyBuff Class Inheritance Of BaseProperty With Value <BuffProperty, int>
    /// </summary>
    public class IntPropertyBuff : BaseProperty<BuffProperty, int>
    {
        BuffProperty type;
        int value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Int Value</param>
        public IntPropertyBuff(BuffProperty type, int value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>Buff Property Type</returns>
        public new BuffProperty GetType()
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
    /// FloatPropertyBuff Class Inheritance Of BaseProperty With Value <BuffProperty, float>
    /// </summary>
    public class FloatPropertyBuff : BaseProperty<BuffProperty, float>
    {
        BuffProperty type;
        float value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Float Value</param>
        public FloatPropertyBuff(BuffProperty type, float value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>Buff Property Type</returns>
        public new BuffProperty GetType()
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
    /// StringProperty Class Inheritance Of BaseProperty With Value <BuffProperty, string>
    /// </summary>
    public class StringPropertyBuff : BaseProperty<BuffProperty, string>
    {
        protected BuffProperty type;
        protected string value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">String Value</param>
        public StringPropertyBuff(BuffProperty type, string value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new BuffProperty GetType()
        {
            return type;
        }

        /// <summary>
        /// Get/Set Value Property
        /// </summary>
        /// <returns>String Type</returns>
        public string Value { get { return value; } set { this.value = value; } }
    }

    public class BuffStatus
    {
        public ObjectState Status { get { return status; } set { status = value; } }

        private Dictionary<BuffProperty, IntPropertyBuff> Dic_IntBuffEffect = new Dictionary<BuffProperty, IntPropertyBuff>();
        private Dictionary<BuffProperty, FloatPropertyBuff> Dic_FloatBuffEffect = new Dictionary<BuffProperty, FloatPropertyBuff>();
        private Dictionary<BuffProperty, StringPropertyBuff> Dic_StringBuffEffect = new Dictionary<BuffProperty, StringPropertyBuff>();

        private ObjectState status = new ObjectState();

        /// <summary>
        /// SetBuffProperty Overload Method
        /// If Condition true : Found Value
        /// Code Will Inactive
        /// And Add Data Into Dictionary
        /// </summary>
        /// <param name="name">Name Of Buff</param>
        /// <param name="property">Property Of Buff</param>
        public void Set_BuffProperty(IntPropertyBuff property)
        {
            BuffProperty type = property.GetType();
            
            if (Dic_IntBuffEffect.ContainsKey(type)) return;
            Dic_IntBuffEffect.Add(type, property);
        }
        public void Set_BuffProperty(FloatPropertyBuff property)
        {
            BuffProperty type = property.GetType();

            if (Dic_FloatBuffEffect.ContainsKey(type)) return;
            Dic_FloatBuffEffect.Add(type, property);
        }
        public void Set_BuffProperty(StringPropertyBuff property)
        {
            BuffProperty type = property.GetType();

            if (Dic_StringBuffEffect.ContainsKey(type)) return;
            Dic_StringBuffEffect.Add(type, property);
        }

        /// <summary>
        /// Get_IntBuffProperty Method
        /// If Condition false : Not Found Value
        /// Code Will Inactive
        /// And Return Data Into Dictionary
        /// With Int Type
        /// </summary>
        /// <param name="type">Key Of Value On Dictionary</param>
        /// <returns>Int</returns>
        public int Get_IntBuffProperty(BuffProperty type)
        {
            if (!Dic_IntBuffEffect.ContainsKey(type)) return 0;
            return Dic_IntBuffEffect[type].Value;
        }

        /// <summary>
        /// Get_FloatBuffProperty Method
        /// If Condition false : Not Found Value
        /// Code Will Inactive
        /// And Return Data Into Dictionary
        /// With Float Type
        /// </summary>
        /// <param name="type">Key Of Value On Dictionary</param>
        /// <returns>Float</returns>
        public float Get_FloatBuffProperty(BuffProperty type)
        {
            if (!Dic_FloatBuffEffect.ContainsKey(type)) return 0f;
            return Dic_FloatBuffEffect[type].Value;
        }

        /// <summary>
        /// Get_StringBuffProperty Method
        /// If Condition false : Not Found Value
        /// Code Will Inactive
        /// And Return Data Into Dictionary
        /// With String Type
        /// </summary>
        /// <param name="type">Key Of Value On Dictionary</param>
        /// <returns>String</returns>
        public string Get_StringBuffProperty(BuffProperty type)
        {
            if (!Dic_StringBuffEffect.ContainsKey(type)) return "0";
            return Dic_StringBuffEffect[type].Value;
        }
    }
}
