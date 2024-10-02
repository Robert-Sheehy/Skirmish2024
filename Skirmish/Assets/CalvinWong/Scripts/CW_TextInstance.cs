using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CW_TextInstance : MonoBehaviour
{

    TMPro.TextMeshPro m_TextMeshPro;
    float timer = 0;
    bool isFlashing = false;

    internal void AttachTo(Transform transformToAttachTo)
    {

        m_TextMeshPro.alignment = TMPro.TextAlignmentOptions.Center;
        //m_TextMeshPro.pivot = (0.5,0);

        //m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();
        //m_TextMeshPro.rectTransform.anchoredPosition = Vector3.zero;
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

        if (isFlashing)
        {
            timer += Time.deltaTime;

            m_TextMeshPro.alpha = Mathf.Pow(Mathf.Cos(timer * Mathf.PI),2);
        }

        transform.LookAt(-Camera.main.transform.position);
    }

    internal void SetColor(Color green)
    {
        throw new NotImplementedException();
    }

    internal void SetPosition(Vector2 vector2)
    {
        throw new NotImplementedException();
    }

    internal void StartFlash(float frequencyOfFlash)
    {
        m_TextMeshPro.alpha = 1.0f;
        timer = 0;
        isFlashing = true;
    }

    internal static CW_TextInstance GetText()
    {
        throw new NotImplementedException();
    }
}
