using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_PlayerB : RS_CharacterAbstract
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    internal override bool shouldMoveBackwards()
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
    internal override bool shouldAttack()
    {
        return Input.GetKeyDown(KeyCode.X);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }
    
}
