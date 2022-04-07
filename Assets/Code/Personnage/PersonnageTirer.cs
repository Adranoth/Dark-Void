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

    public TextMeshProUGUI CompteurCharg;

    public float rechargementDuree = 3f;
    private bool recharge;

    private void Start()
    {
        CompteurMun.text = inventaire.munitionsActuelles.ToString();

        CompteurCharg.text = inventaire.chargeursActuels.ToString();

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
        if (inventaire.chargeursActuels == 0 || (inventaire.munitionsActuelles == inventaire.munitionsMax))
        {
            return;
        }
        else
        {
            inventaire.munitionsActuelles = inventaire.munitionsMax;
            CompteurMun.text = inventaire.munitionsActuelles.ToString();
            inventaire.chargeursActuels -= 1;
            CompteurCharg.text = inventaire.chargeursActuels.ToString();
            StartCoroutine(EnRecharge());
        }
    }

    void Tirer()
    {
        if (inventaire.munitionsActuelles == 0 || recharge)
        {
            return;
        }
        else
        {
            Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
            inventaire.munitionsActuelles -= 1;
            CompteurMun.text = inventaire.munitionsActuelles.ToString();
        }
    }
}

