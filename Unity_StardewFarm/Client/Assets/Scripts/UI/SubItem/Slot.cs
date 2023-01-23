using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public GameObject equipment;
    bool activeEquipment = false;

    public int slotNum;
    public Item item;
    public Image itemIcon;

    public void UpdatesSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {
            bool isUse = item.Use();
            if (isUse)
            {
                Inventory.instance.RemoveItem(slotNum);
            }
            equipment.GetComponent<SpriteRenderer>().sprite = item.itemImage;
            activeEquipment = true;
            equipment.SetActive(activeEquipment);
        }
        else
        {
            activeEquipment = false;
            equipment.SetActive(activeEquipment);
        }
    }
}
