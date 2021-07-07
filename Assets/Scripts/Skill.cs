using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : Tile
{
    public bool isInSlot = false;
    public static bool isTargetSkillInUse = false;
    public static Skill targetSkillInUse;
  

    private void OnMouseDown()
    {
        if (Skill.isTargetSkillInUse)
        {
            Skill.targetSkillInUse.TargetSkillUse(posX, posY);
        }
        else if (isUnknown && !Player.openBlock)
        {
            OpenTile();
        }
        else if (!isUnknown && !isInSlot)
        {
            Player.AddItemOnSlot(this);
        }
        else if (isInSlot)
        {
            SkillUse();
        }
    }
    public virtual void SkillInfoUpdate()
    {

    }
    public virtual void SkillUse()
    {
        Destroy(this.gameObject);
    }
    public virtual void TargetSkillUse(int posX , int posY)
    {
    }
    public void TargetSkillSwitchUse()
    {
        if (!isTargetSkillInUse)
        {
            isTargetSkillInUse = true;
            this.gameObject.transform.localScale *= 1.5f;
        }
        else if (isTargetSkillInUse)
        {
            isTargetSkillInUse = false;
            this.gameObject.transform.localScale /= 1.5f;
        }
    }

    
}
