using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeRecup : MonoBehaviour
{
    public PersonnageLampe personnageLampe;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            personnageLampe.lampeAcquise = true;
            Destroy(gameObject);
        }
    }
}
