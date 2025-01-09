using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_PlayerA : DB_CharacterAbstract, I_DBHealth
{

    private new int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    internal override bool shouldMoveBack()
    {
        return (Input.GetKey(KeyCode.S));
    }

    internal override bool shouldMoveForward()
    {
        return (Input.GetKey(KeyCode.W));
    }

    internal override bool shouldMoveLeft()
    {
        return (Input.GetKey(KeyCode.A));
    }

    internal override bool shouldMoveRight()
    {
        return (Input.GetKey(KeyCode.D));
    }

    internal override bool shouldTurnRight()
    {
        return (Input.GetKey(KeyCode.E));
    }

    internal override bool shouldTurnLeft()
    {
        return (Input.GetKey(KeyCode.Q));
    }

    internal override bool shouldAttack()
    {
        return (Input.GetKey(KeyCode.F));
    }
}
