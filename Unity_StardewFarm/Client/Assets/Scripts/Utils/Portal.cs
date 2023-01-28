using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum NextPositionType
    {
        InitPosition,
        SomePosition,
    };

    public NextPositionType nextPositionType;

    public Transform DestinationPoint;

    public bool Trans = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Trans = true;
            if(nextPositionType == NextPositionType.InitPosition && Trans == true)
            {
                collision.transform.position = Vector3.zero;
            }
            else if (nextPositionType == NextPositionType.SomePosition)
            {
                collision.transform.position = DestinationPoint.position;
                
            }
            else
            {

            }
            Trans = false;
        }
    }
}
