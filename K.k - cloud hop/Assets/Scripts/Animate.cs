using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public Animator anim;

    bool canJump;

    bool running;
    bool onGround;
    bool jumping;
    bool falling;
    bool jumpStart;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        onGround = true;
        running = false;
        jumping = false;
        falling = false;
        jumpStart = false;
    }

    void Update()
    {
        //get left/right input information
        float horizontal = Input.GetAxis("Horizontal");
        //get vertical velocity of player
        float verticalVelocity = rigidBody.velocity.y;

        //if player's velocity is > 0.1 (player is starting jump) then jump animation is true
        if (verticalVelocity > 0.1f)
        {
            jumping = true;
            falling = false;
            canJump = false;
            onGround = false;
        }
        //if player's velocity is < -0.5 (player is falling) then fall animation is true
        else if (verticalVelocity < -.1f)
        {
            jumping = false;
            falling = true;
            canJump = false;
            onGround = false;
        }
        //else the player is on the ground, so idle animation is true and set canJump to true
        else
        {
            jumping = false;
            falling = false;
            canJump = true;
            onGround = true;
        }
        //if press space, jump start animation is true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpStart = true;
        }
        else
        {
            jumpStart = false;
        }

        //if on ground and pressing right or left, then running animation is true
        if (horizontal != 0 && onGround)
        {
            running = true;
        }
        else
        {
            running = false;
        }

        //if moving right, face ninja right
        if (horizontal > 0)
        {
            Vector3 thisScale = transform.localScale;
            if (thisScale.x < 0)
            {
                thisScale.x *= -1;
            }
            transform.localScale = thisScale;
        }
        //if moving left, face ninja left
        else if (horizontal < 0)
        {
            Vector3 thisScale = transform.localScale;
            if (thisScale.x > 0)
            {
                thisScale.x *= -1;
            }
            transform.localScale = thisScale;
        }

        //send animation bools to animator to play animations
        anim.SetBool("Running", running);
        anim.SetBool("OnGround", onGround);
        anim.SetBool("JumpUp", jumping);
        anim.SetBool("Falling", falling);
        anim.SetBool("JumpStart", jumpStart);
    }

}

