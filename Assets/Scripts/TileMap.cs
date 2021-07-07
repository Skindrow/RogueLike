using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    public Tile[] enemies;
    public Tile[] loot;
    public Tile[] skills;
    public int[] numsOfEn;
    public int[] numsOfLoot;
    public int[] numsOfSkills;
    public static Tile[,] tiles = new Tile[10, 10];
    public static List<Tile> tilesInDeck = new List<Tile>();

    void Start()
    {
        tiles = RandWithFix(ArraySum(numsOfEn), ArraySum(numsOfSkills), ArraySum(numsOfLoot));
    }



    public Tile[,] RandWithFix(int numOfEnem, int numOfSkills, int numOfLoot)
    {

        int rows = tiles.GetUpperBound(0) + 1;
        int columns = tiles.GetUpperBound(1) + 1;
        int numOfTiles = rows * columns;

        


        Tile[,] tilesGen = new Tile[rows, columns];
        List<Tile> listOfGO = new List<Tile>();
        List<Tile> listOfEnem = FillListWithFix(enemies, numsOfEn);
        List<Tile> listOfLoot = FillListWithFix(loot, numsOfLoot);
        List<Tile> listOfSkills = FillListWithFix(skills, numsOfSkills);

        for (int i = 0; i < numOfEnem; i++)
        {
            listOfGO.Add(listOfEnem[i]);
        }
        for (int i = 0; i < numOfSkills; i++)
        {
            listOfGO.Add(listOfSkills[i]);
        }
        for (int i = 0; i < numOfLoot; i++)
        {
            listOfGO.Add(listOfLoot[i]);
        }

        int rnd;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                rnd = Random.Range(0, listOfGO.Count);
                Vector2 pos = new Vector2(-11.0f + 1.25f * i, 4.25f - 1.25f * j);
                tilesGen[i, j] = Instantiate(listOfGO[rnd], pos, Quaternion.identity);
                tilesGen[i, j].posX = i;
                tilesGen[i, j].posY = j;
                listOfGO.RemoveAt(rnd);
            }
        }
        return tilesGen;
    }
    public List<Tile> FillListWithFix(Tile[] gOArr, int[] nums)
    {
        List<Tile> gOList = new List<Tile>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums[i]; j++)
            {
                gOList.Add(gOArr[i]);
            }
        }
        return gOList;
    }
    public int ArraySum(int[] arr)
    {
        int arrSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            arrSum += arr[i];
        }
        return arrSum;
    }
}
