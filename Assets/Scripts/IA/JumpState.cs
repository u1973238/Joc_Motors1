using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public float jumpForce = 10f;
    public Enemy Body;

    private Rigidbody2D rb;

    public FallState fallState;

    void Start()
    {
        rb = Body.GetComponent<Rigidbody2D>();
        
    }
    public override State RunCurrentState()
    {
        Body.TrJump();
        rb.velocity = Vector2.up * jumpForce;
        return fallState;
    }
}
