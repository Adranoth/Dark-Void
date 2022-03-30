using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackRecup : MonoBehaviour
{

    public PersonnageMouvements personnageMouvements;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            personnageMouvements.jetpackAcquis = true;
            spriteRenderer.enabled = true;
            Destroy(gameObject);
        }
        
    }
}
