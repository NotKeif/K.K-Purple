using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveHorizontal : MonoBehaviour
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
        point1 = transform.position.x - 1.5f;
        point2 = transform.position.x + 1.5f;

        //randomly assign first target as either point 1 or 2-> randomizes if left,right or right,left
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
        currentPos = transform.position.x;
        if(currentPos == target){
            target = point2;
        } 
        if (currentPos == point2){
            target = point1;
        }
        
        //moveTowards target
        transform.position = Vector2.MoveTowards(transform.position, new Vector2 (target, transform.position.y), speed * Time.deltaTime);
    }
}
