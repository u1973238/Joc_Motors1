using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Body;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Flip(float dir)
    {
        Vector3 flipped = Body.transform.localScale;
        if(Mathf.Sign(flipped.z) != dir)
        {
            flipped.z *= -1f;
            Body.transform.localScale = flipped;
            Body.transform.Rotate(0f, 180f, 0f);
        }
    }

    public void TrRun()
    {
        animator.SetTrigger("TrRun");
    }
    public void TrJump()
    {
        animator.SetTrigger("TrJump");
    }
    public void TrFall()
    {
        animator.SetTrigger("TrFall");
    }
}
