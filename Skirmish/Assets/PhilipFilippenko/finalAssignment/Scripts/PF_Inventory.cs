using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_Inventory 
{
    List <PF_Item> inventoryList = new List<PF_Item>();

    public void addItem(PF_Item item)
    {
        inventoryList.Add (item);
    }

    public PF_Item getItem(int i)
    {
        if (i >= 0 && i < inventoryList.Count)
        {
            return inventoryList[i];
        }
        return null;
    }

    public void listItems()
    {

    }
}
