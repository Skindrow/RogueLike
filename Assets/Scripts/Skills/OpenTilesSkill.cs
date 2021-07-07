using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTilesSkill : Skill
{
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : Open chosen and adjacent tiles";
    }
    public override void SkillUse()
    {
        isTargetSkillInUse = true;
        targetSkillInUse = this.gameObject.GetComponent<OpenTilesSkill>();
    }
    public override void TargetSkillUse(int posX, int posY)
    {
        bool isAnyTileOpened = false;
        try
        {
            if (TileMap.tiles[posX, posY].isUnknown)
            {
                TileMap.tiles[posX, posY].OpenTile();
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX + 1, posY].isUnknown)
            {
                TileMap.tiles[posX + 1, posY].OpenTile();
                isAnyTileOpened = true;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX - 1, posY].isUnknown)
            {
                TileMap.tiles[posX - 1, posY].OpenTile();
                isAnyTileOpened = true;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY + 1].isUnknown)
            {
                TileMap.tiles[posX, posY + 1].OpenTile();
                isAnyTileOpened = true;
            }
        }
        catch { }
        try
        {
            if (TileMap.tiles[posX, posY - 1].isUnknown)
            {
                TileMap.tiles[posX, posY - 1].OpenTile();
                isAnyTileOpened = true;
            }
        }
        catch { }
        isTargetSkillInUse = false;
        if (isAnyTileOpened)
            Destroy(this.gameObject);
        else
            print("no tiles opened");
    }
}
