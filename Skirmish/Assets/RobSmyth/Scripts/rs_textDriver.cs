using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rs_textDriver : MonoBehaviour
{

    public Transform TextCloneTemplate;
    public Transform theGnome;
    rs_gameManager theManager;


    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<rs_gameManager>();

        rs_TestInstanceScript myText = theManager.GetText();
        myText.initialize("Welcome");
        myText.SetText("Hello");
        myText.SetColor(Color.green);
        myText.SetPosition(new Vector2 (1 , 1));    
     // myText.AttachTo(theGnome);
        myText.StartFlash(1.0f);

        rs_TestInstanceScript myOtherText = theManager.GetText();
        myOtherText.initialize("Goodbye");
        myOtherText.SetColor(Color.red);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
