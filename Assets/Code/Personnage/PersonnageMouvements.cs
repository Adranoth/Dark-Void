using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PersonnageMouvements : MonoBehaviour
{
    public Rigidbody2D personnageRb;
    public float linearDragAuSol = 0f;
    public float linearDragJetpack = 10f;
    public float graviteAuSol = 15f;
    public float graviteJetpack = 0f;

    bool faceADroite = true;

    public float vitesse = 15;

    public float dureeMaxDeSaut = 0.3f;
    public float forceDeSaut = 30;
    float tempsDeSaut;
    bool enSaut;
    bool auSol = true;

    public bool jetpackAcquis = false;
    bool jetpackActive = false;
    public float dureeMaxDeJetpack = 3f;
    public float jetpackCD = 10f;
    float tempsDeJetpack;
    float tempsDeJetpackCD;
    bool jetpackEnCD = false;


    void FixedUpdate()
    {
        Direction();
    }

    private void Update()
    {
        Saut();
        Jetpack();
    }

    private void Direction()
    {
        float move = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (difference.x > 0f && !faceADroite)
        {
            Flip();
        }

        if (difference.x < 0f && faceADroite)
        {
            Flip();
        }

        if (!jetpackActive)
        {
            personnageRb.velocity = new Vector2(vitesse * move, personnageRb.velocity.y);
        }else
        {
            personnageRb.velocity = new Vector2(vitesse * move, vitesse * moveY);
        }
    }

    private void Flip()
    {
        faceADroite = !faceADroite;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Jetpack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !auSol && !enSaut && jetpackAcquis && !jetpackEnCD)
        {
            enSaut = false;
            tempsDeJetpack = 0;
            jetpackActive = true;
            personnageRb.drag = linearDragJetpack;
            personnageRb.gravityScale = graviteJetpack;
        }
        if (jetpackActive)
        {
            tempsDeJetpack += Time.deltaTime;
        }
        if ((Input.GetKeyUp(KeyCode.Space) | tempsDeJetpack > dureeMaxDeJetpack) && !jetpackEnCD && jetpackActive)
        {
            jetpackActive = false;
            jetpackEnCD = true;
            tempsDeJetpackCD = 0;
            personnageRb.drag = linearDragAuSol;
            personnageRb.gravityScale = graviteAuSol;
        }
        if (jetpackEnCD)
        {
            tempsDeJetpackCD += Time.deltaTime;
        }
        if (tempsDeJetpackCD > jetpackCD)
        {
            jetpackEnCD = false;
        }
    }

    private void Saut()
    {
        if (Input.GetKeyDown(KeyCode.Space) && auSol)
        {
            enSaut = true;
            tempsDeSaut = 0;
            auSol = false;
        }
        if (enSaut)
        {
            personnageRb.velocity = new Vector2(personnageRb.velocity.x, forceDeSaut);
            tempsDeSaut += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | tempsDeSaut > dureeMaxDeSaut)
        {
            enSaut = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Sol"))
        {
            auSol = true;
        }
    }
}