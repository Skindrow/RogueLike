using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournament : Skill
{
    public int enemyTileOpen = 3;
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : open  tiles with loot";
    }

    public override void SkillUse()
    {
        List<Tile> UnknownTiles = new List<Tile>();
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null && !TileMap.tiles[i, j].isUnknown)
                        UnknownTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }
        if (UnknownTiles.Count > 0)
        {
            for (int i = 0; i < UnknownTiles.Count; i++)
            {
                UnknownTiles[i].CloseTile();
            }
        }
        List<Tile> UnknownEnemyTiles = new List<Tile>();
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null && TileMap.tiles[i, j].isUnknown && TileMap.tiles[i, j].typeOfTile == Tile.Type.Loot)
                        UnknownEnemyTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }
        for (int i = 0; i < enemyTileOpen; i++)
        {
            if (UnknownEnemyTiles.Count > 0)
            {
                int rnd = Random.Range(0, UnknownEnemyTiles.Count);
                UnknownEnemyTiles[rnd].OpenTile();
                UnknownEnemyTiles.RemoveAt(rnd);
            }

        }
    }
}
