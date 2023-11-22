using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    GameObject player;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D other){
        player.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D other){
        player.transform.parent = null;
    }
}
