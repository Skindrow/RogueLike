using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEyedMush : Enemy
{
    public int dmgDesc = -2;
    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + " descreace dmg on " + dmgDesc + " when died";
    }
    
    
    
    public override void DeathEvent()
    {

        Player.DmgAdd(dmgDesc);
       
        base.DeathEvent();

    }
    
}
