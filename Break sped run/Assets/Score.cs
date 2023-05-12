using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
    }
}
