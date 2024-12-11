using System.Collections.Generic;
using UnityEngine;

public class PF_Inventory
{
    private List<PF_Item> items = new List<PF_Item>();

    public void Add(PF_Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"{newItem.Name} added to inventory.");
    }

    public PF_Item GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        Debug.LogWarning("Invalid index!");
        return null;
    }

    public void ListAllItems()
    {
        Debug.Log("Inventory contains:");
        foreach (var item in items)
        {
            Debug.Log($"- {item.Name}: {item.Description} (Weight: {item.Weight})");
        }
    }

    public float GetTotalWeight()
    {
        float totalWeight = 0f;
        foreach (var item in items)
        {
            totalWeight += item.Weight;
        }
        Debug.Log($"Total weight: {totalWeight}");
        return totalWeight;
    }
}
