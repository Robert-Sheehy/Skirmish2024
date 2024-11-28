using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_PlayerB : RW_BoyMovement
{
    internal override bool ShouldAttack()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    internal override bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    internal override bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    internal override bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    internal override bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
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
