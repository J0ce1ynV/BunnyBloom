using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<UI_Slot> slots = new List<UI_Slot>();

    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
    }

    void Refresh()
    {
        Debug.Log("REFRESH DIPANGGIL");
        Debug.Log("UI Slots: " + slots.Count);
        Debug.Log("Inventory Slots: " + player.inventory.slots.Count);

        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                //Debug.Log("Refresh Slot " + i +" | Type: " + player.inventory.slots[i].type +" | Count: " + player.inventory.slots[i].count);

                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    //Debug.Log("SET ITEM pada slot " + i);
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    //Debug.Log("SET EMPTY pada slot " + i);
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int SlotID)
    {
        //Debug.Log("REMOVE dipanggil - SlotID: " + SlotID +
        //      " Count sebelum: " + player.inventory.slots[SlotID].count);

        Collectable itemToDrop = GameManager.Instance.itemManager.GetItemByType(player.inventory.slots[SlotID].type);
        //Collectable itemToDrop     = GameManager.Instance.itemManager.GetItemByType(player.inventory.slots[slotID].type);
        if (itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(SlotID);
            Refresh(); 
        }
        
    }
}