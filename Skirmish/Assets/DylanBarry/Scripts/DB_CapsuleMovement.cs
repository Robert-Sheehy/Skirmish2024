using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_CapsuleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    float turningSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right movement (Arrow keys or A/D)
        float moveVertical = Input.GetAxis("Vertical");     // Forward/Backward movement (Arrow keys or W/S)

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the capsule
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        if (shouldTurnLeft()) turnLeft();
        if (shouldTurnRight()) turnRight();
    }

    private void turnLeft()
    {
        transform.Rotate(new Vector3(0, 1, 0), turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.Q);
    }

    private void turnRight()
    {
        transform.Rotate(new Vector3(0, -1, 0), turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.E);
    }
}
