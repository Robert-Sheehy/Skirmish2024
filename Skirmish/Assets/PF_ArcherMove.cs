using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PF_ArcherMove : MonoBehaviour
{
    Animator animator;

    Vector3 destination;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    private bool hasArived = false;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        destination = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination);

        if (distance > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            
            Vector3 direction = (destination - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed  );
            }

            if (!isMoving)
            {
                Debug.Log("I am going to the destination!");
                isMoving = true;
                hasArived = false;

            }
        }

        else
        {
            if (!hasArived)
            {
                Debug.Log("I am here!");
                hasArived = true;
            }
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);
    }

    public void GoTo(Vector3 GotTodestination)
    {
        destination = new Vector3( GotTodestination.x, transform.position.y, GotTodestination.z);
        hasArived = false;
    }
}
