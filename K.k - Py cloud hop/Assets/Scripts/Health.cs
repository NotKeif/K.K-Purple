using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject player;

    float health = 1;
    public Transform healthBar;
    public SpriteRenderer healthSR;

    public GameObject tryAgain;
    public GameObject won;

    public GameObject rainGenerator;
    private float size = 1.2f;

    void Start()
    {
        player.SetActive(true);
        rainGenerator.SetActive(true);
        tryAgain.SetActive(false);
        won.SetActive(false);
    }
    void Update()
    {
       //healthbar is green if above 40% and red if below
        if(health< .4){
            healthSR.color = new Color32 (154, 20, 0, 255);
        }

        else if(health >= .4){
            healthSR.color = new Color32 (100, 154, 0, 255);
        }

        //when health is 0, try again & restart
        if(health <= 0){
            player.SetActive(false);
            rainGenerator.SetActive(false);
            Invoke("TryAgain", 1);
        }
    } 
     void OnTriggerEnter2D(Collider2D other){
        //if collide with rain, decrease health
        if(other.CompareTag("rain")){
            Destroy(other.gameObject);
            if(health > 0){
                health -= .1f;
                healthBar.localScale = new Vector2 (health, 1);
                size-=0.07f;
                transform.localScale = new Vector2(size,size);
            }
        }

        //if collide with rain, increase health
        if(other.CompareTag("log")){
            Destroy(other.gameObject);
            if(health < 1){
                health += .1f;
                healthBar.localScale = new Vector2 (health, 1);
                size+=0.07f;
                transform.localScale = new Vector2(size, size);
            }
        }

        //turn off rain when reach end zone
        if(other.CompareTag("end")){
            won.SetActive(true);
            //can't generate any more raindrops
            rainGenerator.SetActive(false);

            //destroys all raindrops currently in scene
            //put all raindrops into an array & destroy
            GameObject[] raindrops = GameObject.FindGameObjectsWithTag("rain");
            foreach(GameObject raindrop in raindrops){
                Destroy(raindrop);
            }
            
            Invoke("Restart", 4);
        }
    }

    void TryAgain(){
        tryAgain.SetActive(true);
        Invoke("Pause", 2);
    }

    void Pause(){
        tryAgain.SetActive(false);
        Invoke("Restart", 1);
    }

    void Restart(){
        SceneManager.LoadScene(0);
    }
}