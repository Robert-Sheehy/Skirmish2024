using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DB_CharacterAbstract : MonoBehaviour
{

    public int health;
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    // Start is called before the first frame update
    public void Start()
    {
       
    }

    // Update is called once per frame
    public void Update()
    {
        if(shouldMoveForward())
            moveForward();

        if (shouldMoveBack())
            moveBack();

        if (shouldMoveRight())
            moveRight();

        if (shouldMoveLeft())
            moveLeft();


        if (shouldTurnLeft())
            turnLeft();

        if (shouldTurnRight())
            turnRight();

        if (shouldAttack())
            attack();
    }

    private void attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 3, 1.5f);
        foreach(Collider collider in colliders)
        {
            I_DBHealth enemy = collider.gameObject.GetComponent<I_DBHealth>();
            if (enemy != null)
                enemy.takeDamage(10);
            print("Attacked an object!");
        }

    }

    internal abstract bool shouldAttack();

    private void turnRight()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
    }

    internal abstract bool shouldTurnRight();

    private void turnLeft()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    internal abstract bool shouldTurnLeft();

    private void moveLeft()
    {
        transform.position -= transform.right * Time.deltaTime * moveSpeed;
    }

    internal abstract bool shouldMoveLeft();

    private void moveRight()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }

    internal abstract bool shouldMoveRight();

    private void moveBack()
    {
        transform.position -= transform.forward * Time.deltaTime * moveSpeed;
    }

    internal abstract bool shouldMoveBack();

    private void moveForward()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    internal abstract bool shouldMoveForward();

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
