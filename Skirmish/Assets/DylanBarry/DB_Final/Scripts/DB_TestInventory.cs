using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEditor.Progress;
using UnityEngine.SocialPlatforms.Impl;

public class DB_TestInventory : MonoBehaviour
{

    DB_Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new DB_Inventory();
        // name, desc, weight, attack, dexterity

        DB_Helmet raiderHelm = new DB_Helmet("Raider Helm", "A viking helmet with two horns", 3.3f);

        DB_Helmet crown = new DB_Helmet("Kings Crown", "A majestic crown adorned with gems", 2.1f);

        DB_Sword rapier = new DB_Sword("Beast Slayer Rapier", "Heavily bejeweled Rapier with images on animals on shaft",
                    0.5f, 50f, 20f);

        inventory.addItem(rapier);
        inventory.addItem(crown);
        inventory.addItem(raiderHelm);


      

        // Update is called once per frame
        void Update()
        {

            //display using key presses
            if (Input.GetKeyDown(KeyCode.I))
                inventory.listAllItems();

            if (Input.GetKeyDown(KeyCode.W))
                inventory.getTotalWeight();


            if (Input.GetKeyDown(KeyCode.U))
            {
                DB_Item nextItem = inventory.getItem(0);
                print("You got " + nextItem.getName() + " from inventory");
                print(nextItem.getDescription());
                //          if (nextItem.GetType == DB_Sword)
                //           (nextItem as DB_Sword).attack();

            }
        }
    }
}
