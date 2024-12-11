using UnityEngine;

public class PF_TestDriverClass : MonoBehaviour
{
    private PF_Inventory inventory;

    void Start()
    {
        inventory = new PF_Inventory();

        PF_Sword rapier = new PF_Sword("Beast Slayer Rapier",
                                       "Heavily bejeweled Rapier with images on animals on shaft",
                                       0.5f, 50f, 20f);
        PF_Sword claymore = new PF_Sword("Iron Claymore",
                                         "A heavy two-handed sword forged from iron.",
                                         3.0f, 70f, 10f);

        inventory.Add(rapier);
        inventory.Add(claymore);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.ListAllItems();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.GetTotalWeight();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            PF_Item nextItem = inventory.GetItem(0);
            if (nextItem != null)
            {
                Debug.Log($"You got {nextItem.Name} from inventory.");
                Debug.Log(nextItem.Description);

                if (nextItem is PF_Sword sword)
                {
                    sword.Attack();
                }
            }
        }
    }
}
