using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Dagger : RS_Item
{
    float attackPower = 100;
    float dexterity = 25;
    public RS_Dagger(string newItemName, string NewItemDescription, float NewItemWeight, float NewAttackPower, float NewDexterity)
    {
        itemName = newItemName;
        itemDescription = NewItemDescription;
        itemWeight = NewItemWeight;
        attackPower = NewAttackPower;
        dexterity = NewDexterity;

    }
    internal void attack()
    {
        Debug.Log("You throw the dagger!");
    }
    internal void throwDagger()
    {
        Debug.Log("Dagger thrown the way you are facing");
    }
    internal void DaggerAttributes()
    {

    }
    
}
