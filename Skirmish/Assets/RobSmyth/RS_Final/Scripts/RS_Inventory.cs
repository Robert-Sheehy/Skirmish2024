using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Inventory 
{
    internal List<RS_Item> listOfInventory;

    internal void addItems(RS_Item item)
    {
        listOfInventory.Add(item);
    }
    internal RS_Item getItems(int i)
    {
       
        RS_Item item = listOfInventory[i];
        listOfInventory.Remove(item);

        return item;

    }
    internal void listAllItems()
    {
        foreach (RS_Item r in listOfInventory)
        {
            {
                Debug.Log(r.itemName + r.itemDescription);
            }
        }
    }
    internal float getTotalItemWeights()
    {
        float totalWeight = 0;
        foreach (RS_Item r in listOfInventory)
        {
            totalWeight += r.itemWeight;
        }
        return totalWeight;
    }
    
   
}
