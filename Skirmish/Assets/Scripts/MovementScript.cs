using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right movement (Arrow keys or A/D)
        float moveVertical = Input.GetAxis("Vertical");     // Forward/Backward movement (Arrow keys or W/S)

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the capsule
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}