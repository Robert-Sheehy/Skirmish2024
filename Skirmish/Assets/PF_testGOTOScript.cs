using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_testGOTOScript : MonoBehaviour
{
    PF_ArcherMove theArcher;

    void Start()
    {
       theArcher = FindObjectOfType<PF_ArcherMove>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theArcher.GoTo(new Vector3(0, 0, 0));
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                theArcher.GoTo(hit.point);
            }
        }
    }
}
