using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSearch : Skill
{
    public int lootTileOpen = 2;

    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : open " + lootTileOpen + " tiles with loot";
    }
    public override void SkillUse()
    {

        List<Tile> UnknownLootTiles = new List<Tile>();
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null && TileMap.tiles[i, j].isUnknown && TileMap.tiles[i, j].typeOfTile == Tile.Type.Loot)
                        UnknownLootTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }
        for (int i = 0; i < lootTileOpen; i++)
        {
            if (UnknownLootTiles.Count > 0)
            {
                int rnd = Random.Range(0, UnknownLootTiles.Count);
                UnknownLootTiles[rnd].OpenTile();
                UnknownLootTiles.RemoveAt(rnd);
            }
        }
        base.SkillUse();
    }


}
