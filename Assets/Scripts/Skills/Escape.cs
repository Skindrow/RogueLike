using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : Skill
{
    public Sprite unknownSprite;
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Close all tiles";
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
                    if (TileMap.tiles[i,j]!=null && !TileMap.tiles[i, j].isUnknown)
                        UnknownLootTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }
        if (UnknownLootTiles.Count > 0)
        {
            for (int i = 0; i < UnknownLootTiles.Count; i++)
            {
                UnknownLootTiles[i].CloseTile();
            }
        }
        base.SkillUse();

    }

}
