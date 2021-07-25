using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovementController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D capsuleColider;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;

    public Vector2 facingDirection = Vector2.right;
    public float moveSpeed = 5;
    public float jumpForce = 200;

    public bool isJumping = false;
    public float jumpTime = 3;
    public float jumpTimeCounter = 0;

    void Awake(){
    }
    // Update is called once per frame
    void Update()
    {
        updateSpriteDirection();
        updateSpriteAnimation();
        if (isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                body.velocity = Vector2.up * jumpForce;
            }
        }

        if(Input.GetKey(KeyCode.Space) && isJumping) {
            if(jumpTimeCounter > 0 ){
                body.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;  
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
        }

      
    }

    private void FixedUpdate(){
        float velX = Input.GetAxis("Horizontal") * moveSpeed; 
        body.velocity = new Vector2(velX, body.velocity.y);
    }

    private void updateSpriteAnimation()
    {
        Vector2 vel = body.velocity;
        if (vel.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(vel.y > 0)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }
        else if(vel.y < 0 )
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
    }

    private void updateSpriteDirection()
    {
        float direction = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        if(direction > 0)
        {
            facingDirection = Vector2.right;
            spriteRenderer.flipX = false;
        } 
        else if (direction < 0)
        {
            facingDirection = Vector2.left;
            spriteRenderer.flipX = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capsuleColider.bounds.center, capsuleColider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }


}
