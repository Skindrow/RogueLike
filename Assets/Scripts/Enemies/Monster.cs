using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy
{


    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg+ " ,eating meat on adjacent tiles when opened";
    }
    public override void OpenEvent()
    {
        base.OpenEvent();
        try
        {
            if (TileMap.tiles[posX + 1, posY].GetComponent<Loot>().typeOfLootOnGO == Loot.TypeOfLoot.Food &&
                !TileMap.tiles[posX + 1, posY].isUnknown)
            {
                hp += 3;
                TileInfoUpdate();
                TileMap.tiles[posX + 1, posY].GetComponent<Loot>().DestroyByTile();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX - 1, posY].GetComponent<Loot>().typeOfLootOnGO == Loot.TypeOfLoot.Food &&
                    !TileMap.tiles[posX - 1, posY].isUnknown)
            {
                hp += 3;
                TileInfoUpdate();
                TileMap.tiles[posX - 1, posY].GetComponent<Loot>().DestroyByTile();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY + 1].GetComponent<Loot>().typeOfLootOnGO == Loot.TypeOfLoot.Food &&
                !TileMap.tiles[posX, posY + 1].isUnknown)
            {
                hp += 3;
                TileInfoUpdate();
                TileMap.tiles[posX, posY + 1].GetComponent<Loot>().DestroyByTile();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY - 1].GetComponent<Loot>().typeOfLootOnGO == Loot.TypeOfLoot.Food &&
                !TileMap.tiles[posX, posY - 1].isUnknown)
            {
                hp += 3;
                TileInfoUpdate();
                TileMap.tiles[posX, posY - 1].GetComponent<Loot>().DestroyByTile();
            }
        }
        catch { }
    }
    public override void DeathEvent()
    {
        base.DeathEvent();
        
    }
    

}
