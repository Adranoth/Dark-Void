using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMouvements : MonoBehaviour
{

    public float vitesse;
    public float HauteurDeSaut;

    private bool faceAGauche = true;

    public Transform cible;
    private Vector3 ciblePosition;

    private Rigidbody2D runnerRB;
    public Animator animator;
    


    void Start()
    {
        runnerRB = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        ciblePosition = new Vector3(cible.position.x, runnerRB.position.y, 0);
        runnerRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
        animator.SetFloat("Vitesse", Mathf.Abs(vitesse));

        float difference = transform.position.x - cible.position.x;

        if (difference >= 0.01f && !faceAGauche)
        {
            Flip();
        }

        if(difference <= -0.01f && faceAGauche)
        {
            Flip();
        }
    }

    private void Flip()
    {
        faceAGauche = !faceAGauche;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Saut()
    {
        animator.SetBool("EnSaut", true);
        runnerRB.AddForce(new Vector2(0, HauteurDeSaut));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sol"))
        {
            Saut();
            animator.SetBool("EnSaut", false);
        }
    }
}
