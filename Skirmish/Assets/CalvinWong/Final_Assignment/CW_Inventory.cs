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

    internal void getItems(int i)
    {
        listOfInventory[i] = null;
        CW_Item item = listOfInventory[i];
        if (item != null)
        {
            listOfInventory[i] = item;
        }

    }
}
