using BaseObject;
using BaseStats;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace BaseInventory
{
    /// <summary>
    /// IntPropertyInventory Class Inheritance Of BaseProperty With Value <ObjectProperty, int>
    /// </summary>
    public class IntPropertyInventory : BaseProperty<InventoryProperty, int>
    {
        protected InventoryProperty type;
        protected int value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Int Value</param>
        public IntPropertyInventory(InventoryProperty type, int value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new InventoryProperty GetType()
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
    /// FloatPropertyInventory Class Inheritance Of BaseProperty With Value <ObjectProperty, float>
    /// </summary>
    public class FloatPropertyInventory : BaseProperty<InventoryProperty, float>
    {
        protected InventoryProperty type;
        protected float value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">Float Value</param>
        public FloatPropertyInventory(InventoryProperty type, float value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new InventoryProperty GetType()
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
    /// StringPropertyInventory Class Inheritance Of BaseProperty With Value <ObjectProperty, string>
    /// </summary>
    public class StringPropertyInventory : BaseProperty<InventoryProperty, string>
    {
        protected InventoryProperty type;
        protected string value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Key</param>
        /// <param name="value">String Value</param>
        public StringPropertyInventory(InventoryProperty type, string value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Get Key Property
        /// </summary>
        /// <returns>PlayerPropery Type</returns>
        public new InventoryProperty GetType()
        {
            return type;
        }

        /// <summary>
        /// Get/Set Value Property
        /// </summary>
        /// <returns>String Type</returns>
        public string Value { get { return value; } set { this.value = value; } }
    }

    public class InventoryState
    {
        public ObjectState Status { get { return status; } set { status = value; } }

        private Dictionary<InventoryProperty, IntPropertyInventory> Dic_IntProperty = new Dictionary<InventoryProperty, IntPropertyInventory>();
        private Dictionary<InventoryProperty, FloatPropertyInventory> Dic_FloatProperty = new Dictionary<InventoryProperty, FloatPropertyInventory>();
        private Dictionary<InventoryProperty, StringPropertyInventory> Dic_StringProperty = new Dictionary<InventoryProperty, StringPropertyInventory>();

        private ObjectState status = new ObjectState();


        /// <summary>
        /// Set_Property Overload Method
        /// Using Type Input For Save Type Dictionary
        /// </summary>
        /// <param name="Property">Data.Value Will Be Written If Data.Key Not Duplicate</param>
        public void Set_Property(IntPropertyInventory property)
        {
            InventoryProperty type = property.GetType();
            if (Dic_IntProperty.ContainsKey(type)) return;
            Dic_IntProperty.Add(type, property);
        }
        public void Set_Property(FloatPropertyInventory property)
        {
            InventoryProperty type = property.GetType();
            if (Dic_FloatProperty.ContainsKey(type)) return;
            Dic_FloatProperty.Add(type, property);
        }
        public void Set_Property(StringPropertyInventory property)
        {
            InventoryProperty type = property.GetType();
            if (Dic_StringProperty.ContainsKey(type)) return;
            Dic_StringProperty.Add(type, property);
        }

        /// <summary>
        /// Set_Property Overload Method
        /// Type Of Value Affect Searchability
        /// </summary>
        /// <param name="type">Key For Search Value</param>
        /// <param name="value">Value Will Be Written If Key Found</param>
        public void Set_Property(InventoryProperty type, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            Dic_IntProperty[type].Value = value;
        }
        public void Set_Property(InventoryProperty type, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            Dic_FloatProperty[type].Value = value;
        }
        public void Set_Property(InventoryProperty type, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            Dic_StringProperty[type].Value = value;
        }

        /// <summary>
        /// Get_IntProperty Method For Each Type
        /// </summary>
        /// <param name="type">Key For Search Data</param>
        /// <returns>Int value If Data Found</returns>
        /// <returns>0 If Data Not Found </returns>
        public int Get_IntProperty(InventoryProperty type)
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
        public float Get_FloatProperty(InventoryProperty type)
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
        public string Get_StringProperty(InventoryProperty type)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return "";

            return Dic_StringProperty[type].Value;
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
        public void Change_Property(InventoryProperty type, char operatorType, int value)
        {
            if (!Dic_IntProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_IntProperty[type].Value = value;
            if (operatorType == '+') Dic_IntProperty[type].Value += value;
            if (operatorType == '-') Dic_IntProperty[type].Value -= value;
            if (operatorType == '*') Dic_IntProperty[type].Value *= value;
            if (operatorType == '/') Dic_IntProperty[type].Value /= value;
            if (operatorType == '%') Dic_IntProperty[type].Value %= value;
        }
        public void Change_Property(InventoryProperty type, char operatorType, float value)
        {
            if (!Dic_FloatProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_FloatProperty[type].Value = value;
            if (operatorType == '+') Dic_FloatProperty[type].Value += value;
            if (operatorType == '-') Dic_FloatProperty[type].Value -= value;
            if (operatorType == '*') Dic_FloatProperty[type].Value *= value;
            if (operatorType == '/') Dic_FloatProperty[type].Value /= value;
            if (operatorType == '%') Dic_FloatProperty[type].Value %= value;
        }
        public void Change_Property(InventoryProperty type, char operatorType, string value)
        {
            if (!Dic_StringProperty.ContainsKey(type)) return;

            if (operatorType == '=') Dic_StringProperty[type].Value = value;
            if (operatorType == '+') Dic_StringProperty[type].Value += value;
        }
    }
}
