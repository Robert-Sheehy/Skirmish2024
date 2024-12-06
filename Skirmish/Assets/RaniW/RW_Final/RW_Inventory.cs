using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Inventory 
{
    internal List<RW_Item> items;
    internal void Add(RW_Item item)
        { items.Add(item); }
    internal RW_Item Get(int i)
    {RW_Item item2 = items[i];
        items.RemoveAt(i);
        return item2;
    }

    internal void GetTotalWeight()
    {
        throw new NotImplementedException();
    }
}
