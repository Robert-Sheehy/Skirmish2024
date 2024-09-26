using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_TextDriver : MonoBehaviour
{
    public Transform theGnome;
    public Transform TextCloneTemplate;
    // Start is called before the first frame update
    void Start()
    {
        Transform myTextGO = Instantiate(TextCloneTemplate);
        CW_TextInstance myText = myTextGO.GetComponent<CW_TextInstance>();
        myText.Initialise("Hello");
        myText.SetText("Hello");

        myText.AttachTo(theGnome);
    }

    // Update is called once per frame
    void Update()
    {
        //positionOverParent();
        transform.LookAt(Camera.main.transform);
    }
}
