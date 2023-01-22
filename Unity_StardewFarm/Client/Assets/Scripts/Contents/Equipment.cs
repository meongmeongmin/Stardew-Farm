using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject equipment;
    bool activeEquipment = false;

    public void Start()
    {
        equipment.SetActive(activeEquipment);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            activeEquipment = !activeEquipment;
            equipment.SetActive(activeEquipment);
        }
    }
}
