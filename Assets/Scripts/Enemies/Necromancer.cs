using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : Enemy
{
    public int numsOfSkeletons = 2;
    public Tile skeletonPrefab;
    
    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + "spawn " + numsOfSkeletons + "skeletons when opened";
    }
    public override void OpenEvent()
    {
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
        for (int i = 0; i < numsOfSkeletons; i++)
        {
            if (posArray.Count > 0)
            {
                int rnd = Random.Range(0, posArray.Count);
                TileMap.tiles[posXArray[rnd], posYArray[rnd]] = Instantiate(skeletonPrefab, posArray[rnd], Quaternion.identity);
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].isUnknown = false;
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].TileInitialisation();
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].posX = posXArray[rnd];
                TileMap.tiles[posXArray[rnd], posYArray[rnd]].posY = posYArray[rnd];
                Player.OpenTilesCheck();
                posArray.RemoveAt(rnd);
            }
        }
    }

}
