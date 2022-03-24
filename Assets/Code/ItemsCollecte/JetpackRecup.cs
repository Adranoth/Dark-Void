using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackRecup : MonoBehaviour
{

    public PersonnageMouvements personnageMouvements;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            personnageMouvements.jetpackAcquis = true;
        }
        Destroy(gameObject);
    }
}
