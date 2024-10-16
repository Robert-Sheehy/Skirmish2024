using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_moveCamera : MonoBehaviour
{
    float speed = 30f;
    float turningSpeed = 75f;
    void Start()
    {
        transform.position = new Vector3(1, 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMoveIn()) moveIn();
        if (shouldMoveOut()) moveOut();
        if (shouldTurnLeft()) turnLeft();
        if (shouldTurnRight()) turnRight();
        if (shouldMoveForward()) moveForward();
        if (shouldMoveBack()) moveBack();


    }

    private void turnLeft()
    {
        transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * turningSpeed;
    }

    private void turnRight()
    {
        transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * turningSpeed;
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    private void moveIn()
    {
        //transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * turningSpeed;
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    private void moveOut()
    {
        //transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * turningSpeed;
        transform.position -= speed * transform.forward * Time.deltaTime;
    }

    private bool shouldMoveIn()
    {

        return Input.GetKey(KeyCode.Delete);
    }

    private bool shouldMoveOut()
    {

        return Input.GetKey(KeyCode.Insert);
    }
    private void moveForward()
    {
        transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * turningSpeed;

    }

    private void moveBack()
    {
        transform.position += transform.TransformDirection(Vector3.down) * Time.deltaTime * turningSpeed;
        
    }

    private bool shouldMoveForward()
    {

        return Input.GetKey(KeyCode.UpArrow);
    }

    private bool shouldMoveBack()
    {

        return Input.GetKey(KeyCode.DownArrow);
    }
}
