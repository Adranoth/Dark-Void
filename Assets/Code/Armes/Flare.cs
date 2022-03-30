using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    public float vitesse;
    public float duree;
    private Rigidbody2D rb;


    void Start()
    {
        var direction = transform.right + Vector3.up;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * vitesse, ForceMode2D.Impulse);
        Destroy(gameObject, duree);
    }

    void Update()
    {
    }
}
