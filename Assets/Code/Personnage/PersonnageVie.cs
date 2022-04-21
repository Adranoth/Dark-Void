using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageVie : MonoBehaviour
{
    public Inventaire inventaire;

    public SpriteRenderer graphiques;
    public float flashIntervalle = 0.1f;

    public Transform checkpoint;
    public Transform vaisseau;

    public GameObject ecranDeMort;
    public GameObject UIInfos;


    public int vieMax = 100;
    public int vieActuelle;
    public BarDeVie bardevie;
    public bool pasBeaucoupDeVie = false;
    public GameObject tete;
    public GameObject brasGauche;
    public GameObject brasDroit;
    private bool soin;

    public float invincibiliteDuree = 3f;
    public bool estInvincible = false;

    public AudioClip[] douleur;
    AudioSource audiosource;

    void Start()
    {
        transform.position = checkpoint.position;
        bardevie.MetVieMax(vieMax);
        bardevie.MetVie(vieActuelle);
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (vieActuelle < vieMax * 0.25 && pasBeaucoupDeVie == false)
        {
            FindObjectOfType<AudioManager>().Play("Low-health");
            pasBeaucoupDeVie = true;
            StartCoroutine(pasBeaucoupDeVieFlash());
        }
        else if (vieActuelle > vieMax * 0.25)
        {
            FindObjectOfType<AudioManager>().Stop("Low-health");
            pasBeaucoupDeVie = false;
            StopCoroutine(pasBeaucoupDeVieFlash());
        }
        if (Input.GetKeyDown(KeyCode.T) && soin == false)
        {
            Soigner();
        }
    }

    public void PrendreDegats(int degats)
    {
        if (!estInvincible)
        {
            vieActuelle -= degats;
            audiosource.clip = douleur[Random.Range(0, douleur.Length)];
            audiosource.Play();
            estInvincible = true;
            StartCoroutine(InvincibiliteFlash());
            StartCoroutine(InvincibiliteHandler());
            bardevie.MetVie(vieActuelle);
        }


        if(vieActuelle <= 0)
        {
            ecranDeMort.SetActive(true);
            ecranDeMort.GetComponent<EcranDeMort>().pateAClone = inventaire.pateACloneActuelle;
            UIInfos.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public IEnumerator pasBeaucoupDeVieFlash()
    {
        while (pasBeaucoupDeVie)
        {
            tete.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            graphiques.color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(0.6f);
            tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            graphiques.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.6f);
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

    void Soigner()
    {
        if (inventaire.nbMediKitsActuels == 0 || (vieActuelle == vieMax))
        {
            return;
        }
        else
        {
            StartCoroutine(EnTrainDeSoigner());
        }
    }

    public IEnumerator EnTrainDeSoigner()
    {
        soin = true;
        //audiosource.PlayOneShot(recharger, 3f);
        yield return new WaitForSeconds(2f);
        inventaire.munitionsActuelle = inventaire.munitionsMax;
        bardevie.MetVie(vieMax);
        inventaire.nbMediKitsActuels -= 1;
        inventaire.premierSoin.text = inventaire.nbMediKitsActuels.ToString();
        soin = false;
    }
}
