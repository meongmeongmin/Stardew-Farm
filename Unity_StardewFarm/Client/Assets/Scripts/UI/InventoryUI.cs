using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel; //  �� ��ü�� ���ؼ� ����Ƽ������ � ���� ������Ʈ�� ������ �� ������ �� �ֵ��� ��.
    bool activeInventory = false; // �κ��丮 Ȱ��ȭ ���� false�� ������. ������ ������ ����.

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inventoryPanel.SetActive(activeInventory); // ������Ʈ���� �޾Ƽ� ������
    }

    private void SlotChange(int val)
    {
        // �κ��丮 ���� ũ����� ������ Ȱ��ȭ��
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))                // Ű���� I�� ������
        {
            activeInventory = !activeInventory;         // activeInventory�� false���� true
            inventoryPanel.SetActive(activeInventory); // �ش� ���ӿ�����Ʈ�� ���� �̶� �ش��� ������Ʈ�� �κ��丮����?
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }
}
