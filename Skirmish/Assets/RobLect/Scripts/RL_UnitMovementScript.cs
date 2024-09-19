using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_UnitMovementScript : MonoBehaviour
{
    float speed = 3f;
    float turningSpeed = 45f;
    // Start is called before the first frame update
    void Start()
    {
      transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMoveForward()) moveForward();
        if (shouldTurnLeft()) turnLeft();


      
    }

    private void turnLeft()
    {
        transform.Rotate(new Vector3(0, 1, 0), turningSpeed *Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void moveForward()
    {
        transform.position +=speed * transform.forward * Time.deltaTime;
    }

    private bool shouldMoveForward()
    {
        //if (Input.GetKey(KeyCode.W)) return true;
        //else return false;

        return Input.GetKey(KeyCode.W);
    }
}
