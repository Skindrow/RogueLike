using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Tile
{
    
    public TypeOfLoot typeOfLootOnGO;
    
    public enum TypeOfLoot
    {
        Food,
        Coin,
        Potion,
        Bomb
    }
    private void OnMouseDown()
    {
        if (Skill.isTargetSkillInUse)
        {
            Skill.targetSkillInUse.TargetSkillUse(posX,posY);
        }
        else if (isUnknown && !Player.openBlock)
        {
            OpenTile();
        }
        else if (!isUnknown)
        {
            PickUp();
        }

    }
    
    public void DestroyByTile()
    {
        Destroy(this.gameObject);
        TileMap.tiles[posX, posY] = null;
        Player.OpenTilesCheck();
    }
    public virtual void PickUp()
    {
        Destroy(this.gameObject);
        TileMap.tiles[posX, posY] = null;
        Player.OpenTilesCheck();
    }

}
