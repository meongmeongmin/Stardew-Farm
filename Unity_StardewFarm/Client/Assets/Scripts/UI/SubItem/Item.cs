using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Sickle,
    Shovel,
    Axe,
    FishingRod,
    WateringCan,
    Seed,
    RecoveryPortion,
    Fertilizer,
    Etc,
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;        // ��������Ʈ�� 2D �׷��� ������Ʈ��. �ڼ��� ������ �� ����� Ȯ���ϱ� �ٶ�.
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
    }
}
