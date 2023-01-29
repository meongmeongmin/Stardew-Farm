using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel;   
    bool activeInventory = false;       // �κ��丮�� Ȱ��ȭ���� Ȯ����

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
        // �κ��丮 ���� ũ����� ������ Ȱ��ȭ��
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
        // Ű���� I�� ������ �κ��丮�� ����
        if (Input.GetKeyDown(KeyCode.I))                
        {
            if (inventoryPanel.activeSelf) // �̹� �κ��丮 â�� �����ִ��� Ȯ����
                activeInventory = false;
            else
                activeInventory = true;

            inventoryPanel.SetActive(activeInventory);
        }
    }

    // ���� â�� Ȯ�����ִ� �Լ�
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
