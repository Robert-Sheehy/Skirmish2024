using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_BackPack : RS_Item
// Start is called before the first frame update
{
    float slots = 20;
    float hiddenSpace = 5;
    public RS_BackPack(string newItemName, string newItemDescription, float newItemWeight, float NewSlots, float NewHiddenSpace)
    {
        itemName = newItemName;
        itemDescription = newItemDescription;
        itemWeight = newItemWeight;
        slots = NewSlots;
        hiddenSpace = NewHiddenSpace;
       
    }
    void wear()
    {
        Debug.Log("You wear the backpack on your back!");
    }

    internal void wearBackPack()
    {
        Debug.Log("Wearing the backpack");
    }
    internal void BackPackAttributes()
    {

    }
}
