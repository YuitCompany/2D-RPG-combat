using BaseObject;
using BaseStats;
using BaseBuff;
using BaseInventory;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Character
{
    ObjectState baseState = new ObjectState();
    Dictionary<InventorySlot, InventoryState> inventoryState;
    BuffStatus buffState;
    ObjectState currentState = new ObjectState();

    bool isInventory = false;
    bool isBuff = false;

    // active
    public void ActiveInventory()
    {
        isInventory = true;
        inventoryState = new Dictionary<InventorySlot, InventoryState>();
    }

    public void ActiveBuff()
    {
        isBuff = true;
        buffState = new BuffStatus();
    }

    // base
    public void Set_DefaultState(IntProperty property)
    {
        baseState.Set_Property(property);
    }
    public void Set_DefaultState(FloatProperty property)
    {
        baseState.Set_Property(property);
    }
    public void Set_DefaultState(StringProperty property)
    {
        baseState.Set_Property(property);
    }

    public int Get_IntDefaultState(ObjectProperty type)
    {
        return baseState.Get_IntProperty(type);
    }
    public float Get_FloatDefaultState(ObjectProperty type)
    {
        return baseState.Get_FloatProperty(type);
    }
    public string Get_StringDefaultState(ObjectProperty type)
    {
        return baseState.Get_StringProperty(type);
    }

    // current
    public void Set_CurrentState(IntProperty property)
    {
        currentState.Set_Property(property);
    }
    public void Set_CurrentState(FloatProperty property)
    {
        currentState.Set_Property(property);
    }
    public void Set_CurrentState(StringProperty property)
    {
        currentState.Set_Property(property);
    }

    public int Get_IntCurrentState(ObjectProperty type)
    {
        return currentState.Get_IntProperty(type);
    }
    public float Get_FloatCurrentState(ObjectProperty type)
    {
        return currentState.Get_FloatProperty(type);
    }
    public string Get_StringCurrentState(ObjectProperty type)
    {
        return currentState.Get_StringProperty(type);
    }

    // inventory
    public void EquipInventory(InventorySlot slot, InventoryState inventory)
    {
        if (isInventory) return;
        inventoryState.Add(slot, inventory);
    }

    public void UneqipInventory(InventorySlot slot)
    {
        if (isInventory) return;
        inventoryState.Remove(slot);
    }
    private void UpdateCurrentState(InventoryState inventory)
    {
        if (isInventory) return;
    }
}
