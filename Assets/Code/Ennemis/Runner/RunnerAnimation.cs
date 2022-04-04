using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimation : MonoBehaviour
{
    public Animator animator;
    GameObject Runner;
    bool EnSaut;

    private void Start()
    {
        EnSaut = false;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Vitesse", Mathf.Abs(Runner.GetComponent<RunnerMouvements>().vitesse));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sol"))
        {
            if (EnSaut == true)
            {
                animator.SetBool("EnSaut", false);
                EnSaut = false;
            }
            else
            {
                animator.SetBool("EnSaut", true);
                EnSaut = true;
            }
        }
            
    }
}

