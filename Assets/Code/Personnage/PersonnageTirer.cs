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

    private void Start()
    {
        CompteurMun.text = inventaire.munitionsActuelle.ToString();

        recharge = false;
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
        yield return new WaitForSeconds(rechargementDuree);
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
            inventaire.munitionsActuelle = inventaire.munitionsMax;
            CompteurMun.text = inventaire.munitionsActuelle.ToString();
            inventaire.chargeursActuels -= 1;
            inventaire.chargeur.text = inventaire.chargeursActuels.ToString();
            StartCoroutine(EnRecharge());
        }
    }

    void Tirer()
    {
        if (inventaire.munitionsActuelle == 0 || recharge)
        {
            return;
        }
        else
        {
            Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
            inventaire.munitionsActuelle -= 1;
            CompteurMun.text = inventaire.munitionsActuelle.ToString();
        }
    }
}

