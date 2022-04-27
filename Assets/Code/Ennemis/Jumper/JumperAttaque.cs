using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperAttaque : MonoBehaviour
{
    public int degats = 10;
    public GameObject jumper;
    private bool droite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Joueur"))
        {
            PersonnageVie personnageVie = collision.transform.GetComponent<PersonnageVie>();
            personnageVie.PrendreDegats(degats, droite);
        }
    }
    private void Update()
    {
        if (jumper.GetComponent<JumperMouvements>().faceAGauche == true)
        {
            droite = true;
        }
        else
        {
            droite = false;
        }
    }
}
