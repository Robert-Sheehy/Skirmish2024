using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DB_TextInstanceScript : MonoBehaviour
{
    TextMeshPro textMesh;
    public float fadeDuration = 5f; // Time for the text to fade

    private Color originalColor;

    internal void AttachTo(Transform transformToAttachTo)
    {
        transform.parent = transformToAttachTo;
    }

    internal void initialize(string newText)
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        textMesh.text = newText;
    }

    internal void SetText(string newText)
    {
        textMesh.text = newText;

    }

    void StartFadeOut()
    {
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, alphaValue);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Store the original color of the text
        originalColor = textMesh.color;
        // Start the fade out after 5 seconds
        Invoke("StartFadeOut", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Change the color of the text to green
            textMesh.color = Color.green;
        }
    }

}
