using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CW_TestInventory : MonoBehaviour
{
    CW_Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new CW_Inventory();
        CW_Sword katana = new CW_Sword();
        CW_Helm vikingHelmet = new CW_Helm();
        CW_Banana banana = new CW_Banana();

        inventory.addItems(katana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U)) 
        {
            //inventory.ListAllItems();
        }
        if (Input.GetKey(KeyCode.I))
        {
            //inventory.getTotalWeight();
        }
        if(Input.GetKey(KeyCode.W)) 
        {

            print("you got <name> from inventory");
            print("<Description>");
            
        }

    }
}
