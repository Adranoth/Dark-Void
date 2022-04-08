using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAggro : MonoBehaviour
{
    public GameObject aggro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            aggro.GetComponent<RunnerMouvements>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            aggro.GetComponent<RunnerMouvements>().enabled = false;
        }
    }
}
