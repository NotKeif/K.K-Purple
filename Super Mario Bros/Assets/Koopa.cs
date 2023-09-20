using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    private bool shelled;
    private bool shellMoving;
    public float shellSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        shelled = false;
        shellMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.transform.position.y > transform.position.y + 0.4f)
        {
            if (shelled)
            {
                Launch();
            }
            else
            {
                GetComponent<Animator>().SetTrigger("shell");
                GetComponent<EnemyMovement>().speed = 0;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                shelled = true;
            }

            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.velocity = new Vector2(playerRB.velocity.x, 10);
        }
        else if (shelled && !shellMoving)
        {
            Launch();
        }
        else
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().Hit();
        }
    }
    private void Launch()
    {
        GetComponent<EnemyMovement>().speed = 15;
        GetComponent<Rigidbody2D>().velocity = Vector3.right * 15;
        shellMoving = true;
    }
}
