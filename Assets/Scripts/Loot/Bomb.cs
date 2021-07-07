using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Loot
{
    public int dmg = 15;
    
    public override void TileInfoUpdate()
    {
        tileInfoStr = "deal " + dmg + " dmg to adjacent enemies and destroy loot tiles";
    }

    public override void PickUp()
    {
        try
        {
            if (TileMap.tiles[posX + 1, posY].typeOfTile == Tile.Type.Loot && !TileMap.tiles[posX + 1, posY].isUnknown)
            {
                TileMap.tiles[posX + 1, posY].GetComponent<Loot>().DestroyByTile();
            }
            if (TileMap.tiles[posX + 1, posY].typeOfTile == Tile.Type.Enemy && !TileMap.tiles[posX + 1, posY].isUnknown)
            {
                TileMap.tiles[posX + 1, posY].GetComponent<Enemy>().hp -= dmg;
                TileMap.tiles[posX + 1, posY].GetComponent<Enemy>().CheckIsDead();
                TileMap.tiles[posX + 1, posY].GetComponent<Enemy>().TileInfoUpdate();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX - 1, posY].typeOfTile == Tile.Type.Loot && !TileMap.tiles[posX - 1, posY].isUnknown)
            {
                TileMap.tiles[posX - 1, posY].GetComponent<Loot>().DestroyByTile();
            }
            if (TileMap.tiles[posX - 1, posY].typeOfTile == Tile.Type.Enemy && !TileMap.tiles[posX - 1, posY].isUnknown)
            {
                TileMap.tiles[posX - 1, posY].GetComponent<Enemy>().hp -= dmg;
                TileMap.tiles[posX - 1, posY].GetComponent<Enemy>().CheckIsDead();
                TileMap.tiles[posX - 1, posY].GetComponent<Enemy>().TileInfoUpdate();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY + 1].typeOfTile == Tile.Type.Loot && !TileMap.tiles[posX, posY + 1].isUnknown)
            {
                TileMap.tiles[posX, posY + 1].GetComponent<Loot>().DestroyByTile();
            }
            if (TileMap.tiles[posX, posY + 1].typeOfTile == Tile.Type.Enemy && !TileMap.tiles[posX, posY + 1].isUnknown)
            {
                TileMap.tiles[posX, posY + 1].GetComponent<Enemy>().hp -= dmg;
                TileMap.tiles[posX, posY + 1].GetComponent<Enemy>().CheckIsDead();
                TileMap.tiles[posX, posY + 1].GetComponent<Enemy>().TileInfoUpdate();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY - 1].typeOfTile == Tile.Type.Loot && !TileMap.tiles[posX, posY - 1].isUnknown)
            {
                TileMap.tiles[posX, posY - 1].GetComponent<Loot>().DestroyByTile();
            }
            if (TileMap.tiles[posX, posY - 1].typeOfTile == Tile.Type.Enemy && !TileMap.tiles[posX, posY - 1].isUnknown)
            {
                TileMap.tiles[posX, posY - 1].GetComponent<Enemy>().hp -= dmg;
                TileMap.tiles[posX, posY - 1].GetComponent<Enemy>().CheckIsDead();
                TileMap.tiles[posX, posY - 1].GetComponent<Enemy>().TileInfoUpdate();
            }
        }
        catch { }

        base.PickUp();
    }
}
