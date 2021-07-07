using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassDamage : Skill
{
    public int massDmg = 10;

    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : deal " + massDmg + " damage to all enemies";
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
                    if (TileMap.tiles[i,j]!= null && !TileMap.tiles[i, j].isUnknown && TileMap.tiles[i, j].typeOfTile == Tile.Type.Enemy)
                        OpenEnemyTiles.Add(TileMap.tiles[i, j]);
                }
                catch { }
            }
        }

        if (OpenEnemyTiles.Count > 0)
        {

            for (int i = 0; i < OpenEnemyTiles.Count; i++)
            {
                OpenEnemyTiles[i].GetComponent<Enemy>().hp -= massDmg;
                OpenEnemyTiles[i].GetComponent<Enemy>().CheckIsDead();

            }

        }
        base.SkillUse();
    }



    
}
