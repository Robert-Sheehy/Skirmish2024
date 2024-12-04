using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_TestInventory : MonoBehaviour
{
    PF_Inventory inventory;

    void Start()
    {
        inventory = new PF_Inventory();
        PF_Sword rapier = new PF_Sword("Divine Rapier", "Does damage", 0.5f, 50, 20);
        //Add more items

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.listItems();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PF_Item nextItem = inventory.getItem(0);
            Debug.Log("You got" +  nextItem + "from inventory");

            if (nextItem is PF_Sword)
                {
                    (nextItem as PF_Sword).equipSword();
                }
        }
    }
}
