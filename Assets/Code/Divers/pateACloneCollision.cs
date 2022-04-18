using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pateACloneCollision : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            animator.SetBool("AuSol", true);
        }

    }

}
