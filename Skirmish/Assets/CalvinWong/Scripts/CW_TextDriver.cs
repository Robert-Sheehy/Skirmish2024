using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CW_TextDriver : MonoBehaviour
{
    public Transform theGnome;
    public Transform TextCloneTemplate;
    CW_TextInstance theManager;
    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<CW_TextInstance>();

        CW_TextInstance myText = CW_TextInstance.GetText();
        myText.Initialise("Hello");
        myText.SetText("Hello");
        myText.SetColor(Color.green);
        myText.SetPosition(new Vector2 (2,1));
        myText.AttachTo(theGnome);
        myText.StartFlash(4.0f);

        CW_TextInstance myOtherText = CW_TextInstance.GetText();
        myOtherText.Initialise("Goodbye!");
        //myOtherText.SetText("Goodbye!");
        myOtherText.SetColor(Color.red);
        myOtherText.SetPosition (new Vector2 (2,1));
    }

    // Update is called once per frame
    void Update()
    {
        //positionOverParent();
        transform.LookAt(Camera.main.transform);
    }
}
