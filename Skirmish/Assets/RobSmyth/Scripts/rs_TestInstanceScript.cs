using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_TestInstanceScript : MonoBehaviour
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
        positionOverParent();
        transform.LookAt(Camera.main.transform.position);
    }

    private void positionOverParent()
    {
        throw new NotImplementedException();
    }

    internal void SetColor(Color black)
    {
        throw new NotImplementedException();
    }

    internal void SetPosition(Vector2 vector2)
    {
        throw new NotImplementedException();
    }
}
