using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Helmet : RS_Item
{
    float armor = 100;
    float extraMana = 100;
    public RS_Helmet(string itemName, string itemDescription, float itemWeight, float armor, float extraMana)
    {
        
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
