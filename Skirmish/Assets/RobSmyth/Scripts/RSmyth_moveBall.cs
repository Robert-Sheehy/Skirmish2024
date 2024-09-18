using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSmyth_moveBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1, 2, 1);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 2, -3) * Time.deltaTime; 
    }
}
