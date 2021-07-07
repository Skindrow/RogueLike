using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgForOpenEn : Skill
{
    public int dmgAdd = 2;

    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : add " + dmgAdd + " damage for every open enemy";
    }

    public override void SkillUse()
    {


        List<Tile> OpenEnemyTiles = new List<Tile>();
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null && !TileMap.tiles[i, j].isUnknown && TileMap.tiles[i, j].typeOfTile == Tile.Type.Enemy)
                        OpenEnemyTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }

        if (OpenEnemyTiles.Count > 0)
        {
            Player.DmgAdd(OpenEnemyTiles.Count * dmgAdd);
        }
        base.SkillUse();
    }




}
