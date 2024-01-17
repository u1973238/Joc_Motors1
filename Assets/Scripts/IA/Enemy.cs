using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Body;

    public Animator animator;

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

    public void SetAtack(bool i)
    {
        animator.SetBool("AttackRange", i);
    }
}
