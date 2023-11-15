using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGeneration : MonoBehaviour
{
    public GameObject rain;
    public GameObject rainGenerator;

    int x;
    Vector3 offset;
    int timer;
    
    void Update()
    {
        timer += 1;

        //if timer = 60, instantiate a raindrop at a random x value on screen
        if(timer == 60){
            x = Random.Range(6, -6);
            offset = new Vector3 (x, 0, 0);

            Instantiate(rain, transform.position + offset, transform.rotation); 

            timer = 0;
        } 
    }
}
