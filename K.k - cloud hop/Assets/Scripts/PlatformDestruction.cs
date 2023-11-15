using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    GameObject platformDestructionPoint;
    Score Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.FindWithTag("Player").GetComponent<Score>();
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < platformDestructionPoint.transform.position.y){
            Destroy(gameObject);
            Score.platformsHit.Remove(gameObject);
        }
    }
}
