using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate1 : MonoBehaviour
{
    public GameObject background;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur") && FindObjectOfType<PersonnageMouvements>().move < 0)
        {
            background.SetActive(true);
        }
        else if (collision.CompareTag("Joueur") && FindObjectOfType<PersonnageMouvements>().move > 0)
        {
            background.SetActive(false);
        }
    }
}

