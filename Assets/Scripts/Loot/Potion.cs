using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Loot
{
    public TypeOfPotion typeOfPotionOnGO;
    public enum TypeOfPotion
    {
        HealPotion,
        Poison,
        ManaPotion
    }
}
