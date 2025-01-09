using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEditor.Progress;



public class RW_TestDriver : MonoBehaviour
{
    RW_Inventory items;
    // Start is called before the first frame update
    void Start()
    {
        RW_Inventory items = new RW_Inventory();
        RW_Sword rapier = new RW_Sword("Beast Slayer Rapier", "Heavily bejeweled Rapier with images of animals on shaft",
                        0.5f, 50f, 20f);
        
        items.Add(rapier);


        RW_Sheild sheild = new RW_Sheild("Shelter Sheild", "Heavily bejeweled Sheild with images of animals on sheild",
                        0.5f, 50f, 20f);
        
        items.Add(sheild);

        RW_Helment helment = new RW_Helment("Skull Helment", "Heavily bejeweled Helment with red feathers at the top",
                        0.5f, 50f, 20f);
        
        items.Add(helment);

        RW_Banana banana = new RW_Banana("Funny Banana", "Shiny banana that moves like a boomarang",
                        0.5f, 50f, 20f);

        items.Add(banana);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) RW_Item.ListAllItems();

        if (Input.GetKeyDown(KeyCode.W)) items.GetTotalWeight();

        if (Input.GetKeyDown(KeyCode.U))
        {
            RW_Item nextItem = items.Get(0);
            

            print("You got" + nextItem.name + " from inventory");
            print(nextItem.description);

            if (nextItem is RW_Sword)
              
            (nextItem as RW_Sword).Attack();

            if (nextItem is RW_Sheild)

            (nextItem as RW_Sheild).Block();

            if (nextItem is RW_Helment)

            (nextItem as RW_Helment).Protect();

            if (nextItem is RW_Banana)

            (nextItem as RW_Banana).Freeze();

        }
    }
}
