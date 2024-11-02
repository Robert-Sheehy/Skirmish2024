using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TigerRaycastScript : MonoBehaviour
{
    public Canvas mainCanvas; // Reference to the Canvas with DB_ButtonInstanceScript
    private DB_ButtonInstanceScript buttonInstanceScript;

    // Store references to the buttons so we can remove them later
    private GameObject biteButton;
    private GameObject roarButton;
    private GameObject retreatButton;

    private void Start()
    {
        // Get the DB_ButtonInstanceScript component from the canvas
        buttonInstanceScript = mainCanvas.GetComponent<DB_ButtonInstanceScript>();

        // Check if the component exists
        if (buttonInstanceScript == null)
        {
            Debug.LogError("DB_ButtonInstanceScript component not found on the Canvas.");
            return;
        }
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is over a UI element; if so, don't proceed with raycast
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // Create a ray from the main camera to where the mouse clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a GameObject with the tag "Tiger"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Tiger"))
            {
                // Call method to create buttons
                CreateTigerActionButtons();
            }
            else
            {
                // If the raycast didn't hit a "Tiger", remove the buttons
                RemoveTigerActionButtons();
            }
        }
    }

    private void CreateTigerActionButtons()
    {
        // Define button positions (bottom right corner)
        Vector2 buttonPosition1 = new Vector2(350, -50);  // "Bite" button
        Vector2 buttonPosition2 = new Vector2(350, -120); // "Roar" button
        Vector2 buttonPosition3 = new Vector2(350, -190); // "Retreat" button

        // Remove existing buttons to avoid duplicates
        RemoveTigerActionButtons();

        // Create the buttons with appropriate text and actions, and store references
        biteButton = buttonInstanceScript.CreateButton("Bite", buttonPosition1, BiteAction);
        roarButton = buttonInstanceScript.CreateButton("Roar", buttonPosition2, RoarAction);
        retreatButton = buttonInstanceScript.CreateButton("Retreat", buttonPosition3, RetreatAction);
    }

    private void RemoveTigerActionButtons()
    {
        // Destroy each button if it exists
        if (biteButton != null)
        {
            Destroy(biteButton);
            biteButton = null;
        }

        if (roarButton != null)
        {
            Destroy(roarButton);
            roarButton = null;
        }

        if (retreatButton != null)
        {
            Destroy(retreatButton);
            retreatButton = null;
        }
    }

    // Custom actions for each button
    private void BiteAction()
    {
        Debug.Log("Tiger Bite action triggered!");
    }

    private void RoarAction()
    {
        Debug.Log("Tiger Roar action triggered!");
    }

    private void RetreatAction()
    {
        Debug.Log("Tiger Retreat action triggered!");
    }
}
