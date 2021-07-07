using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : Enemy
{
    public int hpAdd = 4;

    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + " ,increase hp of adjacent enemies on "+hpAdd+" when opened";
    }
    public override void OpenEvent()
    {
        base.OpenEvent();
        try
        {
            if (TileMap.tiles[posX + 1, posY].typeOfTile == Tile.Type.Enemy &&
                !TileMap.tiles[posX + 1, posY].isUnknown)
            {
                TileMap.tiles[posX + 1, posY].GetComponent<Enemy>().hp+=hpAdd;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX - 1, posY].typeOfTile == Tile.Type.Enemy &&
                    !TileMap.tiles[posX - 1, posY].isUnknown)
            {
                TileMap.tiles[posX - 1, posY].GetComponent<Enemy>().hp+=hpAdd;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY + 1].typeOfTile == Tile.Type.Enemy &&
                !TileMap.tiles[posX, posY + 1].isUnknown)
            {
                TileMap.tiles[posX, posY + 1].GetComponent<Enemy>().hp+=hpAdd;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY - 1].typeOfTile == Tile.Type.Enemy &&
                !TileMap.tiles[posX, posY - 1].isUnknown)
            {
                TileMap.tiles[posX, posY - 1].GetComponent<Enemy>().hp+=hpAdd;
            }
        }
        catch { }
    }
    public override void DeathEvent()
    {
        base.DeathEvent();

    }


}
