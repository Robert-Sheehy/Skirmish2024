using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Item
{
    public string itemName;
    public string description;
    public float weight;

    public DB_Item(string itemName, string description, float weight)
    {
        this.itemName = itemName;
        this.description = description;
        this.weight = weight;
    }

    public string getName() {
        return itemName; 
    }

    public string getDescription()
    {
        return description;

    }
    public string toString()
    {
        string output = "\n";
        output += this.itemName + ", ";
        output += this.description + ", ";
        output += this.weight + "\n";

        return itemName;
    }
}
