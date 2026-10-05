using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class UI_Slot : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        {
            itemIcon.enabled = true;
            itemIcon.sprite = slot.icon;
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.enabled = false;
        itemIcon.sprite = null;
        quantityText.text = "";
    }
}
