using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DB_ButtonRaycastScript : MonoBehaviour
{
    public Canvas mainCanvas; // Reference to the Canvas with DB_ButtonInstanceScript
    private DB_ButtonInstanceScript buttonInstanceScript;

    // Store references to the buttons so we can remove them later
    private GameObject actionOneButton;
    private GameObject actionTwoButton;
    private GameObject actionThreeButton;

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

            // Check if the ray hits a GameObject with the tag "RTSUnit"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("RTSUnit"))
            {
                // Call method to create buttons
                CreateRTSUnitActionButtons();
            }
            else
            {
                // If the raycast didn't hit an "RTSUnit", remove the buttons
                RemoveRTSUnitActionButtons();
            }
        }
    }

    private void CreateRTSUnitActionButtons()
    {
        // Define button positions (bottom right corner)
        Vector2 buttonPosition1 = new Vector2(350, -50);  // "Action One" button
        Vector2 buttonPosition2 = new Vector2(350, -120); // "Action Two" button
        Vector2 buttonPosition3 = new Vector2(350, -190); // "Action Three" button

        // Remove existing buttons to avoid duplicates
        RemoveRTSUnitActionButtons();

        // Create the buttons with appropriate text and actions, and store references
        actionOneButton = buttonInstanceScript.CreateButton("Action One", buttonPosition1, RTSUnitActionOne);
        actionTwoButton = buttonInstanceScript.CreateButton("Action Two", buttonPosition2, RTSUnitActionTwo);
        actionThreeButton = buttonInstanceScript.CreateButton("Action Three", buttonPosition3, RTSUnitActionThree);
    }

    private void RemoveRTSUnitActionButtons()
    {
        // Destroy each button if it exists
        if (actionOneButton != null)
        {
            Destroy(actionOneButton);
            actionOneButton = null;
        }

        if (actionTwoButton != null)
        {
            Destroy(actionTwoButton);
            actionTwoButton = null;
        }

        if (actionThreeButton != null)
        {
            Destroy(actionThreeButton);
            actionThreeButton = null;
        }
    }

    // Custom actions for each button
    private void RTSUnitActionOne()
    {
        Debug.Log("RTSUnit Action One triggered!");
    }

    private void RTSUnitActionTwo()
    {
        Debug.Log("RTSUnit Action Two triggered!");
    }

    private void RTSUnitActionThree()
    {
        Debug.Log("RTSUnit Action Three triggered!");
    }
}
