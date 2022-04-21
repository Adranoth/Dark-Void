using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonnageTirer : MonoBehaviour
{
    public Inventaire inventaire;

    public Transform sortieDeLaBalle;
    public GameObject ballePrefab;

    public TextMeshProUGUI CompteurMun;


    public float rechargementDuree = 3f;
    private bool recharge;

    AudioSource audiosource;
    public AudioClip tirer;
    public AudioClip plusDeMunitions;
    public AudioClip recharger;

    private void Start()
    {
        CompteurMun.text = inventaire.munitionsActuelle.ToString();
        recharge = false;
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Tirer();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Recharger();
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
        if (inventaire.munitionsActuelle == 0 || recharge)
        {
            audiosource.PlayOneShot(plusDeMunitions, 2f);
        }
        else
        {
            audiosource.PlayOneShot(tirer, 1.3f);
            Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
            inventaire.munitionsActuelle -= 1;
            CompteurMun.text = inventaire.munitionsActuelle.ToString();
            if (inventaire.munitionsActuelle <= 15)
            {
                CompteurMun.color = new Color(1f, 0f, 0f, 1f);
            }
        }
    }
}

