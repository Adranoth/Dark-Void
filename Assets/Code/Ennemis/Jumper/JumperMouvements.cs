using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMouvements : MonoBehaviour
{

    public float vitesse;

    private bool faceAGauche = true;

    public Transform cible;
    private Vector3 ciblePosition;

    bool auSol = true;
    public float hauteurSaut;
    public float distanceDeSaut;
    public float sautCoefficientX;
    float distanceDuJoueur;

    private Rigidbody2D jumperRB;
    public Animator animator;



    void Start()
    {
        jumperRB = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        distanceDuJoueur = cible.position.x - transform.position.x;

        if(Mathf.Abs(distanceDuJoueur) > distanceDeSaut)
        {
            ciblePosition = new Vector3(cible.position.x, jumperRB.position.y, 0);
            jumperRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
        }
        else
        {
            Saut();
        }


        if (distanceDuJoueur >= 0.01f && faceAGauche)
        {
            Flip();
        }

        if (distanceDuJoueur <= -0.01f && !faceAGauche)
        {
            Flip();
        }
    }

    private void Saut()
    {
        if (auSol)
        {
            animator.SetBool("EnSaut", true);
            auSol = false;
            jumperRB.AddForce(new Vector2(distanceDuJoueur * sautCoefficientX, hauteurSaut), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        faceAGauche = !faceAGauche;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            auSol = true;
            animator.SetBool("EnSaut", false);
        }
    }
}
