using System;
using UnityEngine;

public class DB_CanvasButtonSpawner : MonoBehaviour
{
    private DB_ButtonInstanceScript buttonInstanceScript;

    void Start()
    {
        // Get the DB_ButtonInstanceScript component attached to the same GameObject
        buttonInstanceScript = GetComponent<DB_ButtonInstanceScript>();

        // Check if the component exists
        if (buttonInstanceScript == null)
        {
            Debug.LogError("DB_ButtonInstanceScript component not found on the GameObject.");
            return;
        }

        // Create a button with custom text, position, and an onClick action
        buttonInstanceScript.CreateButton(
            buttonText: "Click Me!",
            position: new Vector2(0, 100),
            onClickAction: OnButtonClick
        );
    }

    // Custom action to perform when the button is clicked
    private void OnButtonClick()
    {
        Debug.Log("Button was clicked!");
    }
}
