using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAttaque : MonoBehaviour
{
    public int degats = 10;
    public GameObject runner;
    private bool droite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Joueur"))
        {
            PersonnageVie personnageVie = collision.transform.GetComponent<PersonnageVie>();
            personnageVie.PrendreDegats(degats, droite);
        }
    }

    private void Update()
    {
        if (runner.GetComponent<RunnerMouvements>().faceAGauche == true)
        {
            droite = true;
        }
        else
        {
            droite = false;
        }
    }
}
