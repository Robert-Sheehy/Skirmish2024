using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Helmet : DB_Item
{
    public DB_Helmet(string itemName, string description, float weight) : base(itemName, description, weight)
    {
        this.itemName = itemName;
        this.description = description;
        this.weight = weight;
    }

    void wear()
    {
        Debug.Log("Worn");
    }
}

