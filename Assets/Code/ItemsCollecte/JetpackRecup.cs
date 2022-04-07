using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackRecup : MonoBehaviour
{

    public Inventaire inventaire;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            inventaire.jetpackAcquis = true;
            spriteRenderer.enabled = true;
            Destroy(gameObject);
        }
        
    }
}
