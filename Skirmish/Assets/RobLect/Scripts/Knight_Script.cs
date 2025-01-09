using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Script : RL_UnitMovementScript
{
    GameObject Horse;
    private Vector3 stableLocation = new Vector3(20,0,20);

    // Start is called before the first frame update
    void Start()
    {
        state = UnitState.Moving;
        MoveTo(stableLocation);   
    }

    // Update is called once per frame
    void Update()
    {
        // code before base update

        base.Update();

        // code after base update
        
    }
}
