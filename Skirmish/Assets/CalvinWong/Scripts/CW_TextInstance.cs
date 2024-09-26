using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_TextInstance : MonoBehaviour
{

    TMPro.TextMeshPro m_TextMeshPro;

    internal void AttachTo(Transform transformToAttachTo)
    {
        transform.parent = transformToAttachTo;
    }

    internal void Initialise(string newText)
    {
        m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();
        m_TextMeshPro.text = newText;
    }

    internal void SetText(string newText)
    {
        m_TextMeshPro.text = newText;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
