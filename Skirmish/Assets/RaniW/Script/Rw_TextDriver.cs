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
        RL_TestInstanceScript elfText = elftextGO.GetComponent<RL_TestInstanceScript>();
        elfText.initialize("Hello");
        elfText.SetText("Hello");
        elfText.SetColor(Color.red);
        elfText.SetPosition(new Vector2(1, 1));
        elfText.AttachTo(theGnome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
