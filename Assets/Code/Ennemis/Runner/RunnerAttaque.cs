using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAttaque : MonoBehaviour
{
    public int degats = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Joueur"))
        {
            PersonnageVie personnageVie = collision.transform.GetComponent<PersonnageVie>();
            personnageVie.PrendreDegats(degats);
        }
    }
}
