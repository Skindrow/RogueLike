using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Potion
{
    public int hpRestore = 15;
    
    public override void PickUp()
    {
        Player.Heal(hpRestore);
        base.PickUp();
    }
    public override void TileInfoUpdate()
    {
        tileInfoStr = "Restores " + hpRestore + " hp";
    }

}
