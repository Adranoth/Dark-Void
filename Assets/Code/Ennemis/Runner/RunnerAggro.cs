using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAggro : MonoBehaviour
{
    public GameObject aggro;
    public GameObject joueur;

    public float distanceX;
    public float distanceY;

    public AudioSource source;
    public AudioClip spotted;
    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 10f;
    public float waitTimeCountdown = -1f;

    public PersonnageVie vie;
    public RunnerVie runner;
    bool enCombat;

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
            if ((enCombat == false) && (vie.vieActuelle > 0))
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
        //Laisse tomber
        if (((Mathf.Abs(distanceX) > 20) && (enCombat == true)) || ((Mathf.Abs(distanceY) > 20) && (enCombat == true)))
        {
            aggro.GetComponent<RunnerMouvements>().enabled = false;
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("station_spatial", 1f, 1f));
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("combat", 2f, 0f));
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            enCombat = false;
            gameObject.tag = "Passif";
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        //En chasse
        else if ((Mathf.Abs(distanceX) < 20) && (Mathf.Abs(distanceY) < 5) && (enCombat == false) && (vie.vieActuelle > 0))
        {
            StartCoroutine(Spot());
        }
        if (vie.vieActuelle <= 0)
        {
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            enCombat = false;
            gameObject.tag = "Passif";
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            aggro.GetComponent<RunnerMouvements>().enabled = false;
        }
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                currentClip = audioClips[Random.Range(0, audioClips.Count)];
                source.clip = currentClip;
                source.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
    public IEnumerator Spot()
    {
        enCombat = true;
        aggro.GetComponent<RunnerMouvements>().enabled = true;
        source.PlayOneShot(spotted);
        gameObject.tag = "Aggro";
        FindObjectOfType<AudioManager>().MonstreAggro(gameObject);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        if (FindObjectOfType<AudioManager>().enCombatMusique == false)
        {
            FindObjectOfType<AudioManager>().Play("combat");
            FindObjectOfType<AudioManager>().enCombatMusique = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().enCombatMusique = true;
        }
        StartCoroutine(FindObjectOfType<AudioManager>().StartFade("station_spatial", 1.5f, 0f));
    }
}
