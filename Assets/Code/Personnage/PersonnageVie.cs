using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageVie : MonoBehaviour
{
    public Inventaire inventaire;

    public float flashIntervalle = 0.1f;

    public GameObject checkpoint;
    public GameObject vaisseau;

    public GameObject ecranDeMort;
    public GameObject UIInfos;

    public int vieMax = 100;
    public int vieActuelle;
    public BarDeVie bardevie;
    public bool pasBeaucoupDeVie = false;
    public float tempsDepuisDegat;
    public bool enCombat;
    public bool fadeOut;
    Rigidbody2D personnageRB;
    public float knockbackL;
    public float knockbackH;
    public float tempsDeKnockback;

    public GameObject tete;
    public GameObject brasGauche;
    public GameObject brasDroit;
    private bool soin;
    public Animator animator;
    public Animator bras;

    public float invincibiliteDuree = 3f;
    public bool estInvincible = false;

    public AudioClip[] douleur;
    AudioSource audiosource;
    public bool cave;
    public CloningPod cloningPod;

    void Start()
    {
        personnageRB = gameObject.GetComponent<Rigidbody2D>();
        transform.position = checkpoint.transform.position;
        bardevie.MetVieMax(vieMax);
        bardevie.MetVie(vieActuelle);
        audiosource = GetComponent<AudioSource>();
        animator.keepAnimatorControllerStateOnDisable = true;
        bras.keepAnimatorControllerStateOnDisable = true;
    }

    private void OnEnable()
    {
        if (cave == true)
        {
            FindObjectOfType<AudioManager>().Play("cave");
        }
        else if (cave == false)
        {
            FindObjectOfType<AudioManager>().Play("station_spatial");
        }
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
        tempsDepuisDegat = tempsDepuisDegat + Time.deltaTime;
        if (tempsDepuisDegat >= 10)
        {
            if ((!enCombat) && (!pasBeaucoupDeVie))
            {
                tempsDepuisDegat = 10;
                StartCoroutine(FindObjectOfType<BarDeVie>().FadeOut(false));
                fadeOut = true;
            }
            else
            {
                tempsDepuisDegat = 10;
                return;
            }
        }
        tempsDeKnockback = tempsDeKnockback - Time.deltaTime;
        if (tempsDeKnockback <= 0)
        {
            tempsDeKnockback = 0;
        }
    }

    public void PrendreDegats(int degats, bool versLaGauche)
    {
        if (!estInvincible)
        {
            vieActuelle -= degats;
            audiosource.clip = douleur[Random.Range(0, douleur.Length)];
            audiosource.Play();
            tempsDeKnockback = 0.5f;
            StartCoroutine(Hitpause(0.1f));
            if (versLaGauche)
            {
                personnageRB.AddForce(new Vector3(-knockbackL, knockbackH, 0f), ForceMode2D.Impulse);
            }
            else
            {
                personnageRB.AddForce(new Vector3(knockbackL, knockbackH, 0f), ForceMode2D.Impulse);
            }
            estInvincible = true;
            StartCoroutine(InvincibiliteFlash());
            StartCoroutine(InvincibiliteHandler());
            bardevie.MetVie(vieActuelle);
            enCombat = true;
            tempsDepuisDegat = 0;
            if (fadeOut)
            {
                StartCoroutine(FindObjectOfType<BarDeVie>().FadeOut());
                fadeOut = false;
            }
        }


        if(vieActuelle <= 0)
        {
            ecranDeMort.SetActive(true);
            ecranDeMort.GetComponent<EcranDeMort>().pateAClone = inventaire.pateACloneActuelle;
            FindObjectOfType<AudioManager>().Restart();
            UIInfos.SetActive(false);
            Time.timeScale = 1.0f;
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
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(0.6f);
            tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.6f);
        }
    }

    public IEnumerator InvincibiliteFlash()
    {
        while(estInvincible)
        {
            tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(flashIntervalle);
            tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flashIntervalle);
        }
    }

    public IEnumerator Hitpause(float duree)
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(duree);
        Time.timeScale = 1.0f;
    }

    public IEnumerator InvincibiliteHandler()
    {
        yield return new WaitForSeconds(invincibiliteDuree);
        estInvincible = false;
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
        vieActuelle = vieMax;
        inventaire.nbMediKitsActuels -= 1;
        inventaire.premierSoin.text = inventaire.nbMediKitsActuels.ToString();
        soin = false;
    }
}
