using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class RunState : State
{
    public List<Transform> JumpPoints;
    public List<Transform> TurnPoints;

    private int currentJumpIndex = 0;
    private int currentTurnIndex = 0;
    private bool inici = false;
    private int direction = 1; // 1 for right, -1 for left

    public Enemy Body;
    public float speed = 10f;

    public JumpState JumpState;

    public override State RunCurrentState()
    {
        if (!inici)
        {
            float directionX = Mathf.Sign(JumpPoints[currentJumpIndex].transform.position.x - Body.transform.position.x);
            Body.Flip(direction);
            inici = true;
        }
        if (Vector2.Distance(Body.transform.position, JumpPoints[currentJumpIndex].position) < 1f)
        {
            Debug.Log("jump: " + currentJumpIndex);
            // Move to the next jump point in the list
            currentJumpIndex = (currentJumpIndex + 1) % JumpPoints.Count;
            inici = false;
            return JumpState;
        }
        //Condició si no toca el terra passar a Fall state

        if (Vector2.Distance(Body.transform.position, TurnPoints[currentTurnIndex].position) < 1f)
        {
            Debug.Log("turn:" + currentTurnIndex);
            direction = direction * -1;
           currentTurnIndex = (currentTurnIndex + 1) % TurnPoints.Count;
            Body.Flip(direction);
        }
        // Move the Body along the x-axis
        float newX = Body.transform.position.x + (speed * direction * Time.deltaTime);
        // Update the position
        Body.transform.position = new Vector2(newX, Body.transform.position.y);
        return this;
    }
}