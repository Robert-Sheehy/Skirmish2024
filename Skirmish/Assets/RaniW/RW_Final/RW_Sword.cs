using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Sword : RW_Item
{
    private float attackValue;
    private float dexteritiyValue;

    public RW_Sword(string newItemName, string newItemDescription, float newItemWeight, float newItemAttackValue, float newItemDexterityValue)
    {
        name = newItemName;
        description = newItemDescription;
        weight = newItemWeight;
        attackValue = newItemAttackValue;
        dexteritiyValue = newItemDexterityValue;
    }

    internal void Attack()
    {
        Debug.Log("Am attacking you");
    }
}
