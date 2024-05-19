using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrisonTile : Tile
{

    [SerializeField]
    private Sprite[] Sprites;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        var floor2 = 15.0f;
        var floor3 = 30.0f;
        var floor4 = 32.0f;
        var floor5 = 34.0f;
        var floor6 = 36.0f;
        var floor7 = 38.0f;

        var choosen = Random.Range(0.0f, 300.0f);

        if (choosen >= 0f && choosen < floor2)
        {
            tileData.sprite = Sprites[1];
        }
        else if (choosen >= floor2 && choosen < floor3)
        {
            tileData.sprite = Sprites[2];
        }
        else if (choosen >= floor3 && choosen < floor4)
        {
            tileData.sprite = Sprites[3];
        }
        else if (choosen >= floor4 && choosen < floor5)
        {
            tileData.sprite = Sprites[4];
        }
        else if (choosen >= floor5 && choosen < floor6)
        {
            tileData.sprite = Sprites[5];
        }
        else if (choosen >= floor6 && choosen <= floor7)
        {
            tileData.sprite = Sprites[6];
        }
        else
        {
            tileData.sprite = Sprites[0];
        }

    }
}
