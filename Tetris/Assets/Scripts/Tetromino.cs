using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    static int width = 10;
    static int height = 20;

    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    //public float tempTime = fallTime;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
            if (!validRotation())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += (Vector3.left);
            if (!validMove())
            {
                transform.position += (Vector3.right);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += (Vector3.right);
            if (!validMove())
            {
                transform.position += (Vector3.left);
            }
        }

        if (Time.time - previousTime > fallTime)
        {
            transform.position += Vector3.down * Time.deltaTime;
            if (!validMove())
            {
                transform.position += Vector3.up * Time.deltaTime;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position+=Vector3.down;
            if (!validMove())
            {
                transform.position+=Vector3.up;
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
            if (transform.position.x < 0.934 || transform.position.x >= 8.1)
            {
                return false;
            }
            if (transform.position.y < -0.056 || transform.position.y >= 18.047)
            {
                return false;
            }
        }
        return true;

    }
    public bool validRotation()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (transform.position.x < 0.952 || transform.position.x >= 8.105 && transform.position.y == -0.06)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        return true;
    }
}
