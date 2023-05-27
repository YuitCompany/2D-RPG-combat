using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int ActiveSlotIndex = 0;

    private PlayerControls playerControls;


    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    /// <summary>
    /// ActiveInventory Private Method
    /// </summary>
    // enable PlayerControls
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Acvtive Slot
    private void ToggleActiveSlot(int indexValue)
    {
        ToggleActiveHighlight(indexValue - 1);
    }

    // Reset and Set Active InventorySlot Highlight
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
