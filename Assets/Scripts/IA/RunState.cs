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

    public LayerMask groundLayer;
    public float groundCheckDistance = 0.2f;

    public override State RunCurrentState()
    {
        if (!inici)
        {
            Body.TrRun();
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
        if (Vector2.Distance(Body.transform.position, TurnPoints[currentTurnIndex].position) < 1f)
        {
            Debug.Log("turn:" + currentTurnIndex);
            direction = direction * -1;
           currentTurnIndex = (currentTurnIndex + 1) % TurnPoints.Count;
            Body.Flip(direction);
        };

        //Condició si no toca el terra
        bool touchingGroundDown = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        bool touchingGroundDownLeft = Physics2D.Raycast(transform.position, new Vector2(-1, -1), groundCheckDistance, groundLayer);
        bool touchingGroundDownRight = Physics2D.Raycast(transform.position, new Vector2(1, -1), groundCheckDistance, groundLayer);
        if(touchingGroundDown || touchingGroundDownLeft || touchingGroundDownRight)
        {
            Body.TrRun();
            // Move the Body along the x-axis
            float newX = Body.transform.position.x + (speed * direction * Time.deltaTime);
            // Update the position
            Body.transform.position = new Vector2(newX, Body.transform.position.y);
        }
        else
        {
            Body.TrFall();
        }

        return this;
    }
}