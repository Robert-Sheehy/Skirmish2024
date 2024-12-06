using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Banana : RW_Item
{
    private float freezeValue;
    private float dexteritiyValue;

    public RW_Banana(string newItemName, string newItemDescription, float newItemWeight, float newItemFreezeValue, float newItemDexterityValue)
    {
        name = newItemName;
        description = newItemDescription;
        weight = newItemWeight;
        freezeValue = newItemFreezeValue;
        dexteritiyValue = newItemDexterityValue;
    }

    internal void Freeze()
    {
        Debug.Log("Stop moving for 10 secs");
    }
}
