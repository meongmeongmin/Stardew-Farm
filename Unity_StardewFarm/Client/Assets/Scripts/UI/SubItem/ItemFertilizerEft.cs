using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Fertilizer")]
public class ItemFertilizerEft : ItemEffect
{
    public int growthPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("Crop growth Add : " + growthPoint);
        return true;
    }
}
