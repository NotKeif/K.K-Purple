using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    GameObject player;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        if(player.transform.position.x > 6.5f || player.transform.position.x < -6.5f){
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        SceneManager.LoadScene(0);
    }
}
