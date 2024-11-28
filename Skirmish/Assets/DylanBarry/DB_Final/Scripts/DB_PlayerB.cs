using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_PlayerB : DB_CharacterAbstract, I_DBHealth
{
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
        return (Input.GetKey(KeyCode.DownArrow));
    }

    internal override bool shouldMoveForward()
    {
        return (Input.GetKey(KeyCode.UpArrow));
    }

    internal override bool shouldMoveLeft()
    {
        return (Input.GetKey(KeyCode.LeftArrow));
    }

    internal override bool shouldMoveRight()
    {
        return (Input.GetKey(KeyCode.RightArrow));
    }

    internal override bool shouldTurnRight()
    {
        return (Input.GetKey(KeyCode.O));
    }

    internal override bool shouldTurnLeft()
    {
        return (Input.GetKey(KeyCode.P));
    }

    internal override bool shouldAttack()
    {
        return (Input.GetKey(KeyCode.L));
    }
}
