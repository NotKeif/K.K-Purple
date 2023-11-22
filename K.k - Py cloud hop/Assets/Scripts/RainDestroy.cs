using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDestroy : MonoBehaviour
{
    int timer;

    void Update()
    {
        if(transform.position.y < -5){
            Destroy(gameObject);
        }
    }
}
