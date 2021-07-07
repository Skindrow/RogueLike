using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : Loot
{
    public int hpRestore = 5;



    public override void TileInfoUpdate()
    {
        tileInfoStr = "Restores " + hpRestore + " hp";
    }
    public override void PickUp()
    {

        Player.Heal(hpRestore);

        base.PickUp();
    }
    
}


