using UnityEngine;

public class PF_Item
{
    internal string Name;
    internal string Description;
    internal float Weight;

    public PF_Item() { }

    public PF_Item(string name, string description, float weight)
    {
        Name = name;
        Description = description;
        Weight = weight;
    }
}
