using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMouvements : MonoBehaviour
{

    public float vitesse;
    public float vitesseDeBase;
    public float vitesseObscurite;
    public float vitesseLumiere;
    public float HauteurDeSaut;
    public float longueurDeSaut;

    public bool faceAGauche = true;

    public Transform cible;
    private Vector3 ciblePosition;
    public float distanceY;
    public float distanceX;
    public bool auSol;
    Vector2 pos1;
    public Vector2 velocite;
    public float seuil;

    public Rigidbody2D runnerRB;
    public Animator animator;
    bool lumiere;

    private void Start()
    {
        vitesseDeBase = Random.Range(9f, 11f);
        vitesse = vitesseDeBase;
        vitesseLumiere = vitesseDeBase * 0.75f;
        vitesseObscurite = vitesseDeBase * 1.25f;
        cible = GameObject.FindGameObjectWithTag("Joueur").transform;
    }

    void FixedUpdate()
    {
        velocite = ((Vector2)runnerRB.transform.position - pos1) / Time.deltaTime;
        pos1 = runnerRB.transform.position;
        distanceY = cible.position.y - runnerRB.position.y;
        distanceX = Mathf.Abs(cible.position.x - runnerRB.position.x);
        if ((distanceY > 0) && (Mathf.Abs(velocite.x) < seuil))
        {
            ciblePosition = new Vector3(cible.position.x, runnerRB.position.y, 0);
            runnerRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
            runnerRB.gravityScale = 0f;
        }
        else if ((distanceY > 5) && (auSol == true) && (distanceX < 2))
        {
            ciblePosition = new Vector3(cible.position.x, runnerRB.position.y, 0);
            runnerRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
            runnerRB.gravityScale = 15f;
            Saut();
        }
        else if (distanceX > 15)
        {
            ciblePosition = new Vector3(cible.position.x, cible.position.y, 0);
            runnerRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
            runnerRB.gravityScale = 0.5f;
        }
        else
        {
            ciblePosition = new Vector3(cible.position.x, runnerRB.position.y, 0);
            runnerRB.position = Vector2.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);
            runnerRB.gravityScale = 15f;
        } 
        
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
        if (FindObjectOfType<Inventaire>().audio1 == true)
        {
            if (lumiere == true)
            {
                vitesse = vitesseLumiere;
            }
            else
            {
                vitesse = vitesseObscurite;
            }
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
        runnerRB.AddForce(new Vector3(longueurDeSaut, HauteurDeSaut, 0), ForceMode2D.Impulse);
        auSol = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mur")
        {
            Saut();
            auSol = true;
            animator.SetBool("EnSaut", false);
        }
        else if (collision.gameObject.tag == "Sol")
        {
            auSol = true;
            animator.SetBool("EnSaut", false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lumiere") && FindObjectOfType<Inventaire>().audio1 == true)
        {
            lumiere = true;
        }
        else
        {
            lumiere = false;
        }
    }
}
