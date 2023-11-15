using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        //follow player's y position + offset
        //do not follow when player is falling
        if(player.transform.position.y > transform.position.y){
            transform.position = new Vector3 (transform.position.x, player.transform.position.y, -10);
        }
    }
}
