using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_PlayerB : PF_CharacterAbstract
{
    internal override bool shouldAttack()
    {
        return Input.GetKeyDown(KeyCode.RightControl);
    }

    internal override bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    internal override bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    internal override bool shouldMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    internal override bool shouldMoveRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
