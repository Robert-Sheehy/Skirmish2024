using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_TestInstanceScript : MonoBehaviour
{
    TMPro.TextMeshPro m_TextMeshPro;

    internal void AttachTo(Transform transformToAttachTo)
    {
       transform.parent = transformToAttachTo;
    }

    internal void initialize(string newText)
    {
        m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();
        m_TextMeshPro.text = newText;
    }

    internal void SetColor(Color newColour)
    {
        throw new NotImplementedException();
    }

    internal void SetPosition(Vector2 vector2)
    {
        throw new NotImplementedException();
    }

    internal void SetText(string newText)
    {
        m_TextMeshPro.text = newText;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.LookAt(Camera.main.transform.position);
    }
}
