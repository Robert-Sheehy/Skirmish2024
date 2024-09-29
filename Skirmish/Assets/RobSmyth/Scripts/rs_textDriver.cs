using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rs_textDriver : MonoBehaviour
{

    public Transform TextCloneTemplate;
    public Transform theGnome;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTextGO = Instantiate(TextCloneTemplate);
        rs_TestInstanceScript myText = myTextGO.GetComponent<rs_TestInstanceScript>();
        myText.initialize("Welcome");
        myText.SetText("Hello");
        myText.SetColor(Color.green);
        myText.SetPosition(new Vector2 (1 , 1));
        myText.AttachTo(theGnome);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
