using BaseObject;
using BaseStats;
using BaseBuff;
using BaseInventory;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;

public class Character
{
    ObjectState baseState = new ObjectState();
    Dictionary<InventorySlot, InventoryState> inventoryState;
    Dictionary<BuffType, BuffStatus> buffState;
    ObjectState currentState = new ObjectState();

    bool isHaveInventory = false;
    bool isHaveBuff = false;

    /// <summary>
    /// ActiveInventory Method
    /// Active Inventory System
    /// </summary>
    public void ActiveInventory()
    {
        isHaveInventory = true;
        inventoryState = new Dictionary<InventorySlot, InventoryState>();
    }

    /// <summary>
    /// ActiveInventory Method
    /// Active Buff System
    /// </summary>
    public void ActiveBuff()
    {
        isHaveBuff = true;
        buffState = new Dictionary<BuffType, BuffStatus>();
    }

    /// <summary>
    /// Set_DefaultState OverLoad Method
    /// Add New Values For BaseState
    /// Add new Values For CurrentState
    /// </summary>
    /// <param name="property">Valuse Will Be Add</param>
    public void Set_DefaultState(IntProperty property)
    {
        baseState.Set_Property(property);
        currentState.Set_Property(property);
    }
    public void Set_DefaultState(FloatProperty property)
    {
        baseState.Set_Property(property);
        currentState.Set_Property(property);
    }
    public void Set_DefaultState(StringProperty property)
    {
        baseState.Set_Property(property);
        currentState.Set_Property(property);
    }

    /// <summary>
    /// Get_IntDefaultState Method
    /// Return Int Property Of BaseState
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>Int</returns>
    public int Get_IntDefaultState(ObjectProperty type)
    {
        return baseState.Get_IntProperty(type);
    }

    /// <summary>
    /// Get_FloatDefaultState Method
    /// Return Float Property Of BaseState
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>Float</returns>
    public float Get_FloatDefaultState(ObjectProperty type)
    {
        return baseState.Get_FloatProperty(type);
    }

    /// <summary>
    /// Get_StringDefaultState Method
    /// Return String Property Of BaseState
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>String</returns>
    public string Get_StringDefaultState(ObjectProperty type)
    {
        return baseState.Get_StringProperty(type);
    }

    /// <summary>
    /// Change_CurrentState OverLoad Method
    /// Change An Property On CurrentState
    /// </summary>
    /// <param name="type">Key For Find Value</param>
    /// <param name="operatorType">Operator Caculate</param>
    /// <param name="value">Value Caculate</param>
    public void Change_CurrentState(ObjectProperty type, char operatorType, int value)
    {
        currentState.Change_Property(type, operatorType, value);
    }
    public void Change_CurrentState(ObjectProperty type, char operatorType, float value)
    {
        currentState.Change_Property(type, operatorType, value);
    }
    public void Change_CurrentState(ObjectProperty type, char operatorType, string value)
    {
        currentState.Change_Property(type, operatorType, value);
    }

    /// <summary>
    /// Add_CurrentState Method
    /// Plus Values From CurrentState
    /// Values Change: Int/Float
    /// </summary>
    /// <param name="state"></param>
    public void Add_CurrentState(ObjectState state)
    {
        foreach(ObjectProperty type in state.Get_IntListState())
        {
            currentState.Change_Property(type, '+', state.Get_IntProperty(type));
        }
        foreach (ObjectProperty type in state.Get_FloatListState())
        {
            currentState.Change_Property(type, '+', state.Get_FloatProperty(type));
        }
    }

    /// <summary>
    /// Remove_CurrentState Method
    /// Minus Values From CurrentState
    /// Values Change: Int/Float
    /// </summary>
    /// <param name="state"></param>
    public void Remove_CurrentState(ObjectState state)
    {
        foreach (ObjectProperty type in state.Get_IntListState())
        {
            currentState.Change_Property(type, '-', state.Get_IntProperty(type));
        }
        foreach (ObjectProperty type in state.Get_FloatListState())
        {
            currentState.Change_Property(type, '-', state.Get_FloatProperty(type));
        }
    }

    /// <summary>
    /// Get_IntCurrentState Method
    /// Return IntProperty of CurrentState
    /// With Type Key
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>Int</returns>
    public int Get_IntCurrentState(ObjectProperty type)
    {
        return currentState.Get_IntProperty(type);
    }

    /// <summary>
    /// Get_FloatCurrentState Method
    /// Return FloatProperty of CurrentState
    /// With Type Key
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>Float</returns>
    public float Get_FloatCurrentState(ObjectProperty type)
    {
        return currentState.Get_FloatProperty(type);
    }

    /// <summary>
    /// Get_StringCurrentState Method
    /// Return StringProperty of CurrentState
    /// With Type Key
    /// </summary>
    /// <param name="type">Key Find Value</param>
    /// <returns>String</returns>
    public string Get_StringCurrentState(ObjectProperty type)
    {
        return currentState.Get_StringProperty(type);
    }

    /// <summary>
    /// Equip_Inventory Method
    /// Add Inventory From InventoryStatus
    /// And Change CurrentState
    /// </summary>
    /// <param name="slot">Slot Of Inventory</param>
    /// <param name="inventory">Inventory Will Equip</param>
    public void Equip_Inventory(InventorySlot slot, InventoryState inventory)
    {
        if (!isHaveInventory) return;
        Add_CurrentState(inventory.Status);
        inventoryState.Add(slot, inventory);
    }

    /// <summary>
    /// Equip_Inventory Method
    /// Remove Inventory From InventoryStatus
    /// And Change CurrentState
    /// </summary>
    /// <param name="slot">Slot Of Inventory On InvenstorySlot</param>
    public void Unequip_Inventory(InventorySlot slot)
    {
        if (!isHaveInventory) return;
        Remove_CurrentState(inventoryState[slot].Status);
        inventoryState.Remove(slot);
    }
    //public InventoryState Get_InfoInventory(InventorySlot slot)
    //{
    //    if (isHaveInventory || !inventoryState.ContainsKey(slot)) return null;

    //    return inventoryState[slot];
    //}

    /// <summary>
    /// Take_BuffEffect Method
    /// Add New Buff From Dictionary BuffState
    /// And Change Character CurrentStatus
    /// </summary>
    /// <param name="type">Type Of Buff</param>
    /// <param name="buff">Buff Status</param>
    public void Take_BuffEffect(BuffType type, BuffStatus buff)
    {
        if (!isHaveBuff) return;
        if(type == BuffType.buff) Add_CurrentState(buff.Status);
        else Remove_CurrentState(buff.Status);
        buffState.Add(type, buff);
    }

    /// <summary>
    /// Remove_BuffEffect Method
    /// Remove A Buff From Dictionary BuffState
    /// And Change Character CurrentStatus
    /// </summary>
    /// <param name="type">Type Of Buff on Slot</param>
    public void Remove_BuffEffect(BuffType type)
    {
        if (!isHaveBuff) return;
        if (type == BuffType.buff) Remove_CurrentState(buffState[type].Status);
        else Add_CurrentState(buffState[type].Status);
        buffState.Remove(type);
    }
}
