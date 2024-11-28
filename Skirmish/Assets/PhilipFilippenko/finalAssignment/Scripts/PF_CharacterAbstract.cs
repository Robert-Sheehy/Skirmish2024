using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class PF_CharacterAbstract : MonoBehaviour, IHealth
{

    float speed = 1f;
    float health = 100;

    void Start()
    {
             
    }

    void Update()
    {
        if (shouldMoveForward())
        {
            moveForward();
        }

        if (shouldMoveBackward())
        {
            moveBackward();
        }

        if (shouldMoveRight())
        {
            moveRight();
        }

        if (shouldMoveLeft())
        {
            moveLeft();
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
            IHealth enemy = collider.gameObject.GetComponent<IHealth>();
            if (enemy != null)
            {
                enemy.takeDamage(10);
            }
        }
    }

    internal abstract bool shouldAttack();

    private void moveLeft()
    {
        transform.Rotate(Vector3.up, -180 * Time.deltaTime);
    }

    internal abstract bool shouldMoveLeft();

    private void moveRight()
    {
        transform.Rotate(Vector3.up, 180 *  Time.deltaTime);
    }

    internal abstract bool shouldMoveRight();

    private void moveBackward()
    {
        transform.position -= transform.forward * Time.deltaTime;
    }

    internal abstract bool shouldMoveBackward();

    private void moveForward()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    internal abstract bool shouldMoveForward();

    public void takeDamage(int damage)
    {
        health -= damage;

        print(health);
        if (health < 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}
