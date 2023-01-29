using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject fieldItemPrefab;
    public Vector3[] pos;   // position �� ����

    private void Start()
    {
        for (int i = 0; i < 7; i++) // �ʵ忡�� ��Ÿ�� ������ ����
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);

            if (i >= 0 && i <= 3)
            {
                go.GetComponent<FieldItems>().SetItem(itemDB[5]);
            }
            else
            {
                go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(6, 8)]);
            }
        }
    }
}
