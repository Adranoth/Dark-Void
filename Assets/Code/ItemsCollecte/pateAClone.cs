using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pateAClone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            FindObjectOfType<Inventaire>().pateACloneActuelle += 100;
            FindObjectOfType<Inventaire>().pateAClone.text = FindObjectOfType<Inventaire>().pateACloneActuelle.ToString();
            Destroy(gameObject);
        }
    }
}
