using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel;   
    bool activeInventory = false;       // 인벤토리를 활성화할지 확인함

    public Slot[] slots;
    public Transform slotHolder;

    public Text _gold;
    int playerGold = 1000;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;

        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        // 인벤토리 슬롯 크기까지 슬롯을 활성화함
        for (int i = 0; i < slots.Length; i++)
        {
             slots[i].slotNum = i;

             if (i < inven.InitialSlotCnt)
                 slots[i].GetComponent<Button>().interactable = true;
             else
                 slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        // 키보드 I를 누르면 인벤토리가 열림
        if (Input.GetKeyDown(KeyCode.I))                
        {
            if (inventoryPanel.activeSelf) // 이미 인벤토리 창이 켜져있는지 확인함
                activeInventory = false;
            else
                activeInventory = true;

            inventoryPanel.SetActive(activeInventory);
        }
    }

    // 슬롯 창을 확장해주는 함수
    public void AddSlot()
    {
        if (playerGold >= 1000)
        {
            inven.InitialSlotCnt = inven.InitialSlotCnt + 4;

            Debug.Log("Gold -1000\nInventory slot +4");
            playerGold = playerGold - 1000;
            _gold.text = $"Gold : {playerGold}";
        }
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdatesSlotUI();
        }
    }
}
