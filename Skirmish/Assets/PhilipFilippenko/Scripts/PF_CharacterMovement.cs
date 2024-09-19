using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_CharacterMovement : MonoBehaviour
{
    float speed = 3.0f; // Speed of the character movement
    float turnSpeed = 50.0f; // Speed of the character turning

    void Update()
    {
        // Move forward if the W key is pressed
        if (shouldMoveForward())
        {
            MoveForward();
        }

        // Move backward if the S key is pressed
        if (shouldMoveBackwards())
        {
            MoveBackwards();
        }

        // Turn left if the A key is pressed
        if (shouldTurnLeft())
        {
            TurnLeft();
        }

        // Turn right if the D key is pressed
        if (shouldTurnRight())
        {
            TurnRight();
        }
    }

    private bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    private bool shouldMoveBackwards()
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void MoveForward()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    private void MoveBackwards()
    {
        transform.position += speed * -transform.forward * Time.deltaTime;
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
