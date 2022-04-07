using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeRecup : MonoBehaviour
{
    public Inventaire inventaire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            inventaire.lampeAcquise = true;
            Destroy(gameObject);
        }
    }
}
