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
    public Sprite itemImage;    // 스프라이트는 2D 그래픽 오브젝트 자세한 내용은 내 노션을 확인하길 바람.

    public bool Use()
    {
        return false;
    }
}
