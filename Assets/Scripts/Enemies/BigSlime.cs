using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlime : Enemy
{
    public Tile[] enemies;
    public int[] persents;



    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + " spawn random enemy when taken damage";
    }
    public override void AttackEvent()
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
        if (posArray.Count > 0)
        {
            int rnd = Random.Range(0, posArray.Count);
            TileMap.tiles[posXArray[rnd], posYArray[rnd]] = Instantiate(RandGOgen(enemies, persents), posArray[rnd], Quaternion.identity);
            TileMap.tiles[posXArray[rnd], posYArray[rnd]].TileInitialisation();
            TileMap.tiles[posXArray[rnd], posYArray[rnd]].posX = posXArray[rnd];
            TileMap.tiles[posXArray[rnd], posYArray[rnd]].posY = posYArray[rnd];
            TileMap.tiles[posXArray[rnd], posYArray[rnd]].OpenTile();
            //posArray.RemoveAt(rnd);
        }

    }
    public Tile RandGOgen(Tile[] GOarr, int[] pers)
    {
        if (GOarr.Length != pers.Length)
            print("pizdec RandGOgen");
        int persSum = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            persSum += pers[i];
        }
        int rnd = Random.Range(1, persSum + 1);
        int index = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            if (rnd <= pers[i])
            {
                index = i;
                break;
            }
            rnd -= pers[i];
        }
        return GOarr[index];
    }
}
