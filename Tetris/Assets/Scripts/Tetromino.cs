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
    public static Transform[,] grid = new Transform[width, height];
    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            grid[x, y] = child;
        }
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
            if (!validMove())
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
                AddToGrid();
                this.enabled = false;
                FindObjectOfType<Spawner>().SpawnTetromino();
                CheckForLines();

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
            if (x < 0 || x >= width)
            {
                return false;
            }
            if (y < -0.5 || y >= height)
            {
                return false;
            }
            if (grid[x, y] != null)
            {
                return false;
            }
        }
        return true;
        

    }
    //public bool validRotation()
    //{
    //    foreach (Transform child in transform)
    //    {
    //        int x = Mathf.RoundToInt(child.transform.position.x);
    //        int y = Mathf.RoundToInt(child.transform.position.y);
    //        if (transform.position.x < -0.5 || transform.position.x >= 9.5 && transform.position.y == -0.5)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return true;
    //        }

    //    }
    //    return true;
    //}
    public void CheckForLines()
    {
        for (int i = height - 1; i >=0; i--)
        {
            Debug.Log("called");
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    public bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
            {
                Debug.Log("false");
                return false;
                
            }
            
        }
        Debug.Log("true");
        return true;
        
    }
    public void DeleteLine(int i)
    {
        Debug.Log("delete");
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    public void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x,y]!= null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
}
