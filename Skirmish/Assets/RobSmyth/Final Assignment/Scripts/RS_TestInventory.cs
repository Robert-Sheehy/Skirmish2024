using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_TestInventory : MonoBehaviour
{
    RS_Inventory inventory;
     void Start()
    {
        inventory = new RS_Inventory();
        RS_Dagger Poison_Dagger = new RS_Dagger("Poison Hell", "Wooden handled dagger with dark obsidian blade, aligned with a purple glow at the tip", 0.5f, 45f, 60f);
        RS_BackPack Large_Brown_Bag = new RS_BackPack("PigSkin Backpack", "Dark brown bag with 2 leather straps for wearing on your back", 0.9f, 25, 5);
        RS_Helmet Scarab_Headgear = new RS_Helmet("Gregorian Iron Helmet", "Silver in colour, almost Roman looking with gaps in the face plate for seeing through", 20f, 100, 100);

        inventory.addItems(Poison_Dagger);
        inventory.addItems(Large_Brown_Bag);
        inventory.addItems(Scarab_Headgear);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventory.listAllItems();
        }

        if (Input.GetKey(KeyCode.W))
        {
            inventory.getTotalItemWeights();
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            RS_Item nextItem = inventory.getItems(0);
            print("You got" +nextItem.itemName + " from your inventory!");
            print(nextItem.itemDescription);


            if(nextItem is RS_Dagger)
                (nextItem as RS_Dagger).attack();
            if(nextItem is RS_BackPack)
                (nextItem as RS_BackPack).wearBackPack();
            if (nextItem is RS_Helmet)
                (nextItem as RS_Helmet).wearHelmet();

        }
    }
}
