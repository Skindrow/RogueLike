using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTile : Skill
{
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : copy chosen tile";
    }
    public override void SkillUse()
    {
        TargetSkillSwitchUse();
        targetSkillInUse = this.gameObject.GetComponent<CopyTile>();
    }
    public override void TargetSkillUse(int posX, int posY)
    {
        Tile tileGO = null;
        if (TileMap.tiles[posX, posY].gameObject != null && !TileMap.tiles[posX, posY].isUnknown)
        {
            tileGO = TileMap.tiles[posX, posY];
            bool isUnknownOnTile = TileMap.tiles[posX, posY].isUnknown;




            List<Tile> NullTiles = new List<Tile>();
            List<int> posXArray = new List<int>();
            List<int> posYArray = new List<int>();
            List<Vector2> posArray = new List<Vector2>();
            for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
                {
                    try
                    {
                        if (TileMap.tiles[i, j] == null)
                        {
                            posArray.Add(new Vector2(-11.0f + 1.25f * i, 4.25f - 1.25f * j));
                            posXArray.Add(i);
                            posYArray.Add(j);

                        }
                    }
                    catch { }
                }
            }
            if (posArray.Count > 0)
            {
                int rnd = Random.Range(0, posArray.Count);
                TileMap.tiles[posXArray[rnd], posYArray[rnd]] = Instantiate(tileGO, posArray[rnd], Quaternion.identity);
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].posX = posXArray[rnd];
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].posY = posYArray[rnd];
                Player.OpenTilesCheck();
            }

            TargetSkillSwitchUse();
            Destroy(this.gameObject);
        }
        else
        {
            print("null hual");
            TargetSkillSwitchUse();
        }

    }
}

