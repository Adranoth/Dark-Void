using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackRecup : MonoBehaviour
{

    public Inventaire inventaire;
    public GameObject jetpack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            inventaire.jetpackAcquis = true;
            jetpack.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
