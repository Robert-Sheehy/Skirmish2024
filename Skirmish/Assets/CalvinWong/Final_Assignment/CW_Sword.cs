using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_Sword : CW_Item
{
    private float attackPower;
    private float dexterity;

    internal void swingSword()
    {
        Debug.Log("Swinging sword");
    }

    internal void block()
    {
        Debug.Log("Blocking with sword");
    }

    internal void swordAttributes(string name, string description, float weight, float attackPower, float dexterity)
    {
        name = "Ghost of Tsushima";
        description = "Forged by the vicious Sakai clan";
        weight = 5.0f;
        attackPower = 35f;
        dexterity = 23.5f;
    }
}
