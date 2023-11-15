using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public float speed;

    float masterSpeed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        masterSpeed = speed;        
    }


    void FixedUpdate()
    {
        //get right/left input information
        float horizontal = Input.GetAxis("Horizontal");

        //get vertical velocity
        float verticalMovement = rigidBody.velocity.y;
        //if player is in the air, decrease speed
        if (verticalMovement != 0)
        {
            speed = masterSpeed / 2f;
        }
        else
        {
            speed = masterSpeed;
        }

        //move player left and right according to user input and speed
        transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed; 
    }
}

