using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class CW_Banana : CW_Item
{
    internal void eatBanana()
    {
        Debug.Log("Eating Banana");
    }

    internal void BananaAttributes(string name, string description, float weight, float healingValue)
    {
        name = "Tropical Banana";
        description = "Its ripeness flourishes your mouth with rich flavours, you can't stop eating it.";
        weight = 2.5f;
        healingValue = 5f;
    }
}
