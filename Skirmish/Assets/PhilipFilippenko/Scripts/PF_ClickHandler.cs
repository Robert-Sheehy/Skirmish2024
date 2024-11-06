using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public PF_ArcherMove archerMove;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Enemy"))
                {
                    archerMove.GoToEnemy(clickedObject.transform);
                }
                else
                {
                    archerMove.GoTo(hit.point);
                }
            }
        }
    }
}
