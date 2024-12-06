using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CW_TestInventory : MonoBehaviour
{
    CW_Inventory item;
    // Start is called before the first frame update
    void Start()
    {
        item = new CW_Inventory();
        CW_Sword katana = new CW_Sword();
        CW_Helm vikingHelmet = new CW_Helm();
        CW_Banana banana = new CW_Banana();

        item.addItems(katana);
        item.addItems(vikingHelmet);
        item.addItems(banana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U)) 
        {
            item.listAllItems();
        }
        if (Input.GetKey(KeyCode.I))
        {
            item.getTotalWeight();
        }
        if(Input.GetKey(KeyCode.W)) 
        {
            CW_Item nextItem = item.getItems(0);
            print("you got " + nextItem.name +" from inventory");

            print(nextItem.description);

            if (nextItem is CW_Sword)
            {
                (nextItem as CW_Sword).swingSword();
                (nextItem as CW_Sword).block();
            }

        }

        if(Input.GetKey(KeyCode.Q))
        {
            CW_Item nextItem1 = item.getItems(1);
            print("You got " + nextItem1.name + " from inventory");
            print(nextItem1.description);

            if (nextItem1 is CW_Helm)
            {
                (nextItem1 as CW_Helm).wearHelm();
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            CW_Item nextItem2 = item.getItems(2);
            print("You got " + nextItem2.name + " from inventory");
            print(nextItem2.description);

            if (nextItem2 is CW_Banana)
            {
                (nextItem2 as CW_Banana).eatBanana();
            }
        }

    }
}
