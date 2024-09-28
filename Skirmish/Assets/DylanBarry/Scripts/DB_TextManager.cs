using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_TextManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform TextCloneTemplate;
    void Start()
    {
        Transform mytextGO = Instantiate(TextCloneTemplate);
        DB_TextInstanceScript myText = mytextGO.GetComponent<DB_TextInstanceScript>();
        myText.initialize("Hello");
        myText.SetText("Hello");
        mytextGO.transform.SetParent(transform);

        // myText.AttachTo();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
