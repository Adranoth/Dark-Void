using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;



public class NoWallClipPLZ : MonoBehaviour
{
    public PersonnageLampe lampe;
    public GameObject personnage;
    public GameObject lumiere;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mur"))
        {
            personnage.GetComponent<PersonnageTirer>().enabled = false;
            if (lampe.estAllume == true)
            {
                lumiere.SetActive(false);
                lampe.estAllume = false;
            }
            else
            {
                return;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mur"))
        {
            if (lampe.estAllume == false)
            {
                personnage.GetComponent<PersonnageTirer>().enabled = true;
                if (lampe.dejaAllume == false)
                {
                    return;
                }
                else
                {
                    lumiere.SetActive(true);
                    lampe.estAllume = true;
                }
            }
        }
    }
}
