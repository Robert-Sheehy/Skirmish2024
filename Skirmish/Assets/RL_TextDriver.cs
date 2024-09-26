using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_TextDriver : MonoBehaviour
{
    public Transform theGnome;
    public Transform TextCloneTemplate;
    // Start is called before the first frame update
    void Start()
    {
        Transform mytextGO = Instantiate(TextCloneTemplate);
        RL_TestInstanceScript myText = mytextGO.GetComponent<RL_TestInstanceScript>();
        myText.initialize("Hello");
        myText.SetText("Hello");
        myText.SetColor(Color.blue);
        myText.SetPosition(new Vector2(1, 1));
        myText.AttachTo(theGnome);
    
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
