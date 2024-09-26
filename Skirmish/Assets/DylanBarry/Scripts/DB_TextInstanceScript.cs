using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DB_TextInstanceScript : MonoBehaviour
{
    TextMeshPro textMesh;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
