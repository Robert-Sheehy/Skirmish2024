using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rw_TextDriver : MonoBehaviour
{
    public Transform theGnome;
    public Transform TestCloneTemplet;
    // Start is called before the first frame update
    void Start()
    {
        Transform elftextGO = Instantiate(TestCloneTemplet);
        RW_TextInstanceScript elfText = elftextGO.GetComponent<RW_TextInstanceScript>();
        elfText.initialize("Hello");
        elfText.SetText("Hello");

        elfText.AttachTo(theGnome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
