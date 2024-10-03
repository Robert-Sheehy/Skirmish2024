using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_TextDriver : MonoBehaviour
{
    public Transform theGnome;
    public Transform TextCloneTemplate;
    RL_GameManagerScript theManager;
    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<RL_GameManagerScript>();

        RL_TestInstanceScript myText = theManager.GetText();
        myText.initialize("Hello");
        myText.SetText("Hello");
        myText.SetColor(Color.yellow);
        myText.SetPosition(new Vector2(1, 1));
        //myText.AttachTo(theGnome);
        myText.StartFlash(1.0f);

        RL_TestInstanceScript myOtherText = theManager.GetText();
        myOtherText.initialize("Goodbye");
        myOtherText.SetColor(Color.red);



    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
