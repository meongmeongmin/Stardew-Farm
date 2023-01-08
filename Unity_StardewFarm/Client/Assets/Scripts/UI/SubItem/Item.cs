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
    ButterflyNet,
    Seed,
    RecoveryPortion,
    fertilizer,
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;    // ��������Ʈ�� 2D �׷��� ������Ʈ �ڼ��� ������ �� ����� Ȯ���ϱ� �ٶ�.

    public bool Use()
    {
        return false;
    }
}
