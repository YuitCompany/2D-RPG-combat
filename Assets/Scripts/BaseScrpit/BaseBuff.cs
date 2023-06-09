using BaseObject;
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

    public class BuffStatus
    {
        private string name;
        private Dictionary<BuffProperty, IntPropertyBuff> Dic_IntBuffEffect = new Dictionary<BuffProperty, IntPropertyBuff>();
        private Dictionary<BuffProperty, FloatPropertyBuff> Dic_FloatBuffEffect = new Dictionary<BuffProperty, FloatPropertyBuff>();

        /// <summary>
        /// SetBuffProperty Overload Method
        /// If Condition true : Found Value
        /// Code Will Inactive
        /// And Add Data Into Dictionary
        /// </summary>
        /// <param name="name">Name Of Buff</param>
        /// <param name="property">Property Of Buff</param>
        public void Set_BuffProperty(string name, IntPropertyBuff property)
        {
            BuffProperty type = property.GetType();
            
            if (Dic_IntBuffEffect.ContainsKey(type)) return;
            Dic_IntBuffEffect.Add(type, property);
        }
        public void Set_BuffProperty(string name, FloatPropertyBuff property)
        {
            BuffProperty type = property.GetType();

            if (Dic_FloatBuffEffect.ContainsKey(type)) return;
            Dic_FloatBuffEffect.Add(type, property);
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
            if (!Dic_IntBuffEffect.ContainsKey(type)) return 0f;
            return Dic_IntBuffEffect[type].Value;
        }
    }
}
