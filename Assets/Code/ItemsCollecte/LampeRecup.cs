using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeRecup : MonoBehaviour
{
    public PersonnageLampe personnageLampe;
    public BrasLampe brasLampe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            personnageLampe.lampeAcquise = true;
            brasLampe.lampeAcquise = true;
            Destroy(gameObject);
        }
    }
}
