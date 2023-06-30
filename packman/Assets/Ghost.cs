using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    private bool frightened;
    private void Awake()
    {
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
        frightened = false;
        Invoke("LeaveHome", homeDuration);
    }
    protected override void ChildUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(atHome && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SetDirection(-direction);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();
        if (node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);
            SetDirection(node.availableDirections[index]);

            if (node.availableDirections[index] == -direction)
            {
                index += 1;
            }
            SetDirection(node.availableDirections[index]);

            if(index == node.availableDirections.Count)
            {
                index = 0;
            }
        }
        
    }
    private void LeaveHome()
    {
        transform.position = new Vector3(0, 2.5f, -1f);
        direction = new Vector2(-1, 0);
        atHome = false;
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);

    }
    public void Frighten()
    {

    }
    private void Flash()
    {

    }
    private void Reset()
    {
        
    }

}
