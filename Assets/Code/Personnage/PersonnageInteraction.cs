using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonnageInteraction : MonoBehaviour
{
    public bool interaction;
    public GameObject texte;
    public PersonnageMouvements flip;

    // Update is called once per frame
    void Update()
    {
        if (!MenuPause.jeuEnPause)
        {
            if (interaction == true)
            {
                texte.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                texte.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (flip.faceADroite == true)
            {
                texte.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                texte.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interaction"))
        {
            interaction = true;
        }
        else if (collision.CompareTag("Vaisseau"))
        {
            interaction = true;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            interaction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interaction"))
        {
            interaction = false;
        }
        else if (collision.CompareTag("Vaisseau"))
        {
            interaction = false;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            interaction = false;
        }
    }
}

