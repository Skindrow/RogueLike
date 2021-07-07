using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : Enemy
{
    public int dmgAdd = 1;
    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg + " add "+ dmgAdd+" dmg when died";
    }
    
    
    
    public override void DeathEvent()
    {

        Player.DmgAdd(dmgAdd);
       
        base.DeathEvent();

    }
    
}
