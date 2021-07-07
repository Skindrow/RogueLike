using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + "open random tile when opened";
    }
    public override void OpenEvent()
    {
        base.OpenEvent();
        List<Tile> UnknownTiles = new List<Tile>();
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null && TileMap.tiles[i, j].isUnknown)
                        UnknownTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }
        try
        {
            if (UnknownTiles.Count > 0)
            {
                int rnd = Random.Range(0, UnknownTiles.Count);
                UnknownTiles[rnd].OpenTile();
            }
        }
        catch { print("knight open error"); }
    }

    public override void DeathEvent()
    {
        base.DeathEvent();
    }

}
