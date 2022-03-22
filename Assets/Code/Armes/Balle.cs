using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    public float vitesse = 50f;
    public int degats = 10;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vitesse;
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
                Destroy(gameObject);
                return;
            }
        }
        Destroy(gameObject);
    }
}