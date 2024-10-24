using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RL_UnitMovementScript : MonoBehaviour
{   enum ArcherState { Firing, Moving, Idle, Melee }
    ArcherState state = ArcherState.Idle;
    float speed = 3f;
    float turningSpeed = 45f;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
   switch(state)
        {
            case ArcherState.Firing:
                break;

            case ArcherState.Moving:

                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                transform.position += speed *transform.forward* Time.deltaTime;



                break;

            case ArcherState.Idle:


                break;
            case ArcherState.Melee:

                break;

        }


      
    }

    internal void MoveTo(Vector3 targetLocation)
    {
        destination = targetLocation;
        state = ArcherState.Moving;

    }


}
