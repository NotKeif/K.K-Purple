using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject [] platforms;
    int platformSelector;
    public Transform generationPoint;
    public float distBetween;
    float platformHeight;

    int xPos;


    // Start is called before the first frame update
    void Start()
    {
        platformHeight = platforms[platformSelector].transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
         if(transform.position.y < generationPoint.position.y)
        {
            platformSelector = Random.Range(0, platforms.Length);

            xPos = Random.Range(-4, 4);

            transform.position = new Vector3(xPos, transform.position.y + platformHeight + distBetween, transform.position.z);
            
            Instantiate(platforms[platformSelector], transform.position, transform.rotation);
        }
    }
}
