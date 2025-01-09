using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_PlayerA : CW_CharacterAbstract
{

    internal override bool shouldAttack()
    {
        return Input.GetKey(KeyCode.J);
    }

    internal override bool shouldMoveBakcWard()
    {
        return Input.GetKey(KeyCode.S);
    }

    internal override bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    internal override bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    internal override bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
