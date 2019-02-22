using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    
    private Inventory playerInventory;
    private ItemSlot[] slots;

	// Use this for initialization
	void Start () {
        slots = GetComponentsInChildren<ItemSlot>();
        playerInventory = GameManager.Instance.player.inventory;
        playerInventory.ItemChange += UpdateUI;
        UpdateUI(null, EventArgs.Empty);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void UpdateUI(object sender,EventArgs e)
    {
        for (int i = 0; i < slots.Length ; i++)
        {
            if(i< playerInventory.items.Count)
            {
                slots[i].AddItem(playerInventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
