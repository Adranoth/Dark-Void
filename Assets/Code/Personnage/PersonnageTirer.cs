using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonnageTirer : MonoBehaviour
{
    public Inventaire inventaire;
    private PersonnageMouvements personnageMouvements;

    public Transform sortieDeLaBalle;
    public GameObject ballePrefab;

    public TextMeshProUGUI CompteurMun;


    public float rechargementDuree = 3f;
    private bool recharge;

    private bool attenteProchaineBalle = false;
    public float tempsMaxEntreBalles = 0.5f;
    public float tempsMinEntreBalles = 0.1f;
    public float tempsPleineVitesse = 3f;
    private float acceleration = 0f;
    private float tempsDepuisTir = 0f;

    public float angleHasardeuxMax = 5f;
    private float angleHasardeuxActuel = 0f;

    AudioSource audiosource;
    public AudioClip tirer;
    public AudioClip plusDeMunitions;
    public AudioClip recharger;

    public ParticleSystem flash;
    public GameObject lumiere;
    public Animator animator;
    public Animator lampe;
    public bool classeB;
    public bool classeC = true;
    public bool classeD;

    private void Start()
    {
        CompteurMun.text = inventaire.munitionsActuelle.ToString();
        recharge = false;
        audiosource = GetComponent<AudioSource>();
        personnageMouvements = gameObject.GetComponent<PersonnageMouvements>();
    }

    void Update()
    {
        if (!MenuPause.jeuEnPause)
        {

            if (classeB == true || classeC == true)
            {
                lampe.SetBool("classeD", false);
                if (Input.GetButton("Fire1"))
                {
                    tempsDepuisTir = 0;
                    Tirer();
                }
                else
                {
                    acceleration -= tempsDepuisTir / tempsPleineVitesse;
                    tempsDepuisTir += Time.deltaTime;
                    if (acceleration < 0)
                    {
                        acceleration = 0;
                    }
                }
            }
            else if (classeD == true)
            {
                lampe.SetBool("classeD", true);
                if (Input.GetButtonDown("Fire1"))
                {
                    Tirer();
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && !recharge && inventaire.chargeursActuels > 0)
            {
                Recharger();
                acceleration = 0;
            }
        }
    }

    public IEnumerator EnRecharge()
    {
        recharge = true;
        audiosource.PlayOneShot(recharger, 3f);
        yield return new WaitForSeconds(rechargementDuree);
        inventaire.munitionsActuelle = inventaire.munitionsMax;
        CompteurMun.text = inventaire.munitionsActuelle.ToString();
        inventaire.chargeursActuels -= 1;
        inventaire.chargeur.text = inventaire.chargeursActuels.ToString();
        CompteurMun.color = new Color(1f, 1f, 1f, 1f);
        recharge = false;
    }

    public IEnumerator IntervalleEntreLesTirs()
    {
        attenteProchaineBalle = true;
        if (acceleration > 1)
        {
            acceleration = 1;
        }
        yield return new WaitForSeconds(Mathf.Lerp(tempsMaxEntreBalles, tempsMinEntreBalles, acceleration));
        attenteProchaineBalle = false;
    }

    void Recharger()
    {
        if (inventaire.chargeursActuels == 0 || (inventaire.munitionsActuelle == inventaire.munitionsMax))
        {
            return;
        }
        else
        {
            StartCoroutine(EnRecharge());
        }
    }

    void Tirer()
    {
        if (classeB == true || classeC == true)
        {
            acceleration += Time.deltaTime / tempsPleineVitesse;

            angleHasardeuxActuel = Mathf.Lerp(0f, angleHasardeuxMax, acceleration);
            angleHasardeuxActuel = Random.Range(-angleHasardeuxActuel, angleHasardeuxActuel) * Mathf.Deg2Rad;
            Quaternion rotationHasardeuse = sortieDeLaBalle.rotation;

            if (personnageMouvements.faceADroite)
            {
                rotationHasardeuse.z = rotationHasardeuse.z + angleHasardeuxActuel;
            }
            else
            {
                rotationHasardeuse.x = rotationHasardeuse.x + angleHasardeuxActuel;
            }

            if ((inventaire.munitionsActuelle == 0 || recharge) && !attenteProchaineBalle)
            {
                audiosource.PlayOneShot(plusDeMunitions, 2f);
                StartCoroutine(IntervalleEntreLesTirs());
            }
            else if (!attenteProchaineBalle)
            {
                audiosource.PlayOneShot(tirer, 1.3f);
                StartCoroutine(MuzzleFlash());
                Instantiate(ballePrefab, sortieDeLaBalle.position, rotationHasardeuse);
                inventaire.munitionsActuelle -= 1;
                CompteurMun.text = inventaire.munitionsActuelle.ToString();
                if (inventaire.munitionsActuelle <= 15)
                {
                    CompteurMun.color = new Color(1f, 0f, 0f, 1f);
                }
                StartCoroutine(IntervalleEntreLesTirs());
            }
        }
        else if (classeD == true)
        {
            if (inventaire.munitionsActuelle > 0)
            {
                audiosource.PlayOneShot(tirer, 1.3f);
                StartCoroutine(MuzzleFlash());
                Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
                inventaire.munitionsActuelle -= 1;
                CompteurMun.text = inventaire.munitionsActuelle.ToString();
                if (inventaire.munitionsActuelle <= 5)
                {
                    CompteurMun.color = new Color(1f, 0f, 0f, 1f);
                }
            }
            else if (inventaire.munitionsActuelle == 0)
            {
                audiosource.PlayOneShot(plusDeMunitions);
            }
        }
    }

    public IEnumerator MuzzleFlash()
    {
        lumiere.SetActive(true);
        flash.Play();
        animator.SetTrigger("Recul");
        lampe.SetTrigger("Recul");
        yield return new WaitForSeconds(0.1f);
        lumiere.SetActive(false);
        animator.SetTrigger("Recul");
        lampe.SetTrigger("Recul");
    }
}
