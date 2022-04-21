using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAggro : MonoBehaviour
{
    public GameObject aggro;
    public GameObject joueur;
    bool enCombat;
    public float distance;
    public AudioSource source;
    public AudioClip spotted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
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
        distance = Vector2.Distance(transform.position, joueur.transform.position);
        if (Mathf.Abs(distance) > 60 && enCombat == true)
        {
            aggro.GetComponent<RunnerMouvements>().enabled = false;
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("station_spatial", 1f, 1f));
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("combat", 3f, 0f));
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            enCombat = false;
            gameObject.tag = "Ennemi";
        }
    }
    public IEnumerator Spot()
    {
        enCombat = true;
        aggro.GetComponent<RunnerMouvements>().enabled = true;
        source.PlayOneShot(spotted);
        yield return new WaitForSeconds(2f);
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
        gameObject.tag = "Aggro";
    }
}
