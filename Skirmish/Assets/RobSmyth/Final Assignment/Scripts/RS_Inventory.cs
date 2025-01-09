using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Inventory 
{
    internal List<RS_Item> items = new List<RS_Item>();

    internal void addItems(RS_Item item)
    {
        items.Add(item);
    }
    internal RS_Item getItems(int i)
    {
       
        RS_Item item = items[i];
        items.Remove(item);

        return item;

    }
    public RS_Item removeItem(int index)
    {
        RS_Item item = items[index];
        items.RemoveAt(index);
        return item;
    }

    internal void listAllItems()
    {
        foreach (RS_Item r in items)
        {
            {
                Debug.Log(r.itemName + r.itemDescription);
            }
        }
    }
    internal float getTotalItemWeights()
    {
        float totalWeight = 0;
        foreach (RS_Item r in items)
        {
            totalWeight += r.itemWeight;
        }
        return totalWeight;
    }
    
   
}
