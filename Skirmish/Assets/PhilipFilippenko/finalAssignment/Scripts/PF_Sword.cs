using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_Sword : PF_Item
{
    float damage;
    float dexterity;

    public PF_Sword(string newName, string newDescription, float newWeight, float newDamage, float newDexterity)
    {
        name = newName;
        description = newDescription;
        weight = newWeight;
        damage = newDamage;
        dexterity = newDexterity;
    }

    internal void equipSword()
    {
        Debug.Log("Equiping sword...");
    }
}
