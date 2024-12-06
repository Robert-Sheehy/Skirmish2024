using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Dagger : RS_Item
{
    public RS_Dagger(string newItemName, string itemDescription, float itemWeight, float attackPower, float dexterity)
    {
        itemName = newItemName;

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
