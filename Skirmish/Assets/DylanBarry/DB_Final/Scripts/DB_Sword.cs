using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DB_Sword : DB_Item
{
    private float attackPower;
    private float dexterity;

    public DB_Sword(string itemName, string description, float weight, float attackPower, float dexterity) : base(itemName, description, weight)
    {
        this.itemName = itemName;
        this.description = description;
        this.weight = weight;
        this.attackPower = attackPower;
        this.dexterity = dexterity;
    }

    public void attack()
    {
        Debug.Log("Attacked");
    }

    public new string toString()
    {
        string output = "\n";
        output += this.itemName + ", ";
        output += this.description + ", ";
        output += this.weight + ", ";
        output += this.attackPower + ", ";
        output += this.dexterity + "\n";

        return itemName;
    }

}
