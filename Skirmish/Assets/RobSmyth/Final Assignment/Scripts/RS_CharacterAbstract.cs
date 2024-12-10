using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RS_CharacterAbstract : MonoBehaviour, I_RSHealth
{
    int currentHealth = 100;
    private float playerSpeed = 10;

    void Start()
    {
        
        
    }

    internal void Update()
    {
        if (shouldMoveForward())
            moveForward();
        if (shouldMoveBackwards())
            moveBackwards();
        if (shouldMoveLeft())
            moveLeft();
        if (shouldMoveRight())
            moveRight();
        if (shouldAttack())
            attack();
    }

    private void attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 3, 1.50f);
        foreach (Collider collider in colliders)
        {
            I_RSHealth enemy = collider.gameObject.GetComponent<I_RSHealth>();
            if (enemy != null)
                enemy.takeDamage(20);
        }
    }
    

    private void moveForward()
    {
        transform.position += playerSpeed * transform.forward * Time.deltaTime;
    }
    private void moveBackwards()
    {
        transform.position -= playerSpeed * transform.forward * Time.deltaTime;
    }
    private void moveLeft()
    {
        transform.Rotate(new Vector3(0, 1, 0), - playerSpeed * Time.deltaTime);
    }
    private void moveRight()
    {
        transform.Rotate(new Vector3(0, 1, 0), playerSpeed * Time.deltaTime);
    }
    

    internal abstract bool shouldMoveForward();
    internal abstract bool shouldMoveBackwards();
    internal abstract bool shouldMoveLeft();
    internal abstract bool shouldMoveRight();
    internal abstract bool shouldAttack();

    public void takeDamage(int damage)
    {
        print("Ouch! That Hurt");
        if (currentHealth <= 0)
            print("You beat the Scarab lord this time!");
            Destroy(gameObject);
    }

    
}
