using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Helmet : RS_Item
{
    float armor = 100;
    float extraMana = 100;
    public RS_Helmet(string newItemName, string newItemDescription, float newItemWeight, float newArmorValue, float newExtraMana)
    {
        itemName = newItemName;
        itemDescription = newItemDescription;
        itemWeight = newItemWeight;
        armor = newArmorValue;
        extraMana = newExtraMana;
    }
    void wear()
    {
        Debug.Log("You slide the helmet onto your head!");
    }

    internal void wearHelmet()
    {
        Debug.Log("Putting on Helmet");
    }

    internal void HelmetAttributes()
    {

    }
   
}
