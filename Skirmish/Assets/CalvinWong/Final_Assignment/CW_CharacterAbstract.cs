using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CW_CharacterAbstract : MonoBehaviour, I_CWHealth
{
    float turningSpeed = 50f;
    float movementSpeed = 10f;
    float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    internal void Update()
    {
        if (shouldMoveForward())
        {
            moveForward();
        }
        if (shouldMoveBakcWard())
        {
            moveBackward();
        }
        if (shouldTurnLeft())
        {
            turnLeft();
        }
        if (shouldTurnRight())
        {
            turnRight();
        }
        if (shouldAttack()) 
        {
            attack();
        }

    }

    private void attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 3, 1.5f);
        foreach (Collider collider in colliders) 
        {
            I_CWHealth enemy = collider.gameObject.GetComponent<I_CWHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }
        }
    }

    private void moveForward()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
    private void moveBackward()
    {
        transform.position -= transform.forward * movementSpeed * Time.deltaTime;
    }
    private void turnLeft()
    {
        transform.Rotate(new Vector3(0,1,0), -turningSpeed * Time.deltaTime);
    }
    private void turnRight()
    {
        transform.Rotate(new Vector3(0,1,0), turningSpeed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        print("Ouch!");
        health -= damage;

        if(health < 0)
        {
            Destroy(gameObject);
        }
    }

    internal abstract bool shouldTurnRight();

    internal abstract bool shouldTurnLeft();

    internal abstract bool shouldMoveBakcWard();

    internal abstract bool shouldMoveForward();

    internal abstract bool shouldAttack();

}
