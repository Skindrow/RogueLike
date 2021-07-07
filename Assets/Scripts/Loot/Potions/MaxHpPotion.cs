using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHpPotion : Potion
{
    public int hpAdd = 5;
    
    public override void PickUp()
    {
        Player.MaxHpAdd(hpAdd);
        base.PickUp();
    }
    public override void TileInfoUpdate()
    {
        tileInfoStr = "add " + hpAdd + " max hp";
    }

}
