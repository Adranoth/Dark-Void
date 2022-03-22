using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageVie : MonoBehaviour
{

    public SpriteRenderer graphiques;
    public float flashIntervalle = 0.1f;

    public int vieMax = 100;
    public int vieActuelle;

    public float invincibiliteDuree = 3f;
    public bool estInvincible = false;

    void Start()
    {
        vieActuelle = vieMax;   
    }

    public void PrendreDegats(int degats)
    {
        if (!estInvincible)
        {
            vieActuelle -= degats;
            estInvincible = true;
            StartCoroutine(InvincibiliteFlash());
            StartCoroutine(InvincibiliteHandler());
        }

        if(vieActuelle <= 0)
        {
            Destroy(gameObject);
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
}
