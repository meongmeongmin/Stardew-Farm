using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseSelect : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase changeTile;
    public TileBase selectTile;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
        transform.position = mousePosition;

        if (Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        {
            sr.color = Color.red;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), changeTile);
            }

            sr.color = Color.green;
        }
    }
}
