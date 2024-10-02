using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_gameManager : MonoBehaviour
{
    public Transform TextCloneUpdate;

    internal rs_TestInstanceScript GetText()
    {
        Transform myTextGO = Instantiate(TextCloneUpdate);
        return myTextGO.GetComponent<rs_TestInstanceScript>();
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
