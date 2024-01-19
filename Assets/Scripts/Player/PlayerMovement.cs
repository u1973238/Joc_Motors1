using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPersonatge;
    private Animator anim;
    private SpriteRenderer sprite;
    private int mirantDreta = 1;
    private float dirX = 0f;
    private enum MovementState {idle, running, jumping, falling}
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float jumpForce = 7f;
    private MovementState state;
    
    // Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    private Tutorial_GrapplingRope ropeInstance ; //Instancia filla, la corda de la Grappling gun

    // Start is called before the first frame update
    void Start()
    {
        rbPersonatge = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        ropeInstance = GetComponentInChildren<Tutorial_GrapplingRope>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing){
            return;
        }
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
        rbPersonatge.velocity = new Vector2(dirX * moveSpeed, rbPersonatge.velocity.y);
        if(!ropeInstance.isGrappling){
            if (Input.GetButtonDown("Jump") && state != MovementState.jumping && state != MovementState.falling){
                rbPersonatge.velocity = new Vector2(0f, jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && canDash){
            StartCoroutine(Dash());
        }

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState(){
        if (dirX > 0){
            sprite.flipX = false;
            state = MovementState.running;
            mirantDreta = 1;
        }
        else if (dirX < 0){
            sprite.flipX = true;
            state = MovementState.running;
            mirantDreta = -1;
        }
        else{
            state = MovementState.idle;
        }

        if(rbPersonatge.velocity.y > .1f){
            state = MovementState.jumping;
        }
        else if(rbPersonatge.velocity.y < -.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("movementState", (int)state);
    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rbPersonatge.gravityScale;
        rbPersonatge.gravityScale = 0;
        rbPersonatge.velocity = new Vector2(mirantDreta * dashingPower, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rbPersonatge.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        Debug.Log("ara");
    }
}
