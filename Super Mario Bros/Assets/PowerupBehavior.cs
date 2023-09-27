using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
     public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.enabled = false;
        Rigidbody2D rb = animator.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * 4f;
    }
}
