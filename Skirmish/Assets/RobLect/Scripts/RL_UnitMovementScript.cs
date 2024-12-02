using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RL_UnitMovementScript : MonoBehaviour,IDamagable
{   internal enum UnitState { Firing, Moving, Idle, Melee }
    internal UnitState state = UnitState.Idle;
    internal float speed = 3f;
    internal float turningSpeed = 45f;
    internal Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    internal void Update()
    {
   switch(state)
        {
            case UnitState.Firing:
                break;

            case UnitState.Moving:

                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                transform.position += speed *transform.forward* Time.deltaTime;



                break;

            case UnitState.Idle:


                break;
            case UnitState.Melee:

                break;

        }


      
    }

    internal void MoveTo(Vector3 targetLocation)
    {
        destination = targetLocation;
        state = UnitState.Moving;

    }

    public void takeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
