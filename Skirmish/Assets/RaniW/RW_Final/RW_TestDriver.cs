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
        RW_Sword rapier = new RW_Sword("Beast Slayer Rapier", "Heavily bejeweled Rapier with images on animals on shaft",
                        0.5f, 50f, 20f);
        //etc...
        items.Add(rapier);

       // etc..
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) RW_Item.ListAllItems();

        if (Input.GetKeyDown(KeyCode.W)) items.GetTotalWeight();

        if (Input.GetKeyDown(KeyCode.U))
        {
            /*Item nextItem = items.Get(0);
            print("You got <name>  from inventory");
            print(Description);
            if (nextItem == RW_Sword) 
                (nextItem as RW_Sword).attack();*/
        }
    }
}
