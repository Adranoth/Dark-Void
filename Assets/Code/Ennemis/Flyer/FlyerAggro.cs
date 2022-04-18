using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyerAggro : MonoBehaviour
{
    public GameObject aggro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            aggro.GetComponent<AIPath>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            aggro.GetComponent<AIPath>().enabled = false;
        }
    }
}
