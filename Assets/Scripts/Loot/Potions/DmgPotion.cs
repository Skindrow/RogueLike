using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPotion : Potion
{
    public int dmgAdd = 2;
    
    public override void PickUp()
    {
        Player.DmgAdd(dmgAdd);
        base.PickUp();
    }
    public override void TileInfoUpdate()
    {
        tileInfoStr = "add " + dmgAdd + " dmg";
    }

}
