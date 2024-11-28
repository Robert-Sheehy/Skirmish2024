using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RS_CharacterAbstract : MonoBehaviour, I_RSHealth
{
    int currentHealth = 100;
    private float playerSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    

    // Update is called once per frame
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
        transform.position -= playerSpeed * transform.right * Time.deltaTime;
    }
    private void moveRight()
    {
        transform.position += playerSpeed * transform.right * Time.deltaTime;
    }

    internal abstract bool shouldMoveForward();
    internal abstract bool shouldMoveBackwards();
    internal abstract bool shouldMoveLeft();
    internal abstract bool shouldMoveRight();
    internal abstract bool shouldAttack();

    public void takeDamage(int damage)
    {
        print("That Hurt");
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    
}
