using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallState : State
{
    public List<Transform> FallTargets;
    private int currentFallIndex = 0;

    public Enemy Body;
    public float speed = 4f;

    private Rigidbody2D rb;

    public RunState RunState;

    private bool inici = false;

    void Start()
    {
        rb = Body.GetComponent<Rigidbody2D>();

    }
    public override State RunCurrentState()
    {
        if (!inici)
        {
            Body.TrFall();
            float directionX = Mathf.Sign(FallTargets[currentFallIndex].transform.position.x - Body.transform.position.x);
            Body.Flip(directionX);
            inici = true;
        }
        if (Vector2.Distance(Body.transform.position, FallTargets[currentFallIndex].position) < 1f)
        {
            //Debug.Log("Fall: " + currentFallIndex);
            // Move to the next jump point in the list
            currentFallIndex = (currentFallIndex + 1) % FallTargets.Count;
            inici = false;
            return RunState;
        }
        else
        {
            // Move the Body towards the Point along the x-axis
            float newX = Mathf.MoveTowards(Body.transform.position.x, FallTargets[currentFallIndex].transform.position.x, speed * Time.deltaTime);
            Body.transform.position = new Vector2(newX, Body.transform.position.y);
            float directionX = Mathf.Sign(FallTargets[currentFallIndex].transform.position.x - Body.transform.position.x);
            
            return this;
        }
    }
}