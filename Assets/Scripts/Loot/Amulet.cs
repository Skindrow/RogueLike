using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amulet : Loot
{
    private int hpRestore = 40;
    public override void TileInfoUpdate()
    {
        tileInfoStr = "restore "+hpRestore+" hp if only this tile open";
    }
    public override void PickUp()
    {
        if (Player.openTiles == 1)
        {
            Player.Heal(hpRestore);
            base.PickUp();
        }
        else
            base.PickUp();
    }
    
}


