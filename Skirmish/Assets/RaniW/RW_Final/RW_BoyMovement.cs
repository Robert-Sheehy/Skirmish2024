using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RW_BoyMovement : MonoBehaviour, i_RW_Health
{
    float speed = 3f;
    float turningSpeed = 45f;
    int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    

    }

    // Update is called once per frame
     internal void Update()
    {
        if (shouldMoveForward()) moveForward();
        if (shouldTurnLeft()) turnLeft();
        if (shouldMoveBackward()) moveBackward();
        if (shouldTurnRight()) turnRight();
        if (ShouldAttack()) attack();

    }

    

    private void attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 3, 1.5f);
        foreach (Collider collider in colliders) 
        {
            i_RW_Health enemy = collider.gameObject.GetComponent<i_RW_Health>();
            if (enemy != null)
                enemy.takeDamage(10);
        
        }
    }

    internal abstract bool ShouldAttack();
    
    private void turnRight()
    {
    
        transform.Rotate(new Vector3(0, 1, 0), turningSpeed * Time.deltaTime);
    }

    private void moveBackward()
    {
        transform.position -= speed * transform.forward * Time.deltaTime;
    }

    private void turnLeft()
    {
    
        transform.Rotate(new Vector3(0, 1, 0), -turningSpeed * Time.deltaTime);
    }

    private void moveForward()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    internal abstract bool shouldTurnRight();


    internal abstract bool shouldMoveBackward();
  

    internal abstract bool shouldTurnLeft();
   

    internal abstract bool shouldMoveForward();
   
    public void takeDamage(int damage)
    {
        print("Ouch");
        health -= damage;

        if (health < 0)Destroy(gameObject);


    }
}
