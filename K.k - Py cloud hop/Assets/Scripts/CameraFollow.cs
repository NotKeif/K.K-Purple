using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        //follow player's y position + offset
        transform.position = new Vector3 (transform.position.x, player.transform.position.y + 5.3f, -10);
    }
}
