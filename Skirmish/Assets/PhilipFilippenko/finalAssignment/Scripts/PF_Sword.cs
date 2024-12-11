using UnityEngine;

public class PF_Sword : PF_Item
{
    public float AttackPower;
    public float Dexterity;

    public PF_Sword(string name, string description, float weight, float attackPower, float dexterity)
        : base(name, description, weight)
    {
        AttackPower = attackPower;
        Dexterity = dexterity;
    }

    public void Attack()
    {
        Debug.Log("You swing your sword!");
    }

    internal void EquipSword()
    {
        Debug.Log("Equipping sword...");
    }
}
