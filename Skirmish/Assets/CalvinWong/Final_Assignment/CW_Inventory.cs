using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CW_Inventory
{
    internal List<CW_Item> listOfInventory;
    
    internal void addItems(CW_Item item)
    {
        listOfInventory.Add(item);
    }

    internal void listAllItems()
    {
        foreach(CW_Item c in listOfInventory)
        {
            Debug.Log(c.name + c.description);
        }
    }

    internal float getTotalWeight()
    {
        float totalWeight = 0;
        foreach (CW_Item c in listOfInventory)
        {
            totalWeight += c.weight;
        }
        return totalWeight;
    }

    internal CW_Item getItems(int index)
    {
        CW_Item item = listOfInventory[index];
        listOfInventory.Remove(item);

        return item;

    }
}
