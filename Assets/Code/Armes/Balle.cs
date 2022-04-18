using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    public float vitesse = 50f;
    public int degats = 10;
    private Rigidbody2D rb;
    public GameObject sang;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vitesse;
        sang.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pre-test pour eviter les autres
        if(collision.CompareTag("Ennemi"))
        {
            RunnerVie runner = collision.GetComponent<RunnerVie>();
            //Est-ce un runner ?
            if(runner != null)
            {
                runner.PrendreDegats(degats);
                Instantiate(sang, transform.position, transform.rotation);
                Destroy(gameObject);
                return;
            }

            JumperVie jumper = collision.GetComponent<JumperVie>();
            //Est-ce un jumper ?
            if (jumper != null)
            {
                jumper.PrendreDegats(degats);
                Instantiate(sang, transform.position, transform.rotation);
                Destroy(gameObject);
                return;
            }

            FlyerVie flyer = collision.GetComponent<FlyerVie>();
            //Est-ce un flyer ?
            if (flyer != null)
            {
                flyer.PrendreDegats(degats);
                Instantiate(sang, transform.position, transform.rotation);
                Destroy(gameObject);
                return;
            }
        }

        if (collision.CompareTag("Joueur") || collision.CompareTag("Checkpoint") || collision.CompareTag("Aggro"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
