using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Banana : DB_Item
{
    public DB_Banana(string itemName, string description, float weight) : base(itemName, description, weight)
    {
        this.itemName = itemName;
        this.description = description;
        this.weight = weight;
    }

    void eat()
    {
        Debug.Log("Eatens");
    }
}
