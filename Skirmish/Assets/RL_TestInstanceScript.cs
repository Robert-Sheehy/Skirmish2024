using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RL_TestInstanceScript : MonoBehaviour
{
    float timer = 0;
    bool isFlashing = false;
    float flashFrequency;
    TMPro.TextMeshPro m_TextMeshPro;
    private bool isOnObject;

    internal void AttachTo(Transform transformToAttachTo)
    {
        transform.SetParent( transformToAttachTo, false);
        m_TextMeshPro.alignment = TMPro.TextAlignmentOptions.Center;
        m_TextMeshPro.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        m_TextMeshPro.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        m_TextMeshPro.rectTransform.pivot = new Vector2(0.5f, 0);
        
        m_TextMeshPro.rectTransform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        m_TextMeshPro.fontSize = 18;
        isOnObject = true;
    }

    internal void initialize(string newText)
    {
        m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();

 
        m_TextMeshPro.text = newText;
    }

    internal void SetColor(Color newColour)
    {
        m_TextMeshPro.color = newColour;
    }

    internal void SetPosition(Vector2 vector2)
    {
     m_TextMeshPro.rectTransform.SetPositionAndRotation(vector2, Quaternion.identity);
    }

    internal void SetText(string newText)
    {
        m_TextMeshPro.text = newText;
    }

    internal void StartFlash(float frequencyOfFlash)
    {
        flashFrequency = frequencyOfFlash;
        m_TextMeshPro.alpha = 1.0f;
        timer = 0;
        isFlashing = true;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {   if (isFlashing)
        {
            timer += Time.deltaTime;


            m_TextMeshPro.alpha = Mathf.Pow(Mathf.Cos(timer * flashFrequency * Mathf.PI),2) ;

        }

       if (isOnObject)
        transform.LookAt(2* transform.position- Camera.main.transform.position);
    }
}
