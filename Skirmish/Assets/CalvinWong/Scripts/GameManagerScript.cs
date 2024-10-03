using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static Transform TextCloneTemplate;

    internal static CW_TextInstance GetText()
    {
        Transform myTextGO = Instantiate(TextCloneTemplate);
        return myTextGO.GetComponent<CW_TextInstance>();
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
