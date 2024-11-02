using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DB_ButtonInstanceScript : MonoBehaviour
{
    public GameObject buttonPrefab; // Reference to the button prefab
    public Canvas mainCanvas;       // Reference to the main canvas for the UI
    private RectTransform canvasRectTransform;

    private void Start()
    {
        if (mainCanvas == null)
        {
            Debug.LogError("Main Canvas is not assigned.");
            return;
        }

        canvasRectTransform = mainCanvas.GetComponent<RectTransform>();
    }

    // Method to create a button with custom text and an action
    public GameObject CreateButton(string buttonText, Vector2 position, Action onClickAction)
    {
        // Instantiate the button prefab as a UI element under the main canvas
        GameObject newButton = Instantiate(buttonPrefab, mainCanvas.transform);

        // Set position of the button relative to the canvas
        RectTransform buttonRectTransform = newButton.GetComponent<RectTransform>();
        buttonRectTransform.anchoredPosition = position;

        // Set the button's text
        TMP_Text buttonTextComponent = newButton.GetComponentInChildren<TMP_Text>();
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = buttonText;
        }

        // Add an onClick listener that calls the custom action when clicked
        Button buttonComponent = newButton.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(() => onClickAction());
        }

        return newButton; // Return the instantiated button GameObject
    }

}