//Camera Movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
        moveBackward();
        moveLeft();
        moveRight();
        moveUp();
        moveDown();
    }

    void moveLeft()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }
    void moveRight()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }
    void moveForward()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
    }
    void moveBackward()
    {
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
    }

    void moveUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
        }
    }
    void moveDown()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.TransformDirection(Vector3.down) * Time.deltaTime * movementSpeed;
        }
    }
}