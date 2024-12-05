using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Sheild : RW_Item
{
    private float protectValue;
    private float dexteritiyValue;

    public RW_Sheild(string newItemName, string newItemDescription, float newItemWeight, float newItemProtectValue, float newItemDexterityValue)
    {
        name = newItemName;
        description = newItemDescription;
        weight = newItemWeight;
        protectValue = newItemProtectValue;
        dexteritiyValue = newItemDexterityValue;
    }

    internal void Block()
    {
        Debug.Log("Am blocking you");
    }
}
