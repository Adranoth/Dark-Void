using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerAttaque : MonoBehaviour
{
    public int degats = 10;
    public GameObject flyer;
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
        if (flyer.GetComponent<FlyerFlip>().versLaDroite == true)
        {
            droite = false;
        }
        else
        {
            droite = true;
        }
    }
}
