using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private PlayerControls playerControls;
    private int ActiveSlotIndex = 0;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    /// <summary>
    /// OnEnable Method
    /// Enable Inventory Keyboard
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }
    
    /// <summary>
    /// ToggleActiveSlot Method
    /// Active Inventory Slot
    /// </summary>
    /// <param name="indexValue">Inventory Slot</param>
    private void ToggleActiveSlot(int indexValue)
    {
        ToggleActiveHighlight(indexValue - 1);
    }

    /// <summary>
    /// ToggleActiveHighlight Method
    /// Active And Highlight New Inventory Slot
    /// Inactive And Remove Highlight Old Inventory Slot
    /// </summary>
    /// <param name="indexValue">Inventory Slot</param>
    private void ToggleActiveHighlight(int indexValue)
    {
        ActiveSlotIndex = indexValue;

        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexValue).GetChild(0).gameObject.SetActive(true);
    }
}
