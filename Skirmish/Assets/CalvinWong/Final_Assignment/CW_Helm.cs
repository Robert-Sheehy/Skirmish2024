using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_Helm : CW_Item
{
    internal void wearHelm()
    {
        Debug.Log("Wearing Helm");
    }

    internal void helmAttributes(string name, string description, float weight, float armorHealth) 
    {
        name = "Viking Helmet";
        description = "Forged and worn by the Vikings who show no mmercy towards their enemys in combat";
        weight = 12.5f;
        armorHealth = 20f;
    }
}
