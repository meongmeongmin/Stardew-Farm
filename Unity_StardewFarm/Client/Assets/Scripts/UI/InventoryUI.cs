using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel;   // 이 객체를 통해서 유니티엔진이 어떤 게임 오브젝트랑 연결할 지 설정할 수 있도록 함.
    bool activeInventory = false;       // 인벤토리 활성화할지 확인하는 변수.

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;

        inventoryPanel.SetActive(activeInventory); // 업데이트에서 받아서 시작함
    }

    private void SlotChange(int val)
    {
        // 인벤토리 슬롯 크기까지 슬롯을 활성화함
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNum = i;

            if (i < inven.BasicSlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))                // 키보드 I를 누르면
        {
            activeInventory = !activeInventory;         // activeInventory가 false에서 true
            inventoryPanel.SetActive(activeInventory); // 해당 게임오브젝트가 열림 이떼 해당한 오브젝트는 인벤토리ㅇㅋ?
        }
    }

    public void AddSlot()
    {
        inven.BasicSlotCnt = inven.BasicSlotCnt + 4;
    }

    void RedrawSlotUI()
    {
        for (int i =0; i < slots.Length; i++)
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
