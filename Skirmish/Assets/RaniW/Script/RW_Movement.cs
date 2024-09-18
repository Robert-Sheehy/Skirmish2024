using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_Movement : MonoBehaviour
{
    private float rotSpeed = 360;
    private float currentSpeed = 13;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1, 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 2, 3) * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
            ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
            
        }

        
    }
}
