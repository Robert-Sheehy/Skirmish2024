using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DB_Inventory
{
    private List<DB_Item> items = new List<DB_Item>();

    public void addItem(DB_Item item)
    {
        items.Add(item);
    }

    public DB_Item removeItem(int index)
    {
        DB_Item item = items[index];
        items.RemoveAt(index);
        return item;
    }

    public DB_Item getItem(int index)
    {
        return items[index];
    }

    public void listAllItems()
    {
        string output = "";
        foreach (DB_Item item in items)
        {
            output += item.toString();
        }
        Debug.Log(output);
    }

    public float getTotalWeight()
    {
        return 0.0f;
    }

    public DB_Inventory(List<DB_Item> items)
    {
        this.items = items;
    }

    public DB_Inventory()
    {

    }
}
