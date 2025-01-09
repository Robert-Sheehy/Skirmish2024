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
        PF_Banana banana = new PF_Banana { Name = "Banana", Description = "A tasty banana", Weight = 0.2f };
        PF_Helmet helmet = new PF_Helmet { Name = "Iron Helmet", Description = "A sturdy iron helmet", Weight = 3.5f };

        inventory.Add(rapier);
        inventory.Add(banana);
        inventory.Add(helmet);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.ListAllItems();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PF_Item nextItem = inventory.GetItem(0);
            if (nextItem != null)
            {
                Debug.Log($"You got {nextItem.Name} from inventory.");
                if (nextItem is PF_Sword sword)
                {
                    sword.EquipSword();
                }
                else if (nextItem is PF_Banana banana)
                {
                    banana.consumeBanana();
                }
                else if (nextItem is PF_Helmet helmet)
                {
                    helmet.equipHelmet();
                }
            }
        }
    }
}
