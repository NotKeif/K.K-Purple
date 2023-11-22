using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    public Text scoreText;
    public List<GameObject> platformsHit;

    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    void OnCollisionEnter2D(Collision2D other){
        //if hit platform && haven't already hit platform(ie gotten a point from platform)
        if(other.gameObject.CompareTag("Platform") && !platformsHit.Contains(other.gameObject)){
            //add to platformHit list & increase score
            platformsHit.Add(other.gameObject);
            score ++;
            scoreText.text = "SCORE: " + score.ToString();
        }
    }
}
