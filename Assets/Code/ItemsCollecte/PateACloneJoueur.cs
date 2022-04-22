using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PateACloneJoueur : MonoBehaviour
{
    public int valeur;
    public GameObject joueur;
    void Start()
    {
        if(valeur == 0)
        {
            Destroy(gameObject);
        }

        float valeurFloat = (float) valeur;
        float taille = valeurFloat/1000f;

        if(taille < 1)
        {
            taille = 1;
        }
        else if (taille > 5)
        {
            taille = 5;
        }

        transform.localScale = new Vector3(taille, taille, 1f);

        joueur = GameObject.Find("Personnage");

    }

    void Update()
    {
        if(!joueur.activeSelf)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            FindObjectOfType<Inventaire>().pateACloneActuelle += valeur;
            FindObjectOfType<Inventaire>().pateAClone.text = FindObjectOfType<Inventaire>().pateACloneActuelle.ToString();
            Destroy(gameObject);
        }
    }
}
