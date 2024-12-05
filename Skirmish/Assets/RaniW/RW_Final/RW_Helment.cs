using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Helment : RW_Item
{
    private float protectValue;
    private float dexteritiyValue;

    public RW_Helment(string newItemName, string newItemDescription, float newItemWeight, float newItemProtectValue, float newItemDexterityValue)
    {
        name = newItemName;
        description = newItemDescription;
        weight = newItemWeight;
        protectValue = newItemProtectValue;
        dexteritiyValue = newItemDexterityValue;
    }

    internal void Protect()
    {
        Debug.Log("Am blocking attack");
    }    
}
