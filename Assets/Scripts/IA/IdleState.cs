using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public float TimeStart = 3.0f;

    public RunState RunState;
    public override State RunCurrentState()
    {
        TimeStart -= Time.deltaTime;
        if(TimeStart <= 0f)
        {
            //Debug.Log("TIME!");
            return RunState;
        }
        else
        {
            return this;
        }
    }
}
