using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_PlayerA : RS_CharacterAbstract
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }
    internal override bool shouldMoveBackwards()
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
    internal override bool shouldAttack()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }
   
}
