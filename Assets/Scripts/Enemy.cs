using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tile
{
    public int hp;
    public int dmg;
    public TypeOfEnemy typeOfEnemyOnGO;
    public int XPforKill;
    public void OnMouseDown()
    {
        if (Skill.isTargetSkillInUse)
        {
            Skill.targetSkillInUse.TargetSkillUse(posX, posY);
        }
        else if (isUnknown && !Player.openBlock)
        {
            OpenTile();
            
            TileInfoUpdate();
            Tile.tileInfoText.text = tileInfoStr;
        }
        else if (!isUnknown)
        {
            Player.TakeDamage(dmg);
            hp = Player.DealDamage(hp);
            AttackEvent();
            TileInfoUpdate();
            Tile.tileInfoText.text = tileInfoStr;

            
        }
        CheckIsDead();
    }
    
    public override void OpenTile()
    {
        base.OpenTile();
        
        OpenEvent();

    }


    public virtual void OpenEvent()
    {
        
    }
    public virtual void DeathEvent()
    {
        Destroy(this.gameObject);
        TileMap.tiles[posX, posY] = null;
        Player.OpenTilesCheck();
    }
    public void DropAfterDeath()
    {

    }

    public enum TypeOfEnemy
    {
        Monster,
        Knight,
        Mush,
        Necromancer,
        BigSlime,
        Skeleton
    }
    public void CheckIsDead()
    {
        if (hp <= 0)
        {
            Tile.tileInfoText.text = " ";
            DeathEvent();
        }
    }
    public virtual void AttackEvent()
    {

    }

}
