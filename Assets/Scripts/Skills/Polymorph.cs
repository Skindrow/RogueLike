using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polymorph : Skill
{
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Skill : replace choosen tile with other random tile";
    }
    public override void SkillUse()
    {
        TargetSkillSwitchUse();
        targetSkillInUse = this.gameObject.GetComponent<Polymorph>();
    }
    public override void TargetSkillUse(int posX, int posY)
    {
        if (TileMap.tiles[posX, posY] != null && TileMap.tiles[posX , posY].isUnknown == false)
        {
            TileMap tileMapOnGo = GameObject.Find("Main Camera").GetComponent<TileMap>();
            List<Tile> allTiles = new List<Tile>();
            for (int i = 0; i < tileMapOnGo.enemies.Length; i ++)
            {
                allTiles.Add(tileMapOnGo.enemies[i]);
            }
            for (int i = 0; i < tileMapOnGo.loot.Length; i++)
            {
                allTiles.Add(tileMapOnGo.loot[i]);
            }
            for (int i = 0; i < tileMapOnGo.skills.Length; i++)
            {
                allTiles.Add(tileMapOnGo.skills[i]);
            }
            int rnd = Random.Range(0,allTiles.Count);
            Vector2 pos = new Vector2(-11.0f + 1.25f * posX, 4.25f - 1.25f * posY);




            Destroy(TileMap.tiles[posX, posY].gameObject);
            TileMap.tiles[posX, posY] = Instantiate(allTiles[rnd],pos,Quaternion.identity);
            TileMap.tiles[posX, posY].isUnknown = false;
            TileMap.tiles[posX, posY].posX = posX;
            TileMap.tiles[posX, posY].posY = posY;
            Player.OpenTilesCheck();
            TargetSkillSwitchUse();
            Destroy(this.gameObject);

        }
        else
        {

            TargetSkillSwitchUse();
        }
    }
}
