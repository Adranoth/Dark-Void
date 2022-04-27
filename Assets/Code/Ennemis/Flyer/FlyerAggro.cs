using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyerAggro : MonoBehaviour
{
    public GameObject aggro;
    public GameObject joueur;
    public bool enCombat;
    public float distanceX;
    public float distanceY;
    public AudioSource source;
    public AudioClip spotted;
    public PersonnageVie vie;

    private void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Joueur");
        aggro = gameObject.transform.parent.gameObject;
        vie = FindObjectOfType<PersonnageVie>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Aggro"))
        {
            if (enCombat == false)
            {
                StartCoroutine(Spot());
            }
            else
            {
                return;
            }
        }
    }

    private void Update()
    {
        distanceX = Mathf.Abs(transform.position.x - joueur.transform.position.x);
        distanceY = Mathf.Abs(transform.position.y - joueur.transform.position.y);
        if ((Mathf.Abs(distanceX) > 20) && (Mathf.Abs(distanceY) > 20) && (enCombat == true))
        {
            aggro.GetComponent<AIPath>().enabled = false;
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("station_spatial", 1f, 1f));
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("combat", 3f, 0f));
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            enCombat = false;
            gameObject.tag = "Passif";
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }

        else if (((Mathf.Abs(distanceX) > 20) && (enCombat == true)) || ((Mathf.Abs(distanceY) > 20) && (enCombat == true)))
        {
            StartCoroutine(Spot());
        }
        if (vie.vieActuelle <= 0)
        {
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            enCombat = false;
            gameObject.tag = "Passif";
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            aggro.GetComponent<AIPath>().enabled = false;
        }
    }

    public IEnumerator Spot()
    {
        enCombat = true;
        aggro.GetComponent<AIPath>().enabled = true;
        source.PlayOneShot(spotted);
        gameObject.tag = "Aggro";
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        if (FindObjectOfType<AudioManager>().enCombatMusique == false)
        {
            FindObjectOfType<AudioManager>().Play("combat");
        }
        else
        {
            FindObjectOfType<AudioManager>().enCombatMusique = true;
        }
        FindObjectOfType<AudioManager>().enCombatMusique = true;
        StartCoroutine(FindObjectOfType<AudioManager>().StartFade("station_spatial", 3f, 0f));
    }
}
