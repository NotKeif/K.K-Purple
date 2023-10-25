using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    static int width = 20;
    static int hight = 10;


    private float previousTime;
    public float fallTime = 0.8f;
    //public float tempTime = fallTime;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 6);
            if (!validMove())
            {
                transform.Translate(Vector3.right * Time.deltaTime * 6);
            }
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 6);
            if (!validMove())
            {
                transform.Translate(Vector3.left * Time.deltaTime * 6);
            }
        }

        if (Time.time - previousTime > fallTime)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            if (!validMove())
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 8);
            if (!validMove())
            {
                transform.Translate(Vector3.up * Time.deltaTime * 8);
            }

        }
    }
    public bool validMove()
    {
        // Locking movement
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (transform.position.x < 0 || transform.position.x >= 0)
            {
                return false;
            }
            if (transform.position.y < 0 || transform.position.y >= 0)
            {
                return false;
            }
        }
        return true;

    }
}
