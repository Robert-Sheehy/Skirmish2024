using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    enum ArcherState {Firing, Moving, Idle, Melee}
    ArcherState state = ArcherState.Idle;
    float speed = 3f;
    float turningSpeed = 45f;
    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (shouldMoveForward()) moveForward();
        //if (shouldTurnLeft()) turnLeft();
        //if (shouldTurnRight()) turnRight();

        switch(state)
        {
            case ArcherState.Firing:
                break;

            case ArcherState.Moving:


                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                transform.position += speed * transform.forward * Time.deltaTime;

                break;

            case ArcherState.Idle:
                break;

            case ArcherState.Melee:
                break;
        }

    }

    internal MoveTo(Vector3 targetLocation)
    {
        destination = targetLocation;
        state = ArcherState.Moving;
    }

    /*private void turnLeft()
    {
        transform.Rotate(new Vector3(0, 1, 0), turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void turnRight()
    {
        transform.Rotate(new Vector3(0,1,0), turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void moveForward()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    private bool shouldMoveForward()
    {
        //if (Input.GetKey(KeyCode.W)) return true;
        //else return false;

        return Input.GetKey(KeyCode.W);
    }*/

}
