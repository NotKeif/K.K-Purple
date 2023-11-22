using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveVertical : MonoBehaviour
{
    float speed;
    int rand;
    float point1;
    float point2;
    float target;
    float currentPos;
    
    void Start()
    {
        //assign point 1 and 2
        point1 = transform.position.y - 1.5f;
        point2 = transform.position.y + 1.5f;

        //randomly assign first target as either point 1 or 2-> randomizes if move up,down or down,up
        rand = Random.Range(1, 3);
        if(rand == 1){
            target = point1;
        }
        if(rand == 2){
            target = point2;
        }
    }

    void FixedUpdate()
    {
        //platforms move at different speeds
        speed = Random.Range(0f, 3.25f);

        //switches moveTowards target when reach point
        currentPos = transform.position.y;
        if(currentPos == target){
            target = point2;
        } 
        if (currentPos == point2){
            target = point1;
        }
        
        //moveTowards target
        transform.position = Vector2.MoveTowards(transform.position, new Vector2 (transform.position.x, target), speed * Time.deltaTime);
    }
}

