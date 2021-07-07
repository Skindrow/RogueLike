using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{


    public override void TileInfoUpdate()
    {
        tileInfoStr = "hp - " + hp + " dmg - " + dmg+ " ";
    }
    

}
