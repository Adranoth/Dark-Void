using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageVie : MonoBehaviour
{

    public SpriteRenderer graphiques;
    public float flashIntervalle = 0.1f;

    public Transform checkpoint;
    public Transform vaisseau;

    public GameObject ecranDeMort;

    public int vieMax = 100;
    public int vieActuelle;
    public BarDeVie bardevie;

    public float invincibiliteDuree = 3f;
    public bool estInvincible = false;

    void Start()
    {
        vieActuelle = vieMax;
        transform.position = checkpoint.position;
        bardevie.MetVieMax(vieMax);
    }

    public void PrendreDegats(int degats)
    {
        if (!estInvincible)
        {
            vieActuelle -= degats;
            estInvincible = true;
            StartCoroutine(InvincibiliteFlash());
            StartCoroutine(InvincibiliteHandler());
            bardevie.MetVie(vieActuelle);
        }

        if(vieActuelle <= 0)
        {
            ecranDeMort.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public IEnumerator InvincibiliteFlash()
    {
        while(estInvincible)
        {
            graphiques.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(flashIntervalle);
            graphiques.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flashIntervalle);
        }
    }

    public IEnumerator InvincibiliteHandler()
    {
        yield return new WaitForSeconds(invincibiliteDuree);
        estInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpoint = collision.transform;
        }
    }
}
