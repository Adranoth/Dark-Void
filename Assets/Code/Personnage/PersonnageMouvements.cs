using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PersonnageMouvements : MonoBehaviour
{
    public Rigidbody2D personnageRb;

    bool faceADroite = true;

    public float vitesse = 15;

    public float dureeMaxDeSaut = 0.3f;
    public float forceDeSaut = 30;
    float tempsDeSaut;
    bool enSaut;
    bool auSol = true;

    void FixedUpdate()
    {
        DroiteGauche();
    }

    private void Update()
    {
            Saut();
    }

    private void DroiteGauche()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0f && !faceADroite)
        {
            Flip();
        }

        if (move < 0f && faceADroite)
        {
            Flip();
        }

        personnageRb.velocity = new Vector2(vitesse * move, personnageRb.velocity.y);
    }

    private void Flip()
    {
        faceADroite = !faceADroite;

        transform.Rotate(0f, 180f, 0f);
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