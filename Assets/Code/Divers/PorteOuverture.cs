using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteOuverture : MonoBehaviour
{
    public Animator animator;
    private bool PorteOuverte = false;
    private bool interaction;
    public GameObject porte;

    private void Update()
    {
        if (interaction == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PorteOuverte == false)
                {
                    animator.SetBool("Interaction", true);
                    StartCoroutine(OuvrirPorte());
                    PorteOuverte = true;
                }
                else
                {
                    animator.SetBool("Interaction", false);
                    StartCoroutine(FermerPorte());
                    PorteOuverte = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = false;
        }
    }

    private IEnumerator OuvrirPorte()
    {
        yield return new WaitForSeconds(2);
        porte.GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator FermerPorte()
    {
        yield return new WaitForSeconds(1);
        porte.GetComponent<BoxCollider2D>().enabled = true;
    }
}
