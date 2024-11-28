using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_PlayerA : RW_BoyMovement
{
    internal override bool ShouldAttack()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    internal override bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.A);
    }

    internal override bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    internal override bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.S);
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
