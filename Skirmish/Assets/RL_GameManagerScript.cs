using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   class RL_GameManagerScript : MonoBehaviour
{
    public  Transform TextCloneTemplate;

    internal  RL_TestInstanceScript GetText()
    {
        Transform myTextGO = Instantiate(TextCloneTemplate);
        return myTextGO.GetComponent<RL_TestInstanceScript>();
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
