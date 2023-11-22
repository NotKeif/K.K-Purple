using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    public Text timerText;
    bool gameOver;

    void Update()
    {
        timer += Time.deltaTime;
        
        //as long as the player hasn't reached the last platform (not gameover), then update the timer on the screen
        if(!gameOver){
            timerText.text = timer.ToString("F2"); //display 2 decimal points
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //if hit the end platform trigger, then gameover is true
        if(other.gameObject.CompareTag("end")){
            gameOver = true;
        }
    }
}
