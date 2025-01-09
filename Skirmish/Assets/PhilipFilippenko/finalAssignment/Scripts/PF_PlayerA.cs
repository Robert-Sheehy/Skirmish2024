using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_PlayerA : PF_CharacterAbstract
{
    internal override bool shouldAttack()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    internal override bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.S);
    }

    internal override bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    internal override bool shouldMoveLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    internal override bool shouldMoveRight()
    {
        return Input.GetKey(KeyCode.D);
    }
}
